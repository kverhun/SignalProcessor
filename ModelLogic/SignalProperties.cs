using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessor.ModelLogic
{
    public class SignalProperties
    {
        public int Points
        {
            get;
            set;
        }

        public double Duration
        {
            get;
            set;
        }

        public double Average
        {
            get;
            set;
        }

        public double Variance
        {
            get;
            set;
        }

        public int WaveletLevelsAvailable
        {
            get;
            set;
        }

    }
}
