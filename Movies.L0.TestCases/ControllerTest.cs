using NUnit.Framework;
using Moq;
using BusinessLayer;
using MoviesWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Movies.L0.TestCases
{
    public class Tests
    {
        Mock<IManageMovies> managemoviemock = null;
       [SetUp]
        public void Setup()
        {
            managemoviemock = new Mock<IManageMovies>();
           
        }

        [Test]
        public void Test1()
        {
            managemoviemock.Setup(x => x.GetMovie(1)).Returns(new DataLayer.Entities.Movie { Director = "ABC", Id = 1, Title = "DEF" });
            MoviesController moviesController = new MoviesController(managemoviemock.Object);
            var movie=  moviesController.Get(1) as ObjectResult;
           
            Assert.IsNotNull(movie);
            Assert.AreEqual(200, movie.StatusCode);
        }

        
    }
}