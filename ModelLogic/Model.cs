using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using SignalProcessor.ModelLogic.Import;
using SignalProcessor.ModelLogic.Export;

namespace SignalProcessor.ModelLogic
{

    /// <summary>
    /// The model class encapsulates all logic
    /// </summary>
    class Model
    {
        public Model()
        {
            importerTxt = new ImporterTxt();
            exporterTxt = new ExporterTxt();
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

        public void ExportTxt(Signal signal, string fname)
        {
            FileInfo fl = new FileInfo(fname);
            try
            {
                exporterTxt.Export(signal, fl);
            }
            catch
            {
                return;
            }
        }

        private IImporter importerTxt;
        private IExporter exporterTxt;
    }
}
