using MovieAPI.BusinessService;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovieController : ApiController
    {
        [Route("movies")]
        [HttpGet]
        public List<Movies> GetAllMovies()
        {
            IMovieInterface movieBusinessService = new MovieBusinessService();
            return movieBusinessService.GetAllMovies();
        }
        [Route("CreateMovie")]
        [HttpPost]
        public bool AddMovie(Movies movie)
        {
            IMovieInterface movieBusinessService = new MovieBusinessService();
            return movieBusinessService.AddMovie(movie);
        }
        [Route("UpdateMovie")]
        [HttpPut]
        public bool UpdateMovie(Movies movie)
        {
            IMovieInterface movieBusinessService = new MovieBusinessService();
            return movieBusinessService.UpdateMovie(movie);
        }
        [Route("DeleteMovie/{movieId}")]
        [HttpPost]
        public bool DeleteMovie(int movieId)
        {
            IMovieInterface movieBusinessService = new MovieBusinessService();
            return movieBusinessService.DeleteMovie(movieId);
        }
    }
}