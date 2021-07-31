using BusinessLayer;
using DataLayer.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.L0.Test
{
    public class BusinessTests
    {
        Mock<IMoviesRepository> moviesrepositorymock = null;
        [SetUp]
        public void Setup()
        {
            moviesrepositorymock = new Mock<IMoviesRepository>();
        }

        [Test]
        public void TestExistingMovieById()
        {
            moviesrepositorymock.Setup(x => x.GetMovieById(1)).Returns(new DataLayer.Entities.Movie { Director = "ABC", Id = 1, Title = "DEF" });
            ManageMovies managemovies = new ManageMovies(moviesrepositorymock.Object);
            var movie = managemovies.GetMovie(1);
            Assert.IsNotNull(movie);
            Assert.AreEqual(1, movie.Id);
        }

        [Test]
        public void TestNonExistingMovieById()
        {
            moviesrepositorymock.Setup(x => x.GetMovieById(1)).Returns(new DataLayer.Entities.Movie { Director = "ABC", Id = 1, Title = "DEF" });
            ManageMovies managemovies = new ManageMovies(moviesrepositorymock.Object);
            var movie = managemovies.GetMovie(5);
            Assert.IsNull(movie);
        }

        
    }
}
