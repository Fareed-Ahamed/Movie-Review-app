using MovieAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.DBAccess
{
    public class ReviewTableAccess
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public ReviewTableAccess()
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
        public List<MovieReviews> GetAllReviewsOfMovie(int movieId)
        {
            List<MovieReviews> movieReviews = new List<MovieReviews>();
            string query = "SELECT * FROM review WHERE mid = @movieId";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@movieId", movieId);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                MovieReviews movieReview = new MovieReviews
                {
                    Id = (int)dataReader["id"],
                    MovieId = (int)dataReader["mid"],
                    UserName = dataReader["uname"].ToString(),
                    Review = dataReader["review"].ToString()
                };
                movieReviews.Add(movieReview);
            }
            dataReader.Close();
            connection.Close();
            return movieReviews;
        }
        public bool AddReview(MovieReviews movieReview)
        {
            string query = "INSERT INTO review(mid,uname,review) values(@mid,@uname,@review)";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mid", movieReview.MovieId);
            cmd.Parameters.AddWithValue("@uname", movieReview.UserName);
            cmd.Parameters.AddWithValue("@review", movieReview.Review);
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