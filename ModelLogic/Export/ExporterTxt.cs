using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace SignalProcessor.ModelLogic.Export
{
    class ExporterTxt : IExporter
    {
        public void Export(Signal signal, System.IO.FileInfo file)
        {
            //FileStream fs = file.Open(FileMode.OpenOrCreate);
            //fs.Close();
            using (StreamWriter sw = file.CreateText())
            {
                for (int i = 0; i < signal.T.Length; ++i)
                    sw.WriteLine(signal.X[i].ToString(CultureInfo.InvariantCulture));
            }
            
        }

        /// <summary>
        /// template: "X" "XT" "TX" "T" "X T" "X\tT"
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="file"></param>
        /// <param name="template"></param>
        public void Export(Signal signal, System.IO.FileInfo file, string template)
        {
            
        }
    }
}
