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
            return chart;
        }

        public static Chart Construct(SignalData data, string name)
        {
            Chart chart = new Chart();
            ChartArea area = new ChartArea();
            Series series = new Series();
            series.Points.DataBindXY(data.T, data.X);
            series.ChartType = SeriesChartType.Line;
            chart.Text = name;
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            return chart;
        }

        public static Chart Construct(Signal signal)
        {
            Chart chart = new Chart();
            ChartArea area = new ChartArea();
            Series series = new Series(signal.Name);
            series.Points.DataBindXY(signal.T, signal.X);
            series.ChartType = SeriesChartType.Line;
            series.LegendText = signal.Name;
            chart.Text = signal.Name;
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            return chart;
        }


        

    }
}
