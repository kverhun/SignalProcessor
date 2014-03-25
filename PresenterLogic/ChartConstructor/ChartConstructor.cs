using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ViewLogic;
using SignalProcessor.ModelLogic;


using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;



namespace SignalProcessor.PresenterLogic
{
    partial class ChartConstructor
    {
        public static Chart Construct(SignalData data)
        {
            Chart chart = new Chart();
            ChartArea area = new ChartArea();
            Series series = new Series();
            series.Points.DataBindXY(data.T, data.X);
            series.ChartType = SeriesChartType.Line;
            
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.Title = "Time";
            chart.ChartAreas[0].AxisY.Title = "Value";
            return chart;
        }

        public static Chart Construct(SignalData data, string name)
        {
            Chart chart = new Chart();
            ChartArea area = new ChartArea();
            chart.Titles.Add(name);
            Series series = new Series();
            series.Points.DataBindXY(data.T, data.X);
            series.ChartType = SeriesChartType.Line;
            //chart.Text = name;
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.Title = "Time";
            chart.ChartAreas[0].AxisY.Title = "Value";
            return chart;
        }

        public static Chart Construct(Signal signal)
        {
            Chart chart = new Chart();
            chart.Titles.Add(signal.Name);
            ChartArea area = new ChartArea();
            Series series = new Series(signal.Name);
            series.Points.DataBindXY(signal.T, signal.X);
            series.ChartType = SeriesChartType.Line;
            series.LegendText = signal.Name;
            chart.Text = signal.Name;
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.Title = "Time";
            chart.ChartAreas[0].AxisY.Title = "Value";
            return chart;
        }

        public static Chart Construct(PDMData data)
        {
            double[] T = new double[data.TArray.Length];
            for (int i = 0; i < data.TArray.Length; ++i)
                T[i] = (double)data.TArray[i];

            Chart chart = Construct(new Signal(T, data.XArray));
            chart.ChartAreas[0].AxisX.Title = "Period";
            chart.ChartAreas[0].AxisY.Title = "PDM Value";
            chart.Series[0].BorderWidth = 2;
            chart.Titles.Clear();
            chart.Titles.Add("PDM result");
            //chart.Titles[0].TextStyle = TextStyle.Default;
            

            return chart;
        }

        

    }
}
