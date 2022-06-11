using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class RyanAir_Plus : RyanAir
    {
        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "Plus";
        public RyanAir_Plus(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "Plus " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa Plus\n\nŚwietne rozwiązanie na dłuższe podróże!\nPakiet Plus został opracowany z myślą o dłuższych podróżach. " +
                "Obejmuje bagaż rejestrowany do 20 kg, rezerwację miejsc oraz bezpłatną odprawę na lotnisku, aby podróż przebiegła bezproblemowo.\n\n" +
                "Spakuj wszystko, czego Ci trzeba!\nDodatkowo do dyspozycji masz bagaż rejestrowany do 20 kg, w którym możesz zabrać " +
                "ze sobą wszystko, czego potrzebujesz na dłuższą podróż. Zabierz wszystkie niezbędne rzeczy i nie martw się o brak miejsca na pamiątki!\n\n" +
                "Wybierz ulubione miejsce!\nPakiet Plus obejmuje rezerwację miejsc, które zapewnią wygodę siedzenia. " +
                "Chcesz zająć miejsce przy przejściu lub przy oknie? Wybierz ulubione, aby podróżować jak najwygodniej!";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 2 * Price * (passengers + children * 0.75);
        }

    }
}
