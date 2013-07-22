using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace SignalProcessor.ModelLogic
{

    /// <summary>
    /// The model class encapsulate all logic
    /// </summary>
    class Model
    {
        public Model()
        {
            environment = new Environment();
        }

        public void ImportFile(string path)
        {
            FileInfo file = new FileInfo(path);
            environment.ImportSignal(file);
        }

        public List<string> GetItems()
        {
            return environment.GetSignalList();
        }

        public void RemoveItem(string item)
        {
            environment.RemoveSignal(item);
        }

        public Signal ChooseItem(string item)
        {
            environment.ChooseSignal(item);
            return environment.CurrentlyChosen;
        }

        private Environment environment;

    }
}
