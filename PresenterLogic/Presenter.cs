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
    /// constructor and fields here
    /// </summary>
    partial class Presenter
    {
        public Presenter(IView view)
        {
            this.view = view;
            SetEventHandlers();
            this.model = new Model();
            signals = new Dictionary<string, Signal>();
            signalLayoutArgs = new Dictionary<string, SignalPanelArgs>();
            signalPropertyArgs = new Dictionary<string, PropertyPanelArgs>();
            signalWaveletShowed = new Dictionary<string, List<int>>();
        }

        private void SetEventHandlers()
        {
            this.view.ImportTxtFileQuery += ImportTxtFile;
            this.view.OpenedRemoveQuery += OpenedRemove;
            this.view.OpenedChooseQuery += OpenedChoose;
            this.view.CountPropertiesQuery += PropertiesCount;
            this.view.CountWaveletQuery += PropertiesWaveletCountQuery;
            this.view.SwitchWaveletStateQuery += PropertiesSwitchWaveletState;
            this.view.OpenWaveletQuery += PropertiesWaveletOpenQuery;
        }


        private Dictionary<string, Signal> signals;
        private Dictionary<string, SignalPanelArgs> signalLayoutArgs;
        private Dictionary<string, PropertyPanelArgs> signalPropertyArgs;
        private Dictionary<string, List<int>> signalWaveletShowed;

       

        private string current;

        private IView view;
        private Model model;
    }
}
