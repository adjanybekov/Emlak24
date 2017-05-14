using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;

namespace Wohnungstausch24.Migrations.Security
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return EmailSender.SendRegistrationMail(message.Destination, message.Subject, message.Body);
        }
    }
}