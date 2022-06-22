using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę ekonomiczną w lini lotniczej Lufthansa
    /// </summary>
    public class Lufthansa_Economy : Lufthansa
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public Lufthansa_Economy(BasicFlight bf) : base(bf)
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
            return "Krótka lub długa podróż – zawsze wygodnie w Klasie Ekonomicznej\nPodróżując na trasach krótkich i średniej długości będziesz miał dużo miejsca. " +
                "Dzięki lżejszej konstrukcji oparć foteli, także w Klasie Ekonomicznej masz więcej miejsca na wygodne rozprostowanie nóg. Na trasach dalekiego zasięgu " +
                "zarówno wygodny fotel o szerokości siedziska ponad 40 cm, jak również indywidualnie regulowany zagłówek w każdym fotelu, zapewniają komfortowe warunki " +
                "podróży.\n\nRozrywka na pokładzie\nPodczas rejsów możesz w pełni skorzystać z naszego bogatego programu rozrywki na pokładzie. " +
                "Czekają na Ciebie najnowsze filmy, międzynarodowe stacje radiowe i duży wybór programów telewizyjnych. " +
                "Usiądź wygodnie i baw się dobrze podczas podróży!\n\nPosiłki i napoje\nNa pokładzie oferujemy posiłki dostosowane do pory dnia i miejsca dolecowego. " +
                "Do posiłków podajemy bogaty wybór napojów. Na wybranych trasach podajemy również przekąskę podczas trwania pokładowego programu rozrywkowego.";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(Price * (passengers + children * 0.75), 2);
        }
    }
}
