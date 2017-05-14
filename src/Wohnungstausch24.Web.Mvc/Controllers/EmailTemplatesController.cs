using System.Web.Mvc;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Email;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
    public class EmailTemplatesController : Controller
    {
        // GET: EmailTemplates
        public ActionResult Register()
        {
            return View(new RegistrationMailViewModel {Name = "Test",ConfirmationUrl = "http://google.com"});
        }
        // GET: EmailTemplates
        public ActionResult CreateAgent()
        {
            return View(new CreateAgentMailViewModel {Name = "Test",ConfirmationUrl = "http://google.com", Password = "test123"});
        }
        // GET: EmailTemplates
        public ActionResult ContactAgent()
        {
            return View(new ContactAgentModel
            {
                NumberOfPersons = 2,
                Gender = Gender.Male,
                Income = 1000,
                NumberOfChildren = 1,
                Age = 21,
                EmploymentStatus = EmploymentStatus.Employee,
                IsSmoker = false,
                HasPets = true,
                PetsFreeText = "pets",
                Name = "test",
                Email = "test@gmail.com",
                Text = "test"
            });
        }
    }
}