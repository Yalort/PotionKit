using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace PotionApp
{
    public partial class Form1 : Form
    {
        private readonly List<Recipe> recipes = new();
        private readonly Queue<Recipe> brewQueue = new();
        private readonly Dictionary<string, int> inventory = new();
        private readonly string[] ingredientNames = { "Animal", "Berry", "Fungi", "Herb", "Magic", "Mineral", "Root", "Solution", "Bottles" };
        private NumericUpDown[] ingredientControls = Array.Empty<NumericUpDown>();
        private readonly ContextMenuStrip inventoryMenu = new();

        private int waterCapacity = 1000;
        private int waterAmount = 1000;

        private readonly string dataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "potionkit2");
        private string IngredientsPath => Path.Combine(dataDir, "ingredients.json");
        private string RecipesPath => Path.Combine(dataDir, "recipes.json");
        private string InventoryPath => Path.Combine(dataDir, "inventory.json");

        public Form1()
        {
            InitializeComponent();
            inventoryMenu.Items.Add("Add Recipe", null, inventoryAddRecipe_Click);
            listInventory.ContextMenuStrip = inventoryMenu;
            listInventory.MouseDown += listInventory_MouseDown;
            SetupIngredientControls();
            lblRecipeColumns.Text = Recipe.Header;
            lblQueueColumns.Text = Recipe.Header;
            LoadData();
            RefreshAll();
            FormClosing += Form1_FormClosing;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var frm = new RecipeForm();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                recipes.Add(frm.Recipe);
                RefreshRecipes();
            }
        }

        private Recipe? SelectedRecipe => listRecipes.SelectedItem as Recipe;

        private void listRecipes_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedRecipe == null) return;
            using var frm = new RecipeForm(SelectedRecipe);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                RefreshRecipes();
            }
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            if (comboRecipes.SelectedItem is Recipe rec)
            {
                brewQueue.Enqueue(rec);
                RefreshQueue();
            }
        }

        private void listQueue_DoubleClick(object sender, EventArgs e)
        {
            if (listQueue.SelectedItem is not Recipe rec) return;
            var items = brewQueue.ToList();
            if (items.Remove(rec))
            {
                brewQueue.Clear();
                foreach (var r in items)
                    brewQueue.Enqueue(r);
                RefreshQueue();
            }
        }

        private void btnBrew_Click(object sender, EventArgs e)
        {
            if (brewQueue.Count == 0) return;
            int totalWaterNeeded = brewQueue.Count * 200;
            if (waterAmount < totalWaterNeeded)
            {
                MessageBox.Show("Not enough water", "Cannot Brew", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            while (brewQueue.Count > 0)
            {
                var rec = brewQueue.Peek();
                string? err = GetBrewError(rec);
                if (err != null)
                {
                    MessageBox.Show(err, "Cannot Brew", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                brewQueue.Dequeue();
                if (!inventory.ContainsKey(rec.Name)) inventory[rec.Name] = 0;
                inventory[rec.Name]++;
                ingredientControls[0].Value -= rec.Animal;
                ingredientControls[1].Value -= rec.Berry;
                ingredientControls[2].Value -= rec.Fungi;
                ingredientControls[3].Value -= rec.Herb;
                ingredientControls[4].Value -= rec.Magic;
                ingredientControls[5].Value -= rec.Mineral;
                ingredientControls[6].Value -= rec.Root;
                ingredientControls[7].Value -= rec.Solution;
                ingredientControls[8].Value -= 1;
                waterAmount -= 200;
            }
            RefreshQueue();
            RefreshInventory();
            RefreshTotals();
            UpdateWaterUI();
        }

        private string? GetBrewError(Recipe rec)
        {
            if (waterAmount < 200)
                return "Not enough water";
            if (ingredientControls[8].Value < 1)
                return "Not enough bottles";

            int[] needs = { rec.Animal, rec.Berry, rec.Fungi, rec.Herb, rec.Magic, rec.Mineral, rec.Root, rec.Solution };
            for (int i = 0; i < needs.Length; i++)
            {
                if (ingredientControls[i].Value < needs[i])
                    return $"Not enough {ingredientNames[i]}";
            }
            return null;
        }

        private void adjustAmount_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not NumericUpDown num) return;
            bool shift = ModifierKeys.HasFlag(Keys.Shift);
            bool ctrl = ModifierKeys.HasFlag(Keys.Control);
            int delta = 1;
            if (shift && ctrl) delta = 100;
            else if (ctrl) delta = 10;
            else if (shift) delta = 5;
            if (btn.Text == "+")
                num.Value = Math.Min(num.Maximum, num.Value + delta);
            else
                num.Value = Math.Max(num.Minimum, num.Value - delta);
        }

        private void adjustWater_Click(object sender, EventArgs e)
        {
            bool shift = ModifierKeys.HasFlag(Keys.Shift);
            bool ctrl = ModifierKeys.HasFlag(Keys.Control);
            int delta = (int)numWaterAdjust.Value;
            if (shift && ctrl) delta *= 100;
            else if (ctrl) delta *= 10;
            else if (shift) delta *= 5;
            if (sender is Button btn && btn == btnWaterPlus)
                waterCapacity = Math.Min(1000000, waterCapacity + delta);
            else
                waterCapacity = Math.Max(1, waterCapacity - delta);
            waterAmount = Math.Min(waterAmount, waterCapacity);
            UpdateWaterUI();
            RefreshTotals();
        }

        private void adjustWaterAmount_Click(object sender, EventArgs e)
        {
            bool shift = ModifierKeys.HasFlag(Keys.Shift);
            bool ctrl = ModifierKeys.HasFlag(Keys.Control);
            int delta = 1;
            if (shift && ctrl) delta = 100;
            else if (ctrl) delta = 10;
            else if (shift) delta = 5;
            if (sender is Button btn && btn == btnWaterAmountPlus)
                waterAmount = Math.Min(waterCapacity, waterAmount + delta);
            else
                waterAmount = Math.Max(0, waterAmount - delta);
            UpdateWaterUI();
            RefreshTotals();
        }

        private void btnFillWater_Click(object sender, EventArgs e)
        {
            waterAmount = waterCapacity;
            UpdateWaterUI();
            RefreshTotals();
        }

        private void listInventory_DoubleClick(object sender, EventArgs e)
        {
            if (listInventory.SelectedItem is not string item) return;
            var parts = item.Split(':');
            if (parts.Length == 2)
            {
                var name = parts[0].Trim();
                if (inventory.TryGetValue(name, out int count) && count > 0)
                {
                    inventory[name] = count - 1;
                    if (inventory[name] <= 0) inventory.Remove(name);
                    RefreshInventory();
                }
            }
        }

        private void btnInventoryAdd_Click(object sender, EventArgs e)
        {
            var name = txtInventoryName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;
            int count = (int)numInventoryCount.Value;
            if (!inventory.ContainsKey(name)) inventory[name] = 0;
            inventory[name] += count;
            RefreshInventory();
        }

        private void listInventory_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            var item = listInventory.Items[e.Index]?.ToString() ?? string.Empty;
            var name = item.Split(':')[0].Trim();
            bool known = recipes.Any(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? SystemColors.HighlightText
                : (known ? listInventory.ForeColor : Color.Orange);
            TextRenderer.DrawText(e.Graphics, item, e.Font, e.Bounds, textColor, TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }

        private void listInventory_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listInventory.IndexFromPoint(e.Location);
                if (index >= 0) listInventory.SelectedIndex = index;
            }
        }

        private void inventoryAddRecipe_Click(object? sender, EventArgs e)
        {
            if (listInventory.SelectedItem is not string item) return;
            var name = item.Split(":")[0].Trim();
            using var frm = new RecipeForm(new Recipe { Name = name });
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                recipes.Add(frm.Recipe);
                RefreshRecipes();
            }
        }

        private void SetupIngredientControls()
        {
            NumericUpDown[] nums = { numAnimal, numBerry, numFungi, numHerb, numMagic, numMineral, numRoot, numSolution, numBottles };
            ingredientControls = nums;
            string[] labels = ingredientNames;
            for (int i = 0; i < nums.Length; i++)
            {
                int row = i / 4;
                int col = i % 4;
                int x = 6 + col * 140;
                int y = 6 + row * 80;
                if (i == nums.Length - 1)
                {
                    x = 6 + 3 * 140;
                    y -= 20;
                }

                Label lbl = new Label
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(x, y),
                    AutoSize = true
                };
                tabBrew.Controls.Add(lbl);

                Button btnMinus = new Button
                {
                    Text = "-",
                    Location = new System.Drawing.Point(x, y + 20),
                    Size = new System.Drawing.Size(20, 23),
                    Tag = nums[i]
                };
                btnMinus.Click += adjustAmount_Click;
                tabBrew.Controls.Add(btnMinus);

                nums[i].Location = new System.Drawing.Point(x + 24, y + 20);
                nums[i].Maximum = 1000000;
                nums[i].Size = new System.Drawing.Size(60, 23);
                nums[i].ValueChanged += (s, e) => RefreshTotals();
                tabBrew.Controls.Add(nums[i]);

                Button btnPlus = new Button
                {
                    Text = "+",
                    Location = new System.Drawing.Point(x + 88, y + 20),
                    Size = new System.Drawing.Size(20, 23),
                    Tag = nums[i]
                };
                btnPlus.Click += adjustAmount_Click;
                tabBrew.Controls.Add(btnPlus);
            }
        }

        private void RefreshRecipes()
        {
            listRecipes.DataSource = null;
            listRecipes.DataSource = recipes;
            comboRecipes.DataSource = null;
            comboRecipes.DataSource = recipes;
        }

        private void RefreshQueue()
        {
            listQueue.DataSource = null;
            listQueue.DataSource = brewQueue.ToArray();
            RefreshTotals();
        }

        private void RefreshInventory()
        {
            listInventory.DataSource = null;
            var items = new List<string>();
            foreach (var kv in inventory)
            {
                items.Add($"{kv.Key}: {kv.Value}");
            }
            listInventory.DataSource = items;
        }

        private void RefreshAll()
        {
            RefreshRecipes();
            RefreshQueue();
            RefreshInventory();
            RefreshTotals();
            UpdateWaterUI();
        }

        private void RefreshTotals()
        {
            if (ingredientControls.Length == 0) return;
            int[] totals = new int[ingredientControls.Length];
            var specialCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var r in brewQueue)
            {
                totals[0] += r.Animal;
                totals[1] += r.Berry;
                totals[2] += r.Fungi;
                totals[3] += r.Herb;
                totals[4] += r.Magic;
                totals[5] += r.Mineral;
                totals[6] += r.Root;
                totals[7] += r.Solution;
                totals[8] += 1; // bottles
                if (!string.IsNullOrWhiteSpace(r.Special))
                {
                    foreach (var sp in r.Special.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        var name = sp.Trim();
                        if (name.Length == 0) continue;
                        if (!specialCounts.ContainsKey(name)) specialCounts[name] = 0;
                        specialCounts[name]++;
                    }
                }
            }

            rtbTotals.Clear();
            for (int i = 0; i < totals.Length; i++)
            {
                int remaining = (int)ingredientControls[i].Value - totals[i];
                rtbTotals.SelectionColor = System.Drawing.Color.Black;
                rtbTotals.AppendText($"{ingredientNames[i]}: {totals[i]} (");
                if (remaining < 0)
                    rtbTotals.SelectionColor = System.Drawing.Color.Red;
                rtbTotals.AppendText(remaining.ToString());
                rtbTotals.SelectionColor = System.Drawing.Color.Black;
                rtbTotals.AppendText(")\n");
            }
            int waterNeeded = brewQueue.Count * 200;
            int waterRemain = waterAmount - waterNeeded;
            rtbTotals.SelectionColor = System.Drawing.Color.Black;
            rtbTotals.AppendText($"Water: {waterNeeded} (");
            if (waterRemain < 0) rtbTotals.SelectionColor = System.Drawing.Color.Red;
            rtbTotals.AppendText(waterRemain.ToString());
            rtbTotals.SelectionColor = System.Drawing.Color.Black;
            rtbTotals.AppendText(")\n");
            if (specialCounts.Count > 0)
            {
                rtbTotals.AppendText("\nSpecial Ingredients:\n");
                foreach (var kv in specialCounts)
                {
                    rtbTotals.AppendText($"{kv.Key}: {kv.Value}\n");
                }
            }
        }

        private void UpdateWaterUI()
        {
            barWater.Maximum = waterCapacity;
            barWater.Value = Math.Max(0, Math.Min(waterCapacity, waterAmount));
            lblWater.Text = $"Water: {waterAmount}/{waterCapacity} mL";
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(RecipesPath))
                {
                    var json = File.ReadAllText(RecipesPath);
                    var list = JsonSerializer.Deserialize<List<Recipe>>(json);
                    if (list != null)
                    {
                        recipes.Clear();
                        recipes.AddRange(list);
                    }
                }

                if (File.Exists(InventoryPath))
                {
                    var json = File.ReadAllText(InventoryPath);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
                    if (dict != null)
                    {
                        inventory.Clear();
                        foreach (var kv in dict)
                            inventory[kv.Key] = kv.Value;
                    }
                }

                if (File.Exists(IngredientsPath))
                {
                    var json = File.ReadAllText(IngredientsPath);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
                    if (dict != null)
                    {
                        if (dict.TryGetValue("Animal", out var a)) numAnimal.Value = a;
                        if (dict.TryGetValue("Berry", out var b)) numBerry.Value = b;
                        if (dict.TryGetValue("Fungi", out var f)) numFungi.Value = f;
                        if (dict.TryGetValue("Herb", out var h)) numHerb.Value = h;
                        if (dict.TryGetValue("Magic", out var m)) numMagic.Value = m;
                        if (dict.TryGetValue("Mineral", out var mi)) numMineral.Value = mi;
                        if (dict.TryGetValue("Root", out var r)) numRoot.Value = r;
                        if (dict.TryGetValue("Solution", out var s)) numSolution.Value = s;
                        if (dict.TryGetValue("Bottles", out var bo)) numBottles.Value = bo;
                        if (dict.TryGetValue("WaterCapacity", out var cap))
                            waterCapacity = Math.Max(1, cap);
                        if (dict.TryGetValue("Water", out var w))
                            waterAmount = Math.Max(0, Math.Min(waterCapacity, w));
                    }
                }
                UpdateWaterUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }

        private void SaveData()
        {
            try
            {
                Directory.CreateDirectory(dataDir);
                var ingredients = new Dictionary<string, int>
                {
                    ["Animal"] = (int)numAnimal.Value,
                    ["Berry"] = (int)numBerry.Value,
                    ["Fungi"] = (int)numFungi.Value,
                    ["Herb"] = (int)numHerb.Value,
                    ["Magic"] = (int)numMagic.Value,
                    ["Mineral"] = (int)numMineral.Value,
                    ["Root"] = (int)numRoot.Value,
                    ["Solution"] = (int)numSolution.Value,
                    ["Bottles"] = (int)numBottles.Value,
                    ["Water"] = waterAmount,
                    ["WaterCapacity"] = waterCapacity
                };
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(IngredientsPath, JsonSerializer.Serialize(ingredients, options));
                File.WriteAllText(RecipesPath, JsonSerializer.Serialize(recipes, options));
                File.WriteAllText(InventoryPath, JsonSerializer.Serialize(inventory, options));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}
