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
            series.LegendText = signal.Name;
            chartTest.ChartAreas.Add(area);
            chartTest.Series.Add(series);
            chartTest.Visible = true;

        
        }

        

        //public event EventHandler<EventArgs> SignalLayoutQuery;


        public void SignalPropertiesLayout(SignalPresenter signal)
        {
            // adding properties to control panel
            this.ControlGrid.Children.Clear();
            this.ControlGrid.Children.Add(signal.GetLayoutPropertiesPanel());
        
        }





        private StackPanel GetPanelLayout(SignalPresenter signal)
        {
            StackPanel panel = new StackPanel();
            panel.Margin = new Thickness(5);
            panel.Orientation = Orientation.Vertical;
            Label lbl = new Label();
            lbl.Content = "Properties of " + this.Name;
            panel.Children.Add(lbl);

            if (signal.Properities == null)
            {
                Button btn = new Button();
                btn.Name = this.Name;
                btn.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                btn.Height = 20;
                btn.Width = 150;
                btn.Content = "Count";
                btn.Margin = new Thickness(5);
                btn.Click += btnSignal_Click;
                panel.Children.Add(btn);

            }
            else
            {

            }
            return panel;
        }

        private StackPanel GetSignalPanel(SignalPanelArgs args)
        {
            StackPanel panel = new StackPanel();

            return panel;
        }

        private StackPanel GetPropertiesPanel(PropertyPanelArgs args)
        {
            StackPanel panel = new StackPanel();

            return panel;
        }

        private void PropertyPanelUpdate(StackPanel panel)
        {
            // here we should put in to view
            ControlGrid.Children.Clear();
            ControlGrid.Children.Add(panel);
        }

        private void SignalLayoutUpdate(StackPanel panel)
        {
            // here we should to view
            panelChart.Children.Clear();
            panelChart.Children.Add(panel);
        }

        private void btnSignal_Click(object sender, EventArgs e)
        {

        }

    }
}