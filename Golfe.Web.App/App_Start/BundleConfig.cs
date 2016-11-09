using System.Web;
using System.Web.Optimization;

namespace Golfe.Web.App
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ol3-plugins").Include(
                        "~/Scripts/libs/ol3.js",
                        "~/Scripts/libs/ol3-layerswitcher.js",
                        "~/Scripts/libs/ol3-popup.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/libs/jquery-1.9.1.js",
                        "~/Scripts/libs/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/foundationDatePicker").Include(
               "~/Content/foundation-datepicker.css",
               "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/ol3").Include(
               "~/Content/ol3.css",
               "~/Content/ol3-layerswitcher.css",
               "~/Content/ol3-popup.css"
               ));

            bundles.Add(new StyleBundle("~/Content/app").Include(
                "~/Content/app.css"
                ));

        }
    }
}