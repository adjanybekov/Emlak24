using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room
{
    public interface IRoomForRent : IFlatForRent
    {
        PeriodType? PeriodType { get; set; }
    }
}
