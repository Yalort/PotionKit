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
        private readonly Dictionary<string, string> potionCategories = new();
        private readonly HashSet<string> categories = new();
        private readonly string[] ingredientNames = { "Animal", "Berry", "Fungi", "Herb", "Magic", "Mineral", "Root", "Solution", "Bottles" };
        private NumericUpDown[] ingredientControls = Array.Empty<NumericUpDown>();
        private readonly ContextMenuStrip inventoryMenu = new();
        private readonly ContextMenuStrip recipeMenu = new();
        private readonly ContextMenuStrip brewMenu = new();

        // Horizontal offset used when laying out controls on the Brewing tab.
        // The water UI is now inside its own group box so no offset is needed.
        private const int BrewOffsetX = 0;

        private readonly List<WaterContainer> waterContainers = new();
        private readonly ContextMenuStrip waterMenu = new();

        private readonly string dataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "potionkit2");
        private string IngredientsPath => Path.Combine(dataDir, "ingredients.json");
        private string RecipesPath => Path.Combine(dataDir, "recipes.json");
        private string InventoryPath => Path.Combine(dataDir, "inventory.json");
        private string PotionCategoriesPath => Path.Combine(dataDir, "potion_categories.json");
        private string WaterContainersPath => Path.Combine(dataDir, "water.json");

        private int TotalWaterCapacity => waterContainers.Sum(c => c.Capacity);
        private int TotalWaterAmount => waterContainers.Sum(c => c.Amount);
        private int ActiveWaterAmount => waterContainers.Where(c => c.Active).Sum(c => c.Amount);

        public Form1()
        {
            InitializeComponent();
            inventoryMenu.Items.Add("Add Recipe", null, inventoryAddRecipe_Click);
            inventoryMenu.Items.Add("Edit Count", null, inventoryEditCount_Click);
            inventoryMenu.Items.Add("Rename", null, inventoryRename_Click);
            inventoryMenu.Items.Add("Add To Queue", null, inventoryAddQueue_Click);
            inventoryMenu.Items.Add("Set Category", null, inventorySetCategory_Click);
            listInventory.ContextMenuStrip = inventoryMenu;
            listInventory.MouseDown += listInventory_MouseDown;

            recipeMenu.Items.Add("Edit", null, recipeEdit_Click);
            recipeMenu.Items.Add("Delete", null, recipeDelete_Click);
            recipeMenu.Items.Add("Set Category", null, recipeSetCategory_Click);
            listRecipes.ContextMenuStrip = recipeMenu;
            listRecipes.MouseDown += listRecipes_MouseDown;

            brewMenu.Items.Add("Add Amount", null, brewAddAmount_Click);
            listBrewRecipes.ContextMenuStrip = brewMenu;
            listBrewRecipes.MouseDown += listBrewRecipes_MouseDown;

            waterMenu.Items.Add("Change Amount", null, waterChangeAmount_Click);
            waterMenu.Items.Add("Delete", null, waterDelete_Click);
            waterMenu.Items.Add("Toggle Active", null, waterToggleActive_Click);
            waterMenu.Items.Add("Edit Name", null, waterEditName_Click);
            waterMenu.Items.Add("Edit Capacity", null, waterEditCapacity_Click);
            waterMenu.Items.Add("Add Another", null, waterAddAnother_Click);
            listWaterContainers!.ContextMenuStrip = waterMenu;
            listWaterContainers.MouseDown += listWaterContainers_MouseDown;
            listWaterContainers.DoubleClick += listWaterContainers_DoubleClick;
            SetupIngredientControls();
            lblRecipeColumns.Text = Recipe.Header;
            lblQueueColumns.Text = Recipe.Header;
            cmbRecipeFilter.SelectedIndexChanged += (s, e) => RefreshRecipes();
            cmbBrewFilter.SelectedIndexChanged += (s, e) => RefreshRecipes();
            cmbInventoryFilter.SelectedIndexChanged += (s, e) => RefreshInventory();
            LoadData();
            RefreshAll();
            FormClosing += Form1_FormClosing;
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            using var frm = new RecipeForm();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                recipes.Add(frm.Recipe);
                RebuildCategories();
                UpdateCategoryFilters();
                RefreshRecipes();
            }
        }

        private Recipe? SelectedRecipe => listRecipes.SelectedItem as Recipe;

        private void listRecipes_DoubleClick(object? sender, EventArgs e)
        {
            if (SelectedRecipe == null) return;
            using var frm = new RecipeForm(SelectedRecipe);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                RebuildCategories();
                UpdateCategoryFilters();
                RefreshRecipes();
            }
        }

        private void btnAddQueue_Click(object? sender, EventArgs e)
        {
            if (listBrewRecipes.SelectedItem is Recipe rec)
            {
                brewQueue.Enqueue(rec);
                RefreshQueue();
            }
        }

        private void listBrewRecipes_DoubleClick(object? sender, EventArgs e)
        {
            btnAddQueue_Click(sender, e);
        }

        private void listQueue_DoubleClick(object? sender, EventArgs e)
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

        private void btnBrew_Click(object? sender, EventArgs e)
        {
            if (brewQueue.Count == 0) return;
            int totalWaterNeeded = brewQueue.Count * 200;
            if (ActiveWaterAmount < totalWaterNeeded)
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
                UseWater(200);
            }
            RefreshQueue();
            RefreshInventory();
            RefreshWater();
        }

        private void btnClearQueue_Click(object? sender, EventArgs e)
        {
            brewQueue.Clear();
            RefreshQueue();
        }

        private string? GetBrewError(Recipe rec)
        {
            if (ActiveWaterAmount < 200)
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

        private void adjustAmount_Click(object? sender, EventArgs e)
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

        private void btnFillWater_Click(object? sender, EventArgs e)
        {
            foreach (var c in waterContainers)
                c.Amount = c.Capacity;
            RefreshWater();
        }

        private void btnAddWater_Click(object? sender, EventArgs e)
        {
            var wc = WaterContainerPrompt.ShowDialog("Add Water Container");
            if (wc != null)
            {
                waterContainers.Add(wc);
                RefreshWater();
            }
        }

        private void listInventory_DoubleClick(object? sender, EventArgs e)
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
                    RebuildCategories();
                    UpdateCategoryFilters();
                    RefreshInventory();
                }
            }
        }

        private void listWaterContainers_DoubleClick(object? sender, EventArgs e)
        {
            if (listWaterContainers!.SelectedIndex < 0) return;
            var c = waterContainers[listWaterContainers.SelectedIndex];
            c.Amount = c.Capacity;
            RefreshWater();
        }

        private WaterContainer? SelectedWaterContainer =>
            listWaterContainers != null && listWaterContainers.SelectedIndex >= 0
                ? waterContainers[listWaterContainers.SelectedIndex]
                : null;

        private void waterChangeAmount_Click(object? sender, EventArgs e)
        {
            if (SelectedWaterContainer == null) return;
            var input = SimplePrompt.ShowDialog("Enter new amount:", "Change Amount", SelectedWaterContainer.Amount.ToString());
            if (input == null) return;
            if (int.TryParse(input, out int val))
            {
                SelectedWaterContainer.Amount = Math.Clamp(val, 0, SelectedWaterContainer.Capacity);
                RefreshWater();
            }
            else MessageBox.Show("Invalid number", "Change Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void waterDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedWaterContainer == null) return;
            waterContainers.Remove(SelectedWaterContainer);
            RefreshWater();
        }

        private void waterToggleActive_Click(object? sender, EventArgs e)
        {
            if (SelectedWaterContainer == null) return;
            SelectedWaterContainer.Active = !SelectedWaterContainer.Active;
            RefreshWater();
        }

        private void waterEditName_Click(object? sender, EventArgs e)
        {
            if (SelectedWaterContainer == null) return;
            var input = SimplePrompt.ShowDialog("Enter name:", "Edit Name", SelectedWaterContainer.Name);
            if (input == null) return;
            SelectedWaterContainer.Name = input.Trim();
            RefreshWater();
        }

        private void waterEditCapacity_Click(object? sender, EventArgs e)
        {
            if (SelectedWaterContainer == null) return;
            var input = SimplePrompt.ShowDialog("Enter capacity:", "Edit Capacity", SelectedWaterContainer.Capacity.ToString());
            if (input == null) return;
            if (int.TryParse(input, out int cap) && cap > 0)
            {
                SelectedWaterContainer.Capacity = cap;
                if (SelectedWaterContainer.Amount > cap)
                    SelectedWaterContainer.Amount = cap;
                RefreshWater();
            }
            else MessageBox.Show("Invalid number", "Edit Capacity", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void waterAddAnother_Click(object? sender, EventArgs e)
        {
            if (SelectedWaterContainer == null) return;
            waterContainers.Add(new WaterContainer
            {
                Name = SelectedWaterContainer.Name,
                Capacity = SelectedWaterContainer.Capacity,
                Amount = SelectedWaterContainer.Amount,
                Active = SelectedWaterContainer.Active
            });
            RefreshWater();
        }

        private void btnInventoryAdd_Click(object? sender, EventArgs e)
        {
            var name = txtInventoryName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;
            int count = (int)numInventoryCount.Value;
            if (!inventory.ContainsKey(name)) inventory[name] = 0;
            inventory[name] += count;
            RebuildCategories();
            UpdateCategoryFilters();
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

        private void listRecipes_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listRecipes.IndexFromPoint(e.Location);
                if (index >= 0) listRecipes.SelectedIndex = index;
            }
        }

        private void listBrewRecipes_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBrewRecipes.IndexFromPoint(e.Location);
                if (index >= 0) listBrewRecipes.SelectedIndex = index;
            }
        }

        private void listWaterContainers_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listWaterContainers!.IndexFromPoint(e.Location);
                if (index >= 0) listWaterContainers.SelectedIndex = index;
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
                RebuildCategories();
                UpdateCategoryFilters();
                RefreshRecipes();
            }
        }

        private void inventoryEditCount_Click(object? sender, EventArgs e)
        {
            if (listInventory.SelectedItem is not string item) return;
            var name = item.Split(":")[0].Trim();
            if (!inventory.TryGetValue(name, out int count)) return;
            var input = SimplePrompt.ShowDialog("Enter new amount:", "Edit Count", count.ToString());
            if (input == null) return;
            if (int.TryParse(input, out int newCount) && newCount >= 0)
            {
                if (newCount == 0)
                    inventory.Remove(name);
                else
                    inventory[name] = newCount;
                RebuildCategories();
                UpdateCategoryFilters();
                RefreshInventory();
            }
            else
            {
                MessageBox.Show("Invalid number", "Edit Count", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inventoryRename_Click(object? sender, EventArgs e)
        {
            if (listInventory.SelectedItem is not string item) return;
            var name = item.Split(":")[0].Trim();
            var input = SimplePrompt.ShowDialog("Enter new name:", "Rename Potion", name);
            if (input == null) return;
            var newName = input.Trim();
            if (newName.Length == 0 || newName.Equals(name, StringComparison.OrdinalIgnoreCase)) return;
            if (!inventory.TryGetValue(name, out int count)) return;
            inventory.Remove(name);
            if (!inventory.ContainsKey(newName))
                inventory[newName] = 0;
            inventory[newName] += count;
            RebuildCategories();
            UpdateCategoryFilters();
            RefreshInventory();
        }

        private void inventoryAddQueue_Click(object? sender, EventArgs e)
        {
            if (listInventory.SelectedItem is not string item) return;
            var name = item.Split(":")[0].Trim();
            var rec = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (rec != null)
            {
                brewQueue.Enqueue(rec);
                RefreshQueue();
            }
            else
            {
                MessageBox.Show($"No recipe found for {name}", "Add To Queue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brewAddAmount_Click(object? sender, EventArgs e)
        {
            if (listBrewRecipes.SelectedItem is not Recipe rec) return;
            var input = SimplePrompt.ShowDialog("Enter amount to add:", "Add To Queue", "1");
            if (input == null) return;
            if (int.TryParse(input, out int count) && count > 0)
            {
                for (int i = 0; i < count; i++) brewQueue.Enqueue(rec);
                RefreshQueue();
            }
            else
            {
                MessageBox.Show("Invalid number", "Add To Queue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recipeEdit_Click(object? sender, EventArgs e)
        {
            if (SelectedRecipe == null) return;
            using var frm = new RecipeForm(SelectedRecipe);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                RebuildCategories();
                UpdateCategoryFilters();
                RefreshRecipes();
                RefreshQueue();
            }
        }

        private void recipeDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedRecipe == null) return;
            recipes.Remove(SelectedRecipe);
            var items = brewQueue.ToList();
            items.RemoveAll(r => r == SelectedRecipe);
            brewQueue.Clear();
            foreach (var r in items)
                brewQueue.Enqueue(r);
            RebuildCategories();
            UpdateCategoryFilters();
            RefreshRecipes();
            RefreshQueue();
        }

        private void SetupIngredientControls()
        {
            NumericUpDown[] nums = { numAnimal, numBerry, numFungi, numHerb, numMagic, numMineral, numRoot, numSolution, numBottles };
            ingredientControls = nums;
            string[] labels = ingredientNames;
            for (int i = 0; i < nums.Length; i++)
            {
                int row = i / 3;
                int col = i % 3;
                int x = BrewOffsetX + 6 + col * 140;
                int y = 6 + row * 80;

                Label lbl = new Label
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(x, y),
                    AutoSize = true
                };
                grpIngredients.Controls.Add(lbl);

                Button btnMinus = new Button
                {
                    Text = "-",
                    Location = new System.Drawing.Point(x, y + 20),
                    Size = new System.Drawing.Size(20, 23),
                    Tag = nums[i]
                };
                btnMinus.Click += adjustAmount_Click;
                grpIngredients.Controls.Add(btnMinus);

                nums[i].Location = new System.Drawing.Point(x + 24, y + 20);
                nums[i].Maximum = decimal.MaxValue;
                nums[i].Size = new System.Drawing.Size(60, 23);
                nums[i].ValueChanged += (s, e) => RefreshTotals();
                grpIngredients.Controls.Add(nums[i]);

                Button btnPlus = new Button
                {
                    Text = "+",
                    Location = new System.Drawing.Point(x + 88, y + 20),
                    Size = new System.Drawing.Size(20, 23),
                    Tag = nums[i]
                };
                btnPlus.Click += adjustAmount_Click;
                grpIngredients.Controls.Add(btnPlus);
            }
        }

        private void RefreshRecipes()
        {
            listRecipes.DataSource = null;
            listBrewRecipes.DataSource = null;
            var filterR = cmbRecipeFilter.SelectedItem as string;
            var filterB = cmbBrewFilter.SelectedItem as string;

            IEnumerable<Recipe> listR = recipes;
            if (!string.IsNullOrEmpty(filterR) && filterR != "All")
                listR = listR.Where(r => r.Category.Equals(filterR, StringComparison.OrdinalIgnoreCase));

            IEnumerable<Recipe> listB = recipes;
            if (!string.IsNullOrEmpty(filterB) && filterB != "All")
                listB = listB.Where(r => r.Category.Equals(filterB, StringComparison.OrdinalIgnoreCase));

            listRecipes.DataSource = listR.ToList();
            listBrewRecipes.DataSource = listB.ToList();
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
            var filter = cmbInventoryFilter.SelectedItem as string;
            foreach (var kv in inventory)
            {
                potionCategories.TryGetValue(kv.Key, out var cat);
                if (string.IsNullOrEmpty(filter) || filter == "All" || cat == filter)
                    items.Add($"{kv.Key}: {kv.Value}");
            }
            listInventory.DataSource = items;
        }

        private void RefreshWaterList()
        {
            listWaterContainers!.DataSource = null;
            listWaterContainers.DataSource = waterContainers.Select(c => c.ToString()).ToList();
        }

        private void RefreshAll()
        {
            RefreshRecipes();
            RefreshQueue();
            RefreshInventory();
            RefreshWaterList();
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
            int waterRemain = ActiveWaterAmount - waterNeeded;
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
            int capacity = TotalWaterCapacity;
            int amount = TotalWaterAmount;
            int barMax = Math.Min(capacity, int.MaxValue);
            barWater.Maximum = barMax;
            barWater.Value = Math.Max(0, Math.Min(barMax, amount));
            lblWater.Text = $"Water: {amount}/{capacity} mL";
        }

        private void RefreshWater()
        {
            RefreshWaterList();
            RefreshTotals();
            UpdateWaterUI();
        }

        private void UseWater(int amount)
        {
            while (amount > 0)
            {
                var container = waterContainers.Where(c => c.Active && c.Amount > 0)
                    .OrderBy(c => c.Amount).FirstOrDefault();
                if (container == null) break;
                int take = Math.Min(amount, container.Amount);
                container.Amount -= take;
                amount -= take;
            }
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

                if (File.Exists(PotionCategoriesPath))
                {
                    var json = File.ReadAllText(PotionCategoriesPath);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                    if (dict != null)
                    {
                        potionCategories.Clear();
                        foreach (var kv in dict)
                            potionCategories[kv.Key] = kv.Value;
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
                    }
                }
                if (File.Exists(WaterContainersPath))
                {
                    var json = File.ReadAllText(WaterContainersPath);
                    var list = JsonSerializer.Deserialize<List<WaterContainer>>(json);
                    if (list != null)
                    {
                        waterContainers.Clear();
                        waterContainers.AddRange(list);
                    }
                }
                if (waterContainers.Count == 0)
                {
                    waterContainers.Add(new WaterContainer { Name = "Bucket", Capacity = 1000, Amount = 1000 });
                }
                UpdateWaterUI();
                categories.Clear();
                foreach (var r in recipes) AddCategory(r.Category);
                foreach (var c in potionCategories.Values) AddCategory(c);
                UpdateCategoryFilters();
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
                    ["Bottles"] = (int)numBottles.Value
                };
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(IngredientsPath, JsonSerializer.Serialize(ingredients, options));
                File.WriteAllText(RecipesPath, JsonSerializer.Serialize(recipes, options));
                File.WriteAllText(InventoryPath, JsonSerializer.Serialize(inventory, options));
                File.WriteAllText(PotionCategoriesPath, JsonSerializer.Serialize(potionCategories, options));
                File.WriteAllText(WaterContainersPath, JsonSerializer.Serialize(waterContainers, options));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data: " + ex.Message);
            }
        }

        // Rebuild the list of all categories from recipes and potion mappings
        private void RebuildCategories()
        {
            categories.Clear();
            foreach (var r in recipes) AddCategory(r.Category);
            foreach (var c in potionCategories.Values) AddCategory(c);
        }

        private void AddCategory(string? cat)
        {
            if (string.IsNullOrWhiteSpace(cat)) return;
            categories.Add(cat.Trim());
        }

        private void UpdateCategoryFilters()
        {
            var list = new List<string> { "All" };
            list.AddRange(categories.OrderBy(c => c, StringComparer.OrdinalIgnoreCase));
            var selR = cmbRecipeFilter.SelectedItem as string;
            var selB = cmbBrewFilter.SelectedItem as string;
            var selI = cmbInventoryFilter.SelectedItem as string;
            cmbRecipeFilter.DataSource = list.ToList();
            cmbBrewFilter.DataSource = list.ToList();
            cmbInventoryFilter.DataSource = list.ToList();
            if (selR != null && list.Contains(selR)) cmbRecipeFilter.SelectedItem = selR;
            if (selB != null && list.Contains(selB)) cmbBrewFilter.SelectedItem = selB;
            if (selI != null && list.Contains(selI)) cmbInventoryFilter.SelectedItem = selI;
        }

        private void inventorySetCategory_Click(object? sender, EventArgs e)
        {
            if (listInventory.SelectedItem is not string item) return;
            var name = item.Split(':')[0].Trim();
            potionCategories.TryGetValue(name, out var current);
            var input = SimplePrompt.ShowDialog("Enter category:", "Set Category", current ?? string.Empty);
            if (input == null) return;
            input = input.Trim();
            if (input.Length == 0)
                potionCategories.Remove(name);
            else
            {
                potionCategories[name] = input;
                AddCategory(input);
            }
            RebuildCategories();
            UpdateCategoryFilters();
            RefreshInventory();
        }

        private void recipeSetCategory_Click(object? sender, EventArgs e)
        {
            if (SelectedRecipe == null) return;
            var input = SimplePrompt.ShowDialog("Enter category:", "Set Category", SelectedRecipe.Category);
            if (input == null) return;
            SelectedRecipe.Category = input.Trim();
            AddCategory(SelectedRecipe.Category);
            RebuildCategories();
            UpdateCategoryFilters();
            RefreshRecipes();
            RefreshQueue();
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}
