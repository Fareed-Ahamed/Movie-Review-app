using MovieAPI.DBAccess;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.BusinessService
{
    public interface IReviewInterFace
    {
        List<MovieReviews> GetAllReviewsOfMovie(int movieId);
        bool AddMovieReview(MovieReviews movie);
    }
    public class ReviewBusinessService : IReviewInterFace
    {
        ReviewTableAccess reviewTableAccess;
        public ReviewBusinessService()
        {
            reviewTableAccess = new ReviewTableAccess();
        }
        public bool AddMovieReview(MovieReviews movieReview)
        {
            return reviewTableAccess.AddReview(movieReview);
        }

        public List<MovieReviews> GetAllReviewsOfMovie(int movieId)
        {
            return reviewTableAccess.GetAllReviewsOfMovie(movieId);
        }
    }
}