using System.Windows.Forms;

namespace PotionApp
{
    partial class RecipeForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private NumericUpDown numAnimal;
        private NumericUpDown numBerry;
        private NumericUpDown numFungi;
        private NumericUpDown numHerb;
        private NumericUpDown numMagic;
        private NumericUpDown numMineral;
        private NumericUpDown numRoot;
        private NumericUpDown numSolution;
        private Button btnOk;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            numAnimal = new NumericUpDown();
            numBerry = new NumericUpDown();
            numFungi = new NumericUpDown();
            numHerb = new NumericUpDown();
            numMagic = new NumericUpDown();
            numMineral = new NumericUpDown();
            numRoot = new NumericUpDown();
            numSolution = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // txtName
            //
            txtName.Location = new System.Drawing.Point(12, 12);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(200, 23);
            txtName.TabIndex = 0;
            txtName.PlaceholderText = "Recipe Name";
            //
            // numeric controls are configured in code
            //
            // btnOk
            //
            btnOk.Location = new System.Drawing.Point(56, 290);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            //
            // btnCancel
            //
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(137, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            //
            // RecipeForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(224, 330);
            Controls.Add(txtName);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnOk;
            CancelButton = btnCancel;
            Name = "RecipeForm";
            Text = "Recipe";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
