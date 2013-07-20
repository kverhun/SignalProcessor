using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessor
{
    public interface IView
    {


        event EventHandler<EventArgs> btnHideCtrlClick;

    }
}
