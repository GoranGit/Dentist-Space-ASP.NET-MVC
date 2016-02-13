using System.Web;
using System.Web.Optimization;

namespace DentistSpace.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string JQueryCDN = @"http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js";
            string ModernizrCDN = @"https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.6.2/modernizr.min.js";
            string JQueryValidateCDN = @"http://ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js";
            string jQueryValidateUnobtrusiveCDN = @"http://ajax.aspnetcdn.com/ajax/mvc/5.2.3/jquery.validate.unobtrusive.min.js";
            string RespondCDN = @"https://cdnjs.cloudflare.com/ajax/libs/respond.js/1.4.2/respond.min.js";
            string MaterializeCDN = @"https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js";
            string MaterializeCSSCDN = @"https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css";

            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery", JQueryCDN).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval", JQueryValidateCDN).Include(
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqunobtrusive", jQueryValidateUnobtrusiveCDN).Include(
                       "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr", ModernizrCDN).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize", MaterializeCDN).Include(
                "~/Scripts/materialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/respond", RespondCDN).Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css", MaterializeCSSCDN).Include(
                      "~/Content/materialize.css"));

            bundles.Add(new StyleBundle("~/Content/main").Include(
                      "~/Content/Site.css"));
        }
    }
}