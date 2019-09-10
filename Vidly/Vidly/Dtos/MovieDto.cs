using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 200, ErrorMessage = "Enter Number between 1 to 200")]
        public byte NumberInStock { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

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
        public HttpPostedFileBase MovieImage { get; set; }



    }
}