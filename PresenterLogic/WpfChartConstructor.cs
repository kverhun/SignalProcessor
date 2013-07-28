using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ViewLogic;
using SignalProcessor.ModelLogic;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Primitives;


namespace SignalProcessor.PresenterLogic
{
    partial class ChartConstructor
    {
        public Chart WpfChartConstruct(SignalData data, string name)
        {
            Chart chart = new Chart();
            LineSeries series = new LineSeries();
            KeyValuePair<double, double>[] points = new KeyValuePair<double, double>[data.T.Length];

            for (int i = 0; i < data.T.Length; ++i)
                points[i] = new KeyValuePair<double, double>(data.T[i], data.X[i]);
            series.ItemsSource = points;


            return chart;
        }

        public Chart WpfChartConstruct(Signal signal)
        {
            Chart chart = new Chart();
            LineSeries series = new LineSeries();
            KeyValuePair<double, double>[] points = new KeyValuePair<double, double>[signal.T.Length];

            for (int i = 0; i < signal.T.Length; ++i)
                points[i] = new KeyValuePair<double, double>(signal.T[i], signal.X[i]);
            series.ItemsSource = points;

            return chart;
        }


    }
}