using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessor.ModelLogic
{
    class Wavelet
    {
        public double[][] SWT;
        public double[] filter = { 1.0 / 16.0, 1.0 / 4.0, 3.0 / 8.0, 1.0 / 4.0, 1.0 / 16.0 };

        public void doSWT(double[] input)
        {
            int fhw = filter.Length / 2;
            int waveletLevelCount;
            // Визначення кількості рівнів у вейвлет-розкладанні
            // (береться така кількість рівнів, щоб хоча б одну точку на рівні можна було визначити правильно)
            waveletLevelCount = (int)Math.Floor(Math.Log(input.Length, 2));

            SWT = new double[waveletLevelCount][];

            // Копіювання вхідних даних у перший рівень розкладання
            SWT[0] = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
                SWT[0][i] = input[i];

            // Обчислення рівнів розкадання
            for (int k = 0; k < waveletLevelCount - 1; k++)
            {
                // Крок
                int d = 1 << k;

                // Номер наступного рівня
                int k1 = k + 1;

                SWT[k1] = new double[input.Length];

                // Обчислення наступного рівня
                /*
                for (int i = d * fhw; i < input.Length - d * fhw; i++)
                    for (int f = -fhw; f <= fhw; f++) 
                        SWT[k1][i] += SWT[k][i + f * d] * filter[f + fhw];
                */
                for (int i = 0; i < input.Length; i++)
                    for (int f = -fhw; f <= fhw; f++)
                        if ((i + f * d >= 0) && (i + f * d < input.Length))
                            SWT[k1][i] += SWT[k][i + f * d] * filter[f + fhw];
                        else
                            SWT[k1][i] += SWT[k][i /*- f * d*/] * filter[f + fhw];


                // Обчислення поточного рівня
                for (int i = 0; i < input.Length; i++)
                    SWT[k][i] -= SWT[k1][i];

            }
        }
    }
}
