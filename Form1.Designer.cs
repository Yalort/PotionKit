namespace PotionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRecipes;
        private System.Windows.Forms.TabPage tabBrew;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.ListBox listRecipes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboRecipes;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.ListBox listQueue;
        private System.Windows.Forms.Button btnBrew;
        private System.Windows.Forms.ListBox listInventory;
        private System.Windows.Forms.NumericUpDown numAnimal;
        private System.Windows.Forms.NumericUpDown numBerry;
        private System.Windows.Forms.NumericUpDown numFungi;
        private System.Windows.Forms.NumericUpDown numHerb;
        private System.Windows.Forms.NumericUpDown numMagic;
        private System.Windows.Forms.NumericUpDown numMineral;
        private System.Windows.Forms.NumericUpDown numRoot;
        private System.Windows.Forms.NumericUpDown numSolution;

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
            tabControl1 = new System.Windows.Forms.TabControl();
            tabRecipes = new System.Windows.Forms.TabPage();
            tabBrew = new System.Windows.Forms.TabPage();
            tabInventory = new System.Windows.Forms.TabPage();
            listRecipes = new System.Windows.Forms.ListBox();
            listQueue = new System.Windows.Forms.ListBox();
            listInventory = new System.Windows.Forms.ListBox();
            btnAdd = new System.Windows.Forms.Button();
            btnAddQueue = new System.Windows.Forms.Button();
            btnBrew = new System.Windows.Forms.Button();
            comboRecipes = new System.Windows.Forms.ComboBox();
            numAnimal = new System.Windows.Forms.NumericUpDown();
            numBerry = new System.Windows.Forms.NumericUpDown();
            numFungi = new System.Windows.Forms.NumericUpDown();
            numHerb = new System.Windows.Forms.NumericUpDown();
            numMagic = new System.Windows.Forms.NumericUpDown();
            numMineral = new System.Windows.Forms.NumericUpDown();
            numRoot = new System.Windows.Forms.NumericUpDown();
            numSolution = new System.Windows.Forms.NumericUpDown();
            tabControl1.SuspendLayout();
            tabRecipes.SuspendLayout();
            tabBrew.SuspendLayout();
            tabInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numAnimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numBerry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numFungi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numHerb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numMagic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numMineral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numSolution)).BeginInit();
            SuspendLayout();
            //
            // tabControl1
            //
            tabControl1.Controls.Add(tabRecipes);
            tabControl1.Controls.Add(tabBrew);
            tabControl1.Controls.Add(tabInventory);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(584, 361);
            //
            // tabRecipes
            //
            tabRecipes.Controls.Add(listRecipes);
            tabRecipes.Controls.Add(btnAdd);
            tabRecipes.Location = new System.Drawing.Point(4, 24);
            tabRecipes.Name = "tabRecipes";
            tabRecipes.Padding = new System.Windows.Forms.Padding(3);
            tabRecipes.Size = new System.Drawing.Size(576, 333);
            tabRecipes.Text = "Recipes";
            tabRecipes.UseVisualStyleBackColor = true;
            //
            // listRecipes
            //
            listRecipes.FormattingEnabled = true;
            listRecipes.ItemHeight = 15;
            listRecipes.Location = new System.Drawing.Point(6, 6);
            listRecipes.Name = "listRecipes";
            listRecipes.Size = new System.Drawing.Size(400, 319);
            listRecipes.DoubleClick += listRecipes_DoubleClick;
            //
            // btnAdd
            //
            btnAdd.Location = new System.Drawing.Point(412, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(75, 23);
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            //
            // tabBrew
            //
            tabBrew.Controls.Add(comboRecipes);
            tabBrew.Controls.Add(btnAddQueue);
            tabBrew.Controls.Add(listQueue);
            tabBrew.Controls.Add(btnBrew);
            tabBrew.Controls.Add(numAnimal);
            tabBrew.Controls.Add(numBerry);
            tabBrew.Controls.Add(numFungi);
            tabBrew.Controls.Add(numHerb);
            tabBrew.Controls.Add(numMagic);
            tabBrew.Controls.Add(numMineral);
            tabBrew.Controls.Add(numRoot);
            tabBrew.Controls.Add(numSolution);
            tabBrew.Location = new System.Drawing.Point(4, 24);
            tabBrew.Name = "tabBrew";
            tabBrew.Padding = new System.Windows.Forms.Padding(3);
            tabBrew.Size = new System.Drawing.Size(576, 333);
            tabBrew.Text = "Brewing";
            tabBrew.UseVisualStyleBackColor = true;
            //
            // comboRecipes
            //
            comboRecipes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRecipes.Location = new System.Drawing.Point(6, 170);
            comboRecipes.Name = "comboRecipes";
            comboRecipes.Size = new System.Drawing.Size(200, 23);
            //
            // btnAddQueue
            //
            btnAddQueue.Location = new System.Drawing.Point(212, 170);
            btnAddQueue.Name = "btnAddQueue";
            btnAddQueue.Size = new System.Drawing.Size(75, 23);
            btnAddQueue.Text = "Add";
            btnAddQueue.UseVisualStyleBackColor = true;
            btnAddQueue.Click += btnAddQueue_Click;
            //
            // listQueue
            //
            listQueue.FormattingEnabled = true;
            listQueue.ItemHeight = 15;
            listQueue.Location = new System.Drawing.Point(6, 199);
            listQueue.Name = "listQueue";
            listQueue.Size = new System.Drawing.Size(400, 128);
            //
            // btnBrew
            //
            btnBrew.Location = new System.Drawing.Point(412, 199);
            btnBrew.Name = "btnBrew";
            btnBrew.Size = new System.Drawing.Size(75, 23);
            btnBrew.Text = "Brew Next";
            btnBrew.UseVisualStyleBackColor = true;
            btnBrew.Click += btnBrew_Click;
            //
            // ingredient numeric controls
            //
            System.Windows.Forms.NumericUpDown[] nums = { numAnimal, numBerry, numFungi, numHerb, numMagic, numMineral, numRoot, numSolution };
            string[] labels = { "Animal", "Berry", "Fungi", "Herb", "Magic", "Mineral", "Root", "Solution" };
            for (int i = 0; i < nums.Length; i++)
            {
                int row = i / 4;
                int col = i % 4;
                int x = 6 + col * 140;
                int y = 6 + row * 80;

                Label lbl = new Label();
                lbl.Text = labels[i];
                lbl.Location = new System.Drawing.Point(x, y);
                lbl.AutoSize = true;
                tabBrew.Controls.Add(lbl);

                Button btnMinus = new Button();
                btnMinus.Text = "-";
                btnMinus.Location = new System.Drawing.Point(x, y + 20);
                btnMinus.Size = new System.Drawing.Size(20, 23);
                btnMinus.Tag = nums[i];
                btnMinus.Click += adjustAmount_Click;
                tabBrew.Controls.Add(btnMinus);

                nums[i].Location = new System.Drawing.Point(x + 24, y + 20);
                nums[i].Maximum = 1000000;
                nums[i].Size = new System.Drawing.Size(60, 23);
                tabBrew.Controls.Add(nums[i]);

                Button btnPlus = new Button();
                btnPlus.Text = "+";
                btnPlus.Location = new System.Drawing.Point(x + 88, y + 20);
                btnPlus.Size = new System.Drawing.Size(20, 23);
                btnPlus.Tag = nums[i];
                btnPlus.Click += adjustAmount_Click;
                tabBrew.Controls.Add(btnPlus);
            }
            //
            // tabInventory
            //
            tabInventory.Controls.Add(listInventory);
            tabInventory.Location = new System.Drawing.Point(4, 24);
            tabInventory.Name = "tabInventory";
            tabInventory.Padding = new System.Windows.Forms.Padding(3);
            tabInventory.Size = new System.Drawing.Size(576, 333);
            tabInventory.Text = "Inventory";
            tabInventory.UseVisualStyleBackColor = true;
            //
            // listInventory
            //
            listInventory.FormattingEnabled = true;
            listInventory.ItemHeight = 15;
            listInventory.Location = new System.Drawing.Point(6, 6);
            listInventory.Name = "listInventory";
            listInventory.Size = new System.Drawing.Size(400, 319);
            listInventory.DoubleClick += listInventory_DoubleClick;
            //
            // Form1
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(584, 361);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Potion Manager";
            tabControl1.ResumeLayout(false);
            tabRecipes.ResumeLayout(false);
            tabBrew.ResumeLayout(false);
            tabInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(numAnimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numBerry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numFungi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numHerb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numMagic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numMineral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numSolution)).EndInit();
            ResumeLayout(false);
        }
    }
}
