using System;
using System.Drawing;
using System.Windows.Forms;

namespace PotionApp
{
    public static class WaterContainerPrompt
    {
        public static WaterContainer? ShowDialog(string caption)
        {
            using var form = new Form();
            form.Text = caption;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ClientSize = new Size(400, 170);

            var lblName = new Label { AutoSize = true, Text = "Name:", Location = new Point(9, 9) };
            var txtName = new TextBox { Location = new Point(120, 6), Width = 250 };

            var lblCap = new Label { AutoSize = true, Text = "Capacity (mL):", Location = new Point(9, 45) };
            var txtCap = new TextBox { Location = new Point(120, 42), Width = 100 };

            var lblAmt = new Label { AutoSize = true, Text = "Current Amount:", Location = new Point(9, 81) };
            var txtAmt = new TextBox { Location = new Point(120, 78), Width = 100 };

            var btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(313, 129) };
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Location = new Point(232, 129) };

            form.Controls.AddRange(new Control[] { lblName, txtName, lblCap, txtCap, lblAmt, txtAmt, btnCancel, btnOk });
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            if (form.ShowDialog() != DialogResult.OK)
                return null;

            if (!int.TryParse(txtCap.Text.Trim(), out int cap) || cap <= 0)
            {
                MessageBox.Show("Invalid capacity", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (!int.TryParse(txtAmt.Text.Trim(), out int amt) || amt < 0)
            {
                MessageBox.Show("Invalid amount", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            amt = Math.Min(amt, cap);
            return new WaterContainer { Name = txtName.Text.Trim(), Capacity = cap, Amount = amt };
        }
    }
}
