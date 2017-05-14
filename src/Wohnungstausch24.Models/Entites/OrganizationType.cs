using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites
{
    public enum OrganizationType
    {
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_BVFI")]
        BVFI =1,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Ivd")]
        Ivd =2,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Bfw")]
        Bfw =3,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Ddiv")]
        Ddiv =4,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Zia")]
        Zia =5,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Cei")]
        Cei =6,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationTyppe_Cepi")]
        Cepi =7,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Fiabci")]
        Fiabci =8,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Gdw")]
        Gdw =9,
        [Display(ResourceType = typeof(Resource), Name = "OrganizationType_Genossenschaftsverband")]
        Genossenschaftsverband =10
    }
}