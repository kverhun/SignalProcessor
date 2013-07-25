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
using System.Windows.Forms.Integration;

namespace SignalProcessor.ViewLogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {


        private void PropertyPanelUpdate(StackPanel panel)
        {
            ControlGrid.Children.Clear();
            ControlGrid.Children.Add(panel);
        }

        private void SignalLayoutUpdate(StackPanel panel)
        {
            panelChart.Children.Clear();
            panelChart.Children.Add(panel);
        }


        
        /// <summary>
        /// methods for getting ready panels based on Args types
        /// </summary>
        /// <param name="args"></param>


        public void SignalLayout(SignalPanelArgs args)
        {

            panelChart.Children.Clear();
            lblCurrentlyChosen.Content = args.Name;
            for (int i = 0; i < args.ChartCount; ++i)
            {
                WindowsFormsHost host = new WindowsFormsHost();
                host.Child = args.GetChart(i);
                this.panelChart.Children.Add(host);
            }

        }

        public void PropertiesLayout(PropertyPanelArgs args)
        {
            this.PropertyPanelUpdate(GetPropertiesPanel(args));
        }

        private void btnPropertiesCount_Click(object sender, EventArgs e)
        {
            CountPropertiesQuery(sender, e);
        }

        public event EventHandler<EventArgs> CountPropertiesQuery;






        ///
        /// Methods for getting panel with data and controls
        ///

        private StackPanel GetPropertiesPanel(PropertyPanelArgs args)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(5);

            Label lblName = new Label();
            lblName.FontSize = 16;
            lblName.FontWeight = FontWeights.Bold;
            lblName.Content = args.Name + " properties:";
            panel.Children.Add(lblName);

            if (args.Properties == null)
            {
                Button btn = new Button();
                btn.Click += btnPropertiesCount_Click;
                btn.Content = "Count properties";
                btn.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                btn.Width = 120;
                btn.Height = 30;
                panel.Children.Add(btn);
            }
            else
            {
                Label lblPoints = new Label();
                lblPoints.Content = "Points: " + args.Properties.Points.ToString();
                panel.Children.Add(lblPoints);

                Label lblDuration = new Label(); ;
                lblDuration.Content = "Duration: " + args.Properties.Duration.ToString();
                panel.Children.Add(lblDuration);

                Label lblAverage = new Label();
                lblAverage.Content = "Average: " + args.Properties.Average.ToString();
                panel.Children.Add(lblAverage);

                // else to be added

            }

            return panel;
        }


    }
}