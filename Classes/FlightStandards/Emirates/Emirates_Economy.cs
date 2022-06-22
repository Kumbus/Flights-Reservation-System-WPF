using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę ekonomiczną w lini lotniczej Emirates
    /// </summary>
    public class Emirates_Economy : Emirates
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public Emirates_Economy(BasicFlight bf) : base(bf)
        {
            Name = "Klasa ekonomiczna";
            NameAndPrice = "Ekonomiczna " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Klasa ekonomiczna - w klasie ekonomicznej Emirates dostajesz o wiele więcej\n\nNasza klasa ekonomiczna\nW klasie ekonomicznej Emirates możesz oczekiwać więcej dzięki tysiącom kanałów, połączeniu Wi - Fi na pokładzie i daniom kuchni " +
                "regionalnej.\n\nPoczuj smak miejsca, do którego lecisz\nWybierz regionalne dania z pokładowego menu i delektuj się potrawami, które zabiorą Cię w podróż po świecie.\n\nOdkryj tysiące kanałów\nOglądaj komedie, thrillery i romanse na pokładzie. " +
                "Wybieraj spośród najnowszych filmów i seriali.\n\nWznieś toast\nDobierz do posiłku któryś z darmowych napojów.\n\nMali podróżni\nMali podróżnicy ucieszą się z naszej rozrywki non‑stop: od kreskówek po klasyczne filmy Disneya.";

        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(Price * (passengers + children * 0.65), 2);
        }
    }
}
