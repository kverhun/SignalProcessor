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
            return (int)Math.Floor(Math.Log(t.Length, 2)) - 1;
        }

        private SignalData GetWaveletLevel(int lvl)
        {
            return new SignalData(waveletComputer.SWT[lvl]);
        }



        private double CountAverage(double[] array)
        {
            double res = 0;
            for (int i = 0; i < array.Length; ++i)
                res += array[i];
            return res / array.Length;
        }

        private double CountAbsVariance(double[] array)
        {
            double average = CountAverage(array);
            return CountAbsVariance(array, average);
        }

        private double CountAbsVariance(double[] array, double average)
        {
            double res = 0;

            for (int i = 0; i < array.Length; ++i)
            {
                res += Math.Pow(array[i] - average, 2);
            }
            return res / (array.Length + 1);
        }


         

        private double CountPDM(double[] array, double variance, int T)
        {
            double res = 0;

            int lng = array.Length;
            if (T > lng)
                throw new Exception();

            int periods = (int)Math.Truncate((double)lng / T);
            double[] s = new double[T];
            double[,] tempData = new double[T, periods];
            
            for (int i = 0; i < T; ++i)
            {
                for (int j = 0; j < periods; ++j)
                        tempData[i, j] = array[i + T * j];
                    
                double[] tempArr = new double[periods];
                for (int k = 0; k < periods; ++k)
                    tempArr[k] = tempData[i, k];
                s[i] = CountAbsVariance(tempArr);
            }
            for (int i = 0; i < T; ++i)
                res += s[i];
            return res / variance / (T-1);
        }

        public PDMData GetPDM(double[] array, int T1, int T2)
        {
            int[] T = new int[T2 - T1 + 1];
            for (int i = 0; i < T2 - T1 + 1; ++i)
                T[i] = T1 + i;

            double[] X = new double[T2 - T1 + 1];

            for (int i = 0; i < T2 - T1 + 1; ++i)
                X[i] = CountPDM(array, CountAbsVariance(array), T[i]);

            PDMData data = new PDMData();
            data.T1 = T1;
            data.T2 = T2;
            data.TArray = T;
            data.XArray = X;
            return data;            
        }

    }
}