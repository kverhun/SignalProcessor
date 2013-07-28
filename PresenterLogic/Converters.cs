using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ViewLogic;
using SignalProcessor.ModelLogic;

namespace SignalProcessor.PresenterLogic
{
    /// <summary>
    /// Presenter class: provides connection
    /// 
    /// constructor and fields here
    /// </summary>
    partial class Presenter
    {
        private SignalPanelArgs ComputeSignalArgs(string name)
        {
            return new SignalPanelArgs(signals[name],signalWaveletShowed[name]);
        }

        private PropertyPanelArgs ComputeSignalPropArgs(string name)
        {
            return new PropertyPanelArgs(signals[name]);
        }
    }
}