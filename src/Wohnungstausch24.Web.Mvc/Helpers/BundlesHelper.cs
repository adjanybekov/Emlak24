using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Web.Mvc.Helpers
{
    public class BundlesHelper
    {
        public static class Wt24Styles
        {
            public static IHtmlString Vendor {
                get { return Styles.Render("~/Content/assets/css/vendorCss"); }
            }
            public static IHtmlString FontAwesome {
                get { return Styles.Render("~/Content/assets/css/fontawesomeCss"); }
            }
            public static IHtmlString ThemeDefault {
                get { return Styles.Render("~/Content/assets/css/themeCss"); }
            }
            public static IHtmlString CustomCss {
                get { return Styles.Render("~/Content/assets/css/customCss"); }
            }
            public static IHtmlString ToastrCss
            {
                get { return Styles.Render("~/Content/toastrCss"); }
            }
            public static IHtmlString ToggleCss
            {
                get { return Styles.Render("~/Content/toggle/css/toggleCss"); }
            }
            public static IHtmlString JQueryFileUploadCss
            {
                get { return Styles.Render("~/Content/jQuery.FileUpload/css/jQueryFileUploadCss"); }
            }

            public static IHtmlString JQueryFileUploadNoscriptCss
            {
                get{return Styles.RenderFormat("<noscript><link rel=\"stylesheet\" href=\"{0}\"></noscript>", "~/Content/jQuery.FileUpload/css/jQueryFileUploadNoScriptCss");}
            }

            public static IHtmlString SweetAlertCss
            {
                get{return Styles.Render("~/Styles/SweetAlertCss");}
            }
            public static IHtmlString AnimateCss
            {
                get{return Styles.Render("~/Content/animateCss");}
            }
            public static IHtmlString FlatCss
            {
                get{return Styles.Render("~/Content/assets/icons/flatCss");}
            }
            public static IHtmlString BootstrapDatetimepicker
            {
                get{return Styles.Render("~/Content/bootstrapDatetimepicker");}
            }

        }
        public static class Wt24Scripts
        {
            public static IHtmlString VendorJs {
                get { return Scripts.Render("~/Content/assets/js/vendorJs"); }
            }
            public static IHtmlString AppJs {
                get { return Scripts.Render("~/Content/assets/js/appJs"); }
            }
            public static IHtmlString CommonJs {
                get { return Scripts.Render("~/Content/assets/js/commonJs"); }
            }
            public static IHtmlString LandingJs {
                get { return Scripts.Render("~/Content/assets/js/landingJs"); }
            }
            public static IHtmlString AgentJs {
                get { return Scripts.Render("~/Content/assets/js/agentJs"); }
            }
            public static IHtmlString ToastrJs {
                get { return Scripts.Render("~/Content/toastrJs"); }
            }
            public static IHtmlString ToggleJs {
                get { return Scripts.Render("~/Content/toggle/js/toggleJs"); }
            }
            public static IHtmlString JqueryVal {
                get { return Scripts.Render("~/scripts/jqueryVal"); }
            }
            public static IHtmlString JqueryUnobtrusiveAjax
            {
                get { return Scripts.Render("~/scripts/jqueryUnobtrusiveAjax"); }
            }
            public static IHtmlString JqueryValidateUnobtrusive
            {
                get { return Scripts.Render("~/scripts/jqueryValidateUnobtrusive"); }
            }
            public static IHtmlString JQueryFileUploadJs
            {
                get { return Scripts.Render("~/scripts/jQuery.FileUpload/jQueryFileUploadJs"); }
            }
            public static IHtmlString ToastrSuccess
            {
                get{return MvcHtmlString.Create($"toastr.success('{Resource.General_Operation_Successfull}');"); ;}
            }
            public static IHtmlString ToastrFail
            {
                get{return MvcHtmlString.Create($"toastr.error('{Resource.General_Operation_Failed}');"); ;}
            }
            public static IHtmlString SweetAlertJs
            {
                get { return Scripts.Render("~/scripts/SweetAlertJs"); }
            }
            public static IHtmlString DatetimePicker
            {
                get { return Scripts.Render("~/scripts/datetimePicker"); }
            }
            public static IHtmlString MomentJs
            {
                get { return Scripts.Render("~/scripts/momentJs"); }
            }
            public static IHtmlString Globalize
            {
                get { return Scripts.Render("~/scripts/globalizeJs"); }
            }
            public static IHtmlString GlobalizeValidate
            {
                get { return Scripts.Render("~/scripts/globalizeValidate"); }
            }
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Styles
            bundles.Add(new StyleBundle("~/Content/assets/css/vendorCss")
                .Include("~/Content/assets/css/vendor.css",new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/assets/css/fontawesomeCss")
                .Include("~/Content/assets/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/assets/css/themeCss")
                .Include("~/Content/assets/css/theme-blue-orange_red.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/assets/css/customCss")
                .Include("~/Content/assets/css/custom.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/toastrCss")
                .Include("~/Content/toastr.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/toggle/css/toggleCss")
                .Include("~/Content/toggle/css/bootstrap-toggle.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Styles/SweetAlertCss")
                .Include("~/Styles/sweetalert.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/jQuery.FileUpload/css/jQueryFileUploadCss")
                .Include("~/Content/jQuery.FileUpload/css/jquery.fileupload.css", new CssRewriteUrlTransform())
                .Include("~/Content/jQuery.FileUpload/css/jquery.fileupload-ui.css", new CssRewriteUrlTransform())
                .Include("~/Content/jQuery.FileUpload/css/blueimp-gallery.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/jQuery.FileUpload/css/jQueryFileUploadNoScriptCss")
                               .Include("~/Content/jQuery.FileUpload/css/jquery.fileupload-noscript.css", new CssRewriteUrlTransform())
                               .Include("~/Content/jQuery.FileUpload/css/jquery.fileupload-ui-noscript.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/animateCss")
                               .Include("~/Content/animate.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/assets/icons/flatCss")
                               .Include("~/Content/assets/icons/flaticon.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/bootstrapDatetimepicker")
                               .Include("~/Content/bootstrap-datetimepicker.css", new CssRewriteUrlTransform()));

            #endregion

            #region Scripts
            bundles.Add(new ScriptBundle("~/Content/assets/js/vendorJs")
                .Include("~/Content/assets/js/vendor.js"));

            bundles.Add(new ScriptBundle("~/Content/assets/js/appJs")
                .Include("~/Content/assets/js/app.js",new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Content/assets/js/commonJs")
                .Include("~/Content/assets/js/common.js",new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Content/assets/js/landingJs")
                .Include("~/Content/assets/js/landing.js",new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Content/assets/js/agentJs")
                .Include("~/Content/assets/js/agent.js",new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Content/toastrJs")
                .Include("~/scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/Content/toggle/js/toggleJs", "https://gitcdn.github.io/bootstrap-toggle/2.2.2/js/bootstrap-toggle.min.js")
                .Include("~/Content/toggle/js/bootstrap-toggle.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueryVal").Include("~/scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/scripts/jqueryUnobtrusiveAjax").Include("~/scripts/jquery.unobtrusive-ajax.js"));
            bundles.Add(new ScriptBundle("~/scripts/jqueryValidateUnobtrusive").Include("~/scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/scripts/jQuery.FileUpload/jQueryFileUploadJs")
                .Include("~/scripts/jquery.ui.widget.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/tmpl.min.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/load-image.all.min.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/canvas-to-blob.min.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.blueimp-gallery.min.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.iframe-transport.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload-process.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload-image.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload-audio.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload-video.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload-validate.js", new CssRewriteUrlTransform())
                .Include("~/scripts/jQuery.FileUpload/jquery.fileupload-ui.js", new CssRewriteUrlTransform())
            );

            bundles.Add(new ScriptBundle("~/scripts/SweetAlertJs").Include("~/scripts/sweetalert.min.js"));
            bundles.Add(new ScriptBundle("~/scripts/datetimePicker").Include("~/scripts/bootstrap-datetimepicker.js"));
            bundles.Add(new ScriptBundle("~/scripts/momentJs").Include("~/scripts/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/scripts/globalizeJs").Include("~/Scripts/globalize/globalize.js"));
            bundles.Add(new ScriptBundle("~/scripts/globalizeValidate").Include("~/scripts/jquery.validate.globalize.js"));

            /*
                <script src="@Url.Content("~/Scripts/globalize/cultures/globalize.culture."+CultureHelper.GetCurrentCulture()+".js")" type="text/javascript"></script>
             */
            #endregion
        }
    }
}