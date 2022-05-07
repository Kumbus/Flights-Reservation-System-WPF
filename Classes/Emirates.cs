﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Emirates : BasicFlight
    {

        public Emirates(BasicFlight bf) : base(bf)
        {

        }

        public string PriceString
        {
            get
            {
                return "Ceny już od: " + (Price * passengersNumber * 1 + Price * childrenNumber * 0.25) + " zł";
            }

            set
            {
            }
        }
    }
}
