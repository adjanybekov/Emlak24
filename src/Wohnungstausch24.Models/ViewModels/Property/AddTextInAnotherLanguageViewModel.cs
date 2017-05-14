using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class AddTextInAnotherLanguageViewModel
    {
        [Display(ResourceType = typeof(Resource), Name = "AddTextInAnotherLanguageViewModel_LanguageCode")]
        public string LanguageCode { get; set; }
        [StringLength(1000000,MinimumLength = 3, ErrorMessage = "Invalid Text")]
        [Display(ResourceType = typeof(Resource), Name = "AddTextInAnotherLanguageViewModel_Description")]
        public string Description { get; set; }
    }
}
