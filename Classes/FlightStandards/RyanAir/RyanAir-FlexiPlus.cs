using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class RyanAir_FlexiPlus : RyanAir
    {
        public new string NameAndPrice { get; set; }
        public new string Name { get; set; } = "FlexiPlus";
        public RyanAir_FlexiPlus(BasicFlight bf) : base(bf)
        {
            NameAndPrice = "FlexiPlus" + GetPrice(passengersNumber, childrenNumber) + " zł";
        }

        public override string Describe()
        {
            return "Klasa FlexiPlus\n\nElastyczne bilety i bezpłatna odprawa na lotnisku!\nMożesz bez żadnych dodatkowych opłat zmienić czas wylotu, cel podróży, a nawet miejsce wylotu(+1 / -1 dzień).\n\n" +
                "Szybsze przejście przez kontrolę bezpieczeństwa!\nSzybka kontrola bezpieczeństwa na lotnisku dzięki dostępowi do specjalnego przejścia. Mijasz kolejkę i szybciej " +
                "docierasz do hali wylotów\n\nPierwszeństwo wejścia i 2 sztuki bagażu podręcznego!\nDzięki pierwszeństwu wejścia i 2 sztukom bagażu podręcznego podróż z Ryanair to " +
                "sprawna i przyjemna. Możesz wejść na pokład i rozsiąść się wygodnie, zanim zrobią to inni. Nie musisz też czekać na bagaż podręczny po wylądowaniu.";
        }

        public override double GetPrice(int passengers, int children)
        {
            return 2.5 * Price * (passengers + children * 0.75);
        }

    }
}
