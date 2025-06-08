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
            if (recipe != null)
            {
                Recipe = recipe;
                txtName.Text = recipe.Name;
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
            Recipe.Animal = (int)numAnimal.Value;
            Recipe.Berry = (int)numBerry.Value;
            Recipe.Fungi = (int)numFungi.Value;
            Recipe.Herb = (int)numHerb.Value;
            Recipe.Magic = (int)numMagic.Value;
            Recipe.Mineral = (int)numMineral.Value;
            Recipe.Root = (int)numRoot.Value;
            Recipe.Solution = (int)numSolution.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
