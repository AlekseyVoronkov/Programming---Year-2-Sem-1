using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;

namespace GoldenRatioMethod
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
                LineStyle = LineStyle.Dot
            };

            lineSeries.Points.AddRange(Graphic);

            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(medianLine);
            plotModel.Series.Add(absicc);

            plot1.Model = plotModel;
        }

        public void GoldenRatioMethod()
        {
            int precision = Convert.ToInt16(tbEpsilon.Text.Replace(".", ","));
            double epsilon = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));
            double result = double.NaN;

            double leftLimitation = Convert.ToDouble(tbA.Text.Replace(",", "."));
            double rightLimitation = Convert.ToDouble(tbB.Text.Replace(",", "."));
            Function func = new Function("f(x) = " + "-" + tbFunc.Text);

            double firstValue = SolveFunc(func, leftLimitation.ToString());
            double secondValue = SolveFunc(func, rightLimitation.ToString());

            double goldenRatio = (Math.Sqrt(5) - 1) / 2;

            double x1 = rightLimitation - goldenRatio * (rightLimitation - leftLimitation);
            double x2 = leftLimitation + goldenRatio * (rightLimitation - leftLimitation);

            double resultOfX1 = SolveFunc(func, x1.ToString());
            double resultOfX2 = SolveFunc(func, x2.ToString());

            while (Math.Abs(rightLimitation - leftLimitation) > epsilon)
            {
                if (resultOfX1 < resultOfX2)
                {
                    rightLimitation = x2;
                    x2 = x1;
                    x1 = rightLimitation - goldenRatio * (rightLimitation - leftLimitation);
                    resultOfX1 = SolveFunc(func, x1.ToString());
                    resultOfX2 = SolveFunc(func, x2.ToString());
                }
                else
                {
                    leftLimitation = x1;
                    x1 = x2;
                    x2 = leftLimitation + goldenRatio * (rightLimitation - leftLimitation);
                    resultOfX1 = SolveFunc(func, x1.ToString());
                    resultOfX2 = SolveFunc(func, x2.ToString());
                }
            }

            result = (leftLimitation + rightLimitation) / 2;

            double resultValue = SolveFunc(func, result.ToString().Replace(",", "."));
            resultValue = Math.Round(resultValue, precision);
            result = Math.Round(result, precision);

            rtbAnswers.AppendText($"x = {result} f(x) = {resultValue}\n\r");
            MessageBox.Show($"x = {result}\nf(x) = {resultValue}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public double SolveFunc(Function function, string x)
        {
            return new Expression($"f({x})", function).calculate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GetFunction(tbFunc.Text);
                GoldenRatioMethod();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }
    }
}
