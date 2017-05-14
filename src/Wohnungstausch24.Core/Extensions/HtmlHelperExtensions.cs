using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace Wohnungstausch24.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        public static MvcHtmlString RawActionLink(this System.Web.Mvc.HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = htmlHelper.ActionLink(repID, actionName, controllerName, routeValues, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string source, string alternativeText)
        {
            //declare the html helper 
            var builder = new TagBuilder("image");
            //hook the properties and add any required logic
            builder.MergeAttribute("src", source);
            builder.MergeAttribute("alt", alternativeText);
            //create the helper with a self closing capability
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
