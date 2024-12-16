using ClosedXML.Excel;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.ComponentModel;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing.Drawing2D;

namespace SLAY
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void tsmGenerateData_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int columnCount = dataGridView1.Columns.Count;
            int rowCount = dataGridView1.Rows.Count;

            if (rowCount > 0 && columnCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rand.Next(-10, 10);
                    }
                }
            }
            else
            {
                MessageBox.Show("Матрица пуста. Задайте её размер.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmFromExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet();
                            DataTable table = result.Tables[0];
                            LoadDataToDataGridView(table, dataGridView1, dataGridView2);
                        }
                    }
                }
            }
        }

        private void LoadDataToDataGridView(DataTable table, DataGridView dgv, DataGridView dgv2)
        {
            int index = 0;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv2.Columns.Add("1", "1");

            foreach (DataColumn column in table.Columns)
            {
                if (index < table.Columns.Count - 1)
                {
                    dgv.Columns.Add(column.ColumnName, $"A{index + 1}");
                    ++index;
                }
                else
                {
                    dgv.Columns.Add(column.ColumnName, "B");

                }
            }
            index = 0;

            foreach (DataRow row in table.Rows)
            {
                dgv.Rows.Add(row.ItemArray);
                dgv.Rows[index].HeaderCell.Value = $"{index + 1}";
                dgv2.Rows.Add();
                dgv2.Rows[index].HeaderCell.Value = $"x{index + 1}";
                ++index;
            }
        }

        private void tsmExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Matrix Data");
                        ExportDataGridViewToExcel(dataGridView1, worksheet, "A");
                        ExportDataGridViewToExcel(dataGridView2, worksheet, "X", dataGridView1.Rows.Count + 2);
                        workbook.SaveAs(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void ExportDataGridViewToExcel(DataGridView dgv, IXLWorksheet worksheet, string name, int startRow = 1)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cell(startRow, i + 1).Value = dgv.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    var cellValue = dgv.Rows[i].Cells[j].Value;
                    XLCellValue value = XLCellValue.FromObject(cellValue);
                    worksheet.Cell(startRow + i + 1, j + 1).Value = value;
                }
            }
        }

        private void tsmClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
        }

        private void tsmCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Убедитесь, что все числа матрицы заданы корректно.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clbMethods.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Выберите метод решения.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clbMethods.CheckedIndices.Contains(0)) // Gauss-Jordan
            {
                SolveUsingGaussJordan();
            }
            else if (clbMethods.CheckedIndices.Contains(1)) // Cramer
            {
                SolveUsingCramer();
            }
            else if (clbMethods.CheckedIndices.Contains(2)) // Gauss
            {
                SolveUsingGauss();
            }
        }

        private bool ValidateInput()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {
                    if (cell.Value == null || !double.TryParse(cell.Value.ToString(), out _))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private async void SolveUsingGaussJordan()
        {
            var matrix = GetMatrix();
            var bVector = GetBVector();
            int iterations = 0;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            await Task.Run(() =>
            {
                int matrixSize = matrix.GetLength(0);
                for (int matrixIndex = 0; matrixIndex < matrixSize; ++matrixIndex)
                {
                    double norm = matrix[matrixIndex, matrixIndex];
                    for (int normalisationIndex = 0; normalisationIndex < matrixSize; ++normalisationIndex)
                    {
                        matrix[matrixIndex, normalisationIndex] /= norm;
                    }
                    bVector[matrixIndex] /= norm;

                    for(int currentRowIndex = 0; currentRowIndex < matrixSize; ++currentRowIndex)
                    {
                        if (currentRowIndex != matrixIndex)
                        {
                            double coef = matrix[currentRowIndex, matrixIndex];
                            for (int columnIndex = 0; columnIndex < matrixSize; ++columnIndex)
                            {
                                matrix[currentRowIndex, columnIndex] -= coef * matrix[matrixIndex, columnIndex];
                            }
                            bVector[currentRowIndex] -= coef * bVector[matrixIndex];
                        }
                    }
                    ++iterations;
                }

                for (int i = 0; i < matrixSize; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = Math.Round(bVector[i], 9);
                }
            });

            stopwatch.Stop();
            MessageBox.Show($"Метод Гаусса-Жордана за {stopwatch.ElapsedMilliseconds} мс пройдя {iterations} итераций.");
        }

        private async void SolveUsingCramer()
        {
            var matrix = GetMatrix();
            var bVector = GetBVector();
            int iterations = 0;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            await Task.Run(() =>
            {
                double determinant = CalculateDeterminant(matrix);
                if (Math.Abs(determinant) < 1e-10)
                {
                    MessageBox.Show("The system has no solutions or has infinite solutions.");
                    return;
                }

                int matrixSize = matrix.GetLength(0);
                double[] solution = new double[matrixSize];

                for (int i = 0; i < matrixSize; ++i)
                {
                    double[,] tempMatrix = (double[,])matrix.Clone();
                    for (int j = 0; j < matrixSize; j++)
                    {
                        tempMatrix[j, i] = bVector[j];
                    }
                    solution[i] = CalculateDeterminant(tempMatrix) / determinant;
                    iterations++;
                }

                for (int i = 0; i < matrixSize; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = Math.Round(solution[i], 9);
                }
            });

            stopwatch.Stop();
            MessageBox.Show($"Метод крамера завершен за {stopwatch.ElapsedMilliseconds} мс, пройдя {iterations} итераций.");
        }

        private async void SolveUsingGauss()
        {
            var matrix = GetMatrix();
            var bVector = GetBVector();
            int iterations = 0;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            await Task.Run(() =>
            {
                int matrixSize = matrix.GetLength(0);
                double[] solution = new double[matrixSize];

                for (int currentRow = 0; currentRow < matrixSize; ++currentRow)
                {
                    int maxRowIndex = currentRow;
                    for (int row = currentRow + 1; row < matrixSize; ++row)
                    {
                        if (Math.Abs(matrix[row, currentRow]) > Math.Abs(matrix[maxRowIndex, currentRow]))
                        {
                            maxRowIndex = row;
                        }
                    }

                    if (maxRowIndex != currentRow)
                    {
                        double[] tempRow = new double[matrixSize];

                        for (int column = 0; column < matrixSize; ++column)
                        {
                            tempRow[column] = matrix[currentRow, column];
                            matrix[currentRow, column] = matrix[maxRowIndex, column];
                            matrix[maxRowIndex, column] = tempRow[column];
                        }

                        double tempVectorValue = bVector[currentRow];
                        bVector[currentRow] = bVector[maxRowIndex];
                        bVector[maxRowIndex] = tempVectorValue;
                    }

                    double factor = matrix[currentRow, currentRow];

                    for(int column = currentRow; column < matrixSize; ++column)
                    {
                        matrix[currentRow, column] /= factor;
                    }

                    bVector[currentRow] /= factor;

                    for (int row = currentRow + 1; row < matrixSize; ++row)
                    {
                        double coefficient = matrix[row, currentRow];

                        for(int column = currentRow; column < matrixSize; ++column)
                        {
                            matrix[row, column] -= coefficient * matrix[currentRow, column];
                        }

                        bVector[row] -= coefficient * bVector[currentRow];
                    }
                    iterations++;

                }

                for (int currentRow = matrixSize - 1; currentRow >= 0; --currentRow)
                {
                    solution[currentRow] = bVector[currentRow];

                    for (int row = currentRow - 1; row >= 0; --row)
                    {
                        bVector[row] -= matrix[row, currentRow] * solution[currentRow];
                    }
                }

                for (int row = 0; row < matrixSize; ++row)
                {
                    dataGridView2.Rows[row].Cells[0].Value = Math.Round(solution[row], 9);
                }
            });

            stopwatch.Stop();
            MessageBox.Show($"Метод Гаусса завершен за {stopwatch.ElapsedMilliseconds} мс пройдя {iterations} итераций.");
        }

        private void tsmMatrixSize_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Введите размер квадратной матрицы:", "Размер матрицы", "3");
            if (int.TryParse(input, out int size) && size >= 2 && size <= 50)
            {
                CreateMatrix(size);
            }
            else
            {
                MessageBox.Show("Размер матрицы должен быть от 2 до 50 .");
            }
        }

        private void CreateMatrix(int size)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();

            for (int i = 1; i <= size; i++)
            {
                dataGridView1.Columns.Add($"a{i}", $"a{i}");
            }
            dataGridView1.Columns.Add("b", "b");

            for (int i = 0; i < size; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            dataGridView2.Columns.Add("1", "1");

            for (int i = 0; i < size; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].HeaderCell.Value = $"x{i + 1}";
            }

            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();

            dataGridView2.RowHeadersWidth = 60;
            var column = dataGridView2.Columns[0];
            column.Width = 90;
        }

        private double[,] GetMatrix()
        {
            int rowCount = dataGridView1.Rows.Count;
            int columnCount = dataGridView1.Columns.Count - 1;
            double[,] matrix = new double[rowCount, columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        matrix[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
            }

            return matrix;
        }

        private double[] GetBVector()
        {
            int rowCount = dataGridView1.Rows.Count;
            double[] bVector = new double[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[rowCount].Value != null)
                {
                    bVector[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value);
                }
            }

            return bVector;
        }

        private double CalculateDeterminant(double[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);

            if (matrixSize == 1)
            {
                return matrix[0, 0];
            }
            else if (matrixSize == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double determinant = 0;
                for (int findDeterminantIndex = 0; findDeterminantIndex < matrixSize; ++findDeterminantIndex)
                {
                    double[,] tempMatrix = CreateTempMatrix(matrix, 0, findDeterminantIndex);
                    determinant += Math.Pow(-1, findDeterminantIndex) * matrix[0, findDeterminantIndex] * CalculateDeterminant(tempMatrix);
                }
                return determinant;
            }
        }


        private double[,] CreateTempMatrix(double[,] matrix, int row, int column)
        {
            int tempMatrixSize = matrix.GetLength(0);
            double[,] tempMatrix = new double[tempMatrixSize - 1, tempMatrixSize - 1];

            for (int rowTemp = 0; rowTemp < tempMatrixSize; ++rowTemp)
            {
                for (int columnTemp = 0; columnTemp < tempMatrixSize; ++columnTemp)
                {
                    if (rowTemp != row && columnTemp != column)
                    {
                        int newRow;
                        if (rowTemp > row)
                        {
                            newRow = rowTemp - 1;
                        }
                        else
                        {
                            newRow = rowTemp;
                        }
                        int newColumn;
                        if (columnTemp > column)
                        {
                            newColumn = columnTemp - 1;
                        }
                        else
                        {
                            newColumn = columnTemp;
                        }
                        tempMatrix[newRow, newColumn] = matrix[rowTemp, columnTemp];
                    }
                }
            }

            return tempMatrix;
        }
    }
}
