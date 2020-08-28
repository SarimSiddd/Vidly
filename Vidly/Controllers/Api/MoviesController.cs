using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET: /Movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        //GET: /Movies/Id
       public IHttpActionResult GetMovies(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPut]
        //PUT: /Movies/Id
        public IHttpActionResult UpdateMovies(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDB == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        //Post /movies
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpDelete]
        //DELETE /movies/Id
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieInDB == null)
                return BadRequest();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
            return Ok();
        }


    }
}
