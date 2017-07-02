using System.Collections.Generic;
using System.Web.Optimization;

namespace MvcAppExample.Web
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
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Utilizando ordenação manual
            var bootstrapBundle = new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js");
            bootstrapBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(bootstrapBundle);

            // Utilizando ordenação manual
            var cssBundle = new ScriptBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css");
            cssBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(cssBundle);
        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
