using MovieAPI.DBAccess;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.BusinessService
{
    public interface IMovieInterface
    {
        List<Movies> GetAllMovies();
        bool AddMovie(Movies movie);
        bool UpdateMovie(Movies movie);
        bool DeleteMovie(int movieId);
        bool AddReview(Movies movie);
    }
    public class MovieBusinessService : IMovieInterface
    {
        MovieTableAccess movieTableAccess;
        public MovieBusinessService()
        {
            movieTableAccess = new MovieTableAccess();
        }
        public bool AddMovie(Movies movie)
        {
            return movieTableAccess.AddMovie(movie);
        }

        public bool AddReview(Movies movie)
        {
            return true;
        }

        public bool DeleteMovie(int movieId)
        {
            return movieTableAccess.DeleteMovie(movieId);
        }

        public List<Movies> GetAllMovies()
        {

            return movieTableAccess.GetAllMovies();
        }

        public bool UpdateMovie(Movies movie)
        {
            return movieTableAccess.UpdateMovie(movie);
        }
    }
}