using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;



namespace Projekt
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }

        private string connectionString = "SERVER=127.0.0.1;DATABASE=loty;UID=root;PASSWORD=pR0tuberancj@915";

        public User(string name, string surame, string email, string password, string birthday, string phoneNumber)
        {
            Name = name;
            Surname = surame;
            Email = email;
            Password = password;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
        }


        public bool Check()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select Email from users where Email = " + "'" + Email + "'", connection);
            connection.Open();
            if (cmd.ExecuteScalar() == null)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public void SaveToDataBase()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Insert into users(Name, Surname, Email, Password, Birth, PhoneNumber) " + 
                "VALUES (" + "'" + Name + "', '" + Surname + "', '" + Email + "', '" + Password + "', '" + Birthday + "', '" + PhoneNumber + "')", connection);

            connection.Open ();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

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
                Name = rdr["Name"].ToString();
                Surname = rdr["Surname"].ToString();
                Birthday = rdr["Birth"].ToString();
                PhoneNumber = rdr["PhoneNumber"].ToString();
            }
            connection.Close();
            return true;
        }

        public void GetData()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select * from users where Email = '" + Email + "' and Password = '" + Password + "'", connection);
            connection.Open();
        }

    }
}
