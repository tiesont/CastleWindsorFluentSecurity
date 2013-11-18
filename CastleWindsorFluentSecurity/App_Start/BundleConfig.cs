using System.Web;
using System.Web.Optimization;

namespace CastleWindsorFluentSecurity
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.unobtrusive*",
                        "~/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/cookie").Include(
                        "~/scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/extensions").Include(
                        "~/scripts/prettify.js",
                        "~/scripts/jquery.form.js",
                        "~/scripts/jquery.blockUI.js",
                        "~/scripts/jquery.extensions.js"));


            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/content/css/bootstrap.css",
                "~/content/fontawesome/font-awesome.css",
                "~/content/css/site.css"));
        }
    }
}