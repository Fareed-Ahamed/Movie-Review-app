using MovieAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.DBAccess
{
    public class UserTableAccess
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public UserTableAccess()
        {
            Initialize();
        }
        private void Initialize()
        {
            server = "localhost";
            database = "movieapp";
            uid = "root";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        public string CheckUser(User user)
        {
            User user1 = new User();
            string query = "SELECT * FROM login WHERE uname = @userName";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@userName", user.Username);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                user1.Username = dataReader["uname"].ToString();
                user1.Password = dataReader["password"].ToString();
                user1.Role = dataReader["role"].ToString();
            }
            dataReader.Close();
            connection.Close();

            if(string.IsNullOrEmpty(user1.Username))
            {
                return string.Empty;
            }
            else
            {
                return user1.Role;
            }
        }
    }
}