using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.House
{
    public interface IStep9House : IStep9Residence
    {
        RoofType? RoofType{ get; set; }
    }
}