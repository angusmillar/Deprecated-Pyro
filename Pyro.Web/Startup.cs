using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;

[assembly: OwinStartup(typeof(Pyro.Web.Startup))]

namespace Pyro.Web
{
  public partial class Startup
  {
    public static HttpConfiguration HttpConfiguration { get; private set; }
    protected RouteCollection _RouteCollection = RouteTable.Routes;
    public void Configuration(IAppBuilder app)
    {
      app.Use(async (environment, next) =>
      {
        var QueryString = environment.Environment["owin.RequestQueryString"] as string;
        var HttpMethod = environment.Environment["owin.RequestMethod"] as string;
        string RequestRoot = $"{environment.Request.Uri.Scheme}://{environment.Request.Uri.Authority}{environment.Request.Uri.AbsolutePath}";
        IHeaderDictionary HeaderDic = environment.Request.Headers;

        Console.WriteLine("-------------------------- Request -------------------------------");
        Console.WriteLine("");
        Console.WriteLine($"Method   : {HttpMethod}");
        Console.WriteLine($"Request  : {RequestRoot}");
        if (!string.IsNullOrWhiteSpace(QueryString))
          Console.WriteLine($"Query    : {QueryString}");
        Console.WriteLine("");
        Console.WriteLine($"------------------------- Headers -------------------------------");
        Console.WriteLine("");
        foreach (var Head in HeaderDic)
        {          
          Console.WriteLine($"{Head.Key.PadRight(16, ' ')}: {string.Join(",", Head.Value)}");
        }
        Console.WriteLine("");
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine("");
        await next();
        Console.WriteLine("-------------------------- Response -------------------------------");
        Console.WriteLine($"Response : {environment.Response.StatusCode} : {environment.Response.ReasonPhrase}");
        Console.WriteLine("-------------------------------------------------------------------");
      });


      HttpConfiguration = new HttpConfiguration();
      //Database.SetInitializer<Pyro.DataLayer.DbModel.DatabaseContext.PyroDbContext>(new Pyro.DataLayer.DbModel.DatabaseInitializer.ServiceSearchParameterInitializer());
      App_Start.SimpleInjectorWebApiInitializer.Initialize(HttpConfiguration);



      //Would like to call these two from here but they fail, they are left in Global.asax??
      //AreaRegistration.RegisterAllAreas();
      //GlobalConfiguration.Configure(WebApiConfig.Register);
      //--------------------------------------------------------
      
      

      WebApiConfig.Register(HttpConfiguration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes();      
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      ConfigureAuth(app);

      app.UseWebApi(HttpConfiguration);

    }

    public virtual void RegisterRoutes()
    {
      RouteConfig.RegisterRoutes(_RouteCollection);
    }
  }
}
