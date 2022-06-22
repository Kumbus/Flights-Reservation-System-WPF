using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projekt
{
    /// <summary>
    /// Klasa bazowa dla wszystkich lotów
    /// </summary>
    public class BasicFlight
    {
        /// <summary>
        /// Właściwość przechowująca numer lotu
        /// </summary>
        public string FlightNumber { get; set; }
        /// <summary>
        /// Właściwość przechowująca miejsce odlotu
        /// </summary>
        public string DeparturePlace { get; set; }
        /// <summary>
        /// Właściwość przechowująca miejsce przylotu
        /// </summary>
        public string DestinationPlace { get; set; }
        /// <summary>
        /// Właściwość przechowująca datę lotu
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Właściwość przechowująca liczbę dostępnych miejsc
        /// </summary>
        public int Seats { get; set; }
        /// <summary>
        /// Właściwość przechowująca liczbę dorosłych pasażerów podczas rezerwowania lotu
        /// </summary>
        public int passengersNumber;
        /// <summary>
        /// Właściwość przechowująca liczbę dzieci podczas rezerwowania lotu
        /// </summary>
        public int childrenNumber;
        /// <summary>
        /// Właściwość przechowująca nazwę lini lotniczej lotu
        /// </summary>
        public string Airline { get; set; }
        /// <summary>
        /// Właściwość przechowująca godzinę odlotu
        /// </summary>
        public string DepartureTime { get; set; }
        /// <summary>
        /// Pole przechowujące godzinę przylotu
        /// </summary>
        public string DestinationTime { get; set; }
        /// <summary>
        /// Właściwość przechowująca czas lotu
        /// </summary>
        public string FlyTime { get; set; }
        /// <summary>
        /// Właściwość przechowująca cenę do zapłaty za lot
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Właściwość przechowująca liczbę klas podróży w klasach pochodnych
        /// </summary>
        public virtual int classAmount { get; set; }
        /// <summary>
        /// Właściwość przechowująca nazwę klasy podróży lotu w klasach pochodnych
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Właściwość przechowująca nazwę klasy podóży lotu i cenę w klasach pochodnych
        /// </summary>
        public virtual string NameAndPrice { get; set; }
        /// <summary>
        /// Właściwość przechowująca konfigurację siedzeń w samolocie w klasach pochodnych
        /// </summary>
        public virtual string seatsString { get; set; }
        /// <summary>
        /// Właściwość przechowująca nazwy foteli zarezerwowanych przez użytkownika dla danego lotu
        /// </summary>
        public string BookedSeatsString { get; set; }
        /// <summary>
        /// Konstruktor bezargumentowy 
        /// </summary>
        public BasicFlight() { }
        /// <summary>
        /// Konstruktor przyjmujący podstawowe dane lotu
        /// </summary>
        public BasicFlight(string departurePlace, string destinationPlace, string date, int seats, int passengers, int children)
        {
            DeparturePlace = departurePlace;
            DestinationPlace = destinationPlace;
            Date = date;
            Seats = seats;
            passengersNumber = passengers;
            childrenNumber = children;
        }
        /// <summary>
        /// Konstrukor kopiujący
        /// </summary>
        public BasicFlight(BasicFlight bf)
        {
            FlightNumber = bf.FlightNumber;
            DeparturePlace = bf.DeparturePlace;
            DestinationPlace = bf.DestinationPlace;
            Date = bf.Date;
            Seats = bf.Seats;
            Airline = bf.Airline;
            DepartureTime = bf.DepartureTime;
            DestinationTime = bf.DestinationTime;
            FlyTime = bf.FlyTime;
            Price = bf.Price;
            passengersNumber = bf.passengersNumber;
            childrenNumber = bf.childrenNumber;
        }
        /// <summary>
        ///  Metoda wirtualna opisująca klasy podróży w klasach pochodnych
        ///  <returns>Opis klasy podróży</returns>
        /// </summary>
        public virtual string Describe()
        {
            return "Cudowny lot";
        }
        /// <summary>
        ///  Metoda wirtualna licząca ile klas podróży mają klasy pochodne
        ///  <returns>Liczba klas podróży</returns>
        /// </summary>
        public virtual int HowManyClasses()
        {
            return classAmount;
        }
        /// <summary>
        ///  Metoda wirtualna zwracająca klasy pochodne dla klas pochodnych
        ///  <returns>Lista zawierająca obiekty klas pochodnych</returns>
        /// </summary>
        public virtual List<BasicFlight> GenerateDerived()
        {
            return new List<BasicFlight>();
        }
        /// <summary>
        ///  Metoda wirtualna zwracająca konfigurację siedzeń 
        ///  <returns>Lista obserwowalnych kolekcji gdzie każda jest ułożenie foteli w danej klasie podróży</returns>
        /// </summary>
        public virtual List<ObservableCollection<Seat>> GetSeats()
        {
            return null;
        }
        /// <summary>
        ///  Metoda wirtualna obliczjąca cenę za zarezerwowane bilety
        ///  <returns>Cena za bilety</returns>
        /// </summary>
        public virtual double GetPrice(int passengers, int children)
        {
            return 0;
        }

    }
}
