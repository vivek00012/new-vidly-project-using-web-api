
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Vidly.Models;

    namespace Vidly.Notification
    {
        public class SendGridEngine
    {

        private string _Message;
        private string _ToEmail;
        private string _Name;
        private string _Subject;

      
        public SendGridEngine(IdentityMessage message)
        {
            _Message = message.Body;
            _ToEmail = message.Destination;
            _Name = "";
            _Subject = message.Subject;
        }

        public async Task Execute()
            {
                var apiKey = ConfigurationManager.AppSettings["sendGridApiKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(ConfigurationManager.AppSettings["mailAccount"],ConfigurationManager.AppSettings["mailPassword"]);
                var subject = _Subject;
                var to = new EmailAddress(_ToEmail, _Name);
                var htmlContent = _Message;
                var msg = MailHelper.CreateSingleEmail(from, to, subject,"Text", htmlContent);
                var response = await client.SendEmailAsync(msg);
            var st_code=response.StatusCode;
            }
        }
    }
