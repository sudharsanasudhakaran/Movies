using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.DTO;
using Movies.Models;
using Movies.Request;

namespace Movies.Repositories
{
    public interface IMovieRepository
    {
        List<Languages> AllLanguages();

        List<MovieDTO> MovieByLanguage(int langId);
        List<ReviewDTO> GetReviewsByMovieId(int MovId);
        bool AddRev(AddReview request);
    }
}
