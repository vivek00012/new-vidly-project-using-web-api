using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Vidly.Models;
using Vidly.Models.ImageProcessor;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 200, ErrorMessage = "Enter Number between 1 to 200")]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public byte? NumberAvailable { get; set; }

        [StringLength(255)]
        [Required]

        public string MovieThumbnailLocation { get; set; }

        [StringLength(255)]
        public string MovieThumbnailName { get; set; }

        [StringLength(255)]
        public string MovieImageLocation { get; set; }

        [StringLength(255)]
        public string MovieImageName { get; set; }

        [Display(Name = "Image")]
        public HttpPostedFileBase MovieImage { get; set; }


        public string ImagePath {get;set;}



        public string Title { get {
                return Id != null && Id!=0? "Edit Movie" : "New Movie";
            }
        }

        public MovieViewModel()
        {
            Id = 0;
            MovieThumbnailLocation = ConfigurationManager.AppSettings["thumbnailLocation"];
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
            MovieImage = movie.MovieImage;
            MovieImageLocation = movie.MovieImageLocation;
            MovieThumbnailLocation = movie.MovieThumbnailLocation;
            MovieImageName = movie.MovieImageName;
            ImagePath= movie.MovieImageLocation.Substring(1)+ '/' + movie.MovieImageName;
            NumberAvailable=movie.NumberAvailable;


        }
    }
}