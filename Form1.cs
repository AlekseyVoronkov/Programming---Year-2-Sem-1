using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;

namespace DichotomyMethod
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


    public void DichotomyMethod()
    {
      Function func = new Function("f(x) = " + tbFunc.Text);

      double fa = SolveFunc(func, tbA.Text);
      double fb = SolveFunc(func, tbB.Text);

      double a = Convert.ToDouble(tbA.Text);
      double b = Convert.ToDouble(tbB.Text);
      double eps = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));

     if (fa * fb > 0)
      {
        MessageBox.Show(" f (a) * f (b) must have 0 in the interval [a,b]\nRigth answer is not guaranteed.");
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

      double answer = (a + b) / 2;
      rtbAnswers.AppendText($"Ответ: {Math.Round(answer, Convert.ToInt32(tbAcc.Text.Replace(".", ".")))}\n");
      return;
    }

    public double SolveFunc(Function function, string x)
    {
      return new Expression($"f({x})", function).calculate();
    }

    private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        DichotomyMethod();
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
