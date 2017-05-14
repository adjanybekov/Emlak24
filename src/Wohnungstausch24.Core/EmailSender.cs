using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wohnungstausch24.Core
{
    public static class EmailSender
    {
        private static string mailFrom = "test@ventusbilisim.com.tr";
        private static string password = "dVe3v5!4";

        public class FakeController : Controller
        {
        }

        public static Task SendRegistrationMail(string destination, string subject, string body)
        {
            return SendMailAsync(destination, subject, body);
        }

        public static void SendAgentContactEmail(List<string> emails, string subject, string body)
        {
            foreach (var mailTo in emails)
            {
                SendEmail(mailTo, subject, body);
            }
        }

        public static string GetRazorViewAsString(object model, string filePath)
        {
            var st = new StringWriter();
            var context = new HttpContextWrapper(HttpContext.Current ?? new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null)));
            var routeData = new RouteData();
            var controllerContext = new ControllerContext(new RequestContext(context, routeData), new FakeController());
            var razor = new RazorView(controllerContext, filePath, null, false, null);
            razor.Render(new ViewContext(controllerContext, razor, new ViewDataDictionary(model), new TempDataDictionary(), st), st);
            return st.ToString();
        }
        private static void SendEmail(string mailTo, string subject, string body)
        {
            var msg = new MailMessage();

            msg.From = new MailAddress(mailFrom);
            msg.To.Add(mailTo);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            using (var client = new SmtpClient())
            {
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailFrom, password);
                client.Host = "mail.ventusbilisim.com.tr";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }
        }
        private static Task SendMailAsync(string destination, string subject, string body)
        {
            MailMessage mail = new MailMessage(mailFrom, destination);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.ventusbilisim.com.tr";
            client.Credentials = new NetworkCredential(mailFrom, password);
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = body;
            return client.SendMailAsync(mail);
        }
    }
}
