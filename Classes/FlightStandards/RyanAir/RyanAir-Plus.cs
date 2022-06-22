using System;
///
namespace Projekt
{
    /// <summary>
    /// Klasa reprezentująca klasę plus w lini lotniczej RyanAir
    /// </summary>
    public class RyanAir_Plus : RyanAir
    {
        /// <summary>
        /// Konstruktor kopiujący po klasie bazowej
        /// </summary>
        public RyanAir_Plus(BasicFlight bf) : base(bf)
        {
            Name = "Plus";
            NameAndPrice = "Plus " + GetPrice(passengersNumber, childrenNumber) + " zł";
        }
        /// <summary>
        /// Metoda opisująca klasę podróży 
        /// </summary>
        /// <returns>Opis klasy podróży</returns>
        public override string Describe()
        {
            return "Klasa Plus\n\nŚwietne rozwiązanie na dłuższe podróże!\nPakiet Plus został opracowany z myślą o dłuższych podróżach. " +
                "Obejmuje bagaż rejestrowany do 20 kg, rezerwację miejsc oraz bezpłatną odprawę na lotnisku, aby podróż przebiegła bezproblemowo.\n\n" +
                "Spakuj wszystko, czego Ci trzeba!\nDodatkowo do dyspozycji masz bagaż rejestrowany do 20 kg, w którym możesz zabrać " +
                "ze sobą wszystko, czego potrzebujesz na dłuższą podróż. Zabierz wszystkie niezbędne rzeczy i nie martw się o brak miejsca na pamiątki!\n\n" +
                "Wybierz ulubione miejsce!\nPakiet Plus obejmuje rezerwację miejsc, które zapewnią wygodę siedzenia. " +
                "Chcesz zająć miejsce przy przejściu lub przy oknie? Wybierz ulubione, aby podróżować jak najwygodniej!";
        }
        /// <summary>
        ///  Metoda obliczająca cenę dla tej klasy podróży
        ///  <param name="passengers">Liczba dorosłych pasażerów</param>
        ///  <param name="children">Liczba dzieci</param>
        ///  <returns>Cena lotu</returns>
        /// </summary
        public override double GetPrice(int passengers, int children)
        {
            return Math.Round(2 * Price * (passengers + children * 0.85), 2);
        }

    }
}
