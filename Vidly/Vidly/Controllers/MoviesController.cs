using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ImageProcessor;
using Vidly.ViewModels;
using System.IO;
using System.Web.Hosting;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        // GET: Movie
        public MoviesController()
        {
            this._context =new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();    
        }

        public ActionResult Index()
        {
            //var MovieList = _context.Movies.Include(g => g.Genre).ToList();
        
          if(User.IsInRole(RoleName.CanManageMovies))
             return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList(),
            };

            ViewBag.action = "Create";
            return View("MovieForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);


            var viewModel = new MovieViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()

                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                var MovieImage = movie.MovieImage;
                var imageUploader = new ImageUploader(movie);
                movie.DateAdded = Movie.CurrentDate;
                movie.NumberAvailable = movie.NumberInStock;
                movie.MovieThumbnailLocation = imageUploader.MovieThumbnailLocation;
                movie.MovieImageName = imageUploader.MovieImageName;
                movie.MovieImageLocation = imageUploader.MovieImageLocation;
                movie.MovieThumbnailName = imageUploader.MovieThumbnailName;
                _context.Movies.Add(movie);
            }
            else
            {
               
                var moviesInDb = _context.Movies.Single(m => m.Id == movie.Id);
                ImageUploader.RemoveFile(moviesInDb);
                moviesInDb.Name = movie.Name;
                moviesInDb.GenreId = movie.GenreId;
                moviesInDb.ReleaseDate = movie.ReleaseDate;
                moviesInDb.DateAdded = Movie.CurrentDate;
                moviesInDb.NumberInStock = movie.NumberInStock;
                moviesInDb.NumberAvailable = movie.NumberInStock;
                var imageUploader = new ImageUploader(movie);
                moviesInDb.MovieImageName = imageUploader.MovieImageName;
                moviesInDb.MovieImageLocation = imageUploader.MovieImageLocation;
                moviesInDb.MovieThumbnailName = imageUploader.MovieThumbnailName;
                moviesInDb.MovieThumbnailLocation = imageUploader.MovieThumbnailLocation;


            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");

        }

    }
}