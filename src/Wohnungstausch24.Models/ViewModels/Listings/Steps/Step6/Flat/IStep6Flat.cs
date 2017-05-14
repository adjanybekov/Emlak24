using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Flat
{
    public interface IStep6Flat : IStep6Residence
    {
        string Tercet { get; set; }
    }
}