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



namespace SignalProcessor.ViewLogic
{

    /// <summary>
    /// Handler for menu buttons
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            // MakeButtonCheckedOfPanel(btnFile, FilePanel);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            //MakeButtonCheckedOfPanel(btnOpen, OpenPanel);
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnImport, ImportPanel);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnExport, ExportPanel);
        }

        private void btnOpened_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnOpened, OpenedPanel);
        }

        // focuses/unfocuses button btn and shows/hides dockpanel panel
        private void MakeButtonCheckedOfPanel(Button btn, DockPanel panel)
        {
            if (panel.Visibility == Visibility.Visible)
            {
                panel.Visibility = Visibility.Collapsed;
                btn.Background = Brushes.LightGray;
                btn.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                panel.Visibility = Visibility;
                btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF1C75F5");
                btn.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void HideAllPanelsExceptOf(DockPanel dockPanel)
        {
            UIElementCollection children = ControlPanel.Children;
            int index = children.IndexOf(dockPanel);
            for (int i = 0; i < children.Count; ++i)
                if (i != index) children[i].Visibility = Visibility.Collapsed;
        }



        public void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg);    
        }
    }

}