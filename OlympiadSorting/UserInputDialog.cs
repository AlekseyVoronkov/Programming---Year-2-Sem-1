using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlympiadSorting
{
    internal class UserInputDialog
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox tbUserInput = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            tbUserInput.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            tbUserInput.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            tbUserInput.Anchor = tbUserInput.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, tbUserInput, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = tbUserInput.Text;
            return dialogResult;
        }


        public static void RandomNumberInputBox(string title, int exampleCount, int exampleMin, int exampleMax, RichTextBox richTextBox)
        {
            Form form = new Form();
            Label labelCount = new Label() { Text = "Count:", AutoSize = true };
            Label labelMin = new Label() { Text = "Minimum Value:", AutoSize = true };
            Label labelMax = new Label() { Text = "Maximum Value:", AutoSize = true };
            Label labelResult = new Label() { Text = "Generated Numbers:", AutoSize = true, Top = 110 };

            TextBox tbCount = new TextBox() { Text = exampleCount.ToString() };
            TextBox tbMin = new TextBox() { Text = exampleMin.ToString() };
            TextBox tbMax = new TextBox() { Text = exampleMax.ToString() };

            Button buttonGenerate = new Button() { Text = "Generate" };
            Button buttonCancel = new Button() { Text = "Cancel", DialogResult = DialogResult.Cancel };

            buttonGenerate.Click += (sender, e) =>
            {
                try
                {
                    if (int.TryParse(tbCount.Text, out int newCount) && int.TryParse(tbMin.Text, out int newMinValue) && int.TryParse(tbMax.Text, out int newMaxValue) && newMinValue < newMaxValue)
                    {
                        Random random = new Random();
                        var numbers = Enumerable.Range(0, newCount).Select(_ => random.Next(newMinValue, newMaxValue)).ToArray();
                        labelResult.Text = "Generated Numbers: " + string.Join(", ", numbers);
                        richTextBox.AppendText(string.Join(", ", numbers) + "\n");
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numbers and ensure Minimum is less than Maximum.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Negative count? Really?.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Set bounds and add controls to the form
            labelCount.SetBounds(9, 20, 100, 13);
            tbCount.SetBounds(120, 20, 100, 20);
            labelMin.SetBounds(9, 50, 100, 13);
            tbMin.SetBounds(120, 50, 100, 20);
            labelMax.SetBounds(9, 80, 100, 13);
            tbMax.SetBounds(120, 80, 100, 20);
            buttonGenerate.SetBounds(120, 110, 75, 23);
            buttonCancel.SetBounds(200, 110, 75, 23);
            labelResult.SetBounds(9, 140, 300, 40);

            form.ClientSize = new Size(300, 200);
            form.Controls.AddRange(new Control[] { labelCount, tbCount, labelMin, tbMin, labelMax, tbMax, buttonGenerate, buttonCancel, labelResult });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonGenerate;
            form.CancelButton = buttonCancel;

            form.ShowDialog();
        }



    }
}
