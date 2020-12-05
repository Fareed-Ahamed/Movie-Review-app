﻿using MovieAPI.BusinessService;
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
    public class ReviewController : ApiController
    {
        [Route("Reviews/{movieId}")]
        [HttpGet]
        public List<MovieReviews> GetAllReviewsOfMovie(int movieId)
        {
            IReviewInterFace movieBusinessService = new ReviewBusinessService();
            return movieBusinessService.GetAllReviewsOfMovie(movieId);
        }
        [Route("AddReview")]
        [HttpPost]
        public bool AddMovieReview(MovieReviews movieReview)
        {
            IReviewInterFace movieBusinessService = new ReviewBusinessService();
            return movieBusinessService.AddMovieReview(movieReview);
        }
    }
}