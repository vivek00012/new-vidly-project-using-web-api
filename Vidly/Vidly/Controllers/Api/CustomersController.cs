using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private  ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }
        //GET /api/Customers

        //public IEnumerable<Customer> Customers()
        //{
        //    return _context.Customers.ToList();

        //}

        //using DTO
        public IEnumerable<CustomerDto> GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers.Include(c=>c.MembershipType);

                if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery
                    .Where(c => string.Concat(c.FirstName,c.MiddleName,c.LastName).Contains(query));


           var customerDtos=customersQuery
                    .ToList()
                    .Select(Mapper.Map<Customer, CustomerDto>);


            return customerDtos;

        }



        //GET /api/Customers/1

        //public Customer GetCustomer(int id)
        //{
        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customer == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    return customer;
        //}


        //using Dto


        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }



        //POST /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);

        }

        //PUT /api/customers
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        //Delete /api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
