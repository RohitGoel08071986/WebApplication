using CommonLayer;
using DataLayer.DataGenerator;
using DataLayer.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.L0.Test
{
    public class DataLayerTest
    {
        MoviesGenerator moviesgenerator = null;
        InMemoryMovieRepository inMemoryMovieRepository = null;
        [SetUp]
        public void Setup()
        {
            moviesgenerator = new MoviesGenerator();
             inMemoryMovieRepository = new InMemoryMovieRepository(moviesgenerator);
        }

        [Test]
        public void TestExistingMovieById()
        {
             var movie=  inMemoryMovieRepository.GetMovieById(1);
             Assert.IsNotNull(movie);
             Assert.AreEqual(1, movie.Id);
        }

        [Test]
        public void TestPagedRecord()
        {
            FilterParams filterParams = new FilterParams { PageNumber = 1, PageSize = 2 };
            var movie = inMemoryMovieRepository.GetMovies(filterParams);
            Assert.IsNotNull(movie);
            Assert.AreEqual(2, movie.Count);
        }


        
    }
}
