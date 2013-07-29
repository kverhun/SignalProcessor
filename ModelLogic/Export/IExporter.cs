using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SignalProcessor.ModelLogic.Export
{
    interface IExporter
    {
        void Export(Signal signal, FileInfo file);
        void Export(Signal signal, FileInfo file, string template);
    }
}
