using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessor.ModelLogic
{

    /// <summary>
    /// class represents signal (time series)
    /// </summary>
    class Signal
    {

        // default constructor creates empty signal
        public Signal()
        {

        }


        // sets t[] as 1,2,3...
        public Signal(double[] values)
        {
            // creating time
            this.t = new double[values.Length];

            // setting time
            for (int i = 0; i < t.Length; ++i)
                t[i] = i + 1;
            
            // creating values
            this.x = values;
        }


        // creates signal based on time and values
        public Signal(double[] time, double[] values)
        {
            this.t = time;
            this.x = values;
        }





        // array of time points
        private double[] t;

        // array of values: x[i] = x(t[i])
        private double[] x;

    }
}
