using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IMailService
    {
        void SendContactAgentMail(ContactAgentModel model);
    }
}
