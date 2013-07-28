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
        private void SignalAdd(Signal signal, string name)
        {
            signals.Add(name, signal);
            signalWaveletShowed.Add(name, new List<int>());
        }


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
                //signals.Add(signal.Name, signal);
                SignalAdd(signal, signal.Name);
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

        private void PropertiesWaveletCount(object sender, EventArgs e)
        {
            string lvlString = sender as string;
            if (lvlString == null)
                return;
            int lvl;
            try
            {
                lvl = int.Parse(lvlString);
            }
            catch
            {
                return;
            }
            signals[current].CountWavelet(lvl);
            PropertyLayoutArgsUpdate(current);
            view.PropertiesLayout(GetPropertyArgs(current));
        }


        // if show/hide button is pressed
        // sender is a string with wavelet level number
        private void PropertiesSwitchWaveletState(object sender, EventArgs e)
        {
            int lvl;
            try
            {
                lvl = int.Parse(sender as string);
            }
            catch
            {
                return;
            }

            if (signalWaveletShowed[current].Contains(lvl))
            {
                signalWaveletShowed[current].Remove(lvl);
            }
            else
            {
                signalWaveletShowed[current].Add(lvl);
            }
            PropertyLayoutArgsUpdate(current);
            SignalLayoutArgsUpdate(current);
            view.PropertiesLayout(GetPropertyArgs(current));
            view.SignalLayout(GetSignalArgs(current));
        }

        private void PropertiesWaveletCountQuery(object sender, EventArgs e)
        {
            int lvl;
            try
            {
                lvl = int.Parse(sender as string);
            }
            catch
            {
                return;
            }

            if (signals[current].waveletCalculated[lvl - 1] == true)
                return;
            else
            {
                signals[current].CountWavelet(lvl);
            }

            PropertyLayoutArgsUpdate(current);
            //SignalLayoutArgsUpdate(current);
            view.PropertiesLayout(GetPropertyArgs(current));
            //view.SignalLayout(GetSignalArgs(current));
        }


        private void PropertiesWaveletOpenQuery(object sender, EventArgs e)
        {
            int lvl;
            try
            {
                lvl = int.Parse(sender as string);
            }
            catch
            {
                return;
            }


            SignalData dt = signals[current].GetWavelet(lvl);
            Signal signal = new Signal(dt, signals[current].Name + "_wavelet_level_" + lvl.ToString());
            this.SignalAdd(signal, signal.Name);
            this.OpenedListUpdate();
        }


    }
}