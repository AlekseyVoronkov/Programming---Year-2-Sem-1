using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;

namespace NewtonMethod
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

        public void NewtonMethod()
        {
            bool isWorking = true;
            Function function = new Function("f(x) = " + tbFunc.Text);
            double epsilon = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));
            double currentX = Convert.ToDouble(tbB.Text.Replace(".", ","));
            double funcRes = SolveFunc(function, currentX.ToString());
            double nextX;
            double iterationCount = 0;
            var derivative = new Expression($"der({tbFunc.Text}, x, {currentX})");
            var secondDerivative = new Expression($"der(der({tbFunc.Text}, x, x), x, {currentX})");

            if (checkedListBox1.CheckedIndices.Contains(0))
            {
                if (SolveFunc(function, tbA.Text) * new Expression($"der(der({tbFunc.Text}, x, x), x, {tbA.Text.Replace(".", ",")})").calculate() > 0)
                {
                    currentX = Convert.ToDouble(tbA.Text.Replace(".", ","));
                    funcRes = SolveFunc(function, currentX.ToString());
                    derivative = new Expression($"der({tbFunc.Text}, x, {currentX})");
                }

                while (isWorking)
                {
                    nextX = currentX - funcRes / derivative.calculate();
                    funcRes = SolveFunc(function, nextX.ToString().Replace(",", "."));
                    derivative = new Expression($"der({tbFunc.Text}, x, {nextX.ToString().Replace(",", ".")})");

                    if (Math.Abs(nextX - currentX) < epsilon || Math.Abs(derivative.calculate()) < 1e-10)
                    {
                        break;
                    }

                    if (iterationCount == 20)
                    {
                        MessageBox.Show($"Превышенно максимальное чисчло итераций.\n");
                        isWorking = false;
                        break;
                    }
                    ++iterationCount;
                    currentX = nextX;
                }

                if (isWorking)
                {
                    rtbAnswers.AppendText($"Корень X: {Math.Round(currentX, Convert.ToInt32(tbAcc.Text))}\n");
                    MessageBox.Show($"Корень X: {Math.Round(currentX, Convert.ToInt32(tbAcc.Text))}");
                }
            }

            if (checkedListBox1.CheckedIndices.Contains(1))
            {
                if (SolveFunc(function, tbA.Text) * new Expression($"der(der({tbFunc.Text}, x, x), x, {tbA.Text.Replace(".", ",")})").calculate() > 0)
                {
                    currentX = Convert.ToDouble(tbA.Text.Replace(".", ","));
                    funcRes = SolveFunc(function, currentX.ToString());
                    derivative = new Expression($"der({tbFunc.Text}, x, {currentX})");
                    secondDerivative = new Expression($"der(der({tbFunc.Text}, x, x), x, {currentX})");
                }

                while (isWorking)
                {
                    nextX = currentX - derivative.calculate() / secondDerivative.calculate();
                    funcRes = SolveFunc(function, nextX.ToString().Replace(",", "."));
                    derivative = new Expression($"der({tbFunc.Text}, x, {nextX.ToString().Replace(",", ".")})");
                    secondDerivative = new Expression($"der(der({tbFunc.Text}, x, x), x, {nextX.ToString().Replace(",", ".")})");

                    if (Math.Abs(nextX - currentX) < epsilon || Math.Abs(derivative.calculate()) < 1e-10)
                    {
                        break;
                    }

                    if (iterationCount == 20)
                    {
                        MessageBox.Show($"Превышенно максимальное чисчло итераций.\n");
                        isWorking = false;
                        break;
                    }
                    ++iterationCount;
                    currentX = nextX;
                }

                if (isWorking)
                {
                    rtbAnswers.AppendText($"Точка минимума: {Math.Round(currentX, Convert.ToInt32(tbAcc.Text))}\n");
                    MessageBox.Show($"Точка минимума: {Math.Round(currentX, Convert.ToInt32(tbAcc.Text))}");
                }
            }

            if (checkedListBox1.CheckedIndices.Contains(2))
            {
                if (SolveFunc(function, tbA.Text) * new Expression($"der(der({tbFunc.Text}, x, x), x, {tbA.Text.Replace(".", ",")})").calculate() > 0)
                {
                    currentX = Convert.ToDouble(tbA.Text.Replace(".", ","));
                    funcRes = SolveFunc(function, currentX.ToString());
                    derivative = new Expression($"der({tbFunc.Text}, x, {currentX})");
                    secondDerivative = new Expression($"der(der({tbFunc.Text}, x, x), x, {currentX})");
                }

                while (isWorking)
                {
                    nextX = currentX - derivative.calculate() / secondDerivative.calculate();
                    funcRes = SolveFunc(function, nextX.ToString().Replace(",", "."));
                    derivative = new Expression($"der({tbFunc.Text}, x, {nextX.ToString().Replace(",", ".")})");
                    secondDerivative = new Expression($"der(der({tbFunc.Text}, x, x), x, {nextX.ToString().Replace(",", ".")})");

                    if (Math.Abs(nextX - currentX) < epsilon || Math.Abs(derivative.calculate()) < 1e-10)
                    {
                        break;
                    }

                    if (iterationCount == 20)
                    {
                        MessageBox.Show($"Превышенно максимальное чисчло итераций.\n");
                        isWorking = false;
                        break;
                    }
                    ++iterationCount;
                    currentX = nextX;
                }

                if (isWorking)
                {
                    rtbAnswers.AppendText($"Точка максимума: {Math.Round(currentX * -1, Convert.ToInt32(tbAcc.Text))}\n");
                    MessageBox.Show($"Точка максимума: {Math.Round(currentX * -1, Convert.ToInt32(tbAcc.Text))}");
                }
            }
        }
        public double SolveFunc(Function function, string x)
        {
            return new Expression($"f({x})", function).calculate();
        }

        private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewtonMethod();
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
