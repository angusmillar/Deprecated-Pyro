﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces;
using Pyro.DataModel;


[assembly: OwinStartup(typeof(Pyro.Web.Startup))]

namespace Pyro.Web
{
  public partial class Startup
  {
    public static HttpConfiguration HttpConfiguration { get; private set; }
    public void Configuration(IAppBuilder app)
    {
      app.Use(async (environment, next) =>
      {
        var QueryString = environment.Environment["owin.RequestQueryString"] as string;
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine(string.Format("Request : {0}?{1}", environment.Request.Path, QueryString));
        await next();
        Console.WriteLine(string.Format("Response : {0}", environment.Response.StatusCode));
        Console.WriteLine("-------------------------------------------------------------------");
      });


      HttpConfiguration = new HttpConfiguration();

      App_Start.SimpleInjectorWebApiInitializer.Initialize(HttpConfiguration);

      //Would like to call these two from here but they fail, they are left in Global.asax??
      //AreaRegistration.RegisterAllAreas();
      //GlobalConfiguration.Configure(WebApiConfig.Register);
      //--------------------------------------------------------

      WebApiConfig.Register(HttpConfiguration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      ConfigureAuth(app);

      app.UseWebApi(HttpConfiguration);

    }
  }
}
