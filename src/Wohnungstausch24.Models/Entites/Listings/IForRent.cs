using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public interface IForRent
    {
        bool? IsRentedOut { get; set; }
    }
}