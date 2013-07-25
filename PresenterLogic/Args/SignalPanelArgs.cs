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
    public class SignalPanelArgs
    {
        public SignalPanelArgs(Signal signal)
        {
            charts = new List<Chart>();
            Name = signal.Name;
            
            /// temporary -- only 1 chart is added
            /// 
            this.ChartCount = 1;

            Chart chart = new Chart();
            ChartArea area = new ChartArea();
            Series series = new Series(signal.Name);
            series.Points.DataBindXY(signal.T, signal.X);
            series.ChartType = SeriesChartType.Line;
            series.LegendText = signal.Name;
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            charts.Add(chart);
        }

        public string Name
        {
            get;
            private set;
        }

        public Chart GetChart(int index)
        {
            if (charts.Count <= index)
                return null;
            else
                return charts[index];
        }

        public int ChartCount;

        private List<Chart> charts;


    }
}
