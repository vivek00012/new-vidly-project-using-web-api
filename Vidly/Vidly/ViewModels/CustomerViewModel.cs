using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {

        public List<Customer> Customers { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CustomerBirthDate { get; set; }
        public string MembershipType { get; set; }
    }
}