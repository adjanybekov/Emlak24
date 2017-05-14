using System.Collections.Generic;
using Wohnungstausch24.Models.Images;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Base
{
    public interface IStep5Listing:IStep5ViewModelBase
    {
        List<FileDto> Images { get; set; }
    }
}