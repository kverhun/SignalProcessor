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
    public class Signal
    {

        // default constructor creates empty signal
        public Signal()
        {
            
        }


        // sets t[] as 1,2,3...
        public Signal(double[] values, string name)
        {
            // creating time
            this.t = new double[values.Length];

            // setting time
            for (int i = 0; i < t.Length; ++i)
                t[i] = i + 1;
            
            // creating values
            this.x = values;
            this.Name = name;
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
            this.Name = "signal";
        }

        // creates signal based on time and values
        public Signal(double[] time, double[] values)
        {
            this.t = time;
            this.x = values;
            this.Name = "some signal";
        }

        // creates signal based on time, values and name
        public Signal(double[] time, double[] values, string name)
        {
            this.t = time;
            this.x = values;
            this.Name = name;
        }


        public void CountProperities()
        {
            properities = new SignalProperties();
            properities.Points = GetPointsCount();
            properities.Duration = GetDuration();
            properities.Average = GetAverage();
            properities.Variance = GetVariance();
            properities.WaveletLevelsAvailable = GetWaveletLevelsAvailable();

            properitiesReady = true;
        }

        public SignalProperties Properities
        {
            get
            {
                if (properitiesReady)
                    return properities;
                else
                    return null;
            }
        }

        private bool properitiesReady;
        private SignalProperties properities;




        public string Name
        {
            get;
            set;
        }

        public double[] T
        {
            get
            {
                return t;
            }
        }

        public double[] X
        {
            get
            {
                return x;
            }
        }


        // array of time points
        private double[] t;

        // array of values: x[i] = x(t[i])
        private double[] x;




        private int GetPointsCount()
        {
            return t.Length;
        }

        private double GetDuration()
        {
            return (t[t.Length - 1] - t[0]);
        }

        private double GetAverage()
        {
            // average here to be counted
            return 0.0;
        }

        private double GetVariance()
        {
            // variance here to be counted
            return 1.0;
        }

        private int GetWaveletLevelsAvailable()
        {
            return (int)Math.Floor(Math.Log(t.Length, 2));            
        }





    }
}
