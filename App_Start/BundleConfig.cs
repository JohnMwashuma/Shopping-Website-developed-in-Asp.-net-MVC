using System.Web.Optimization;

namespace GrandLabFixers
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.appear.min.js",
                        "~/Scripts/imagesloaded.pkgd.min.js",
                        "~/Scripts/global.js",
                        "~/Scripts/responsive.js",
                        "~/Scripts/Datatables/jquery.dataTables.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/responsiveslides.min.js",
                      "~/Scripts/respond.js"
                      //"~/Scripts/datatables/datatables.bootstrap.js"
                      ));



            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Datatables/css/dataTables.bootstrap.css",
                      "~/Content/site.css",
                       "~/Content/styles.css",
                      "~/Content/screen.css",
                      "~/Content/media-queries.css"));
        }
    }
}
