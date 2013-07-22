﻿using System;
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


        // Opened
        void OpenedSetItems(List<string> items);
        event EventHandler<EventArgs> OpenedRemoveQuery;
        event EventHandler<EventArgs> OpenedChooseQuery;


        // Signal representation
        void SignalLayout(SignalPresenter signal);
        //event EventHandler<EventArgs> SignalLayoutQuery;
        
    }
}
