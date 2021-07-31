using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using CommonLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        readonly IManageMovies _manageMovies;
        public MoviesController(IManageMovies manageMovies)
        {
            _manageMovies = manageMovies ?? throw new ArgumentNullException();
        }
       [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie=_manageMovies.GetMovie(id);
            return Ok(movie);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            try
            {
                 _manageMovies.AddNewMovie(movie);
                return Ok(StatusCodes.Status202Accepted);
            }
            catch(Exception)
            {   // Can use logging Like Serilogs
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FilterParams @params)
        {
            try
            {
                var movies = _manageMovies.GetMovies(@params);
                return Ok(movies);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
  
}

