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
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if (newRental.MovieIds.Count != movies.Count)
            //    return BadRequest("Movie Not Available");
            
            
            foreach (var movie in movies)
            {
                movie.NumberAvailable--;

                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");
                //avoiding mapping 
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                    DateReturned=newRental.DateReturned
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
                
        }
    }
}
