using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataGenerator
{
    public class MoviesGenerator
    {
        static List<Movie> movies = new List<Movie>();
        public MoviesGenerator()
        {
            movies.Add(new Movie { Title = "Movie-1", Director = "ABC", Id = 1 });
            movies.Add(new Movie { Title = "Movie-2", Director = "DEF", Id = 2 });
        }
        public List<Movie> GetAllMovies() => movies;

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }   
}
