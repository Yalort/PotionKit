namespace PotionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRecipes;
        private System.Windows.Forms.TabPage tabQueue;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.ListBox listRecipes;
        private System.Windows.Forms.ListBox listQueue;
        private System.Windows.Forms.ListBox listInventory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.Button btnBrew;

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
            tabQueue = new System.Windows.Forms.TabPage();
            tabInventory = new System.Windows.Forms.TabPage();
            listRecipes = new System.Windows.Forms.ListBox();
            listQueue = new System.Windows.Forms.ListBox();
            listInventory = new System.Windows.Forms.ListBox();
            btnAdd = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            btnQueue = new System.Windows.Forms.Button();
            btnBrew = new System.Windows.Forms.Button();
            tabControl1.SuspendLayout();
            tabRecipes.SuspendLayout();
            tabQueue.SuspendLayout();
            tabInventory.SuspendLayout();
            SuspendLayout();
            //
            // tabControl1
            //
            tabControl1.Controls.Add(tabRecipes);
            tabControl1.Controls.Add(tabQueue);
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
            tabRecipes.Controls.Add(btnEdit);
            tabRecipes.Controls.Add(btnRemove);
            tabRecipes.Controls.Add(btnQueue);
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
            // btnEdit
            //
            btnEdit.Location = new System.Drawing.Point(412, 35);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(75, 23);
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            //
            // btnRemove
            //
            btnRemove.Location = new System.Drawing.Point(412, 64);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 23);
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            //
            // btnQueue
            //
            btnQueue.Location = new System.Drawing.Point(412, 93);
            btnQueue.Name = "btnQueue";
            btnQueue.Size = new System.Drawing.Size(75, 23);
            btnQueue.Text = "Queue";
            btnQueue.UseVisualStyleBackColor = true;
            btnQueue.Click += btnQueue_Click;
            //
            // tabQueue
            //
            tabQueue.Controls.Add(listQueue);
            tabQueue.Controls.Add(btnBrew);
            tabQueue.Location = new System.Drawing.Point(4, 24);
            tabQueue.Name = "tabQueue";
            tabQueue.Padding = new System.Windows.Forms.Padding(3);
            tabQueue.Size = new System.Drawing.Size(576, 333);
            tabQueue.Text = "Queue";
            tabQueue.UseVisualStyleBackColor = true;
            //
            // listQueue
            //
            listQueue.FormattingEnabled = true;
            listQueue.ItemHeight = 15;
            listQueue.Location = new System.Drawing.Point(6, 6);
            listQueue.Name = "listQueue";
            listQueue.Size = new System.Drawing.Size(400, 319);
            //
            // btnBrew
            //
            btnBrew.Location = new System.Drawing.Point(412, 6);
            btnBrew.Name = "btnBrew";
            btnBrew.Size = new System.Drawing.Size(75, 23);
            btnBrew.Text = "Brew Next";
            btnBrew.UseVisualStyleBackColor = true;
            btnBrew.Click += btnBrew_Click;
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
            tabQueue.ResumeLayout(false);
            tabInventory.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
