using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Web.Hosting;
using Vidly.ViewModels;

namespace Vidly.Models.ImageProcessor
{
    public class ImageUploader
    {
        public string MovieThumbnailLocation { get; set; }

        public string MovieThumbnailName { get; set; }

  
        public string MovieImageLocation { get; set; }

     
        public string MovieImageName { get; set; }

        public HttpPostedFileBase MovieImage { get; set; }

        public ImageUploader()
        {


        }
        public ImageUploader(Movie  movie)
        {

            MovieImage = movie.MovieImage;

            var FileName = Path.GetFileNameWithoutExtension(MovieImage.FileName);
            var extension = Path.GetExtension(MovieImage.FileName);
            var array = movie.Name.Split(' ');
            var movieFileName = string.Join("_",array) + DateTime.Now.ToString("yymmssfff") + extension;
            MovieImageName = movieFileName;
            MovieImageLocation = ConfigurationManager.AppSettings["imageLocation"];//relative path

            var absImagePath = Path.Combine(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["imageLocation"]), movieFileName);//absolute path
            MovieImage.SaveAs(absImagePath);
            var ThumbNailName = "thumbnail_" + movieFileName + DateTime.Now.ToString("yymmssfff") + extension;
            MovieThumbnailName = ThumbNailName;
            MovieThumbnailLocation = ConfigurationManager.AppSettings["thumbnailLocation"];
            ThumbnailEngine.Crop(Convert.ToInt32(ConfigurationManager.AppSettings["thumbnailWidth"]),
                Convert.ToInt32(ConfigurationManager.AppSettings["thumbnailHeight"]), 
                MovieImage.InputStream,
                Path.Combine((HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["thumbnailLocation"]) ), ThumbNailName));
        }

        public static void RemoveFile(Movie movie)
        {

            var movieImage = HostingEnvironment.MapPath(movie.MovieImageLocation+"/"+ movie.MovieImageName);
            var movieThumbnail = HostingEnvironment.MapPath(movie.MovieThumbnailLocation+"/"+movie.MovieThumbnailName);
            //var movieViewModel = new MovieViewModel();

            if (File.Exists(movieImage))
            {
                File.Delete(movieImage);
            }
            if (File.Exists(movieThumbnail))
            {
                File.Delete(movieThumbnail);
            }

        }
    }
}