using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class RyanAir_Value : RyanAir
    {
        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "Value";
        public RyanAir_Value(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "Value " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa Value\n\nPodróżuj z małym bagażem! \nTaryfa value pozwala na podróż z tylko 1 małym bagażem - bagaż musi się zmieścić " +
                "pod siedzeniem (40cm x 20cm x 25cm) \n\n" +
                "Jeśli zależy Ci na tanim transporcie, a wygody nie są dla Ciebie priorytetem, ten standard jest właśnie dla Ciebie. ";
        }

        public override double GetPrice(int passengers, int children)
        {
            return Price * (passengers + children * 0.75);
        }
    }
}
