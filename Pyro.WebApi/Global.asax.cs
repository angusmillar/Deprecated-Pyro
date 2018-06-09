using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Pyro.WebApi
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      //Pyro.WebApi.App_Start.SimpleInjectorWebApiInitializer.Initialize(GlobalConfiguration.Configuration);
      //GlobalConfiguration.Configure(Pyro.WebApi.WebApiConfig.Register);
    }
  }
}
