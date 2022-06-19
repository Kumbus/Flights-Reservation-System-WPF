using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projekt
{
    /// <summary>
    /// Klasa bazowa dla wszystkich lotów
    /// </summary>
    public class BasicFlight
    {
        public string FlightNumber { get; set; }
        public string DeparturePlace { get; set; }
        public string DestinationPlace { get; set; }
        public string Date { get; set; }
        public int Seats { get; set; }

        public int passengersNumber;

        public int childrenNumber;
        public string Airline { get; set; }
        public string DepartureTime { get; set; }
        public string DestinationTime { get; set; }
        public string FlyTime { get; set; }
        public double Price { get; set; }

        public virtual int classAmount { get; set; }

        public virtual string Name { get; set; }
        public virtual string NameAndPrice { get; set; }
        public virtual string seatsString { get; set; }
        public string BookedSeatsString { get; set; }

        public BasicFlight() { }
        public BasicFlight(string departurePlace, string destinationPlace, string date, int seats, int passengers, int children)
        {
            DeparturePlace = departurePlace;
            DestinationPlace = destinationPlace;
            Date = date;
            Seats = seats;
            passengersNumber = passengers;
            childrenNumber = children;
        }

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

        public virtual string Describe()
        {
            return "Cudowny lot";
        }

        public virtual int HowManyClasses()
        {
            return classAmount;
        }

        public virtual List<BasicFlight> GenerateDerived()
        {
            return new List<BasicFlight>();
        }

        public virtual List<ObservableCollection<Seat>> GetSeats()
        {
            return null;
        }
        public virtual double GetPrice(int passengers, int children)
        {
            return 0;
        }

    }
}
