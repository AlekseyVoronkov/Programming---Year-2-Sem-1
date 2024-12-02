using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;

namespace DefiniteIntegralCalculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<DataPoint> Graphic = new List<DataPoint>();
        public void GetFunction(string functionText)
        {
            double interval = Math.Abs(Convert.ToDouble(tbA.Text)) + Math.Abs(Convert.ToDouble(tbB.Text));
            Graphic.Clear();

            Function function = new Function("f(x) = " + functionText);

            var plotModel = new PlotModel { Title = "Graph of f(x)" };

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

            var lineSeries = new LineSeries
            {
                Title = "f(x)",
                Color = OxyColor.FromRgb(255, 0, 0),
            };

            string ihatemxparser = "";
            for (double counterI = Convert.ToDouble(tbA.Text) * interval; counterI < Convert.ToDouble(tbB.Text) * interval + 1; counterI += 0.5)
            {
                ihatemxparser = (counterI / interval).ToString().Replace(",", ".");

                Expression e1 = new Expression($"f({ihatemxparser})", function);
                double y = e1.calculate();
                lineSeries.Points.Add(new DataPoint(Convert.ToDouble(ihatemxparser.Replace(".", ",")), y));
            }

            lineSeries.Points.AddRange(Graphic);

            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(medianLine);
            plotModel.Series.Add(absicc);

            plot1.Model = plotModel;
        }

        private void LogCalculationData(string calculationMethod, double result)
        {
            try
            {
                double epsilon = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));
                result = Math.Round(result, (int)Math.Floor(-Math.Log10(epsilon)));
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Epsilon value");
                return; // Exit if the epsilon value is invalid
            }

            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("CalculationMethod", "Calculation Method");
                dataGridView1.Columns.Add("Result", "Result");
            }

            DataGridViewButtonColumn visualizationButton = new DataGridViewButtonColumn
            {
                Name = "Visualization",
                Text = "Visualize",
                UseColumnTextForButtonValue = true
            };

            if (!dataGridView1.Columns.Contains(visualizationButton.Name))
            {
                dataGridView1.Columns.Insert(2, visualizationButton);
            }

            if (!string.IsNullOrEmpty(calculationMethod) && result != 0)
            {
                dataGridView1.Rows.Add(calculationMethod, result);
            }
        }

        public double SolveFunc(Function function, string x)
        {
            return new Expression($"f({x})", function).calculate();
        }

        private void rectangleMethod(bool isVisualize)
        {
            double result = 0;
            int intervalCount = Convert.ToInt32(Math.Round(Convert.ToDouble(tbInteralCount.Text), 1));
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;

            if (!isVisualize)
            {
                for (int rectangleIndex = 0; rectangleIndex < intervalCount; ++rectangleIndex)
                {
                    double tempX = lowBorder + rectangleIndex * smallIntegralWidth;
                    double resolvedX = SolveFunc(function, tempX.ToString().Replace(",", "."));

                    result += resolvedX * smallIntegralWidth;
                }
                LogCalculationData("Rectangle Method", result);
            }

            else
            {
                // Visualization of rectangles
                for (int rectangleIndex = 0; rectangleIndex < intervalCount; ++rectangleIndex)
                {
                    double tempX = lowBorder + rectangleIndex * smallIntegralWidth;
                    double resolvedX = SolveFunc(function, tempX.ToString().Replace(",", "."));
                    double nextX = lowBorder + (rectangleIndex + 1) * smallIntegralWidth;

                    var rectangleSeries = new RectangleBarSeries
                    {
                        Title = "Rectangles",
                        FillColor = OxyColor.FromArgb(100, 0, 255, 0),
                    };

                    rectangleSeries.Items.Add(new RectangleBarItem(tempX, 0, nextX, resolvedX));
                    plot1.Model.Series.Add(rectangleSeries);
                }
            }
        }

        private void trapezoidMethod(bool isVisualize)
        {
            double result = 0;
            int intervalCount = Convert.ToInt32(Math.Round(Convert.ToDouble(tbInteralCount.Text), 1));
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;

            if (!isVisualize)
            {
                for (int trapezoidIndex = 0; trapezoidIndex < intervalCount; ++trapezoidIndex)
                {
                    double tempX1 = lowBorder + trapezoidIndex * smallIntegralWidth;
                    double tempX2 = lowBorder + (trapezoidIndex + 1) * smallIntegralWidth;

                    double resolvedX1 = SolveFunc(function, tempX1.ToString().Replace(",", "."));
                    double resolvedX2 = SolveFunc(function, tempX2.ToString().Replace(",", "."));

                    result += (resolvedX1 + resolvedX2) * smallIntegralWidth / 2;
                }
                LogCalculationData("Trapezoid Method", result);
            }

            else
            {
                // Visualization of trapezoids
                for (int trapezoidIndex = 0; trapezoidIndex < intervalCount; ++trapezoidIndex)
                {
                    double tempX1 = lowBorder + trapezoidIndex * smallIntegralWidth;
                    double tempX2 = lowBorder + (trapezoidIndex + 1) * smallIntegralWidth;

                    double resolvedX1 = SolveFunc(function, tempX1.ToString().Replace(",", "."));
                    double resolvedX2 = SolveFunc(function, tempX2.ToString().Replace(",", "."));

                    var trapezoidSeries = new LineSeries
                    {
                        Title = "Trapezoids",
                        Color = OxyColor.FromArgb(100, 255, 165, 0),
                    };

                    trapezoidSeries.Points.Add(new DataPoint(tempX1, resolvedX1));
                    trapezoidSeries.Points.Add(new DataPoint(tempX2, resolvedX2));
                    trapezoidSeries.Points.Add(new DataPoint(tempX2, 0));
                    trapezoidSeries.Points.Add(new DataPoint(tempX1, 0));
                    trapezoidSeries.Points.Add(new DataPoint(tempX1, resolvedX1));

                    plot1.Model.Series.Add(trapezoidSeries);
                }
            }
        }

        private void simpsonMethod(bool isVisualize)
        {
            double result = 0;
            int intervalCount = Convert.ToInt32(Math.Round(Convert.ToDouble(tbInteralCount.Text), 1));
            if (intervalCount % 2 != 0) intervalCount++; // Ensure even intervals for Simpson's rule
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;
            result = SolveFunc(function, upBorder.ToString().Replace(",", ".")) + SolveFunc(function, lowBorder.ToString().Replace(",", "."));

            if (!isVisualize)
            {
                for (int simpsonIndex = 1; simpsonIndex < intervalCount; simpsonIndex += 2)
                {
                    result += 4 * SolveFunc(function, (lowBorder + simpsonIndex * smallIntegralWidth).ToString().Replace(",", "."));
                }

                for (int simpsonIndex = 2; simpsonIndex < intervalCount - 1; simpsonIndex += 2)
                {
                    result += 2 * SolveFunc(function, (lowBorder + simpsonIndex * smallIntegralWidth).ToString().Replace(",", "."));
                }

                LogCalculationData("Simpson's Method", result * smallIntegralWidth / 3);
            }
            else
            {
                // Improved visualization of Simpson's method
                for (int simpsonIndex = 0; simpsonIndex < intervalCount; simpsonIndex += 2)
                {
                    double tempX1 = lowBorder + simpsonIndex * smallIntegralWidth;
                    double tempX2 = lowBorder + (simpsonIndex + 1) * smallIntegralWidth;

                    double resolvedX1 = SolveFunc(function, tempX1.ToString().Replace(",", "."));
                    double resolvedX2 = SolveFunc(function, tempX2.ToString().Replace(",", "."));

                    var simpsonSeries = new LineSeries
                    {
                        Title = "Simpson's Method",
                        Color = OxyColor.FromArgb(100, 0, 0, 255),
                    };

                    simpsonSeries.Points.Add(new DataPoint(tempX1, resolvedX1));
                    simpsonSeries.Points.Add(new DataPoint(tempX2, resolvedX2));
                    simpsonSeries.Points.Add(new DataPoint(tempX2, 0));
                    simpsonSeries.Points.Add(new DataPoint(tempX1, 0));
                    simpsonSeries.Points.Add(new DataPoint(tempX1, resolvedX1));

                    plot1.Model.Series.Add(simpsonSeries);
                }
            }
        }

        private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkedListBox1.CheckedIndices.Contains(0))
                {
                    GetFunction(tbFunc.Text);
                    rectangleMethod(false);
                }

                if (checkedListBox1.CheckedIndices.Contains(1))
                {
                    GetFunction(tbFunc.Text);
                    trapezoidMethod(false);
                }

                if (checkedListBox1.CheckedIndices.Contains(2))
                {
                    GetFunction(tbFunc.Text);
                    simpsonMethod(false);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        private void посторитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GetFunction(tbFunc.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Visualization"].Index && e.RowIndex >= 0)
            {
                try
                {
                    var calculationMethodCell = dataGridView1.Rows[e.RowIndex].Cells["CalculationMethod"].Value;
                    if (calculationMethodCell != null)
                    {
                        string calculationMethod = calculationMethodCell.ToString();
                        VisualizeMethod(calculationMethod);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void VisualizeMethod(string method)
        {
            // Clear previous series
            plot1.Model.Series.Clear();

            // Call the appropriate method based on user selection
            if (method == "Rectangle Method")
            {
                GetFunction(tbFunc.Text);
                rectangleMethod(true);
            }
            else if (method == "Trapezoid Method")
            {
                GetFunction(tbFunc.Text);
                trapezoidMethod(true);
            }
            else if (method == "Simpson's Method")
            {
                GetFunction(tbFunc.Text);
                simpsonMethod(true);
            }

            // Refresh the plot
            plot1.Model.InvalidatePlot(true);
        }

        private void очиститьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to clear the data?", "Confirm Clear", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
        }
    }
}
