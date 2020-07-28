using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Repositories;
using Movies.Request;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
       
            private readonly IMovieRepository repository;

            public MovieController(IMovieRepository repository)

            {
                this.repository = repository;
            }

            [HttpGet("AllLanguages")]

            public IActionResult Languages()
            {
                return Ok(repository.AllLanguages());
            }

            [HttpGet("MoviesByLanguage/{LanguageId}")]
            public IActionResult MovieByLanguage(int LanguageId)
            {
                return Ok(repository.MovieByLanguage(LanguageId));
            }

            [HttpGet("Reviews/{MovieId}")]
            public IActionResult ReviewByMovieId(int MovieId)
            {
                return Ok(repository.GetReviewsByMovieId(MovieId));
            }


            [HttpPost("AddReview")]
            public IActionResult AddGrade(AddReview data)
            {
                return Ok(repository.AddRev(data));
            }
        }
    }

