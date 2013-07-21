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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {

        private ViewModel vm;
        private VisibilityToColorConverter visibitityToColorCoverter;
        private WidthConverter widthConverter;
        public MainWindow()
        {
            this.vm = new ViewModel(this);
            this.widthConverter = new WidthConverter();
            this.visibitityToColorCoverter = new VisibilityToColorConverter();

            

        }

        
        private void btnHider_Click(object sender, RoutedEventArgs e)
        {
            btnHideCtrlClick(sender, e);

        }
        public event EventHandler<EventArgs> btnHideCtrlClick;

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            // TODO here:
            // confirm shutdown
            // ask about saving
            Application.Current.Shutdown();
        }

        private void MenuItemImport_Click(object sender, RoutedEventArgs e)
        {
            ImportWindow window = new ImportWindow();
            window.ShowDialog();
            if (window.DialogResult.HasValue && window.DialogResult.Value == true)
            {
                // handling OK here
            }
            
        }

        private void MenuItemExport_Click(object sender, RoutedEventArgs e)
        {
            ExportWindow window = new ExportWindow();
            window.ShowDialog();
            if (window.DialogResult.HasValue && window.DialogResult.Value == true)
            {
                // handling OK here
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnImport, ImportPanel);
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

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnFile, FilePanel);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnOpen, OpenPanel);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnExport, ExportPanel);
        }

        private void btnOpened_Click(object sender, RoutedEventArgs e)
        {
            MakeButtonCheckedOfPanel(btnOpened, OpenedPanel);
        }
        

    }
}
