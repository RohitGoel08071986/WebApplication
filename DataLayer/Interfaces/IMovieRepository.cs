using CommonLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IMoviesRepository
    {
        void AddMovie(Movie movie);
        Movie GetMovieById(int movieId);

        List<Movie> GetMovies(FilterParams filterParams);
    }
}
