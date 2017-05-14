using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Flat;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Room
{
    public interface IStep3RoomForRent:IStep3FlatForRent
    {
        PeriodType? PeriodType { get; set; }
    }
}
