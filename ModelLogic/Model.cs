using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using SignalProcessor.ModelLogic.Import;

namespace SignalProcessor.ModelLogic
{

    /// <summary>
    /// The model class encapsulate all logic
    /// </summary>
    class Model
    {
        public Model()
        {
            importerTxt = new ImporterTxt();
        }

        public Signal ImportTxt(string fname)
        {
            FileInfo fl = new FileInfo(fname);
            try
            {
                return importerTxt.Import(fl);
            }
            catch
            {
                return null;
            }
            
        }

        private IImporter importerTxt;
    }
}
