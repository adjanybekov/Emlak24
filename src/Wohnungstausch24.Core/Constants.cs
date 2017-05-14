using System.Web.Configuration;

namespace Wohnungstausch24.Core
{
    public static class Constants
    {
        public static string SearchProfileSchemaName = "searchProfile";
        public static int ItemsPerPage = int.Parse(WebConfigurationManager.AppSettings["ItemsPerPage"]);
        public static string DefaultImagePath = "/Content/assets/img/no-image.jpg";
    }
}
