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
using System.ComponentModel;

namespace SignalProcessor
{
    public class ViewModel
    {
        public ViewModel(IView view)
        {
            this.view = view;
            this.IsVisible = true;
            

            view.btnHideCtrlClick += ChangeHideButtonState;
        }



        public bool IsVisible
        {
            get;
            set;
        }
     

        public void ChangeHideButtonState(object sender, EventArgs e)
        {
            if (IsVisible == true)
                IsVisible = false;
            else
                IsVisible = true;
        }
        

        private IView view;

    }
}
