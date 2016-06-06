using System.Web;
using System.Web.Optimization;

namespace Projecte_Final
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/select2js").Include(
                      "~/Scripts/select2.min.js"
                ));
            bundles.Add(new StyleBundle("~/Content/select2css").Include(
                      "~/Content/select2.min.css"
                ));

            //Inclusión del tema Janux

            bundles.Add(new StyleBundle("~/Themes/janux.css").Include(
                    "~/Themes/janux/css/bootstrap-responsive.min.css",
                    "~/Themes/janux/css/style-responsive.css",
                    "~/Themes/janux/css/style.css"
                ));

            bundles.Add(new StyleBundle("~/Themes/janux-bootstrap").Include(
                    "~/Themes/janux/css/bootstap.css"
                ));

            bundles.Add(new ScriptBundle("~/Themes/janux.js").Include(
                    "~/Themes/janux/js/bootstrap.min.js",
                    "~/Themes/janux/js/counter.js",
                    "~/Themes/janux/js/custom.js",
                    "~/Themes/janux/js/excanvas.js",
                    "~/Themes/janux/js/fullcalendar.min.js",
                    "~/Themes/janux/js/jquery-1.9.1.min.js",
                    "~/Themes/janux/js/jquery-migrate-1.0.0.min.js",
                    "~/Themes/janux/js/jquery-ui-1.10.0.custom.min.js",
                    "~/Themes/janux/js/jquery.chosen.min.js",
                    "~/Themes/janux/js/jquery.cleditor.min.js",
                    "~/Themes/janux/js/jquery.cookie.js",
                    "~/Themes/janux/js/jquery.dataTables.min.js",
                    "~/Themes/janux/js/jquery.elfinder.min.js",
                    "~/Themes/janux/js/jquery.flot.js",
                    "~/Themes/janux/js/jquery.flot.pie.js",
                    "~/Themes/janux/js/jquery.flot.resize.min.js",
                    "~/Themes/janux/js/jquery.flot.stack.js",
                    "~/Themes/janux/js/jquery.gritter.min.js",
                    "~/Themes/janux/js/jquery.imagesloaded.js",
                    "~/Themes/janux/js/jquery.knob.modified.js",
                    "~/Themes/janux/js/jquery.masonry.min.js",
                    "~/Themes/janux/js/jquery.noty.js",
                    "~/Themes/janux/js/jquery.raty.min.js",
                    "~/Themes/janux/js/jquery.sparkline.min.js",
                    "~/Themes/janux/js/jquery.ui-touch-punch.js",
                    "~/Themes/janux/js/jquery.uniform.min.js",
                    "~/Themes/janux/js/jquery.uploadify-3.1.min.js",
                    "~/Themes/janux/js/modernizr.js",
                    "~/Themes/janux/js/retina.js",
                    "~/Themes/janux/js/jquery.ui.touch-punch.js",
                    "~/Themes/janux/js/jquery.iphone.toggle.js"
                ));
        }
    }
}
