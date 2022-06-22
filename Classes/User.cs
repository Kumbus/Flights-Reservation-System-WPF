using MySql.Data.MySqlClient;



namespace Projekt
{
    /// <summary>
    /// Klasa odpowiadająca użytkownikowi korzystajaćemu z aplikacji
    /// </summary>
    public class User
    {
        /// <summary>
        /// Właściwość odpowiadająca ID użytkownika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca imieniu użytkownika
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca nazwisku użytkownika
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca emailowi użytkownika
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca hasłu do konta użytkownika
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca dacie urodzenia użytkownika
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// Właściwość odpowiadająca numerowi telefonu użytkownika
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// String pozwalający na połączenie się z bazą danych
        /// </summary>

        private string connectionString = "SERVER=127.0.0.1;DATABASE=loty;UID=root;PASSWORD=pR0tuberancj@915";
        /// <summary>
        /// Konstruktor przypisujący wszystkie dane
        /// </summary>
        public User(string name, string surame, string email, string password, string birthday, string phoneNumber)
        {
            Name = name;
            Surname = surame;
            Email = email;
            Password = password;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Metoda sprawdzająca w bazie danych czy istnieje już użytkownik na podany adres email
        /// </summary>
        /// <returns>True jeśli nie istnieje konto na podany adres email, false jeśli istnieje</returns>
        public bool Check()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select Email from users where Email = '" + Email + "'", connection);
            connection.Open();
            if (cmd.ExecuteScalar() == null)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        /// <summary>
        /// Metoda zapisująca użytkownika do bazy danych
        /// </summary>
        public void SaveToDataBase()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Insert into users(Name, Surname, Email, Password, Birth, PhoneNumber) " + 
                "VALUES (" + "'" + Name + "', '" + Surname + "', '" + Email + "', '" + Password + "', '" + Birthday + "', '" + PhoneNumber + "')", connection);

            connection.Open ();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Metoda przypisująca użytkownikowi, który się loguje dane z bazy danych po zalogowaniu i sprawdzająca czy istnieje użytkownik o podanym adresie email i haśle
        /// </summary>
        /// <returns>True jeśli użytkownik istnieje i hasło jest poprawne, false jeśli nie istnieje lub zostało podane złe hasło</returns>
        public bool Login()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select Email from users where Email = '" + Email + "' and Password = '" + Password + "'", connection);
            connection.Open();
            if (cmd.ExecuteScalar() == null)
            {
                connection.Close();
                return false;
            }

          
            cmd = new MySqlCommand("Select * from users where Email = '" + Email + "'", connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Id = (int)rdr["ID"];
                Name = rdr["Name"].ToString();
                Surname = rdr["Surname"].ToString();
                Birthday = rdr["Birth"].ToString().Substring(0, 10);
                PhoneNumber = rdr["PhoneNumber"].ToString();
            }
            connection.Close();
            return true;
        }

    }
}
