using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

namespace OlympiadSorting
{
    public partial class Form1 : Form
    {
        private BufferedGraphics buffered;
        public Form1()
        {
            InitializeComponent();
        }

        string exmapleValue = "1.5, 9.2, 8.3, 3.1, 6.4, 9.0, 12.7, -3.5";
        int exampleCount = 30;
        double exampleMin = 0;
        double exampleMax = 10.0;
        private void btnUserData_Click(object sender, EventArgs e)
        {
            if (UserInputDialog.InputBox("Input Data", "Enter numbers", ref exmapleValue) == DialogResult.OK)
            {
                richTextBox1.AppendText($"{exmapleValue}\n");
            }
        }

        private void btnRandomData_Click(object sender, EventArgs e)
        {
            UserInputDialog.RandomNumberInputBox("Generate Numbers", exampleCount, exampleMin, exampleMax, richTextBox1);
        }

        private void btnFromExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files (*.xls; *.xlsx)|*.xls;*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={openFileDialog.FileName};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();
                            DataTable sheets = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = sheets.Rows[0]["TABLE_NAME"].ToString(); // Select the first sheet for simplicity
                            OleDbDataAdapter adapter = new OleDbDataAdapter($"SELECT * FROM [{sheetName}]", connection);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    if (double.TryParse(item.ToString(), out double number))
                                    {
                                        richTextBox1.AppendText(number.ToString() + ", ");
                                    }
                                }
                            }
                            richTextBox1.AppendText("\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        static void Swap(double[] array, int i, int j)
        {
            double temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private double[] ParseNumbers()
        {
            try
            {
                string input = richTextBox1.Text;
                var matches = System.Text.RegularExpressions.Regex.Matches(input, @"-?\d+(\.\d+)?");
                double[] numbers = new double[matches.Count];

                for (int i = 0; i < matches.Count; i++)
                {
                    numbers[i] = double.Parse(matches[i].Value);
                }

                return numbers;
            }
            catch (Exception e)
            {
                MessageBox.Show("The array numbers are either too large or too small.");
                return new double[5] { 1.0, 2.0, 3.0, 4.0, 5.0 };
            }
        }

        private void LogSortingData(string sortMethod, int iterations, long elapsedTime, double[] sortedArray)
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("SortMethod", "Sorting Method");
                dataGridView1.Columns.Add("Iterations", "Number of Iterations");
                dataGridView1.Columns.Add("ElapsedTime", "Elapsed Time (ms)");
                dataGridView1.Columns.Add("SortedArray", "Sorted Array");
            }

            DataGridViewButtonColumn visualizationButton = new DataGridViewButtonColumn();
            visualizationButton.Name = "Visualization";
            visualizationButton.Text = "Visualize";
            visualizationButton.UseColumnTextForButtonValue = true;

            if (!dataGridView1.Columns.Contains(visualizationButton.Name))
            {
                dataGridView1.Columns.Insert(4, visualizationButton);
            }

            string sortedArrayString = string.Join(", ", sortedArray);
            dataGridView1.Rows.Add(sortMethod, iterations, elapsedTime, sortedArrayString);
        }

        private void сортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool descending = sortOrderCheckBox.Checked; // Assuming there's a checkbox for sorting order
            if (sortsListBox.CheckedIndices.Contains(0)) // Bubble Sort
            {
                double[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                for (int write = 0; write < arr.Length - 1; write++)
                {
                    if (write == 0)
                    {
                        if (IsSorted(arr, descending))
                        {
                            iterations = 1;
                            break;
                        }
                    }

                    bool isSorted = true;

                    for (int sort = 0; sort < arr.Length - 1 - write; sort++)
                    {
                        iterations++;
                        if ((descending && arr[sort] < arr[sort + 1]) || (!descending && arr[sort] > arr[sort + 1]))
                        {
                            Swap(arr, sort, sort + 1);
                            isSorted = false;
                        }
                    }

                    if (isSorted) break;
                }

                watch.Stop();
                LogSortingData("Bubble Sort", iterations, watch.ElapsedMilliseconds, arr);
            }

            if (sortsListBox.CheckedIndices.Contains(1)) // Insertion Sort
            {
                double[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                for (int i = 1; i < arr.Length; i++)
                {
                    if (i == 1)
                    {
                        if (IsSorted(arr, descending))
                        {
                            iterations = 1;
                            break;
                        }
                    }
                    double key = arr[i];
                    int j = i - 1;

                    while (j >= 0 && ((descending && arr[j] < key) || (!descending && arr[j] > key)))
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        iterations++;
                    }
                    arr[j + 1] = key;
                    iterations++; // Count the final placement of the key
                }

                watch.Stop();
                LogSortingData("Insertion Sort", iterations, watch.ElapsedMilliseconds, arr);
            }

            if (sortsListBox.CheckedIndices.Contains(2)) // Shaker Sort
            {
                double[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                bool swapped = true;
                int start = 0;
                int end = arr.Length - 1;

                while (swapped)
                {
                    swapped = false;

                    for (int i = start; i < end; i++)
                    {
                        iterations++;
                        if ((descending && arr[i] < arr[i + 1]) || (!descending && arr[i] > arr[i + 1]))
                        {
                            Swap(arr, i, i + 1);
                            swapped = true;
                        }
                    }
                    end--;

                    if (!swapped)
                    {
                        iterations++; // Increment as there was at least one pass
                        break;
                    }

                    swapped = false;

                    for (int i = end; i > start; i--)
                    {
                        iterations++;
                        if ((descending && arr[i] > arr[i - 1]) || (!descending && arr[i] < arr[i - 1]))
                        {
                            Swap(arr, i, i - 1);
                            swapped = true;
                        }
                    }
                    start++;
                }

                watch.Stop();
                LogSortingData("Shaker Sort", iterations, watch.ElapsedMilliseconds, arr);
            }

            if (sortsListBox.CheckedIndices.Contains(3)) // Quick Sort
            {
                double[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                void QuickSort(double[] array, int left, int right)
                {
                    if (left < right)
                    {
                        int pivot = Partition(array, left, right);
                        QuickSort(array, left, pivot - 1);
                        QuickSort(array, pivot + 1, right);
                    }
                }

                int Partition(double[] array, int left, int right)
                {
                    double pivot = array[right];
                    int i = left - 1;

                    for (int j = left; j < right; j++)
                    {
                        iterations++;
                        if ((descending && array[j] >= pivot) || (!descending && array[j] <= pivot))
                        {
                            i++;
                            Swap(array, i, j);
                        }
                    }
                    Swap(array, i + 1, right);
                    return i + 1;
                }
                if (IsSorted(arr, descending))
                {
                    iterations = 1;
                    LogSortingData("Quick Sort", iterations, 0, arr);
                }
                else
                {
                    QuickSort(arr, 0, arr.Length - 1);
                    watch.Stop();
                    LogSortingData("Quick Sort", iterations, watch.ElapsedMilliseconds, arr);
                }
            }

            if (sortsListBox.CheckedIndices.Contains(4)) // Bogo Sort
            {
                double[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Random rand = new Random();
                while (!IsSorted(arr, descending))
                {
                    if (iterations < 100000000)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            iterations++;
                            int j = rand.Next(arr.Length);
                            Swap(arr, i, j);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bogo sort took too long :(");
                        break;
                    }
                }

                watch.Stop();
                LogSortingData("Bogo Sort", iterations, watch.ElapsedMilliseconds, arr);
            }
        }

        private bool IsSorted(double[] array, bool descending)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if ((descending && array[i - 1] < array[i]) || (!descending && array[i - 1] > array[i]))
                    return false;
            }
            return true;
        }

        private void ClearResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to clear the data?", "Confirm Clear", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Visualization"].Index)
            {
                try
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["SortMethod"].Value.ToString() != null)
                    {
                        string sortMethod = dataGridView1.Rows[e.RowIndex].Cells["SortMethod"].Value.ToString();
                        UserInputDialog.SortingVisualization("Sorting Visualization", sortMethod, ParseNumbers(), sortOrderCheckBox.Checked);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("The array numbers are either too large or too small.");
                }
            }
        }
    }
}
