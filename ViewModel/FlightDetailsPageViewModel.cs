using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class FlightDetailsPageViewModel : BaseViewModel
    {
        public object Flight { get; set; }
        public FlightDetailsPageViewModel()
        {
            Flight = FlightUse.FindOne();
        }



    }
}
