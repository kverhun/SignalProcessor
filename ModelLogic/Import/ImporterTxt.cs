using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace SignalProcessor.ModelLogic.Import
{
    class ImporterTxt : IImporter
    {
        public Signal Import(FileInfo file)
        {
            string textFromFile;
            using (StreamReader sr = file.OpenText())
            {
                textFromFile = sr.ReadToEnd();
            }
            textFromFile = textFromFile.Replace('.', ',');
            textFromFile = textFromFile.Trim('\n', ' ');
            string[] txtValues =  textFromFile.Split(' ', '\n', '\t');
            double[] values = new double[txtValues.Length];
            for (int i = 0; i < txtValues.Length; ++i)
                values[i] = double.Parse(txtValues[i]);

            return new Signal(values, file.Name.Remove(file.Name.Length - 4));
        }
    }
}
