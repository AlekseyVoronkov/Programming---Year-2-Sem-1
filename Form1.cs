using System;
using System.Windows.Forms;
using System.Drawing;
using OxyPlot;
using OxyPlot.Series;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;

namespace GoldenRatio
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

      AddMedianAndAbscissaLines(interval, plotModel);
      AddFunctionPoints(function, plotModel);

      plot1.Model = plotModel;
    }

    private void AddMedianAndAbscissaLines(double interval, PlotModel plotModel)
    {
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

      plotModel.Series.Add(medianLine);
      plotModel.Series.Add(absicc);
    }

    private void AddFunctionPoints(Function function, PlotModel plotModel)
    {
      var lineSeries = new LineSeries
      {
        Title = "f(x)",
        Color = OxyColor.FromRgb(255, 0, 0),
      };

      for (double counterI = Convert.ToDouble(tbA.Text) * 10; counterI < Convert.ToDouble(tbB.Text) * 10 + 1; ++counterI)
      {
        string ihatemxparser = (counterI / 10).ToString().Replace(",", ".");
        double y = new Expression($"f({ihatemxparser})", function).calculate();
        lineSeries.Points.Add(new DataPoint(Convert.ToDouble(ihatemxparser.Replace(".", ",")), y));
      }

      lineSeries.Points.AddRange(Graphic);
      plotModel.Series.Add(lineSeries);
    }

    public void GoldenRatioMethod()
    {
      if (checkedListBox1.CheckedIndices.Contains(0)) // find min
      {
        CalculateExtremum(true);
      }

      if (checkedListBox1.CheckedIndices.Contains(1)) // max
      {
        CalculateExtremum(false);
      }
    }

    private void CalculateExtremum(bool isMin)
    {
      double epsilon = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));
      double leftLimitation = Convert.ToDouble(tbA.Text.Replace(",", "."));
      double rightLimitation = Convert.ToDouble(tbB.Text.Replace(",", "."));
      Function func = new Function("f(x) = " + (isMin ? "-" : "") + tbFunc.Text);
      double goldenRatio = (Math.Sqrt(5) - 1) / 2;

      double x1 = rightLimitation - goldenRatio * (rightLimitation - leftLimitation);
      double x2 = leftLimitation + goldenRatio * (rightLimitation - leftLimitation);
      double resultOfX1 = SolveFunc(func, x1.ToString());
      double resultOfX2 = SolveFunc(func, x2.ToString());

      while (Math.Abs(rightLimitation - leftLimitation) > epsilon)
      {
        if ((isMin && resultOfX1 < resultOfX2) || (!isMin && resultOfX1 > resultOfX2))
        {
          rightLimitation = x2;
          x2 = x1;
          x1 = rightLimitation - goldenRatio * (rightLimitation - leftLimitation);
        }
        else
        {
          leftLimitation = x1;
          x1 = x2;
          x2 = leftLimitation + goldenRatio * (rightLimitation - leftLimitation);
        }
        resultOfX1 = SolveFunc(func, x1.ToString());
        resultOfX2 = SolveFunc(func, x2.ToString());
      }

      double result = (leftLimitation + rightLimitation) / 2;
      double resultValue = Math.Round(SolveFunc(func, result.ToString().Replace(",", ".")), Convert.ToInt32(tbAcc.Text));
      result = Math.Round(result, Convert.ToInt32(tbAcc.Text));

      rtbAnswers.AppendText($"{(isMin ? "min" : "max")} = {result}\n\r");
    }

    public double SolveFunc(Function function, string x)
    {
      return new Expression($"f({x})", function).calculate();
    }

    private void расчетыToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        GoldenRatioMethod();
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
