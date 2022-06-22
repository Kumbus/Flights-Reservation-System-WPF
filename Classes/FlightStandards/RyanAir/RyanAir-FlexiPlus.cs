using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę flexi plus w lini lotniczej RyanAir
    /// </summary>
    public class RyanAir_FlexiPlus : RyanAir
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public RyanAir_FlexiPlus(BasicFlight bf) : base(bf)
        {
            Name = "FlexiPlus";
            NameAndPrice = "FlexiPlus" + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Klasa FlexiPlus\n\nElastyczne bilety i bezpłatna odprawa na lotnisku!\nMożesz bez żadnych dodatkowych opłat zmienić czas wylotu, cel podróży, a nawet miejsce wylotu(+1 / -1 dzień).\n\n" +
                "Szybsze przejście przez kontrolę bezpieczeństwa!\nSzybka kontrola bezpieczeństwa na lotnisku dzięki dostępowi do specjalnego przejścia. Mijasz kolejkę i szybciej " +
                "docierasz do hali wylotów\n\nPierwszeństwo wejścia i 2 sztuki bagażu podręcznego!\nDzięki pierwszeństwu wejścia i 2 sztukom bagażu podręcznego podróż z Ryanair to " +
                "sprawna i przyjemna. Możesz wejść na pokład i rozsiąść się wygodnie, zanim zrobią to inni. Nie musisz też czekać na bagaż podręczny po wylądowaniu.";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(2.5 * Price * (passengers + children * 0.85),2);
        }

    }
}
