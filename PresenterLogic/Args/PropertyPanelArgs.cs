using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ViewLogic;
using SignalProcessor.ModelLogic;


namespace SignalProcessor.PresenterLogic
{
    public class PropertyPanelArgs
    {
        public PropertyPanelArgs(Signal signal)
        {
            SignalProperties props = signal.Properities;
            Properties = props;
            Name = signal.Name;
        }

        public string Name
        {
            get;
            private set;
        }

        public SignalProperties Properties
        {
            get;
            private set;
        }

    
    }

    

}
