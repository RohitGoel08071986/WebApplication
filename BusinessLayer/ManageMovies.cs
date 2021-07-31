using CommonLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ManageMovies : IManageMovies
    {
        readonly IMoviesRepository _moviesRepository;
        public ManageMovies(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository ?? throw new ArgumentNullException();
        }
        public void AddNewMovie(Movie movie)
        {
            _moviesRepository.AddMovie(movie);
        }

        public Movie GetMovie(int id)
        {
           return _moviesRepository.GetMovieById(id);

        }

        public List<Movie> GetMovies(FilterParams filterParams)
        {
            return _moviesRepository.GetMovies(filterParams);
        }
    }

    public interface IManageMovies
    {
        void AddNewMovie(Movie movie);
        Movie GetMovie(int id);
        List<Movie> GetMovies(FilterParams filterParams);
    }
}
