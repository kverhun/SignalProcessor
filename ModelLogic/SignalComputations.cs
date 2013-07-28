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
    public partial class Signal
    {
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

            double sum = 0;
            foreach (double val in this.X)
                sum += val;
            this.average = sum/(this.X.Length);
            return this.average;
        }

        private double GetVariance()
        {
            double sum = 0;
            foreach (double val in this.X)
                sum += Math.Pow((val - this.average), 2);
            return sum/(this.X.Length - 1);
        }

        private int GetWaveletLevelsAvailable()
        {
            return (int)Math.Floor(Math.Log(t.Length, 2));
        }

        private SignalData GetWaveletLevel(int lvl)
        {
            return new SignalData(waveletComputer.SWT[lvl]);
        }
    
    }
}