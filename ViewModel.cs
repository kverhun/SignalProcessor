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

using SignalProcessor.ModelLogic;

namespace SignalProcessor
{
    public class ViewModel
    {
        public ViewModel(IView view)
        {
            this.view = view;
            model = new Model();
        }

        private void CreateBindings()
        {

            
        }



        public string ImportTxtFilename
        {
            get
            {
                return importTxtFilename;
            }
            set
            {
                MessageBox.Show(value);
                importTxtFilename = value;
            }
        }
        private string importTxtFilename;


        private IView view;
        private Model model;
    }
}
