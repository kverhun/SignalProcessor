using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.PresenterLogic;

namespace SignalProcessor
{
    public interface IView
    {
        // Import
        string GetImportTxtFilename();
        event EventHandler<EventArgs> ImportTxtFileQuery;
        
        // Export
        string GetExportTxtFilename();
        event EventHandler<EventArgs> ExportTxtFileQuery;

        // Opened
        void OpenedSetItems(List<string> items);
        event EventHandler<EventArgs> OpenedRemoveQuery;
        event EventHandler<EventArgs> OpenedChooseQuery;
        
        // Signal representation
        void SignalLayout(SignalPanelArgs args);
        void PropertiesLayout(PropertyPanelArgs args);
        event EventHandler<EventArgs> CountPropertiesQuery;
        event EventHandler<EventArgs> ShowPDMQuery;

        // wavelets
        event EventHandler<EventArgs> CountWaveletQuery;
        event EventHandler<EventArgs> SwitchWaveletStateQuery;
        event EventHandler<EventArgs> OpenWaveletQuery;
    }
}
