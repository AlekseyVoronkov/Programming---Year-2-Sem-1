using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            for (double counterI = Convert.ToDouble(tbA.Text) * 10; counterI < Convert.ToDouble(tbB.Text) * 10 + 1; ++counterI)
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

            plot1.Model = plotModel;
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
            int intervalCount = 1000;
            Function function = new Function("f(x) = " + tbFunc.Text);
            double upBorder = Convert.ToDouble(tbA.Text.Replace(".", ","));
            double lowBorder = Convert.ToDouble(tbB.Text.Replace(".", ","));

            double smallIntegralWidth = (upBorder - lowBorder) / intervalCount;

            for (int rectangleIndex = 0; rectangleIndex < intervalCount; ++rectangleIndex)
            {
                double tempX = lowBorder + rectangleIndex * smallIntegralWidth;
                double resolvedX = SolveFunc(function, tempX.ToString().Replace(",", "."));

                result += resolvedX * smallIntegralWidth;
            }
            return result;
        }

        private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtbAnswers.AppendText($"{rectangleMethod()}\n");
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