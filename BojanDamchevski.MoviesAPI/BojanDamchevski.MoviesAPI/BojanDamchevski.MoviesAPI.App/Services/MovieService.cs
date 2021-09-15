using BojanDamchevski.MoviesAPI.App.Db;
using BojanDamchevski.MoviesAPI.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.MoviesAPI.App.Services
{
    public class MovieService
    {
        private AppDbContext _dbContext;
        public MovieService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovie(int id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            Movie newMovie = new Movie();
            newMovie.Description = movie.Description;
            newMovie.Genre = movie.Genre;
            newMovie.Title = movie.Title;
            newMovie.Year = movie.Year;
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            Movie movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            Movie oldMovie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie.Genre == 0 || string.IsNullOrEmpty(movie.Title) || movie.Year == 0)
            {
                throw new Exception("Error");
            }
            else
            {
                if (oldMovie != null)
                {
                    oldMovie.Description = movie.Description;
                    oldMovie.Genre = movie.Genre;
                    oldMovie.Title = movie.Title;
                    oldMovie.Year = movie.Year;
                }
            }

            _dbContext.SaveChanges();
            return oldMovie;
        }
    }
}
