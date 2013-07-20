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

namespace SignalProcessor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            

            this.vm = new ViewModel(this);



            
           
            //ControlGrid.Visibility = Visibility.Hidden;
        }

        public ViewModel vm;
        private void btnHider_Click(object sender, RoutedEventArgs e)
        {
            btnHideCtrlClick(sender, e);

        }
        public event EventHandler<EventArgs> btnHideCtrlClick;
    }
}
