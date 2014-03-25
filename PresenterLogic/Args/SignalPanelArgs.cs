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
            Chart chart = ChartConstructor.Construct(signal);

            charts.Add(chart);
        }

        public SignalPanelArgs(Signal signal, List<int> lvlShowed)
        {
            charts = new List<Chart>();
            Name = signal.Name;

            Chart chart = ChartConstructor.Construct(signal);
            charts.Add(chart);

            wpfCharts = new List<System.Windows.Controls.DataVisualization.Charting.Chart>();
            System.Windows.Controls.DataVisualization.Charting.Chart wchart = ChartConstructor.WpfConstruct(signal);
            wpfCharts.Add(wchart);

            foreach (int lvl in lvlShowed)
            {
                Chart chartWave = ChartConstructor.Construct(signal.GetWavelet(lvl), "Wavelet transfort level " + lvl.ToString());
                charts.Add(chartWave);
            }

        }

        public SignalPanelArgs(Signal signal, List<int> lvlShowed, bool PDMShowed)
        {
            charts = new List<Chart>();
            Name = signal.Name;

            Chart chart = ChartConstructor.Construct(signal);
            charts.Add(chart);

            foreach (int lvl in lvlShowed)
            {
                Chart chartWave = ChartConstructor.Construct(signal.GetWavelet(lvl), "Wavelet transfort level " + lvl.ToString());
                charts.Add(chartWave);
            }

            if (PDMShowed)
                charts.Add(ChartConstructor.Construct(signal.CurrentPDMData));
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

        public System.Windows.Controls.DataVisualization.Charting.Chart GetWChart(int index)
        {
            if (wpfCharts.Count <= index)
                return null;
            else
                return wpfCharts[index];
        }

        public int ChartCount
        {
            get
            {
                return this.charts.Count;
            }
        }

        private List<Chart> charts;
        private List<System.Windows.Controls.DataVisualization.Charting.Chart> wpfCharts;

    }
}
