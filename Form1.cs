using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PotionApp
{
    public partial class Form1 : Form
    {
        private readonly List<Recipe> recipes = new();
        private readonly Queue<Recipe> brewQueue = new();
        private readonly Dictionary<string, int> inventory = new();

        public Form1()
        {
            InitializeComponent();
            RefreshAll();
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
    }
}
