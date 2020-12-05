using MovieAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.DBAccess
{
    public class MovieTableAccess
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public MovieTableAccess()
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
        public List<Movies> GetAllMovies()
        {
            List<Movies> movies = new List<Movies>();
            string query = "SELECT * FROM movie";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Movies movie = new Movies
                {
                    Id = (int)dataReader["id"],
                    MovieName = dataReader["mname"].ToString(),
                    Genre = dataReader["genre"].ToString(),
                    Synopsis = dataReader["synopsis"].ToString()
                };
                movies.Add(movie);
            }
            dataReader.Close();
            connection.Close();
            return movies;
        }
        public bool AddMovie(Movies movie)
        {
            string query = "INSERT INTO movie(mname,genre,synopsis) values(@mname,@genre,@synopsis)";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mname", movie.MovieName);
            cmd.Parameters.AddWithValue("@genre", movie.Genre);
            cmd.Parameters.AddWithValue("@synopsis", movie.Synopsis);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            if(result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool UpdateMovie(Movies movie)
        {
            string query = "UPDATE movie SET mname = @mname ,genre = @genre, synopsis = @synopsis WHERE id = @id";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", movie.Id);
            cmd.Parameters.AddWithValue("@mname", movie.MovieName);
            cmd.Parameters.AddWithValue("@genre", movie.Genre);
            cmd.Parameters.AddWithValue("@synopsis", movie.Synopsis);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DeleteMovie(int id)
        {
            string query = "DELETE FROM movie WHERE id = @id";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}