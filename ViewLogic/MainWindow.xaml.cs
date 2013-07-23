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

namespace SignalProcessor.ViewLogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {

        private ViewModel vm;
        private Presenter presenter;
        private VisibilityToColorConverter visibitityToColorCoverter;
        private WidthConverter widthConverter;
        public MainWindow()
        {
            this.vm = new ViewModel(this);
            this.presenter = new Presenter(this);
            this.widthConverter = new WidthConverter();
            this.visibitityToColorCoverter = new VisibilityToColorConverter();
            InitializeComponent();

        }


        private void CreateBindings()
        {

            
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void StackPanel_MouseDown1(object sender, MouseButtonEventArgs e)
        {

        }

        private void DockPanelMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                
                this.MyDragMove();
            }
        }

        private void MyDragMove()
        {
            this.DragMove();
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.btnExit_Click(sender, e);
        }

        private void mainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                
            }
            else
            {

            }
        }





     

    }
}
