using BojanDamchevski.MoviesAPI.App.Models;
using BojanDamchevski.MoviesAPI.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.MoviesAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieService _movieService;
        private DirectorService _directorService;
        public MoviesController(MovieService movieService, DirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        [HttpGet("get-all")]
        public ActionResult<List<Movie>> Get()
        {
            List<Movie> allMovies = _movieService.GetAllMovies();
            return Ok(allMovies);
        }

        [HttpGet("get-all-directors")]
        public ActionResult<List<Director>> GetDirectors()
        {
            List<Director> Directors = _directorService.GetAll();
            return Ok(Directors);
        }

        [HttpGet("get-by-id/{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Id can not be less than zero");
            }
            Movie movie = _movieService.GetMovie(id);
            if (movie == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Movie with Id {id} not found");
            }
            return Ok(movie);
        }

        [HttpDelete("delete-movie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can not be less than zero");
                }
                Movie movie = _movieService.GetMovie(id);
                if (movie == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Movie with Id {id} not found");
                }
                _movieService.DeleteMovie(movie.Id);
                return StatusCode(StatusCodes.Status204NoContent, "Movie deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpPost("add-movie")]
        public IActionResult AddBook([FromBody] Movie movie)
        {
            _movieService.AddMovie(movie);
            return Ok();
        }

        [HttpPut("update-movie-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] Movie movie)
        {
            Movie newmovie = _movieService.UpdateMovie(id, movie);
            return Ok(newmovie);
        }
        [HttpGet("filterMovies")]
        public ActionResult<List<Movie>> FilterMovies(GenreEnum genre, int year)
        {
            try
            {
                if (genre == 0 && year == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Filter parameter required!");
                }
                if (genre == 0)
                {
                    List<Movie> movies = _movieService.GetAllMovies()
                        .Where(x => x.Year == year).ToList();
                    return Ok(movies);
                }
                if (year == 0)
                {
                    List<Movie> movies = _movieService.GetAllMovies()
                        .Where(x => x.Genre == genre).ToList();
                    return Ok(movies);
                }
                List<Movie> moviesFil = _movieService.GetAllMovies()
                    .Where(x => x.Genre == genre && x.Year == year).ToList();
                return Ok(moviesFil);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
    }
}
