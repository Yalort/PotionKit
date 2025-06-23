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
        private System.Windows.Forms.ListBox listBrewRecipes;
        private System.Windows.Forms.Button btnAddQueue;
        private System.Windows.Forms.ListBox listQueue;
        private System.Windows.Forms.Button btnBrew;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.ListBox listInventory;
        private System.Windows.Forms.TextBox txtInventoryName;
        private System.Windows.Forms.NumericUpDown numInventoryCount;
        private System.Windows.Forms.Button btnInventoryAdd;
        private System.Windows.Forms.ComboBox cmbRecipeFilter;
        private System.Windows.Forms.ComboBox cmbBrewFilter;
        private System.Windows.Forms.ComboBox cmbInventoryFilter;
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
        private System.Windows.Forms.Button btnFillWater;
        private System.Windows.Forms.Button btnAddWater;
        private System.Windows.Forms.ListBox listWaterContainers;
        private System.Windows.Forms.RichTextBox rtbTotals;
        private System.Windows.Forms.Label lblRecipeColumns;
        private System.Windows.Forms.Label lblQueueColumns;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.GroupBox grpIngredients;
        private System.Windows.Forms.GroupBox grpQueue;
        private System.Windows.Forms.GroupBox grpWater;

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
            btnBrew = new System.Windows.Forms.Button();
            btnAddQueue = new System.Windows.Forms.Button();
            btnClearQueue = new System.Windows.Forms.Button();
            cmbRecipeFilter = new System.Windows.Forms.ComboBox();
            cmbBrewFilter = new System.Windows.Forms.ComboBox();
            cmbInventoryFilter = new System.Windows.Forms.ComboBox();
            listBrewRecipes = new System.Windows.Forms.ListBox();
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
            btnFillWater = new System.Windows.Forms.Button();
            btnAddWater = new System.Windows.Forms.Button();
            listWaterContainers = new System.Windows.Forms.ListBox();
            txtHelp = new System.Windows.Forms.TextBox();
            lblRecipeColumns = new System.Windows.Forms.Label();
            lblQueueColumns = new System.Windows.Forms.Label();
            rtbTotals = new System.Windows.Forms.RichTextBox();
            grpIngredients = new System.Windows.Forms.GroupBox();
            grpQueue = new System.Windows.Forms.GroupBox();
            grpWater = new System.Windows.Forms.GroupBox();
            tabControl1.SuspendLayout();
            tabRecipes.SuspendLayout();
            tabBrew.SuspendLayout();
            tabInventory.SuspendLayout();
            tabHelp.SuspendLayout();
            grpIngredients.SuspendLayout();
            grpQueue.SuspendLayout();
            grpWater.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numAnimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numBerry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numFungi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numHerb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numMagic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numMineral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numBottles)).BeginInit();
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
            tabControl1.Size = new System.Drawing.Size(1539, 619);
            //
            // tabRecipes
            //
            tabRecipes.Controls.Add(lblRecipeColumns);
            tabRecipes.Controls.Add(listRecipes);
            tabRecipes.Controls.Add(btnAdd);
            tabRecipes.Controls.Add(cmbRecipeFilter);
            tabRecipes.Location = new System.Drawing.Point(4, 24);
            tabRecipes.Name = "tabRecipes";
            tabRecipes.Padding = new System.Windows.Forms.Padding(3);
            tabRecipes.Size = new System.Drawing.Size(1529, 582);
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
            // cmbRecipeFilter
            //
            cmbRecipeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbRecipeFilter.Location = new System.Drawing.Point(412, 35);
            cmbRecipeFilter.Name = "cmbRecipeFilter";
            cmbRecipeFilter.Size = new System.Drawing.Size(150, 23);
            //
            // tabBrew
            //
            tabBrew.Controls.Add(grpWater);
            tabBrew.Controls.Add(grpQueue);
            tabBrew.Controls.Add(grpIngredients);
            tabBrew.Controls.Add(listBrewRecipes);
            tabBrew.Controls.Add(cmbBrewFilter);
            tabBrew.Controls.Add(btnAddQueue);
            tabBrew.Controls.Add(lblQueueColumns);
            tabBrew.Controls.Add(listQueue);
            tabBrew.Controls.Add(btnBrew);
            tabBrew.Controls.Add(btnClearQueue);
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
            tabBrew.Controls.Add(btnFillWater);
            tabBrew.Controls.Add(btnAddWater);
            tabBrew.Controls.Add(listWaterContainers);
            tabBrew.Location = new System.Drawing.Point(4, 24);
            tabBrew.Name = "tabBrew";
            tabBrew.Padding = new System.Windows.Forms.Padding(3);
            tabBrew.Size = new System.Drawing.Size(1529, 582);
            tabBrew.Text = "Brewing";
            tabBrew.UseVisualStyleBackColor = true;
            //
            // listBrewRecipes
            //
            listBrewRecipes.FormattingEnabled = true;
            listBrewRecipes.ItemHeight = 15;
            listBrewRecipes.Location = new System.Drawing.Point(6, 6);
            listBrewRecipes.Name = "listBrewRecipes";
            listBrewRecipes.Size = new System.Drawing.Size(400, 436);
            listBrewRecipes.Font = new System.Drawing.Font("Consolas", 9F);
            listBrewRecipes.DoubleClick += listBrewRecipes_DoubleClick;
            //
            // cmbBrewFilter
            //
            cmbBrewFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBrewFilter.Location = new System.Drawing.Point(412, 6);
            cmbBrewFilter.Name = "cmbBrewFilter";
            cmbBrewFilter.Size = new System.Drawing.Size(90, 23);
            //
            // btnAddQueue
            //
            btnAddQueue.Location = new System.Drawing.Point(612, 130);
            btnAddQueue.Name = "btnAddQueue";
            btnAddQueue.Size = new System.Drawing.Size(75, 23);
            btnAddQueue.Text = "Add";
            btnAddQueue.UseVisualStyleBackColor = true;
            btnAddQueue.Click += btnAddQueue_Click;
            //
            // grpIngredients
            //
            grpIngredients.Location = new System.Drawing.Point(475, 5);
            grpIngredients.Name = "grpIngredients";
            grpIngredients.Size = new System.Drawing.Size(398, 223);
            grpIngredients.TabStop = false;
            grpIngredients.Text = "Ingredients";
            //
            // grpQueue
            //
            grpQueue.Location = new System.Drawing.Point(411, 235);
            grpQueue.Name = "grpQueue";
            grpQueue.Size = new System.Drawing.Size(490, 228);
            grpQueue.TabStop = false;
            grpQueue.Text = "Queue";
            //
            // grpWater
            //
            grpWater.Location = new System.Drawing.Point(1241, 5);
            grpWater.Name = "grpWater";
            grpWater.Size = new System.Drawing.Size(283, 437);
            grpWater.TabStop = false;
            grpWater.Text = "Water";
            //
            // listQueue
            // listQueue
            //
            listQueue.FormattingEnabled = true;
            listQueue.ItemHeight = 15;
            listQueue.Location = new System.Drawing.Point(416, 256);
            listQueue.Name = "listQueue";
            listQueue.Size = new System.Drawing.Size(480, 208);
            listQueue.Font = new System.Drawing.Font("Consolas", 9F);
            listQueue.DoubleClick += listQueue_DoubleClick;
            //
            // lblQueueColumns
            //
            lblQueueColumns.AutoSize = true;
            lblQueueColumns.Location = new System.Drawing.Point(416, 240);
            lblQueueColumns.Name = "lblQueueColumns";
            lblQueueColumns.Size = new System.Drawing.Size(0, 15);
            lblQueueColumns.TabIndex = 9;
            lblQueueColumns.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            //
            // btnBrew
            //
            btnBrew.Location = new System.Drawing.Point(1246, 235);
            btnBrew.Name = "btnBrew";
            btnBrew.Size = new System.Drawing.Size(75, 23);
            btnBrew.Text = "Brew All";
            btnBrew.UseVisualStyleBackColor = true;
            btnBrew.Click += btnBrew_Click;
            //
            // btnClearQueue
            //
            btnClearQueue.Location = new System.Drawing.Point(1327, 235);
            btnClearQueue.Name = "btnClearQueue";
            btnClearQueue.Size = new System.Drawing.Size(70, 23);
            btnClearQueue.Text = "Clear";
            btnClearQueue.UseVisualStyleBackColor = true;
            btnClearQueue.Click += btnClearQueue_Click;
            //
            // rtbTotals
            //
            rtbTotals.Location = new System.Drawing.Point(1246, 243);
            rtbTotals.Name = "rtbTotals";
            rtbTotals.ReadOnly = true;
            rtbTotals.Size = new System.Drawing.Size(150, 214);
            rtbTotals.TabStop = false;
            rtbTotals.Font = new System.Drawing.Font("Consolas", 9F);
            //
            // lblWater
            //
            lblWater.AutoSize = true;
            lblWater.Location = new System.Drawing.Point(1394, 6);
            lblWater.Name = "lblWater";
            lblWater.Size = new System.Drawing.Size(45, 15);
            lblWater.Text = "Water";
            //
            // barWater
            //
            barWater.Location = new System.Drawing.Point(1404, 24);
            barWater.Maximum = int.MaxValue;
            barWater.Name = "barWater";
            barWater.Size = new System.Drawing.Size(15, 415);
            barWater.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            barWater.ForeColor = System.Drawing.Color.Blue;
            //
            // btnFillWater
            //
            btnFillWater.Location = new System.Drawing.Point(1420, 82);
            btnFillWater.Name = "btnFillWater";
            btnFillWater.Size = new System.Drawing.Size(92, 23);
            btnFillWater.Text = "Fill";
            btnFillWater.UseVisualStyleBackColor = true;
            btnFillWater.Click += btnFillWater_Click;
            //
            // btnAddWater
            //
            btnAddWater.Location = new System.Drawing.Point(1420, 53);
            btnAddWater.Name = "btnAddWater";
            btnAddWater.Size = new System.Drawing.Size(92, 23);
            btnAddWater.Text = "Add";
            btnAddWater.UseVisualStyleBackColor = true;
            btnAddWater.Click += btnAddWater_Click;
            //
            // listWaterContainers
            //
            listWaterContainers.FormattingEnabled = true;
            listWaterContainers.ItemHeight = 15;
            listWaterContainers.Location = new System.Drawing.Point(1246, 6);
            listWaterContainers.Name = "listWaterContainers";
            listWaterContainers.Size = new System.Drawing.Size(150, 214);
            //
            // tabInventory
            //
            tabInventory.Controls.Add(listInventory);
            tabInventory.Controls.Add(txtInventoryName);
            tabInventory.Controls.Add(numInventoryCount);
            tabInventory.Controls.Add(btnInventoryAdd);
            tabInventory.Controls.Add(cmbInventoryFilter);
            tabInventory.Location = new System.Drawing.Point(4, 24);
            tabInventory.Name = "tabInventory";
            tabInventory.Padding = new System.Windows.Forms.Padding(3);
            tabInventory.Size = new System.Drawing.Size(1529, 582);
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
            // cmbInventoryFilter
            //
            cmbInventoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbInventoryFilter.Location = new System.Drawing.Point(412, 64);
            cmbInventoryFilter.Name = "cmbInventoryFilter";
            cmbInventoryFilter.Size = new System.Drawing.Size(150, 23);
            //
            // tabHelp
            //
            tabHelp.Controls.Add(txtHelp);
            tabHelp.Location = new System.Drawing.Point(4, 24);
            tabHelp.Name = "tabHelp";
            tabHelp.Padding = new System.Windows.Forms.Padding(3);
            tabHelp.Size = new System.Drawing.Size(1529, 582);
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
            txtHelp.Size = new System.Drawing.Size(1523, 425);
            txtHelp.Text = "Controls:\r\n\r\nRecipes tab:\r\n - Add new recipes with the Add button.\r\n - Double-click a recipe to edit it.\r\n - Right-click a recipe to edit, delete, or set its category.\r\n\r\nBrewing tab:\r\n - Double-click a recipe or use the Add button to queue it.\r\n - Double-click a queued item to remove it.\r\n - Brew All consumes ingredients, bottles, and water.\r\n - Use + and - next to each ingredient to change amounts.\r\n - Water containers list shows all storage. Double-click one to fill it or right-click for more options.\r\n - Fill All fills every container.\r\n - Hold Shift for \u00b15, Ctrl for \u00b110, and both for \u00b1100 when adjusting ingredients.\r\n\r\nInventory tab:\r\n - Type a name and count then click Add.\r\n - Double-click an item to consume one.\r\n - Right-click an item to create a recipe, rename it, edit the count, add to queue, or set a category.\r\n - Unknown potions show in orange.";
            //
            // Form1
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1539, 619);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Potion Manager";
            tabControl1.ResumeLayout(false);
            tabRecipes.ResumeLayout(false);
            tabBrew.ResumeLayout(false);
            grpWater.ResumeLayout(false);
            grpQueue.ResumeLayout(false);
            grpIngredients.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(numInventoryCount)).EndInit();
            ResumeLayout(false);
        }
    }
}
