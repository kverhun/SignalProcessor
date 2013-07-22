using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ViewLogic;
using SignalProcessor.ModelLogic;

namespace SignalProcessor.PresenterLogic
{
    /// <summary>
    /// Presenter class: provides connection
    /// 
    /// view queries here
    /// </summary>
    partial class Presenter
    {
        private void ImportTxtFile(object sender, EventArgs e)
        {
            // here we have to say to model what to do

            string txtFileName = view.GetImportTxtFilename();
            model.ImportFile(txtFileName);
        }
    }
}