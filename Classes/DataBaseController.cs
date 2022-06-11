using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class DataBaseController
    {

        private readonly string connectionString = "SERVER=127.0.0.1;DATABASE=loty;UID=root;PASSWORD=pR0tuberancj@915";
        public string GetSeats(BasicFlight flight)
        {
            string seatsString = "";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select SeatsLayout from flights where ID = '" + flight.FlightNumber + "'", connection);
            connection.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                seatsString = rdr["SeatsLayout"].ToString();
            }
            rdr.Close();
            connection.Close();
            return seatsString;
        }

        public void UpdateAfterPurchase(BasicFlight flight, List<Seat> chosenSeats)
        {
            string newLayout = ChangeSeatsLayout(flight, chosenSeats);
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE flights SET Seats = " + (flight.Seats - flight.passengersNumber - flight.childrenNumber) + 
                " , SeatsLayout = '" + newLayout + "' WHERE ID = '" + flight.FlightNumber + "'", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private string ChangeSeatsLayout(BasicFlight flight, List<Seat> chosenSeats)
        {
            StringBuilder layout = new StringBuilder(flight.seatsString, flight.seatsString.Length);
            int l;

            for (int j = 0; j < chosenSeats.Count; j++)
            {
                l = 0;
                char classSign = chosenSeats[j].Number[0];
                int index = Int32.Parse(chosenSeats[j].Number.Substring(1));
                for (int i = 0; i < layout.Length; i++)
                {

                    if (classSign != layout[i])
                        continue;

                    l++;

                    if (l == index)
                        layout.Replace("0", "1", i + 1, 1);

                }
            }

            return layout.ToString();

        }

        public void LoadLoggedUserFlight(BasicFlight flight, User user, List<Seat> chosenSeats)
        {
            string seats = MakeSeatsString(chosenSeats);
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO logged_users_flights (Flight_ID, User_ID, Passengers, Children, Seats) " +
                "VALUES ('" + flight.FlightNumber + "', '" + user.Id + "', '" + flight.passengersNumber + "', '" + flight.childrenNumber + "', '" + seats + "')", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void LoadUnloggedUserFlight(BasicFlight flight, string name, string surname, string email, string phoneNumber, string date, List<Seat> chosenSeats)
        {
            string seats = MakeSeatsString(chosenSeats);
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO anonymous_users_flights (Flights_ID, Passengers, Children, Seats, Name, Surname, Email, Birthday, Phone) " +
                "VALUES ('" + flight.FlightNumber + "', '" + flight.passengersNumber + "', '" + flight.childrenNumber + "', '" + seats + "', '" + name + "', '" + surname + "', '"
                + email + "', '" + date + "', '" + phoneNumber + "')", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private string MakeSeatsString(List<Seat> chosenSeats)
        {
            string seatsString = "";

            for (int i = 0; i < chosenSeats.Count; i++)
                seatsString += chosenSeats[i].Number;

            return seatsString;
        }

        public ObservableCollection<BasicFlight> AddFlightToAccount(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM flights INNER JOIN logged_users_flights ON flights.ID = Flight_ID where logged_users_flights.User_ID = " + id, connection);
            connection.Open();

            MySqlDataReader rdr = cmd.ExecuteReader();

            ObservableCollection<BasicFlight> Flights = new ObservableCollection<BasicFlight>();
            while (rdr.Read())
            {
                BasicFlight flight = new BasicFlight();
                flight.DeparturePlace = rdr["DeparturePlace"].ToString();
                flight.DestinationPlace = rdr["DestinationPlace"].ToString();
                flight.Date = rdr["Date"].ToString();
                flight.FlightNumber = rdr["ID"].ToString();
                flight.Seats = Int32.Parse(rdr["Seats"].ToString());
                flight.Airline = rdr["Airline"].ToString();
                flight.DepartureTime = rdr["DepartureTime"].ToString().Substring(0, 5);
                flight.DestinationTime = rdr["DestinationTime"].ToString().Substring(0, 5);
                flight.FlyTime = rdr["FlyTime"].ToString().Substring(0, 5);
                flight.Price = Int32.Parse(rdr["Price"].ToString());

                Flights.Add(flight);
            }
            connection.Close();

            return Flights;
            
        }
    }
}
