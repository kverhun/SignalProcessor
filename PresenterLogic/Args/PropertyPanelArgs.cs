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
            WaveletCounted = signal.waveletCalculated;
            WaveletLevels = signal.WaveletLevelsAvailable;
        }

        public PropertyPanelArgs(Signal signal, List<int> waveletShown)
            : this(signal)
        {
            WaveletShown = new List<bool>();
            for (int i = 0; i < WaveletLevels; ++i)
                if (waveletShown.Contains(i+1)) WaveletShown.Add(true);
                else WaveletShown.Add(false);
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

        public int WaveletLevels
        {
            get;
            private set;
        }

        public List<bool> WaveletCounted
        {
            get;
            private set;
        }

        public List<bool> WaveletShown
        {
            get;
            private set;
        }

        

    
    }

    

}
