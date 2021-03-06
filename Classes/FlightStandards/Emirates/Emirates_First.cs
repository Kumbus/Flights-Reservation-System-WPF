using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę pierwszą w lini lotniczej Emirates
    /// </summary>
    public class Emirates_First : Emirates
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public Emirates_First(BasicFlight bf) : base(bf)
        {
            Name = "Pierwsza klasa";
            NameAndPrice = "Pierwsza klasa " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Emirates - lataj we własnym stylu w pierwszej klasie\n\nPrywatna kabina\nZasuń drzwi, przygaś światło i zrelaksuj się w prywatnym kinie.\n\nWyśpij się pod gwiazdami\nPrzekształć swój fotel w całkowicie płaskie łóżko i poproś personel" +
                " o przygotowanie pościeli, aby móc się wygodnie wyspać.\n\nDelektuj się wybornymi posiłkami\nOd wykwintnych dań a la carte po smaczne przekąski... Odkryj naszą spersonalizowaną ofertę gastronomiczną.\n\nPrzyleć na miejsce odświeżony\nOdzyskaj " +
                "energię w spa z prysznicem na pokładzie. Skorzystaj z naszych ekskluzywnych zestawów kosmetyków Emirates Private Collection Bvlgari.\n\nNajlepsza pierwsza klasa na świecie w 2020 r.\nPrywatność, wykwintne potrawy, bary koktajlowe" +
                " i spa z prysznicem na wysokości 12 km – lepiej nie będzie nigdzie indziej.Lataj z nami w najlepszej pierwszej klasie na świecie w 2020 r.według użytkowników portalu TripAdvisor.";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(11.1 * Price * (passengers + children * 0.65), 2);
        }
    }
}
