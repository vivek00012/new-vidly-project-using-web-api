using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Models
{
    public class Message
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string UserMessage { get; set; }


    }
}