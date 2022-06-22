using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę regular w lini lotniczej RyanAir
    /// </summary>
    public class RyanAir_Regualar : RyanAir
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public RyanAir_Regualar(BasicFlight bf) : base(bf)
        {
            Name = "Regular";
            NameAndPrice = "Regular " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Klasa Regular\n\nPakiet regular to idealne rozwiązanie podczas krótkich wyjazdów!\nPakiet Regular został opracowany z myślą o zapewnieniu najlepszej oferty dla pasażerów podróżujących " +
                "na krótkich trasach. Obejmuje pierwszeństwo wejścia i 2 sztuki bagażu podręcznego oraz zarezerwowanie miejsca, aby zapewnić Ci szybką obsługę i komfortową podróż. \n\n" +
                "Pierwszeństwo wejścia i 2 sztuki bagażu podręcznego! \n" +
                "Dzięki pierwszeństwu wejścia i 2 sztukom bagażu podręcznego podróż z Ryanair jest sprawna i przyjemna. Możesz wejść na pokład i rozsiąść się wygodnie, zanim zrobią to inni." +
                "Nie musisz też czekać na bagaż podręczny po wylądowaniu.\n\n" +
                "Wybierz ulubione miejsce!\nPakiet Regular obejmuje rezerwację miejsc, które zapewnią wygodę siedzenia. Chcesz zająć miejsce przy przejściu lub przy oknie? Wybierz ulubione, aby podróżować jak najwygodniej!";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(1.45 * Price * (passengers + children * 0.85), 2);
        }
    }
}
