using System;
using System.Drawing;
using System.Windows.Forms;

namespace PotionApp
{
    public static class SimplePrompt
    {
        public static string? ShowDialog(string text, string caption, string defaultValue = "")
        {
            using var form = new Form();
            form.Text = caption;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ClientSize = new Size(400, 100);

            var lbl = new Label { AutoSize = true, Text = text, Location = new Point(9, 9) };
            var tb = new TextBox { Text = defaultValue, Location = new Point(12, 30), Width = 376 };
            var btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(313, 62) };
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Location = new Point(232, 62) };

            form.Controls.AddRange(new Control[] { lbl, tb, btnCancel, btnOk });
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? tb.Text : null;
        }
    }
}
