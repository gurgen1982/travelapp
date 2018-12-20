using System.Web;
using System.Web.Optimization;

namespace Travel
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/styles.css",
                      "~/Content/social.css",
                      "~/Content/ChilliStyle.css"));

            //bundles.Add(new StyleBundle("~/Content/Index").Include("~/Content/Layout/index.css"));

            bundles.Add(new ScriptBundle("~/bundles/homeIndex").Include("~/Scripts/Home/IndexBehaviour.js"));
            bundles.Add(new ScriptBundle("~/bundles/layout").Include("~/Scripts/Layout/LayoutBehaviour.js"));

            //bundles.Add(new StyleBundle("~/Content/index").Include("~/Content/index.css"));
        }
    }
}
