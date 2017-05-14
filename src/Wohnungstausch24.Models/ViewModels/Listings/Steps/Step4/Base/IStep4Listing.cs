namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Base
{
    public interface IStep4Listing:IStep4ViewModelBase
    {
        int? TotalArea { get; set; }
        decimal? PlotArea { get; set; }
    }
}