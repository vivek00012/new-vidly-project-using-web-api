using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Notification
{
    public class MailSender :SendGridEngine
    {
        public MailSender(IdentityMessage message)
            :base(message)
        {
        }
       
    }
}