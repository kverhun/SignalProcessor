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
            this.holder = new SignalHolder();
        }

        private void SetEventHandlers()
        {
            this.view.ImportTxtFileQuery += ImportTxtFile;
            this.view.OpenedRemoveQuery += OpenedRemove;
            this.view.OpenedChooseQuery += OpenedChoose;
        }
        
        
        

        private IView view;
        private Model model;
        private SignalHolder holder;
    }
}
