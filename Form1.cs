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
        CalculateExtremumBruteForce(true);
      }

      if (checkedListBox1.CheckedIndices.Contains(1)) // max
      {
        CalculateExtremumBruteForce(false);
      }
    }

    private void CalculateExtremumBruteForce(bool isMin)
    {
      double epsilon = Convert.ToDouble(tbEpsilon.Text.Replace(".", ","));
      double leftLimitation = Convert.ToDouble(tbA.Text.Replace(",", "."));
      double rightLimitation = Convert.ToDouble(tbB.Text.Replace(",", "."));
      double step = (rightLimitation - leftLimitation) / 300; // 300 steps
      double extremumValue = isMin ? double.MaxValue : double.MinValue;
      double extremumPoint = leftLimitation;

      for (double x = leftLimitation; x <= rightLimitation; x += step)
      {
        double currentValue = SolveFunc(new Function("f(x) = " + tbFunc.Text), x.ToString().Replace(",", "."));
        if ((isMin && currentValue < extremumValue) || (!isMin && currentValue > extremumValue))
        {
          extremumValue = currentValue;
          extremumPoint = x;
        }
      }

      rtbAnswers.AppendText($"{(isMin ? "Minimum" : "Maximum")} = {Math.Round(extremumValue, Convert.ToInt32(tbAcc.Text))} at x = {Math.Round(extremumPoint, Convert.ToInt32(tbAcc.Text))}\n");
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

    private void очиститьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rtbAnswers.Clear();
    }
  }
}
