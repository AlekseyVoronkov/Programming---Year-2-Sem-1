using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

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
            Graphic.Clear();

            Function function = new Function("f(x) = " + functionText);

            for (int counterI = Convert.ToInt32(tbA.Text); counterI < Convert.ToInt32(tbB.Text); ++counterI)
            {
                Expression e1 = new Expression($"f({counterI})", function);
                Graphic.Add(new DataPoint(counterI, e1.calculate()));
            }

            var plotModel = new PlotModel { Title = "График функции f(x)" };

            var medianLine = new LineSeries
            {
                Title = "X",
                Color = OxyColor.FromRgb(0, 0, 0),
                StrokeThickness = 2
            };

            medianLine.Points.Add(new DataPoint(Convert.ToInt32(tbA.Text), 0));
            medianLine.Points.Add(new DataPoint(Convert.ToInt32(tbB.Text), 0));

            var absicc = new LineSeries
            {
                Title = "Y",
                Color = OxyColor.FromRgb(0, 0, 0),
                StrokeThickness = 2,
            };

            absicc.Points.Add(new DataPoint(0, Convert.ToInt32(tbA.Text)));
            absicc.Points.Add(new DataPoint(0, Convert.ToInt32(tbB.Text)));

            // Создаем серию точек графика
            var lineSeries = new LineSeries
            {
                Title = "f(x)",
                Color = OxyColor.FromRgb(255, 0, 0),
            };

            for (double counterI = -10; counterI <= 5; ++counterI)
            {
                double y = SolveFunc(function, counterI.ToString());
                lineSeries.Points.Add(new DataPoint(counterI, y));
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

            if(SolveFunc(function, tbA.Text) * new Expression($"der(der({tbFunc.Text}, x, x), x, {tbA.Text.Replace(".", ",")})").calculate() > 0)
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
                    MessageBox.Show($"В данном интервале [{tbA.Text}; {tbB.Text}] нет корней, Также возможен случай, что x=0.\n");
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
        public double SolveFunc(Function function, string x)
        {
            return new Expression($"f({x})", function).calculate();
        }

        private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFunction(tbFunc.Text);
            NewtonMethod();
        }
    }
}
