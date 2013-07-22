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
            string name = file.Name.Remove(file.Name.Length - 4);
            Signal signal = ImportProcess(file);
            if (signal != null)
            {
                try
                {
                    signal.Name = name;
                    signals.Add(name, signal);
                }
                catch
                {

                }
            }
        }

        public void ImportSignal(FileInfo file, string name)
        {
            Signal signal = ImportProcess(file);
            if (signal != null)
            {
                signal.Name = name;
                signals.Add(name, signal);
            }
        }

        public void RemoveSignal(string name)
        {
            signals.Remove(name);
        }

        public void ChooseSignal(string name)
        {
            currentlyChosenName = name;
            currentlyChosen = signals[name];
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

        public Signal CurrentlyChosen
        {
            get
            {
                return currentlyChosen;
            }
        }

        private Signal currentlyChosen;
        private string currentlyChosenName;

        private Dictionary<string, Signal> signals;
        private IImporter txtImporter;


    }
}
