using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SignalProcessor.ModelLogic
{

    /// <summary>
    /// class represents signal (time series)
    /// </summary>
    
    [Serializable]
    public partial class Signal
    {

        // default constructor creates empty signal
        public Signal()
        {
            this.wavelets = new List<SignalData>();
            this.waveletCalculated = new List<bool>(this.waveletLevelsAvailable);
            
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
            this.waveletLevelsAvailable = GetWaveletLevelsAvailable();
            this.wavelets = new List<SignalData>();
            this.waveletCalculated = new List<bool>(this.waveletLevelsAvailable);
            fillWaveletList();
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
            this.waveletLevelsAvailable = GetWaveletLevelsAvailable();
            this.wavelets = new List<SignalData>();
            this.waveletCalculated = new List<bool>(this.waveletLevelsAvailable);
            fillWaveletList();
        }

        // creates signal based on time and values
        public Signal(double[] time, double[] values)
        {
            this.t = time;
            this.x = values;
            this.Name = "some signal";
            this.waveletLevelsAvailable = GetWaveletLevelsAvailable();
            this.wavelets = new List<SignalData>();
            this.waveletCalculated = new List<bool>(this.waveletLevelsAvailable);
            fillWaveletList();
        }

        // creates signal based on time, values and name
        public Signal(double[] time, double[] values, string name)
        {
            this.t = time;
            this.x = values;
            this.Name = name;
            this.waveletLevelsAvailable = GetWaveletLevelsAvailable();
            this.wavelets = new List<SignalData>();
            this.waveletCalculated = new List<bool>(this.waveletLevelsAvailable);
            fillWaveletList();
        }

        public Signal(SignalData data, string name)
        {
            this.t = data.T;
            this.x = data.X;
            this.Name = name;
            this.waveletLevelsAvailable = GetWaveletLevelsAvailable();
            this.wavelets = new List<SignalData>();
            this.waveletCalculated = new List<bool>(this.waveletLevelsAvailable);
            fillWaveletList();
        }

        private void fillWaveletList()
        {
            wavelets = new List<SignalData>();
            for (int i = 0; i < this.waveletLevelsAvailable; ++i)
            {
                this.waveletCalculated.Add(false);
                this.wavelets.Add(null);
            }
            
            
        }

        public SignalData GetWavelet(int lvl)
        {
            if (waveletCalculated[lvl-1])
                return wavelets[lvl-1];
            else
            {
                try
                {
                    CountWavelet(lvl);
                }
                catch
                {
                    return null;
                }
                return wavelets[lvl-1];
            }
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

        private double average;
        private double variance;


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




        
        /// Wavelet levels
        /// 
        private List<SignalData> wavelets;
        public List<bool> waveletCalculated
        {
            get;
            private set;
        }

        public int WaveletLevelsAvailable
        {
            get { return waveletLevelsAvailable; }
        }

        private int waveletLevelsAvailable;

        public void CountWavelet(int lvl)
        {
            if (waveletComputer == null)
            {
                waveletComputer = new Wavelet();
                waveletComputer.doSWT(this.X);
            }

            if (waveletCalculated[lvl-1] == true)
                return;
            
            

            if (lvl > waveletLevelsAvailable)
                return ;


            // here we have to call method for caclulations
            // but now we are just copying signal

            wavelets[lvl - 1] = this.GetWaveletLevel(lvl);

            waveletCalculated[lvl-1] = true;
        }

        private Wavelet waveletComputer;




        public PDMData GetPDM(int T1, int T2)
        {
        //    return GetPDM(this.X, T1, T2);
            CurrentPDMData = GetPDM(this.X, T1, T2);
            return CurrentPDMData;
        }

        public PDMData CurrentPDMData
        {
            get;
            set;
        }

        public string SerializeBin()
        {
            string res = string.Empty;
            BinaryFormatter bf = new BinaryFormatter();

            return res;
        }

    }
}
