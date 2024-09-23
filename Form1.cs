using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;

namespace DichotomyMethod
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<DataPoint> Graphic = new List<DataPoint>();

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                GetFunction(txtFunction.Text);
                DichotomyMethod();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        public void GetFunction(string functionText)
        {
            Graphic.Clear();

            Function function = new Function("f(x) = " + functionText);

            for (int counterI = Convert.ToInt32(txtStart.Text); counterI < Convert.ToInt32(txtEnd.Text); ++counterI)
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

            medianLine.Points.Add(new DataPoint(Convert.ToInt32(txtStart.Text), 0));
            medianLine.Points.Add(new DataPoint(Convert.ToInt32(txtEnd.Text), 0));

            var absicc = new LineSeries
            {
                Title = "Y",
                Color = OxyColor.FromRgb(0, 0, 0), // Красный цвет
                StrokeThickness = 2,
            };

            absicc.Points.Add(new DataPoint(0, Convert.ToInt32(txtStart.Text)));
            absicc.Points.Add(new DataPoint(0, Convert.ToInt32(txtEnd.Text)));

            // Создаем серию точек графика
            var lineSeries = new LineSeries
            {
                Title = "f(x)",
                Color = OxyColor.FromRgb(255, 0, 0), // Синий цвет линии
                LineStyle = LineStyle.Dot
            };

            // Добавляем все точки в серию
            lineSeries.Points.AddRange(Graphic);

            // Добавляем серию точек к модели графика
            plotModel.Series.Add(lineSeries);
            plotModel.Series.Add(medianLine);
            plotModel.Series.Add(absicc);

            // Отображаем график
            plot1.Model = plotModel;
        }

        public void DichotomyMethod()
        {
            Function func = new Function("f(x) = " + txtFunction.Text);

            double fa = SolveFunc(func, txtA.Text);
            double fb = SolveFunc(func, txtB.Text);

            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            double eps = Convert.ToDouble(txtE.Text);

            if (fa * fb > 0)
            {
                MessageBox.Show("The function must have opposite signs at the endpoints of the interval.");
            }

            while (b - a > eps)
            {
                double c = (a + b) / 2;
                double fc = SolveFunc(func, c.ToString().Replace(",", "."));

                if (Math.Abs(fc) == 0)
                {
                    MessageBox.Show($"Ответ: {c}");
                    return;
                }
                else if (fa * fc < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                    fa = fc;
                }
            }
            rtbAnswers.AppendText($"Ответ: {(a + b) / 2}\r\n");
            MessageBox.Show($"Ответ: {(a + b) / 2}");
            return;
        }

        public double SolveFunc(Function function, string x)
        {
            return new Expression($"f({x})", function).calculate();
        }

    }
}
