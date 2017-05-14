using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Web.Mvc.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString ToggleButtonFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            var dic = GetHtmlAttributes(null, new object());
            return html.CheckBoxFor(expression, dic);
        }
        public static MvcHtmlString ToggleButtonFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, ToggleOptions opts)
        {
            var dic = GetHtmlAttributes(opts, new object());
            return html.CheckBoxFor(expression, dic);
        }
        public static MvcHtmlString ToggleButtonFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, ToggleOptions opts, object htmlAttributes)
        {
            var dic = GetHtmlAttributes(opts, htmlAttributes);
            return html.CheckBoxFor(expression, dic);
        }

        private static Dictionary<string, object> GetHtmlAttributes(ToggleOptions opts, object htmlAttributes)
        {
            var dic = htmlAttributes.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(htmlAttributes, null));
            dic["data-toggle"] = "toggle";
            dic["data-on"] = Resource.Yes;
            dic["data-off"] = Resource.No;
            dic["data-onstyle"] = "success";
            dic["data-offstyle"] = "danger";

            if (opts != null)
            {
                dic["data-on"] = string.IsNullOrEmpty(opts.OnText) ? Resource.Yes : opts.OnText;
                dic["data-off"] = string.IsNullOrEmpty(opts.OffText) ? Resource.No : opts.OffText;
                if (!string.IsNullOrEmpty(opts.OnShowId))
                {
                    dic["data-on-id-to-show"] = opts.OnShowId;
                }
                if (!string.IsNullOrEmpty(opts.OffShowId))
                {
                    dic["data-off-id-to-show"] = opts.OffShowId;
                }
                if (!string.IsNullOrEmpty(opts.OnShowClass))
                {
                    dic["data-on-class-to-show"] = opts.OnShowClass;
                }
                if (!string.IsNullOrEmpty(opts.OffShowClass))
                {
                    dic["data-off-class-to-show"] = opts.OffShowClass;
                }
            }
            return dic;
        }
    }
}
