using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca za połączenie z bazą danych i wykonywanie na niej operacji
    /// </summary>
    public class DataBaseController
    {
        /// <summary>
        /// Mutex używany do blokowania dostępu do bazy danych przez dwa różne wątki
        /// </summary>
        private Mutex mutex = new Mutex();
        /// <summary>
        /// Dane pozwalające połączyć się z bazą danych
        /// </summary>
        private readonly string connectionString = "SERVER=127.0.0.1;DATABASE=loty;UID=root;PASSWORD=pR0tuberancj@915";
        /// <summary>
        /// Pobiera z bazy danych string odpowidający siedzeniom
        /// </summary>
        /// <param name="flight">Lot, z którego pobierane są siedzenia</param>
        /// <returns>String odpowidający ustawieniu siedzeń</returns>
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
        /// <summary>
        /// Aktualizuje informacje o locie w bazie danych po dokonaniu rezerwacji
        /// </summary>
        /// <param name="flight">Lot, w którym zostały zarezerwowane miejsca</param>
        /// <param name="chosenSeats">Miejsca wybrane podczas rezerwacji</param>
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
        /// <summary>
        /// Zmienia konfigurację krzeseł po zakupie
        /// </summary>
        /// <param name="flight">Lot, w którym jest zmieniana konfiguracja</param>
        /// <param name="chosenSeats">Fotele wybrane podczas rezerwacji</param>
        /// <returns>Zaktualizowana konfiguracja foteli</returns>
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
        /// <summary>
        /// Dodaje lot zarezerwowany przez zalogowanego użytkownika do bazy danych i łączy go z tym kontem
        /// </summary>
        /// <param name="flight">Lot, którego doytyczy rezerwacja</param>
        /// <param name="user">Użytkownik, który dokonał rezerwacji</param>
        /// <param name="chosenSeats">Miejsca wybrane podczas rezerwacji</param>
        public void LoadLoggedUserFlight(BasicFlight flight, User user, List<Seat> chosenSeats)
        {
            string seats = MakeSeatsString(chosenSeats);
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO logged_users_flights (Flight_ID, User_ID, Passengers, Children, ChosenSeats) " +
                "VALUES ('" + flight.FlightNumber + "', '" + user.Id + "', '" + flight.passengersNumber + "', '" + flight.childrenNumber + "', '" + seats + "')", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Dodaje lot zarezerwowany przez niezalogowanego użytkownika do bazy danych i łączy go z danymi podanymi przy rezerwacji 
        /// </summary>
        /// <param name="flight">Lot, którego doytyczy rezerwacja</param>
        /// <param name="name">Imię użytkownika</param>
        /// <param name="surname">Nazwisko użytownika</param>
        /// <param name="email">Email użytkownika</param>
        /// <param name="phoneNumber">Numer telefonu użytkownika</param>
        /// <param name="date">Data urodzenia użytkownika</param>
        /// <param name="chosenSeats">Miejsca wybrane podczas rezerwacji</param>
        public void LoadUnloggedUserFlight(BasicFlight flight, string name, string surname, string email, string phoneNumber, string date, List<Seat> chosenSeats)
        {
            string seats = MakeSeatsString(chosenSeats);
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO anonymous_users_flights (Flights_ID, Passengers, Children, ChosenSeats, Name, Surname, Email, Birthday, Phone) " +
                "VALUES ('" + flight.FlightNumber + "', '" + flight.passengersNumber + "', '" + flight.childrenNumber + "', '" + seats + "', '" + name + "', '" + surname + "', '"
                + email + "', '" + date + "', '" + phoneNumber + "')", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Tworzy string, który przechowuje konfigurację foteli na podstawie lsity z wybranymi siedzeniami
        /// </summary>
        /// <param name="chosenSeats">Siedzenia wybrane podczas rezerwacji</param>
        /// <returns></returns>
        private string MakeSeatsString(List<Seat> chosenSeats)
        {
            string seatsString = "";

            for (int i = 0; i < chosenSeats.Count; i++)
                seatsString += chosenSeats[i].Number;

            return seatsString;
        }
        /// <summary>
        /// Pobiera loty użytkownika z bazy danych 
        /// </summary>
        /// <param name="id">Id użytkownika</param>
        /// <returns>Kolekcja lotów, które zarezerwował użytkownik</returns>
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
                flight.childrenNumber = Int32.Parse(rdr["Children"].ToString());
                flight.passengersNumber = Int32.Parse(rdr["Passengers"].ToString());
                flight.BookedSeatsString = rdr["ChosenSeats"].ToString();
                flight.seatsString = rdr["SeatsLayout"].ToString();

                Flights.Add(flight);
            }
            connection.Close();

            return Flights;
            
        }
        /// <summary>
        /// Metoda rozpoczynająca sekwencję metod, które anulują rezerwację lotu
        /// </summary>
        /// <param name="flightNumber">Numer lotu, którego rezerwacja jest anulowana</param>
        /// <param name="flight">Lot, którego rezerwacja jest anulowana</param>
        /// <param name="id">ID użytkownika, który anuluje zarezerwowany wcześniej lot</param>
        /// <returns>Kolekcja lotów użytkownika po anulowaniu lotu</returns>
        public ObservableCollection<BasicFlight> CancelMethods(string flightNumber, BasicFlight flight, int id)
        {
            ObservableCollection<BasicFlight> flights = new ObservableCollection<BasicFlight>();
            Thread t1 = new Thread(() => DeleteFromFlights(flightNumber));
            t1.Start();
            Thread t2 = new Thread(() => UptdateAfterCancellation(flight));
            t2.Start();
            Thread t3 = new Thread(() => flights = AddFlightToAccount(id));
            t1.Join();
            t2.Join();

            t3.Start();
            return flights;
        }
        /// <summary>
        /// Usuwa lot z zarezerwowanych lotów w bazie danych
        /// </summary>
        /// <param name="flightNumber">Numer lotu, którego rezerwacja jest anulowana</param>
        public void DeleteFromFlights(string flightNumber)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM logged_users_flights WHERE Flight_Id = '" + flightNumber + "' AND User_ID = " + AccountPageViewModel.User.Id
                , connection);
            mutex.WaitOne();
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            mutex.ReleaseMutex();
        }
        /// <summary>
        /// Aktualizuje informacje o locie w bazie danych po anulowaniu rezerwacji
        /// </summary>
        /// <param name="flight">Lot, którego rezerwacja jest anulowana</param>
        public void UptdateAfterCancellation(BasicFlight flight)
        {
            string newLayout = ChangeSeatsLayoutAfterCancellation(flight);
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("UPDATE flights SET Seats = " + (flight.Seats + flight.passengersNumber + flight.childrenNumber) +
                " , SeatsLayout = '" + newLayout + "' WHERE ID = '" + flight.FlightNumber + "'", connection);
            mutex.WaitOne();
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            mutex.ReleaseMutex();
        }
        /// <summary>
        /// Aktualizuje string odpowiadający konfiguracji foteli po anulowaniu rezerwacji
        /// </summary>
        /// <param name="flight">Lot, którego rezerwacja jest anulowana</param>
        /// <returns>Zaktualizowany string odpowiadający konfiguracji foteli</returns>
        private string ChangeSeatsLayoutAfterCancellation(BasicFlight flight)
        {
            StringBuilder layout = new StringBuilder(flight.seatsString, flight.seatsString.Length);
            string seats = flight.BookedSeatsString;
            int l;

            for (int j = 0; j < seats.Length; j++)
            {
                if (seats[j] < 65 || seats[j] > 90)
                    continue;

                l = 0;
                char classSign = seats[j];
                string indexString = "";
                indexString = indexString + seats[j + 1];
                if (j < seats.Length - 2 && (seats[j + 2] < 65 || seats[j + 2] > 90)) 
                    indexString = indexString + seats[j + 2];    
                int index = Int32.Parse(indexString);
                for (int i = 0; i < layout.Length; i++)
                {

                    if (classSign != layout[i])
                        continue;

                    l++;

                    if (l == index)
                        layout.Replace("1", "0", i + 1, 1);

                }
            }

            return layout.ToString();
        }
        /// <summary>
        /// Usuwa konto użytkwnika z bazy danych
        /// </summary>
        /// <param name="email">Email użytkownika, którego konto jest usuwane</param>
        public void DeleteAccount(string email)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Delete from users where Email = '" + email + "'", connection);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
