using System;
using System.Windows.Forms;

namespace PotionApp
{
    public partial class RecipeForm : Form
    {
        public Recipe Recipe { get; private set; }

        public RecipeForm(Recipe? recipe = null)
        {
            InitializeComponent();
            SetupNumericControls();
            if (recipe != null)
            {
                Recipe = recipe;
                txtName.Text = recipe.Name;
                txtCategory.Text = recipe.Category;
                txtSpecial.Text = recipe.Special;
                numAnimal.Value = recipe.Animal;
                numBerry.Value = recipe.Berry;
                numFungi.Value = recipe.Fungi;
                numHerb.Value = recipe.Herb;
                numMagic.Value = recipe.Magic;
                numMineral.Value = recipe.Mineral;
                numRoot.Value = recipe.Root;
                numSolution.Value = recipe.Solution;
            }
            else
            {
                Recipe = new Recipe();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Recipe.Name = txtName.Text.Trim();
            Recipe.Category = txtCategory.Text.Trim();
            Recipe.Animal = (int)numAnimal.Value;
            Recipe.Berry = (int)numBerry.Value;
            Recipe.Fungi = (int)numFungi.Value;
            Recipe.Herb = (int)numHerb.Value;
            Recipe.Magic = (int)numMagic.Value;
            Recipe.Mineral = (int)numMineral.Value;
            Recipe.Root = (int)numRoot.Value;
            Recipe.Solution = (int)numSolution.Value;
            Recipe.Special = txtSpecial.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetupNumericControls()
        {
            int top = 110;
            NumericUpDown[] nums = { numAnimal, numBerry, numFungi, numHerb, numMagic, numMineral, numRoot, numSolution };
            string[] labels = { "Animal", "Berry", "Fungi", "Herb", "Magic", "Mineral", "Root", "Solution" };
            for (int i = 0; i < nums.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = labels[i],
                    Location = new System.Drawing.Point(12, top + i * 30),
                    AutoSize = true
                };
                Controls.Add(lbl);

                nums[i].Location = new System.Drawing.Point(80, top + i * 30 - 3);
                nums[i].Name = "num" + labels[i];
                nums[i].Maximum = decimal.MaxValue;
                Controls.Add(nums[i]);
            }

            btnOk.Location = new System.Drawing.Point(56, top + nums.Length * 30);
            btnCancel.Location = new System.Drawing.Point(137, top + nums.Length * 30);
            ClientSize = new System.Drawing.Size(224, top + nums.Length * 30 + 40);
        }
    }
}
