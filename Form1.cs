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
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using org.mariuszgromada.math.mxparser;
using MarkerType = OxyPlot.MarkerType;

namespace SLAY
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private PlotModel CreateGraph(double downLimitation, double upLimitation, string functionText)
        {
            double interval = Math.Abs(Convert.ToDouble(downLimitation)) + Math.Abs(Convert.ToDouble(upLimitation));
            List<DataPoint> Graphic = new List<DataPoint>();

            Function function = new Function("f(x) = " + functionText);

            var plotModel = new PlotModel { Title = "График функции f(x)" };

            var medianLine = new LineSeries
            {
                Title = "X",
                Color = OxyColor.FromRgb(0, 0, 0),
                StrokeThickness = 2
            };

            medianLine.Points.Add(new DataPoint(-interval, 0));
            medianLine.Points.Add(new DataPoint(interval, 0));

            var absicc = new LineSeries
            {
                Title = "Y",
                Color = OxyColor.FromRgb(0, 0, 0),
                StrokeThickness = 2,
            };

            absicc.Points.Add(new DataPoint(0, interval));
            absicc.Points.Add(new DataPoint(0, -interval));

            // Создаем серию точек графика
            var lineSeries = new LineSeries
            {
                Title = "f(x)",
                Color = OxyColor.FromRgb(255, 0, 0),
            };

            // why
            string ihatemxparser = "";
            for (double counterI = Convert.ToDouble(downLimitation) * 10; counterI < Convert.ToDouble(upLimitation) * 10 + 1; ++counterI)
            {
                ihatemxparser = (counterI / 10).ToString().Replace(",", ".");

                Expression e1 = new Expression($"f({ihatemxparser})", function);
                double y = e1.calculate();
                lineSeries.Points.Add(new DataPoint(Convert.ToDouble(ihatemxparser.Replace(".", ",")), y));
            }

            lineSeries.Points.AddRange(Graphic);

            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(medianLine);
            plotModel.Series.Add(absicc);

            return plotModel;
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
                            LoadDataToDataGridView(table, dataGridView1);
                        }
                    }
                }
            }
        }

        private void LoadDataToDataGridView(DataTable table, DataGridView dgv)
        {
            int index = 0;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.Rows.Clear();
            dgv.Columns.Clear();

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
        }

        private void tsmCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Убедитесь, что все числа матрицы заданы корректно.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (linear.Checked == false && quadro.Checked == false) 
            {
                MessageBox.Show("Выберите метод решения.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (linear.Checked == true)
            {

                var output = SolveMNK(GetXValue(), GetYValue(), true);
                ShowResult(output.Item1, output.Item2);
            } 
            else
            {
                var output = SolveMNK(GetXValue(), GetYValue(), false);
                ShowResult(output.Item1, output.Item2);
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

        public (double[], PlotModel plotModel) SolveMNK(double[] inputX, double[] inputY, bool IsLinear)
        {
            double[] result = new double[inputX.Length];
            PlotModel plotModel = new PlotModel { Title = "График" };
            if (IsLinear)
            {
                var output = LinearMNK(inputX, inputY);
                result = output.Item1;
                plotModel = CreateGraph(5, 5, output.Item2);
            }
            else
            {
                var output = NotLinearMNK(inputX, inputY);
                result = output.Item1;
                plotModel = CreateGraph(5, 5, output.Item2);
            }
            return (result, plotModel);
        }

        void ShowResult(double[] result, OxyPlot.PlotModel plotModel)
        {
            string resultString = "";
            if (result != null)
            {
                for (int outputIndex = 0; outputIndex < result.Length; ++outputIndex)
                {
                    if (outputIndex == 0)
                    {
                        resultString += "a" + " = " + Math.Round(result[outputIndex], 2).ToString() + "\n";
                    }
                    else if (outputIndex == 1)
                    {
                        resultString += "b" + " = " + Math.Round(result[outputIndex], 2).ToString() + "\n";
                    }
                    else if (outputIndex == 2)
                    {
                        resultString += "c" + " = " + Math.Round(result[outputIndex], 2).ToString() + "\n";
                    }

                }

            }
            var series = new LineSeries();
            series.MarkerType = MarkerType.Circle;
            series.Color = OxyColors.Blue;
            series.MarkerSize = 5;
            var points = new List<DataPoint>();
            for (int outputIndex = 0; outputIndex < GetXValue().Length; outputIndex++)
            {
                points.Add(new DataPoint(GetXValue()[outputIndex], GetYValue()[outputIndex]));
                points.Add(new DataPoint(double.NaN, double.NaN));
            }


            series.ItemsSource = points;

            plot1.Model = plotModel;
            plotModel.Series.Add(series);
            plot1.Model = plotModel;
            MessageBox.Show(resultString, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        double[] GetXValue()
        {
            double[] valuesOFX = new double[dataGridView1.Rows.Count - 1];

            for (int indexOfX = 0; indexOfX < dataGridView1.Rows.Count - 1; ++indexOfX)
            {
                valuesOFX[indexOfX] = Convert.ToDouble(dataGridView1.Rows[indexOfX].Cells[0].Value);
            }

            return valuesOFX;
        }

        double[] GetYValue()
        {
            double[] valuesOFY = new double[dataGridView1.Rows.Count - 1];

            for (int indexOfY = 0; indexOfY < dataGridView1.Rows.Count - 1; ++indexOfY)
            {
                valuesOFY[indexOfY] = Convert.ToDouble(dataGridView1.Rows[indexOfY].Cells[1].Value);
            }

            return valuesOFY;
        }
        private (double[], string) LinearMNK(double[] inputX, double[] inputY)
        {
            double[] result = new double[inputX.Length];
            double SummOfX = 0;
            double SummOfY = 0;
            double SummOfPowX = 0;
            double SummOfXAndY = 0;
            string expression;
            double[] PowX = new double[inputX.Length];
            double[] XAndY = new double[inputX.Length];
            foreach (double numberOfX in inputX)
            {
                SummOfX += numberOfX;
            }
            foreach (double numberOfY in inputY)
            {
                SummOfY += numberOfY;
            }
            for (int inputIndex = 0; inputIndex < inputX.Length; ++inputIndex)
            {
                PowX[inputIndex] = inputX[inputIndex] * inputX[inputIndex];
                SummOfPowX += PowX[inputIndex];
                XAndY[inputIndex] = inputX[inputIndex] * inputY[inputIndex];
                SummOfXAndY += XAndY[inputIndex];
            }
            double[,] matrix = new double[2, 2];
            matrix[0, 0] = SummOfPowX;
            matrix[0, 1] = SummOfX;
            matrix[1, 0] = SummOfX;
            matrix[1, 1] = inputX.Length;
            double[] vector = new double[3];
            vector[0] = SummOfXAndY;
            vector[1] = SummOfY;
            result = JordanoGaussMethod(matrix, vector);
            expression = result[0].ToString() + "*x +" + result[1].ToString();

            return (result, expression);
        }

        private (double[], string) NotLinearMNK(double[] inputX, double[] inputY)
        {
            double[] result = new double[inputX.Length];
            double SummOfX = 0;
            double SummOfY = 0;
            double SummOfPowX = 0;
            double SummOfThirdPowX = 0;
            double SummOfQuadroPowX = 0;
            double SummOfXAndY = 0;
            double SummOfPowXAndY = 0;
            double[] PowX = new double[inputX.Length];
            double[] ThirdPowX = new double[inputX.Length];
            double[] QuadroPowX = new double[inputX.Length];
            double[] XAndY = new double[inputX.Length];
            double[] PowXAndY = new double[inputX.Length];
            string expression;
            foreach (double numberOfX in inputX)
            {
                SummOfX += numberOfX;
            }
            foreach (double numberOfY in inputY)
            {
                SummOfY += numberOfY;
            }
            for (int inputIndex = 0; inputIndex < inputX.Length; ++inputIndex)
            {
                PowX[inputIndex] = inputX[inputIndex] * inputX[inputIndex];
                SummOfPowX += PowX[inputIndex];
                ThirdPowX[inputIndex] = inputX[inputIndex] * inputX[inputIndex] * inputX[inputIndex];
                SummOfThirdPowX += ThirdPowX[inputIndex];
                QuadroPowX[inputIndex] = inputX[inputIndex] * inputX[inputIndex] * inputX[inputIndex] * inputX[inputIndex];
                SummOfQuadroPowX += QuadroPowX[inputIndex];
                XAndY[inputIndex] = inputX[inputIndex] * inputY[inputIndex];
                SummOfXAndY += XAndY[inputIndex];
                PowXAndY[inputIndex] = inputX[inputIndex] * inputX[inputIndex] * inputY[inputIndex];
                SummOfPowXAndY += PowXAndY[inputIndex];
            }
            double[,] matrix = new double[3, 3];
            matrix[0, 0] = SummOfQuadroPowX;
            matrix[0, 1] = SummOfThirdPowX;
            matrix[0, 2] = SummOfPowX;
            matrix[1, 0] = SummOfThirdPowX;
            matrix[1, 1] = SummOfPowX;
            matrix[1, 2] = SummOfX;
            matrix[2, 0] = SummOfPowX;
            matrix[2, 1] = SummOfX;
            matrix[2, 2] = inputX.Length;
            double[] vector = new double[4];
            vector[0] = SummOfPowXAndY;
            vector[1] = SummOfXAndY;
            vector[2] = SummOfY;
            result = JordanoGaussMethod(matrix, vector);
            expression = result[0].ToString() + "*x^2 +" + result[1].ToString() + "*x +" + result[2].ToString();
            return (result, expression);
        }

        public double[] JordanoGaussMethod(double[,] matrix, double[] vector)
        {
            int matrixSize = matrix.GetLength(0);

            // Прямой ход
            for (int matrixIndex = 0; matrixIndex < matrixSize; ++matrixIndex)
            {
                // Нормализация строки (деление на главный элемент)
                double norm = matrix[matrixIndex, matrixIndex];
                for (int normalisationIndex = 0; normalisationIndex < matrixSize; ++normalisationIndex)
                {
                    matrix[matrixIndex, normalisationIndex] /= norm;
                }
                vector[matrixIndex] /= norm;

                // Вычитание строки из всех остальных строк
                for (int currentRowIndex = 0; currentRowIndex < matrixSize; ++currentRowIndex)
                {
                    if (currentRowIndex != matrixIndex)
                    {
                        double coef = matrix[currentRowIndex, matrixIndex];
                        for (int columnIndex = 0; columnIndex < matrixSize; ++columnIndex)
                        {
                            matrix[currentRowIndex, columnIndex] -= coef * matrix[matrixIndex, columnIndex];
                        }
                        vector[currentRowIndex] -= coef * vector[matrixIndex];
                    }
                }
            }

            // Обратный ход (по факту его тут нет, просто запись из вектора в решение)
            double[] solution = new double[matrixSize];
            for (int resultIndex = 0; resultIndex < matrixSize; ++resultIndex)
            {
                solution[resultIndex] = vector[resultIndex];
            }

            return solution;
        }



        private void tsmMatrixSize_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Enter the size of the square matrix:", "Matrix Size", "3");
            if (int.TryParse(input, out int size) && size <= 50)
            {
                CreateMatrix(size);
            }
            else
            {
                MessageBox.Show("Matrix size must be between 2 and 50.");
            }
        }


        private void CreateMatrix(int size)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add($"X", $"X");
            dataGridView1.Columns.Add($"Y", $"Y");


            for (int i = 0; i < size * 2; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            dataGridView1.RowHeadersWidth = 60;
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

        private void linear_CheckedChanged(object sender, EventArgs e)
        {
            if (linear.Checked == true)
            {
                quadro.Checked = false;
            }
        }

        private void quadro_CheckedChanged(object sender, EventArgs e)
        {
            if (quadro.Checked == true)
            {
                linear.Checked = false;
            }
        }
    }
}
