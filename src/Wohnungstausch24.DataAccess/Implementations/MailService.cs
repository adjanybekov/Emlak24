using Wohnungstausch24.Core;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class MailService:IMailService
    {
        private IListingService _listingService;

        public MailService(IListingService listingService)
        {
            _listingService = listingService;
        }

        public void SendContactAgentMail(ContactAgentModel model)
        {
            var emails = _listingService.GetContactEmailsByListingId(model.ListingId);
            emails.Add(model.Email);
            var mailContent = EmailSender.GetRazorViewAsString(model, "~/Views/EmailTemplates/ContactAgent.cshtml");
            EmailSender.SendAgentContactEmail(emails, Resource.Contact_Agent_Mail_Title, mailContent);
        }
    }
}
