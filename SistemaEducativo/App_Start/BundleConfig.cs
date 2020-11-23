using System.Web;
using System.Web.Optimization;

namespace SistemaEducativo
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Script").Include(
                      "~/Script/toastr.js"
                      ));

            //Admin-LTE

            bundles.Add(new StyleBundle("~/admin-lte/css").Include(
                      "~/admin-lte/css/AdminLTE.css",
                      "~/plugins/fontawesome-free/css/all.min.css",
                      "~/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                      "~/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                      "~/plugins/jqvmap/jqvmap.min.css",
                      "~/admin-lte/css/adminlte.min.css",
                      "~/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                      "~/plugins/daterangepicker/daterangepicker.css",
                      "~/plugins/summernote/summernote-bs4.css"
                      ));

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                      "~/admin-lte/js/adminlte.min.js",
                      "~/admin-lte/plugins/jquery-ui/jquery-ui.min.js",
                      "~/admin-lte/plugins/bootstrap/js/bootstrap.bundle.min.js",
                      "~/admin-lte/plugins/chart.js/Chart.min.js",
                      "~/admin-lte/plugins/sparklines/sparkline.js",
                      "~/admin-lte/plugins/jquery-knob/jquery.knob.min.js",
                      "~/admin-lte/plugins/moment/moment.min.js",
                      "~/admin-lte/plugins/daterangepicker/daterangepicker.js",
                      "~/admin-lte/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                      "~/admin-lte/plugins/summernote/summernote-bs4.min.js",
                      "~/admin-lte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"
                      ));
        }
    }
}