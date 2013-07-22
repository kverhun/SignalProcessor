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



     

    }
}
