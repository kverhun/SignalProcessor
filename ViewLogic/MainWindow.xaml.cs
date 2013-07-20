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

        private WidthConverter widthConverter;

        public MainWindow()
        {
            this.vm = new ViewModel(this);
            this.widthConverter = new WidthConverter();
            
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
       
    }
}
