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
        private List<string> GetItemList()
        {
            List<string> list = new List<string>();

            foreach (string str in signals.Keys)
                list.Add(str);

            return list;
        }

        private SignalPanelArgs GetSignalArgs(string name)
        {
            if (name == null) return null;
            try
            {
                return signalLayoutArgs[name];
            }
            catch
            {
                signalLayoutArgs.Add(name, ComputeSignalArgs(name));
                return signalLayoutArgs[name];
            }
        }

        private PropertyPanelArgs GetPropertyArgs(string name)
        {
            try
            {
                return signalPropertyArgs[name];
            }
            catch
            {
                signalPropertyArgs.Add(name, ComputeSignalPropArgs(name));
                return signalPropertyArgs[name];
            }
        }


        private void SignalLayoutArgsUpdate(string name)
        {

            signalLayoutArgs[name] = new SignalPanelArgs(signals[name],signalWaveletShowed[name],signalPDMData[current] == null ? false : true);
        }


        private void PropertyLayoutArgsUpdate(string name)
        {
            signalPropertyArgs[name] = new PropertyPanelArgs(signals[name], signalWaveletShowed[name]);
        }
    }
}