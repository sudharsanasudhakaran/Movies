using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.DTO;
using Movies.Models;
using Movies.Request;

namespace Movies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext db;

        public MovieRepository(MovieDbContext _db)
        {
            this.db = _db;
        }

        public List<Languages> AllLanguages()
        {
            return db.Languages.ToList();
        }

        public List<MovieDTO> MovieByLanguage(int langId)
        {

            var movies = db.Movies.Include("Language").Where(a => a.Language.Id == langId).ToList();
            List<MovieDTO> movieData = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                movieData.Add(new MovieDTO
                {
                    MovieName = movie.Name,
                    MovieLanguage = movie.Language.Language
                });
            }

            return movieData;


        }
        public bool AddRev(AddReview request)
        {
            if (request.Reviews != null && request.MovId > 0)
            {
                var mov = db.Movies.Where(a => a.MovieId == request.MovId).FirstOrDefault();

                Reviews review = new Reviews();
                review.Review = request.Reviews;
                review.Movie = mov;
                db.Reviews.Add(review);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<ReviewDTO> GetReviewsByMovieId(int MovId)
        {
            var reviews = db.Reviews.Include("Movie").Where(a => a.Movie.MovieId == MovId).ToList();
            List<ReviewDTO> reviewData = new List<ReviewDTO>();

            foreach (var review in reviews)
            {
                reviewData.Add(new ReviewDTO
                {
                    RevId = review.Id,
                    ReviewContent = review.Review,
                    ReviewForMovie = review.Movie.Name
                });
            }
            return reviewData;
        }
    }
}
