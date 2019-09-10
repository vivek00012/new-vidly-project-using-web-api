using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.ImageProcessor;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController( )
        {
            this._context =new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get /api/Movies

        public IEnumerable<MovieDto> GetMovies(string query=null)
        {

            var movieQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m=>m.NumberAvailable>0);

            if (!string.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));


            var movieDto = movieQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return movieDto;

        }

        //Get /api/Movies/1

        public MovieDto GetMovie(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

           return  Mapper.Map<Movie, MovieDto>(movie);

        }

        //POST /api/Movies

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //Put /api/Movies
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void updateMovie(MovieDto movieDto,int id)
        {

            if (!ModelState.IsValid)
                BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                NotFound();
            var movie = Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();                       
        }

        //Delete /api/Movies
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //file--delete
      
                ImageUploader.RemoveFile(movieInDb); ;

         
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

        

    }
}
