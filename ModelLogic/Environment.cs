using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ModelLogic.Import;
using System.IO;

namespace SignalProcessor.ModelLogic
{
    class Environment
    {
        public Environment()
        {
            signals = new Dictionary<string, Signal>();
            txtImporter = new ImporterTxt();
        }

        public List<string> GetSignalList()
        {
            List<string> keys = new List<string>();
            foreach (var key in signals.Keys)
                keys.Add(key);
            return keys;    
        }

        public void ImportSignal(FileInfo file)
        {
            string name = file.Name;
            Signal signal = ImportProcess(file);
            if (signal != null)
            {
                signals.Add(name, signal);
            }
        }

        public void ImportSignal(FileInfo file, string name)
        {
            Signal signal = ImportProcess(file);
            if (signal != null)
                signals.Add(name, signal);
        }

        public void RemoveSignal(string name)
        {
            signals.Remove(name);
        }



        private Signal ImportProcess(FileInfo file)
        {
            switch (file.Extension)
            {
                case ".txt":
                    try
                    {
                        return txtImporter.Import(file);
                    }
                    catch
                    {
                        return null;
                    }
                case ".xls":

                    break;
            }
            return new Signal();
        }
        

        private Dictionary<string, Signal> signals;
        IImporter txtImporter;


    }
}
