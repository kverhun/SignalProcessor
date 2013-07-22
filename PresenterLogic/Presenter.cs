using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalProcessor.ViewLogic;

namespace SignalProcessor.PresenterLogic
{
    class Presenter
    {
        public Presenter(IView view)
        {
            this.view = view;
        }


        private IView view;

    }
}
