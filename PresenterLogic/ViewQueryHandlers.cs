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
            OpenedListUpdate();
        }

        private void OpenedRemove(object sender, EventArgs e)
        {
            string name = sender as string;
            if (name == null)
                return;
            model.RemoveItem(name);
            OpenedListUpdate();
        }

        private void OpenedChoose(object sender, EventArgs e)
        {
            string name = sender as string;
            if (name == null)
                return;

            // TODO here: tell model to change currenly chosen signal
            Signal current = model.ChooseItem(name);
            SignalPresenter presenter = new SignalPresenter(current);
            view.SignalLayout(presenter);
        }


        private void OpenedListUpdate()
        {
            List<string> items = model.GetItems();
            view.OpenedSetItems(items);
        }

    }
}