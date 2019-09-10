using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        // GET: Customers[Rout
        //outputcache
        public ActionResult Index()
        {
            //var CustomerList = _context.Customers.Include(c=>c.MembershipType).ToList();

            //var ViewModel = new CustomerViewModel
            //{
            //    Customers = CustomerList
            //};
           // ViewBag.customerId = "AllCustomers";

            if(User.IsInRole(RoleName.CanManageMovies))
                 return View("List");
            return View("ReadOnlyList");

        }

        //get customer by id
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
         
            var selectedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (selectedCustomer == null)
            
                return HttpNotFound();
            
            var viewModel = new CustomerFormViewModel
            {
               Customer=selectedCustomer,
               MembershipTypes=_context.MembershipTypes.ToList()

            };

            //ViewBag.customerId = id;
            return View("CustomerForm",viewModel);

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            ViewBag.action = "Create";
            var viewModel = new CustomerFormViewModel
            {
                Customer=new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid) {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes=_context.MembershipTypes.ToList()

                };
                return View("CustomerForm", viewModel);
                 }
            if (customer.Id == 0)
            {
                customer.MiddleName = string.IsNullOrEmpty(customer.MiddleName) ? null : customer.MiddleName;
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.MiddleName = string.IsNullOrEmpty(customer.MiddleName) ? null : customer.MiddleName;
                customerInDb.LastName = customer.LastName;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;


                //OR Mapper.Map(customer,customerInDb)

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}