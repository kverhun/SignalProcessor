using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SignalProcessor.PresenterLogic;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace SignalProcessor.ViewLogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {



        public void SignalLayout(SignalPresenter signal)
        {
            /// TODO here:
            /// optimize process: if I create plot then save it and get it ready when asked again
            /// im mainwindow make a collection of plots. add and delete them then addind/deliting signal to/from workspace
            
            this.lblCurrentlyChosen.Content = signal.Name;
            chartTest.ChartAreas.Clear();
            chartTest.Series.Clear();
            ChartArea area = new ChartArea();
            Series series = new Series(signal.Name);
            series.Points.DataBindXY(signal.T, signal.X);
            series.ChartType = SeriesChartType.Line;
            
            chartTest.ChartAreas.Add(area);
            chartTest.Series.Add(series);
        }

        //public event EventHandler<EventArgs> SignalLayoutQuery;
    }
}