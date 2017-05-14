namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    public interface IStep3Residence:IStep3Listing
    {
        bool IsHeatingCostsIncluded { get; set; }
        decimal? HeatingCosts { get; set; }
        decimal? Clearance { get; set; }
        string ClearanceText { get; set; }
        bool SpeakToOwner { get; set; }
        decimal? InsideCourtage { get; set; }
        decimal? CurrentColdRent { get; set; }     
    }
}
