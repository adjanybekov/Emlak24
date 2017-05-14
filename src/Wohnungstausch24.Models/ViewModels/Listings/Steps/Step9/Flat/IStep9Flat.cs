using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Flat
{
    public interface IStep9Flat : IStep9Residence
    {
        int? FlatNumber { get; set; }
    }
}