using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using OxyPlot.WindowsForms;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CoordinateDescent
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
            double interval = Math.Abs(-5) + Math.Abs(5);
            Graphic.Clear();

            Function function = new Function("f(x) = " + functionText.Replace("y", "x"));

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
            for (double counterI = Convert.ToDouble(-5) * 10; counterI < Convert.ToDouble(5) * 10 + 1; ++counterI)
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

        public void CoordinateDescent()
        {
            int minMax = 0;
            double epsilon = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));
            string function = tbFunc.Text;
            double startX = Convert.ToDouble(tbStartx.Text.Replace(".", ","));
            double startY = Convert.ToDouble(tbStarty.Text.Replace(".", ","));
            double step = Convert.ToDouble(tbStep.Text.Replace(".", ","));
            int iterations = Convert.ToInt32(tbIterations.Text.Replace(".", ","));

            if (checkedListBox1.CheckedIndices.Contains(0) && !checkedListBox1.CheckedItems.Contains(1))
            {
                minMax = 0;
                var answser = OptimizeVariable(function, startX, startY, step, iterations, minMax);
                var calculatedFunction =
                Math.Round(new Expression($"{function.Replace("x", answser.Item1.Last().ToString()).Replace("y", answser.Item2.Last().ToString()).Replace(",", ".")}").calculate(), (int)Math.Floor(-Math.Log10(epsilon)));
                rtbAnswers.AppendText($"Min: x = {Math.Round(answser.Item1.Last<double>(), (int)Math.Floor(-Math.Log10(epsilon)))}" +
                    $" y = {Math.Round(answser.Item2.Last<double>(), (int)Math.Floor(-Math.Log10(epsilon)))} function = {calculatedFunction}\n");
            }

            if (checkedListBox1.CheckedIndices.Contains(1) && !checkedListBox1.CheckedItems.Contains(0))
            {
                minMax = 1;
                var answser = OptimizeVariable(function, startX, startY, step, iterations, minMax);
                var calculatedFunction =
                Math.Round(new Expression($"{function.Replace("x", answser.Item1.Last().ToString()).Replace("y", answser.Item2.Last().ToString()).Replace(",", ".")}").calculate(), (int)Math.Floor(-Math.Log10(epsilon)));
                rtbAnswers.AppendText($"Max: x = {Math.Round(answser.Item1.Last<double>(), (int)Math.Floor(-Math.Log10(epsilon)))}" +
                    $" y = {Math.Round(answser.Item2.Last<double>(), (int)Math.Floor(-Math.Log10(epsilon)))} function = {calculatedFunction}\n");
            }

            if (checkedListBox1.CheckedIndices.Contains(0) && checkedListBox1.CheckedItems.Contains(1))
            {
                minMax = 2;

            }
        }

        private (List<double>, List<double>) OptimizeVariable(string function, double startX, double startY, double stepSize, int iterations, int minMax)
        {
            double nextX = startX;
            double nextY = startY;
            List<double> allX = new List<double> { startX };
            List<double> allY = new List<double> { startY };

            if (minMax == 0)
            {
                return OptimizeForMin(function, startX, startY, nextX, nextY, allX, allY, stepSize, iterations);
            }

            if (minMax == 1)
            {
                return OptimizeForMax(function, startX, startY, nextX, nextY, allX, allY, stepSize, iterations);
            }

            // Handling case when minMax is neither 0 nor 1
            var forMin = OptimizeForMin(function, startX, startY, nextX, nextY, allX, allY, stepSize, iterations);
            var forMax = OptimizeForMax(function, startX, startY, nextX, nextY, allX, allY, stepSize, iterations);

            return (forMin.Item1.Concat(forMax.Item1).ToList(), forMax.Item2);
        }
        private (List<double>, List<double>) OptimizeForMin(string function, double startX, double startY, double nextX, double nextY, List<double> allX,
            List<double> allY, double stepSize, int iterations)
        {
            int i = 0;
            int j = 0;

            while (i < iterations)
            {
                nextX += stepSize;
                allX.Add(nextX);


                if (new Expression($"{function.Replace("x", allX[i + 1].ToString()).Replace("y", startY.ToString()).Replace(",", ".")}").calculate()
                    > new Expression($"{function.Replace("x", allX[i].ToString()).Replace("y", startY.ToString()).Replace(",", ".")}").calculate())
                {
                    break;
                }
                ++i;
            }

            while (j < iterations)
            {
                nextY += stepSize;
                allY.Add(nextY);

                if (new Expression($"{function.Replace("x", allX.Last<double>().ToString()).Replace("y", allY[j + 1].ToString()).Replace(",", ".")}").calculate()
                    > new Expression($"{function.Replace("x", allX.Last<double>().ToString()).Replace("y", allY[j].ToString()).Replace(",", ".")}").calculate())
                {
                    break;
                }

                ++j;
            }

            return (allX, allY);
        }

        private (List<double>, List<double>) OptimizeForMax(string function, double startX, double startY, double nextX, double nextY, List<double> allX,
    List<double> allY, double stepSize, int iterations)
        {
            int i = 0;
            int j = 0;

            while (i < iterations)
            {
                nextX += stepSize;
                allX.Add(nextX);


                if (new Expression($"{function.Replace("x", allX[i + 1].ToString()).Replace("y", startY.ToString()).Replace(",", ".")}").calculate()
                    < new Expression($"{function.Replace("x", allX[i].ToString()).Replace("y", startY.ToString()).Replace(",", ".")}").calculate())
                {
                    break;
                }
                ++i;
            }

            while (j < iterations)
            {
                nextY += stepSize;
                allY.Add(nextY);

                if (new Expression($"{function.Replace("x", allX.Last<double>().ToString()).Replace("y", allY[j + 1].ToString()).Replace(",", ".")}").calculate()
                    < new Expression($"{function.Replace("x", allX.Last<double>().ToString()).Replace("y", allY[j].ToString()).Replace(",", ".")}").calculate())
                {
                    break;
                }

                ++j;
            }

            return (allX, allY);
        }
        private double EvaluateFunction(Function function, double point)
        {
            return new Expression($"f({point})", function).calculate();
        }

        private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoordinateDescent();
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

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbAnswers.Clear();
        }
    }
}
