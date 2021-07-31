using DataLayer.DataGenerator;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CommonLayer;

namespace DataLayer.Repository
{
    public class InMemoryMovieRepository : IMoviesRepository
    {
         readonly MoviesGenerator _moviesGenerator;
        public InMemoryMovieRepository(MoviesGenerator moviesGenerator)
        {
            _moviesGenerator = moviesGenerator ?? throw new ArgumentNullException();
        }
        public void AddMovie(Movie movie)
        {
            _moviesGenerator.AddMovie(movie);
        }

        public Movie GetMovieById(int movieId)
        {
           return _moviesGenerator.GetAllMovies().Where(x => x.Id == movieId).FirstOrDefault();
        }

        public List<Movie> GetMovies(FilterParams filterParams)
        {
            return _moviesGenerator.GetAllMovies().Skip((filterParams.PageNumber - 1) * filterParams.PageSize) .Take(filterParams.PageSize).ToList();
        }
    }
}
