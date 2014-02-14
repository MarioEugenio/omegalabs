using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace Administracao
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Src/js/externals/Jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Src/js/bootstrap-min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Src/js/externals/angular/angular.js",
                        "~/Src/js/externals/angular/angular-route.js",
                        "~/Src/js/externals/angular/angular-strap/dist/angular-strap-min.js",
                        "~/Src/js/externals/angular/angular-strap/dist/angular-strap-tpl-min.js"));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                        "~/Src/js/core.js"));

            bundles.Add(new ScriptBundle("~/bundles/init").Include(
                        "~/Src/app/initial/loginController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Src/css/app.css",
                "~/Src/css/bootstrap-min.css",
                "~/Src/css/bootstrap-theme-min.css"));

            bundles.Add(new StyleBundle("~/Content/main/css").Include(
                "~/Src/css/main.css",
                "~/Src/css/bootstrap-min.css",
                "~/Src/css/bootstrap-theme-min.css"));

            var scripts = new ScriptBundle("~/Scripts/js");
            bundles.Add(scripts.IncludeDirectory("~/Src/app/initial", "*.js"));
            bundles.Add(scripts.IncludeDirectory("~/Src/app/substancia", "*.js"));
        }

    }
}