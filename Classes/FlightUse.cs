using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;

namespace Projekt
{
    public class FlightUse
    {
        public static ObservableCollection<BasicFlight>? Flights { get; set; }
        public static string Indeks { get; set; }
        public void Search(BasicFlight flightToSearch)
        {
            string connectionString = "SERVER=127.0.0.1;DATABASE=loty;UID=root;PASSWORD=pR0tuberancj@915";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select * from flights where DeparturePlace = '" + flightToSearch.DeparturePlace + "' and DestinationPlace = '" + flightToSearch.DestinationPlace +
                "' and Date = '" + flightToSearch.Date + "' and Seats >= " + flightToSearch.Seats, connection);
            connection.Open();

            MySqlDataReader rdr = cmd.ExecuteReader();
            
            Flights = new ObservableCollection<BasicFlight>();
            while (rdr.Read())
            {
                BasicFlight flight = new BasicFlight(flightToSearch.DeparturePlace, flightToSearch.DestinationPlace, flightToSearch.Date, flightToSearch.Seats, flightToSearch.passengersNumber, flightToSearch.childrenNumber);
                flight.FlightNumber = rdr["ID"].ToString();
                flight.Seats = Int32.Parse(rdr["Seats"].ToString());
                flight.Airline = rdr["Airline"].ToString();
                flight.DepartureTime = rdr["DepartureTime"].ToString().Substring(0, 5);
                flight.DestinationTime = rdr["DestinationTime"].ToString().Substring(0, 5);
                flight.FlyTime = rdr["FlyTime"].ToString().Substring(0, 5);
                flight.Price = Int32.Parse(rdr["Price"].ToString());
                

                if(flight.Airline == "LOT")
                {
                    Lot lot = new Lot(flight);
                    Flights.Add(lot);
                }
                else if(flight.Airline == "Emirates")
                {
                    Emirates emirates = new Emirates(flight);
                    Flights.Add(emirates);
                }
                else if (flight.Airline == "RyanAir")
                {
                    RyanAir ryanAir = new RyanAir(flight);
                    Flights.Add(ryanAir);
                }
                else if (flight.Airline == "Lufthansa")
                {
                    Lufthansa lufthansa = new Lufthansa(flight);
                    Flights.Add(lufthansa);
                }



            }
            connection.Close();

        }

        public static BasicFlight FindOne()
        {
            for(int i = 0; i < Flights.Count; i++)
            {
                if(Flights[i].FlightNumber == Indeks)
                {
                    return Flights[i];
                }
            }

            return null;
        }

 

    }
}
