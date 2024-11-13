using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlympiadSorting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string exmapleValue = "1, 9, 8, 3, 6, 9, 12, -3";
        int exampleCount = 10;
        int exampleMin = -10;
        int exampleMax = 10;
        private void btnUserData_Click(object sender, EventArgs e)
        {
            if(UserInputDialog.InputBox("Ввод данных", "Введите числа", ref exmapleValue) == DialogResult.OK)
            {
                richTextBox1.AppendText($"{exmapleValue}\n");
            }
        }

        private void btnRandomData_Click(object sender, EventArgs e)
        {
            UserInputDialog.RandomNumberInputBox("Генерация чисел", exampleCount, exampleMin, exampleMax, richTextBox1);
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

        private int[] ParseNumbers()
        {
            string input = richTextBox1.Text;
            // Use regular expressions to find all integers in the input
            var matches = System.Text.RegularExpressions.Regex.Matches(input, @"-?\d+");
            int[] numbers = new int[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                numbers[i] = int.Parse(matches[i].Value);
            }

            
            return numbers;
        }

        private void LogSortingData(string sortMethod, int iterations, long elapsedTime)
        {
            // Ensure the DataGridView has the necessary columns
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("SortMethod", "Sorting Method");
                dataGridView1.Columns.Add("Iterations", "Number of Iterations");
                dataGridView1.Columns.Add("ElapsedTime", "Elapsed Time (ms)");
            }

            // Add the sorting data to the DataGridView
            dataGridView1.Rows.Add(sortMethod, iterations, elapsedTime);
        }

        private void сортироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sortsListBox.CheckedIndices.Contains(0)) // Bubble Sort
            {
                string test = "";
                int[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                for (int write = 0; write < arr.Length; write++)
                {
                    for (int sort = 0; sort < arr.Length - 1; sort++)
                    {
                        iterations++;
                        if (arr[sort] > arr[sort + 1])
                        {
                            int temp = arr[sort];
                            arr[sort] = arr[sort + 1];
                            arr[sort + 1] = temp;
                        }
                    }
                }

                watch.Stop();
                
                for (int index = 0; index < arr.Length; index++)
                {
                    test += arr[index].ToString();
                    test += " ";
                }

                MessageBox.Show($"{test}");
                LogSortingData("Bubble Sort", iterations, watch.ElapsedMilliseconds);
            }

            if (sortsListBox.CheckedIndices.Contains(1)) // Insertion Sort
            {
                int[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                for (int i = 1; i < arr.Length; i++)
                {
                    int key = arr[i];
                    int j = i - 1;

                    while (j >= 0 && arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        iterations++;
                    }
                    arr[j + 1] = key;
                }

                watch.Stop();
                LogSortingData("Insertion Sort", iterations, watch.ElapsedMilliseconds);
            }

            if (sortsListBox.CheckedIndices.Contains(2)) // Shaker Sort
            {
                int[] arr = ParseNumbers();
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
                        if (arr[i] > arr[i + 1])
                        {
                            int temp = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = temp;
                            swapped = true;
                        }
                    }
                    end--;

                    if (!swapped) break;

                    swapped = false;

                    for (int i = end; i > start; i--)
                    {
                        iterations++;
                        if (arr[i] < arr[i - 1])
                        {
                            int temp = arr[i];
                            arr[i] = arr[i - 1];
                            arr[i - 1] = temp;
                            swapped = true;
                        }
                    }
                    start++;
                }

                watch.Stop();
                LogSortingData("Shaker Sort", iterations, watch.ElapsedMilliseconds);
            }

            if (sortsListBox.CheckedIndices.Contains(3)) // Quick Sort
            {
                int[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                void QuickSort(int[] array, int left, int right)
                {
                    if (left < right)
                    {
                        int pivot = Partition(array, left, right);
                        QuickSort(array, left, pivot - 1);
                        QuickSort(array, pivot + 1, right);
                    }
                }

                int Partition(int[] array, int left, int right)
                {
                    int pivot = array[right];
                    int i = left - 1;

                    for (int j = left; j < right; j++)
                    {
                        iterations++;
                        if (array[j] <= pivot)
                        {
                            i++;
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                    int temp1 = array[i + 1];
                    array[i + 1] = array[right];
                    array[right] = temp1;
                    return i + 1;
                }

                QuickSort(arr, 0, arr.Length - 1);
                watch.Stop();
                LogSortingData("Quick Sort", iterations, watch.ElapsedMilliseconds);
            }

            if (sortsListBox.CheckedIndices.Contains(4)) // Bogo Sort
            {
                int[] arr = ParseNumbers();
                int iterations = 0;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                Random rand = new Random();
                while (!IsSorted(arr))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        iterations++;
                        int j = rand.Next(arr.Length);
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;

                        if (iterations > 100000000)
                        {
                            break;
                            MessageBox.Show($"Bogo sort took too long :(");
                        }
                    }
                }

                watch.Stop();
                LogSortingData("Bogo Sort", iterations, watch.ElapsedMilliseconds);
            }
        }

        private bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                    return false;
            }
            return true;
        }
    }
}
