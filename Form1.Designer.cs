namespace PotionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRecipes;
        private System.Windows.Forms.TabPage tabBrew;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.ListBox listRecipes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboRecipes;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.ListBox listQueue;
        private System.Windows.Forms.Button btnBrew;
        private System.Windows.Forms.ListBox listInventory;
        private System.Windows.Forms.TextBox txtInventoryName;
        private System.Windows.Forms.NumericUpDown numInventoryCount;
        private System.Windows.Forms.Button btnInventoryAdd;
        private System.Windows.Forms.NumericUpDown numAnimal;
        private System.Windows.Forms.NumericUpDown numBerry;
        private System.Windows.Forms.NumericUpDown numFungi;
        private System.Windows.Forms.NumericUpDown numHerb;
        private System.Windows.Forms.NumericUpDown numMagic;
        private System.Windows.Forms.NumericUpDown numMineral;
        private System.Windows.Forms.NumericUpDown numRoot;
        private System.Windows.Forms.NumericUpDown numSolution;
        private System.Windows.Forms.NumericUpDown numBottles;
        private VerticalProgressBar barWater;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.Label lblWaterAdjust;
        private System.Windows.Forms.NumericUpDown numWaterAdjust;
        private System.Windows.Forms.Button btnWaterAmountPlus;
        private System.Windows.Forms.Button btnWaterAmountMinus;
        private System.Windows.Forms.Button btnWaterPlus;
        private System.Windows.Forms.Button btnWaterMinus;
        private System.Windows.Forms.Button btnFillWater;
        private System.Windows.Forms.RichTextBox rtbTotals;
        private System.Windows.Forms.Label lblRecipeColumns;
        private System.Windows.Forms.Label lblQueueColumns;
        private System.Windows.Forms.TextBox txtHelp;

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
            tabHelp = new System.Windows.Forms.TabPage();
            listRecipes = new System.Windows.Forms.ListBox();
            listQueue = new System.Windows.Forms.ListBox();
            listInventory = new System.Windows.Forms.ListBox();
            txtInventoryName = new System.Windows.Forms.TextBox();
            numInventoryCount = new System.Windows.Forms.NumericUpDown();
            btnInventoryAdd = new System.Windows.Forms.Button();
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
            numBottles = new System.Windows.Forms.NumericUpDown();
            barWater = new VerticalProgressBar();
            lblWater = new System.Windows.Forms.Label();
            lblWaterAdjust = new System.Windows.Forms.Label();
            numWaterAdjust = new System.Windows.Forms.NumericUpDown();
            btnWaterAmountPlus = new System.Windows.Forms.Button();
            btnWaterAmountMinus = new System.Windows.Forms.Button();
            txtHelp = new System.Windows.Forms.TextBox();
            lblRecipeColumns = new System.Windows.Forms.Label();
            lblQueueColumns = new System.Windows.Forms.Label();
            btnWaterPlus = new System.Windows.Forms.Button();
            btnWaterMinus = new System.Windows.Forms.Button();
            btnFillWater = new System.Windows.Forms.Button();
            rtbTotals = new System.Windows.Forms.RichTextBox();
            tabControl1.SuspendLayout();
            tabRecipes.SuspendLayout();
            tabBrew.SuspendLayout();
            tabInventory.SuspendLayout();
            tabHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numAnimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numBerry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numFungi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numHerb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numMagic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numMineral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numBottles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numWaterAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numInventoryCount)).BeginInit();
            SuspendLayout();
            //
            // tabControl1
            //
            tabControl1.Controls.Add(tabRecipes);
            tabControl1.Controls.Add(tabBrew);
            tabControl1.Controls.Add(tabInventory);
            tabControl1.Controls.Add(tabHelp);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 1;
            tabControl1.Size = new System.Drawing.Size(780, 361);
            //
            // tabRecipes
            //
            tabRecipes.Controls.Add(lblRecipeColumns);
            tabRecipes.Controls.Add(listRecipes);
            tabRecipes.Controls.Add(btnAdd);
            tabRecipes.Location = new System.Drawing.Point(4, 24);
            tabRecipes.Name = "tabRecipes";
            tabRecipes.Padding = new System.Windows.Forms.Padding(3);
            tabRecipes.Size = new System.Drawing.Size(772, 333);
            tabRecipes.Text = "Recipes";
            tabRecipes.UseVisualStyleBackColor = true;
            //
            // listRecipes
            //
            listRecipes.FormattingEnabled = true;
            listRecipes.ItemHeight = 15;
            listRecipes.Location = new System.Drawing.Point(6, 26);
            listRecipes.Name = "listRecipes";
            listRecipes.Size = new System.Drawing.Size(400, 299);
            listRecipes.Font = new System.Drawing.Font("Consolas", 9F);
            listRecipes.DoubleClick += listRecipes_DoubleClick;
            //
            // lblRecipeColumns
            //
            lblRecipeColumns.AutoSize = true;
            lblRecipeColumns.Location = new System.Drawing.Point(6, 6);
            lblRecipeColumns.Name = "lblRecipeColumns";
            lblRecipeColumns.Size = new System.Drawing.Size(0, 15);
            lblRecipeColumns.TabIndex = 3;
            lblRecipeColumns.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
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
            tabBrew.Controls.Add(lblQueueColumns);
            tabBrew.Controls.Add(listQueue);
            tabBrew.Controls.Add(btnBrew);
            tabBrew.Controls.Add(rtbTotals);
            tabBrew.Controls.Add(numAnimal);
            tabBrew.Controls.Add(numBerry);
            tabBrew.Controls.Add(numFungi);
            tabBrew.Controls.Add(numHerb);
            tabBrew.Controls.Add(numMagic);
            tabBrew.Controls.Add(numMineral);
            tabBrew.Controls.Add(numRoot);
            tabBrew.Controls.Add(numSolution);
            tabBrew.Controls.Add(numBottles);
            tabBrew.Controls.Add(barWater);
            tabBrew.Controls.Add(lblWater);
            tabBrew.Controls.Add(lblWaterAdjust);
            tabBrew.Controls.Add(numWaterAdjust);
            tabBrew.Controls.Add(btnWaterPlus);
            tabBrew.Controls.Add(btnWaterMinus);
            tabBrew.Controls.Add(btnFillWater);
            tabBrew.Controls.Add(btnWaterAmountPlus);
            tabBrew.Controls.Add(btnWaterAmountMinus);
            tabBrew.Location = new System.Drawing.Point(4, 24);
            tabBrew.Name = "tabBrew";
            tabBrew.Padding = new System.Windows.Forms.Padding(3);
            tabBrew.Size = new System.Drawing.Size(772, 333);
            tabBrew.Text = "Brewing";
            tabBrew.UseVisualStyleBackColor = true;
            //
            // comboRecipes
            //
            comboRecipes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRecipes.Location = new System.Drawing.Point(6, 130);
            comboRecipes.Name = "comboRecipes";
            comboRecipes.Size = new System.Drawing.Size(200, 23);
            //
            // btnAddQueue
            //
            btnAddQueue.Location = new System.Drawing.Point(212, 130);
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
            listQueue.Size = new System.Drawing.Size(480, 128);
            listQueue.Font = new System.Drawing.Font("Consolas", 9F);
            listQueue.DoubleClick += listQueue_DoubleClick;
            //
            // lblQueueColumns
            //
            lblQueueColumns.AutoSize = true;
            lblQueueColumns.Location = new System.Drawing.Point(6, 180);
            lblQueueColumns.Name = "lblQueueColumns";
            lblQueueColumns.Size = new System.Drawing.Size(0, 15);
            lblQueueColumns.TabIndex = 9;
            lblQueueColumns.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            //
            // btnBrew
            //
            btnBrew.Location = new System.Drawing.Point(492, 199);
            btnBrew.Name = "btnBrew";
            btnBrew.Size = new System.Drawing.Size(75, 23);
            btnBrew.Text = "Brew All";
            btnBrew.UseVisualStyleBackColor = true;
            btnBrew.Click += btnBrew_Click;
            //
            // rtbTotals
            //
            rtbTotals.Location = new System.Drawing.Point(492, 228);
            rtbTotals.Name = "rtbTotals";
            rtbTotals.ReadOnly = true;
            rtbTotals.Size = new System.Drawing.Size(150, 99);
            rtbTotals.TabStop = false;
            rtbTotals.Font = new System.Drawing.Font("Consolas", 9F);
            //
            // lblWater
            //
            lblWater.AutoSize = true;
            lblWater.Location = new System.Drawing.Point(640, 6);
            lblWater.Name = "lblWater";
            lblWater.Size = new System.Drawing.Size(45, 15);
            lblWater.Text = "Water";
            //
            // barWater
            //
            barWater.Location = new System.Drawing.Point(640, 24);
            barWater.Maximum = 1000;
            barWater.Name = "barWater";
            barWater.Size = new System.Drawing.Size(23, 150);
            barWater.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            barWater.ForeColor = System.Drawing.Color.Blue;
            //
            // lblWaterAdjust
            //
            lblWaterAdjust.AutoSize = true;
            lblWaterAdjust.Location = new System.Drawing.Point(669, 108);
            lblWaterAdjust.Name = "lblWaterAdjust";
            lblWaterAdjust.Size = new System.Drawing.Size(47, 15);
            lblWaterAdjust.Text = "Amount";
            //
            // numWaterAdjust
            //
            numWaterAdjust.Location = new System.Drawing.Point(669, 126);
            numWaterAdjust.Maximum = 1000;
            numWaterAdjust.Minimum = 1;
            numWaterAdjust.Name = "numWaterAdjust";
            numWaterAdjust.Size = new System.Drawing.Size(60, 23);
            numWaterAdjust.Value = 1;
            //
            // btnWaterPlus
            //
            btnWaterPlus.Location = new System.Drawing.Point(669, 24);
            btnWaterPlus.Name = "btnWaterPlus";
            btnWaterPlus.Size = new System.Drawing.Size(23, 23);
            btnWaterPlus.Text = "+";
            btnWaterPlus.UseVisualStyleBackColor = true;
            btnWaterPlus.Click += adjustWater_Click;
            //
            // btnWaterMinus
            //
            btnWaterMinus.Location = new System.Drawing.Point(669, 53);
            btnWaterMinus.Name = "btnWaterMinus";
            btnWaterMinus.Size = new System.Drawing.Size(23, 23);
            btnWaterMinus.Text = "-";
            btnWaterMinus.UseVisualStyleBackColor = true;
            btnWaterMinus.Click += adjustWater_Click;
            //
            // btnFillWater
            //
            btnFillWater.Location = new System.Drawing.Point(669, 82);
            btnFillWater.Name = "btnFillWater";
            btnFillWater.Size = new System.Drawing.Size(92, 23);
            btnFillWater.Text = "Fill";
            btnFillWater.UseVisualStyleBackColor = true;
            btnFillWater.Click += btnFillWater_Click;
            //
            // btnWaterAmountPlus
            //
            btnWaterAmountPlus.Location = new System.Drawing.Point(698, 24);
            btnWaterAmountPlus.Name = "btnWaterAmountPlus";
            btnWaterAmountPlus.Size = new System.Drawing.Size(23, 23);
            btnWaterAmountPlus.Text = "+";
            btnWaterAmountPlus.UseVisualStyleBackColor = true;
            btnWaterAmountPlus.Click += adjustWaterAmount_Click;
            //
            // btnWaterAmountMinus
            //
            btnWaterAmountMinus.Location = new System.Drawing.Point(698, 53);
            btnWaterAmountMinus.Name = "btnWaterAmountMinus";
            btnWaterAmountMinus.Size = new System.Drawing.Size(23, 23);
            btnWaterAmountMinus.Text = "-";
            btnWaterAmountMinus.UseVisualStyleBackColor = true;
            btnWaterAmountMinus.Click += adjustWaterAmount_Click;
            //
            // tabInventory
            //
            tabInventory.Controls.Add(listInventory);
            tabInventory.Controls.Add(txtInventoryName);
            tabInventory.Controls.Add(numInventoryCount);
            tabInventory.Controls.Add(btnInventoryAdd);
            tabInventory.Location = new System.Drawing.Point(4, 24);
            tabInventory.Name = "tabInventory";
            tabInventory.Padding = new System.Windows.Forms.Padding(3);
            tabInventory.Size = new System.Drawing.Size(772, 333);
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
            listInventory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            listInventory.DrawItem += listInventory_DrawItem;
            listInventory.DoubleClick += listInventory_DoubleClick;
            //
            // txtInventoryName
            //
            txtInventoryName.Location = new System.Drawing.Point(412, 6);
            txtInventoryName.Name = "txtInventoryName";
            txtInventoryName.Size = new System.Drawing.Size(150, 23);
            //
            // numInventoryCount
            //
            numInventoryCount.Location = new System.Drawing.Point(412, 35);
            numInventoryCount.Maximum = 1000;
            numInventoryCount.Minimum = 1;
            numInventoryCount.Name = "numInventoryCount";
            numInventoryCount.Size = new System.Drawing.Size(60, 23);
            numInventoryCount.Value = 1;
            //
            // btnInventoryAdd
            //
            btnInventoryAdd.Location = new System.Drawing.Point(478, 34);
            btnInventoryAdd.Name = "btnInventoryAdd";
            btnInventoryAdd.Size = new System.Drawing.Size(84, 23);
            btnInventoryAdd.Text = "Add";
            btnInventoryAdd.UseVisualStyleBackColor = true;
            btnInventoryAdd.Click += btnInventoryAdd_Click;
            //
            // tabHelp
            //
            tabHelp.Controls.Add(txtHelp);
            tabHelp.Location = new System.Drawing.Point(4, 24);
            tabHelp.Name = "tabHelp";
            tabHelp.Padding = new System.Windows.Forms.Padding(3);
            tabHelp.Size = new System.Drawing.Size(772, 333);
            tabHelp.Text = "Help";
            tabHelp.UseVisualStyleBackColor = true;
            //
            // txtHelp
            //
            txtHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            txtHelp.Location = new System.Drawing.Point(3, 3);
            txtHelp.Multiline = true;
            txtHelp.Name = "txtHelp";
            txtHelp.ReadOnly = true;
            txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtHelp.Size = new System.Drawing.Size(766, 327);
            txtHelp.Text = "Controls:\r\n\r\nRecipes tab:\r\n - Add new recipes with the Add button.\r\n - Double-click a recipe to edit it.\r\n\r\nBrewing tab:\r\n - Choose a recipe and press Add to queue.\r\n - Double-click a queued item to remove it.\r\n - Brew All consumes ingredients and bottles.\r\n - Use the + and - buttons next to the water bar to change the current water.\r\n - Use the + and - by the Amount box to change water capacity. Hold Shift for \u00b15, Ctrl for \u00b110, and both for \u00b1100. Set the water amount box to choose the capacity adjustment size.\r\n\r\nInventory tab:\r\n - Enter a name and count then click Add.\r\n - Double-click an item to consume one.\r\n - Right-click an item to create a recipe with that name.\r\n Unknown potions show in orange.";
            //
            // Form1
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 361);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Potion Manager";
            tabControl1.ResumeLayout(false);
            tabRecipes.ResumeLayout(false);
            tabBrew.ResumeLayout(false);
            tabInventory.ResumeLayout(false);
            tabHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(numAnimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numBerry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numFungi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numHerb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numMagic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numMineral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numBottles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numWaterAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numInventoryCount)).EndInit();
            ResumeLayout(false);
        }
    }
}
