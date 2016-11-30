using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pyro.Web
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      //If I don't have these two then Help pages do not render correctly
      //RegisterAllAreas seems to create page and Configure populates the pages
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      //------------------------------------------------------

      //Below have been moved to Startup.cs for OWIN set-up

      //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      //RouteConfig.RegisterRoutes(RouteTable.Routes);
      //BundleConfig.RegisterBundles(BundleTable.Bundles);      

    }


  }
}
