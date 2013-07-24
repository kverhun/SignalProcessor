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

using System.Windows.Forms.Integration;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

using SignalProcessor.ModelLogic;

namespace SignalProcessor.PresenterLogic
{
    public class SignalPresenter
    {
        public SignalPresenter(Signal signal)
        {
            this.signal = signal;           
        }


        public StackPanel GetLayoutPanel()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(5);

            // here we shoud place charts to panel
            


            return panel;
        }

        public StackPanel GetLayoutPropertiesPanel()
        {
            StackPanel panel = new StackPanel();
            panel.Margin = new Thickness(5);
            panel.Orientation = Orientation.Vertical;
            Label lbl = new Label();
            lbl.Content = "Properties of " + this.Name;
            panel.Children.Add(lbl);

            if (this.Properities == null)
            {
                Button btn = new Button();
                btn.Name = this.Name;
                btn.Style = App.Current.FindResource("PanelButtonStyle") as Style;
                btn.Height = 20;
                btn.Width = 150;
                btn.Content = "Count";
                btn.Margin = new Thickness(5);
                //btn.Click += btnSignal_Click;
                panel.Children.Add(btn);
                
            }
            else
            {

            }

            return panel;
        }
        
        private Signal signal;

        public SignalProperties Properities
        {
            get;
            set;
        }
        
        public double[] X
        {
            get
            {
                return signal.X;
            }
            
        }

        public double[] T
        {
            get
            {
                return signal.T;
            }
        }


        // implement the renaming ???
        public string Name
        {
            get
            {
                return signal.Name;
            }
        }

        // maybe for storage renamed value before saved
        private string name;

    }
}
