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
            //model.ImportFile(txtFileName);
            //OpenedListUpdate();
            Signal signal = model.ImportTxt(txtFileName);
            if (signal == null)
                return;
            try
            {
                signals.Add(signal.Name, signal);
                this.OpenedListUpdate();
            }
            catch
            {
                // message to be generated
            }
        }

        private void OpenedRemove(object sender, EventArgs e)
        {
            string name = sender as string;
            if (name == null)
                return;
            this.signals.Remove(name);
            OpenedListUpdate();
        }

        private void OpenedChoose(object sender, EventArgs e)
        {
            string name = sender as string;
            if (name == null)
                return;

            // TODO here: tell model to change currenly chosen signal
            //Signal current = model.ChooseItem(name);
            //SignalPresenter presenter = new SignalPresenter(current);
            //view.SignalLayout(presenter);
            
            
            this.current = name;
            // here we have to tell view to show signal and it's properties
            view.SignalLayout(GetSignalArgs(current));
            view.PropertiesLayout(GetPropertyArgs(current));

        }

        private void PropertiesCount(object sender, EventArgs e)
        {
            signals[current].CountProperities();
            PropertyLayoutArgsUpdate(current);
            view.PropertiesLayout(GetPropertyArgs(current));
        }

        private void OpenedListUpdate()
        {
            //List<string> items = model.GetItems();
            //view.OpenedSetItems(items);
            view.OpenedSetItems(GetItemList());
        }

        






    }
}