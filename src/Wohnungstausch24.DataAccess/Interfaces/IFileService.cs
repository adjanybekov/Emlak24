using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.Images;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IFileService
    {
        List<FileDto> GetAllByListingId(int id);
        void DeleteImageById(string getUserId, int id);
        void DeleteAvatarByUserId(string userId);
        FileDto SaveFile(HttpPostedFileBase file, string getUserId, int listingId);
        FileDto SaveProfilePicture(HttpPostedFileBase file, string userId);
        List<FileDto> GetProfilePicture(string userId);
        ClientDocument SaveDocument(HttpPostedFileBase file, string getUserId, ClientDocumentType docType, int id);
        List<ClientDocument> GetAllDocsByClientId(int id);
        void DeleteDocById(int id);
    }
}
