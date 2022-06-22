using System;

namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę value w lini lotniczej RyanAir
    /// </summary>
    public class RyanAir_Value : RyanAir
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public RyanAir_Value(BasicFlight bf) : base(bf)
        {
            Name = "Value";
            NameAndPrice = "Value " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Klasa Value\n\nPodróżuj z małym bagażem! \nTaryfa value pozwala na podróż z tylko 1 małym bagażem - bagaż musi się zmieścić " +
                "pod siedzeniem (40cm x 20cm x 25cm) \n\n" +
                "Jeśli zależy Ci na tanim transporcie, a wygody nie są dla Ciebie priorytetem, ten standard jest właśnie dla Ciebie. ";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(Price * (passengers + children * 0.85),2);
        }
    }
}
