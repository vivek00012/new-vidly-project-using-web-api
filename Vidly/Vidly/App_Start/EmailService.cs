using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Vidly.Notification;

namespace Vidly
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return configSendGridasyncAsync(message);
        }

        private async Task configSendGridasyncAsync(IdentityMessage message)
        {

            var MailEngine = new SendGridEngine(message);

            await MailEngine.Execute();

        }
    }
}
