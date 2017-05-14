using System.Collections.Generic;
using Wohnungstausch24.Models.Images;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Base
{
    public class Step5Listing :Step5ViewModelBase, IStep5Listing
    {
        public List<FileDto> Images { get; set; }
    }
}