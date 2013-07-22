using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ModelLogic;

namespace SignalProcessor.PresenterLogic
{
    public class SignalPresenter
    {
        public SignalPresenter(Signal signal)
        {
            this.Name = signal.Name;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string name;

    }
}
