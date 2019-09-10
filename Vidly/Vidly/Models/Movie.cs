using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 200, ErrorMessage = "Enter Number between 1 to 200")]
        public byte NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        public byte NumberAvailable { get; set; }

        [StringLength(255)]
        public string MovieThumbnailLocation { get; set; }

        [StringLength(255)]
        public string MovieThumbnailName { get; set; }

        [StringLength(255)]
        public string MovieImageLocation { get; set; }

        [StringLength(255)]
        public string MovieImageName { get; set; }


        [Display(Name = "Image")]
        [NotMapped]
        public HttpPostedFileBase MovieImage { get; set; }

        public static readonly DateTime CurrentDate=DateTime.Today;
    }
}