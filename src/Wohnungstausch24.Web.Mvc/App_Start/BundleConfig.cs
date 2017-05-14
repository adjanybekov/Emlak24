using System.Web;
using System.Web.Optimization;
using Wohnungstausch24.Web.Mvc.Helpers;

namespace Wohnungstausch24.Web.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundlesHelper.RegisterBundles(bundles);
        }
    }
}
