using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę biznesową w lini lotniczej Lufthansa
    /// </summary>
    public class Lufthansa_Business : Lufthansa
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public Lufthansa_Business(BasicFlight bf) : base(bf)
        {
            Name = "Klasa Biznes";
            NameAndPrice = "Biznes " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Klasa Biznes\nWygodniejsza podróż - rozkoszuj się komfortem i prywatnością w Klasie Biznes Lufthansy, a na miejsce dotrzesz wypoczęty i zrelaksowany. " +
                "Gdziekolwiek podróżujesz, podróżuj w komfortowych warunkach Klasą Biznes Lufthansy. Możliwość korzystania z saloników na lotnisku, priorytetowy boarding, " +
                "większy limit bezpłatnego bagażu i wyjątkowe dania – to wszystko oferujemy naszym pasażerom Klasy Biznes.\n\nPełen relaks od samego startu\nPodróżuj Klasą " +
                "Biznes Lufthansy, a do celu podróży dotrzesz wypoczęty i zrelaksowany.Przed wejściem na pokład odpręż się w jednym z saloników Lufthansa Business Lounge, " +
                "a potem ciesz się znakomitą obsługą na pokładzie. Nowe fotele w Klasie Biznes Lufthansy można zamienić w prawie dwumetrowe płaskie łóżko, zapewniające " +
                "idealny odpoczynek podczas długiej podróży. Otwarty plan kabiny, rozmieszczenie foteli oraz subtelna, naturalna kolorystyka stwarzają poczucie " +
                "przestronności.\n\nRozkosze podniebienia\nW Klasie Biznes oferujemy wyśmienite dania, polecane przez najlepszych szefów kuchni, podawane na porcelanowej " +
                "zastawie.Oprócz tego, zapewniamy bogaty wybór różnych napojów.\n\nRozrywka na pokładzie\nProgram rozrywkowy oferowany w Klasie Biznes pozwoli Ci się " +
                "świetnie bawić ponad chmurami. Program sportowy, ulubiony serial, muzyka - na swoim ekranie sam wybierasz to, na co masz ochotę.\n\nRozrywka na pokładzie\n" +
                "Program rozrywkowy oferowany w Klasie Biznes pozwoli Ci się świetnie bawić ponad chmurami.Program sportowy, ulubiony serial, muzyka - na swoim ekranie sam " +
                "wybierasz to, na co masz ochotę.\n\nLufthansa Welcome Lounge\nW saloniku Lufthansa Welcome Lounge, można znaleźć bistro, jak również luksusowe kabiny " +
                "prysznicowe, aby odświeżyć się po długiej podróży.";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(2.5 * Price * (passengers + children * 0.75), 2);
        }
    }
}
