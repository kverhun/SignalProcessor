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
    public class SignalHolder
    {

        

        public void AddSignal(SignalPresenter signal, string name)
        {
            signals.Add(name, signal);
        }

        public void RemoveSignal(string name)
        {
            signals.Remove(name);
        }

        public void CountProperties()
        {
            signals[Current].CountProperties();
        }

        public string Current
        {
            get;
            set;
        }

        private Dictionary<string, SignalPresenter> signals;




        IView view;
    }
}
