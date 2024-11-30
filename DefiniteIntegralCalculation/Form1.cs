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
        private bool isGraphicBuilt = false;

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
            isGraphicBuilt = true;
        }

        public void DefiniteIntegralCalculation()
        {
        }
        public double SolveFunc(Function function, string x)
        {
            return new Expression($"f({x})", function).calculate();
        }

        private double rectangleMethod()
        {
            double result = 0;
            int intervalCount = Convert.ToInt32(Math.Round(Convert.ToDouble(tbInteralCount.Text), 1));
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;

            for (int rectangleIndex = 0; rectangleIndex < intervalCount; ++rectangleIndex)
            {
                double tempX = lowBorder + rectangleIndex * smallIntegralWidth;
                double resolvedX = SolveFunc(function, tempX.ToString().Replace(",", "."));

                result += resolvedX * smallIntegralWidth;
            }

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

            return result;
        }

        private double trapezoidMethod()
        {
            double result = 0;
            int intervalCount = Convert.ToInt32(Math.Round(Convert.ToDouble(tbInteralCount.Text), 1));
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;

            for (int trapezoidIndex = 0; trapezoidIndex < intervalCount; ++trapezoidIndex)
            {
                double tempX1 = lowBorder + trapezoidIndex * smallIntegralWidth;
                double tempX2 = lowBorder + (trapezoidIndex + 1) * smallIntegralWidth;

                double resolvedX1 = SolveFunc(function, tempX1.ToString().Replace(",", "."));
                double resolvedX2 = SolveFunc(function, tempX2.ToString().Replace(",", "."));

                result += (resolvedX1 + resolvedX2) * smallIntegralWidth / 2;
            }

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

            return result;
        }

        private double simpsonMethod()
        {
            double result = 0;
            int intervalCount = Convert.ToInt32(Math.Round(Convert.ToDouble(tbInteralCount.Text), 1));
            if (intervalCount % 2 != 0) intervalCount++; // Simpson's rule requires an even number of intervals
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;

            for (int simpsonIndex = 0; simpsonIndex < intervalCount; simpsonIndex += 2)
            {
                double tempX0 = lowBorder + simpsonIndex * smallIntegralWidth;
                double tempX1 = lowBorder + (simpsonIndex + 1) * smallIntegralWidth;
                double tempX2 = lowBorder + (simpsonIndex + 2) * smallIntegralWidth;

                double resolvedX0 = SolveFunc(function, tempX0.ToString().Replace(",", "."));
                double resolvedX1 = SolveFunc(function, tempX1.ToString().Replace(",", "."));
                double resolvedX2 = SolveFunc(function, tempX2.ToString().Replace(",", "."));

                result += (resolvedX0 + 4 * resolvedX1 + resolvedX2) * smallIntegralWidth / 6;
            }

            // Visualization of Simpson's method
            for (int simpsonIndex = 0; simpsonIndex < intervalCount; simpsonIndex += 2)
            {
                double tempX0 = lowBorder + simpsonIndex * smallIntegralWidth;
                double tempX1 = lowBorder + (simpsonIndex + 1) * smallIntegralWidth;
                double tempX2 = lowBorder + (simpsonIndex + 2) * smallIntegralWidth;

                double resolvedX0 = SolveFunc(function, tempX0.ToString().Replace(",", "."));
                double resolvedX1 = SolveFunc(function, tempX1.ToString().Replace(",", "."));
                double resolvedX2 = SolveFunc(function, tempX2.ToString().Replace(",", "."));

                var simpsonSeries = new LineSeries
                {
                    Title = "Simpson's Method",
                    Color = OxyColor.FromArgb(100, 0, 0, 255),
                };

                simpsonSeries.Points.Add(new DataPoint(tempX0, resolvedX0));
                simpsonSeries.Points.Add(new DataPoint(tempX1, resolvedX1));
                simpsonSeries.Points.Add(new DataPoint(tempX2, resolvedX2));

                plot1.Model.Series.Add(simpsonSeries);
            }

            return result;
        }

        private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int roundTo = tbEpsilon.Text.Length;
            try
            {
                if (checkedListBox1.CheckedIndices.Contains(0))
                {
                    GetFunction(tbFunc.Text);
                    rtbAnswers.AppendText($"{Math.Round(rectangleMethod(), roundTo)}\n");
                }

                if (checkedListBox1.CheckedIndices.Contains(1))
                {
                    GetFunction(tbFunc.Text);
                    rtbAnswers.AppendText($"{Math.Round(trapezoidMethod(), roundTo)}\n");
                }

                if (checkedListBox1.CheckedIndices.Contains(2))
                {
                    GetFunction(tbFunc.Text);
                    rtbAnswers.AppendText($"{Math.Round(simpsonMethod(), roundTo)}\n");
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
    }
}