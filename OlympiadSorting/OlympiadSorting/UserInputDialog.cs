using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        public static void RandomNumberInputBox(string title, int exampleCount, double exampleMin, double exampleMax, RichTextBox richTextBox)
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

        public static void SortingVisualization(string title, string sortName, double[] array, bool descending)
        {
            Form form = new Form()
            {
                Text = title,
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            PictureBox pictureBox = new PictureBox()
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.AutoSize,
                BackColor = Color.White
            };
            pictureBox.SetBounds(20, 20, 500, 500);

            Button buttonStart = new Button()
            {
                Text = "Start",
                Dock = DockStyle.Bottom,
                Top = 500,
                Width = 100,
                Height = 80,
                Font = new Font("Arial", 20)
            };
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.ForeColor = Color.White;
            buttonStart.BackColor = Color.DarkBlue;
            buttonStart.Padding = new Padding(10);
            form.Controls.Add(pictureBox);
            form.Controls.Add(buttonStart);

            buttonStart.Click += (sender, e) =>
            {
                try
                {
                    switch (sortName)
                    {
                        case "Bubble Sort":
                            VisualizeBubbleSort(array, pictureBox, descending);
                            break;
                        case "Insertion Sort":
                            VisualizeInsertionSort(array, pictureBox, descending);
                            break;
                        case "Shaker Sort":
                            VisualizeShakerSort(array, pictureBox, descending);
                            break;
                        case "Quick Sort":
                            VisualizeQuickSort(array, pictureBox, descending);
                            break;
                        case "Bogo Sort":
                            VisualizeBogoSort(array, pictureBox, descending);
                            break;
                    }
                }
                catch (Exception)
                {

                }
            };

            form.Show();
        }

        private static async void VisualizeBubbleSort(double[] array, PictureBox pictureBox, bool descending)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);

            for (int i = 0; i < array.Length - 1; i++)
            {
                bool isSorted = true;

                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    DrawArray(g, array, j); // Pass the pivot index
                    pictureBox.Image = bitmap;
                    await Task.Delay(50);
                    if ((descending && array[j] < array[j + 1]) || (!descending && array[j] > array[j + 1]))
                    {
                        Swap(array, j, j + 1);
                        isSorted = false;
                    }
                }

                if (isSorted) break;
            }
        }

        private static void DrawArray(Graphics g, double[] array, int pivotIndex)
        {
            g.Clear(Color.White);
            double max = array.Max();
            double min = array.Min();
            double numberToHigh = 500 / Math.Abs(max);
            double range = max - min;
            double scale = 500 / range;

            for (int i = 0; i < array.Length; i++)
            {
                int rectangleWidth = 20;
                int rectangleHeight = (int)((array[i] - min) * scale);
                int rectangleX = i * 25 + rectangleWidth;
                int rectangleY = 500 - rectangleHeight;

                if (array[i] < 0)
                {
                    rectangleY = 500 - rectangleHeight;
                }

                g.FillRectangle(Brushes.Blue, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                if (i == pivotIndex)
                {
                    g.DrawRectangle(new Pen(Color.Red), rectangleX, rectangleY, rectangleWidth, rectangleHeight);
                }
            }
        }

        static void Swap(double[] array, int i, int j)
        {
            double temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static async void VisualizeInsertionSort(double[] array, PictureBox pictureBox, bool descending)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);

            for (int i = 1; i < array.Length; i++)
            {
                double key = array[i];
                int j = i - 1;

                while (j >= 0 && ((descending && array[j] < key) || (!descending && array[j] > key)))
                {
                    array[j + 1] = array[j];
                    j--;
                    DrawArray(g, array, j + 1); // Pass the pivot index
                    pictureBox.Image = bitmap;
                    await Task.Delay(50);
                }
                array[j + 1] = key;
            }
        }

        private static async void VisualizeShakerSort(double[] array, PictureBox pictureBox, bool descending)
        {
            int start = 0;
            int end = array.Length - 1;
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            bool swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = start; i < end; i++)
                {
                    if ((descending && array[i] < array[i + 1]) || (!descending && array[i] > array[i + 1]))
                    {
                        Swap(array, i, i + 1);
                        swapped = true;
                    }
                    DrawArray(g, array, i); // Pass the pivot index
                    pictureBox.Image = bitmap;
                    await Task.Delay(50);
                }
                end--;

                if (!swapped) break;

                swapped = false;

                for (int i = end; i > start; i--)
                {
                    if ((descending && array[i] > array[i - 1]) || (!descending && array[i] < array[i - 1]))
                    {
                        Swap(array, i, i - 1);
                        swapped = true;
                    }
                    DrawArray(g, array, i); // Pass the pivot index
                    pictureBox.Image = bitmap;
                    await Task.Delay(50);
                }
                start++;
            }
        }

        private static async void VisualizeQuickSort(double[] array, PictureBox pictureBox, bool descending)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            await QuickSort(array, 0, array.Length - 1, g, pictureBox, descending);
            DrawArray(g, array, -1); // No pivot after sorting
            pictureBox.Image = bitmap;
        }

        private static async Task QuickSort(double[] array, int left, int right, Graphics g, PictureBox pictureBox, bool descending)
        {
            if (left < right)
            {
                int pivot = await Partition(array, left, right, g, pictureBox, descending);
                await QuickSort(array, left, pivot - 1, g, pictureBox, descending);
                await QuickSort(array, pivot + 1, right, g, pictureBox, descending);
                DrawArray(g, array, pivot); // Draw the pivot after partitioning
                pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                g = Graphics.FromImage(pictureBox.Image);
                g.DrawRectangle(new Pen(Color.Red), pivot * 20, 0, 20, 500);
                await Task.Delay(100);
                g.Dispose();
            }
        }

        private static async Task<int> Partition(double[] array, int left, int right, Graphics g, PictureBox pictureBox, bool descending)
        {
            double pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if ((descending && array[j] >= pivot) || (!descending && array[j] <= pivot))
                {
                    i++;
                    Swap(array, i, j);
                    DrawArray(g, array, i); // Pass the pivot index
                    pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                    g = Graphics.FromImage(pictureBox.Image);
                    g.DrawRectangle(new Pen(Color.Green), i * 20, 0, 20, 500);
                    await Task.Delay(50);
                }
            }
            Swap(array, i + 1, right);
            DrawArray(g, array, i + 1); // Pass the pivot index
            g.Dispose();
            return i + 1;
        }

        private static async void VisualizeBogoSort(double[] array, PictureBox pictureBox, bool descending)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            int iterations = 0;
            Random rand = new Random();
            while (!IsSorted(array, descending))
            {
                if (iterations < 1000)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        iterations++;
                        int j = rand.Next(array.Length);
                        Swap(array, i, j);
                    }
                    DrawArray(g, array, -1); // No pivot during Bogo sort
                    pictureBox.Image = bitmap;
                    await Task.Delay(150);
                }
                else
                {
                    MessageBox.Show("Bogo sort took too long :)");
                    break;
                }
            }
        }

        private static bool IsSorted(double[] array, bool descending)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if ((descending && array[i - 1] < array[i]) || (!descending && array[i - 1] > array[i]))
                    return false;
            }
            return true;
        }
    }
}
