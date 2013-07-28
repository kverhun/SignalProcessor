using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessor.ModelLogic
{
    public class SignalData
    {
        public SignalData(double[] x)
        {
            X = x;
            T = new double[x.Length];
            for (int i = 0; i < x.Length; ++i)
                T[i] = i + 1;
        }


        public SignalData(double[] t, double[] x)
        {
            if (x.Length != t.Length)
                throw new Exception();
            X = x;
            T = t;
        }



        public double[] X
        {
            get;
            private set;
        }

        public double[] T
        {
            get;
            private set;
        }

    }
}
