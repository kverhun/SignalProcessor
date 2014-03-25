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

            if (values.Length < 2)
            {
                throw new Exception("Should be at least 2 values in file!");
            }
            try
            {
                var s = new Signal(values, file.Name.Remove(file.Name.Length - 4));
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Signal Import(FileInfo file, string template)
        {
            throw new NotImplementedException();
        }
    }
}
