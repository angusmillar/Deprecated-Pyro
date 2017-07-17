using System.Web;
using System.Web.Optimization;

namespace Pyro.Web
{
  public class BundleConfig
  {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.UseCdn = true;

      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

      bundles.Add(new ScriptBundle("~/bundles/FhirRest").Include(
                 "~/Scripts/FhirRest.js"));

      bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                 "~/Scripts/typeahead.bundle.min.js"));

      var HighLighttheme = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.12.0/styles/googlecode.min.css";
      bundles.Add(new StyleBundle("~/highlight/css", HighLighttheme).Include(
        "~/Content/googlecode.css"));


      var HighLightjs = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.12.0/highlight.min.js";
      bundles.Add(new ScriptBundle("~/highlight/script", HighLightjs).Include(
        "~/bundles/highlight.pack.js"));



      BundleTable.EnableOptimizations = true;

    }
  }
}
