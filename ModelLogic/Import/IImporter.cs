using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace SignalProcessor.ModelLogic.Import
{
    interface IImporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>
        /// Signal object improted from file
        /// null if file is not valid
        /// </returns>
        Signal Import(FileInfo file);
        Signal Import(FileInfo file, string template);
    }
}
