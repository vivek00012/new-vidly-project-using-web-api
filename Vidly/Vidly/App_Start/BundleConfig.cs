using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                      "~/Scripts/Site.js",
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery-ui.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables.bootstrap.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/select2.min.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/lightgallery.js",
                      "~/Scripts/jquery.mousewheel.min.js",
                      "~/Scripts/lg-thumbnail.js",
                      "~/Scripts/lg-fullscreen.js",
                      "~/Scripts/justifiedGallery.min.js",
                      "~/Scripts/zoom.js",
                      "~/Scripts/jquery.easyPaginate.js",
                      "~/Scripts/jquery-perfect-scrollbar.js",
                       "~/Scripts/hamburger.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Scripts/moment.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker-min").Include(
          "~/Scripts/bootstrap-datetimepicker-min.js"));

            bundles.Add(new StyleBundle("~/Content/main").Include(
                       "~/Content/util.css",
                       "~/Content/main.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/homepage").Include(
                       "~/Content/util.css",
                      "~/Content/homepage.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/jquery-ui.css",
                  "~/Content/bootstrap.css",
                  "~/Content/datatables/css/datatables.bootstrap.css",
                  "~/Content/site.css",
                  "~/Content/toastr.css",
                  "~/Content/typehead.css",
                  "~/Content/select2.min.css",
                  "~/Content/lightgallery.css",
                  "~/Content/perfect-scrollbar.css",
                  "~/Content/hamburger.css"
                  ));
            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                     "~/Scripts/main.js"));
            
        }
    }
}
