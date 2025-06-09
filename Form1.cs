using System;
using System.Collections.Generic;
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

        private readonly string dataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "potionkit2");
        private string IngredientsPath => Path.Combine(dataDir, "ingredients.json");
        private string RecipesPath => Path.Combine(dataDir, "recipes.json");
        private string InventoryPath => Path.Combine(dataDir, "inventory.json");

        public Form1()
        {
            InitializeComponent();
            SetupIngredientControls();
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

        private void btnBrew_Click(object sender, EventArgs e)
        {
            if (brewQueue.Count == 0) return;
            var rec = brewQueue.Dequeue();
            if (!inventory.ContainsKey(rec.Name)) inventory[rec.Name] = 0;
            inventory[rec.Name]++;
            RefreshQueue();
            RefreshInventory();
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

        private void SetupIngredientControls()
        {
            NumericUpDown[] nums = { numAnimal, numBerry, numFungi, numHerb, numMagic, numMineral, numRoot, numSolution };
            string[] labels = { "Animal", "Berry", "Fungi", "Herb", "Magic", "Mineral", "Root", "Solution" };
            for (int i = 0; i < nums.Length; i++)
            {
                int row = i / 4;
                int col = i % 4;
                int x = 6 + col * 140;
                int y = 6 + row * 80;

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
                    }
                }
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
                    ["Solution"] = (int)numSolution.Value
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
