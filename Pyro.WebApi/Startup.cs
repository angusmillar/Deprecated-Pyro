using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
//using System.Web.Mvc;
//using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(Pyro.WebApi.Startup))]

namespace Pyro.WebApi
{
  public partial class Startup
  {
    public static HttpConfiguration HttpConfiguration { get; private set; }
    protected RouteCollection _RouteCollection = RouteTable.Routes;
    public void Configuration(IAppBuilder app)
    {
      RegisterSignalRHubs(app);

      app.Use(async (environment, next) =>
      {
        var QueryString = environment.Environment["owin.RequestQueryString"] as string;
        var HttpMethod = environment.Environment["owin.RequestMethod"] as string;
        string RequestRoot = $"{environment.Request.Uri.Scheme}://{environment.Request.Uri.Authority}{environment.Request.Uri.AbsolutePath}";
        IHeaderDictionary HeaderDic = environment.Request.Headers;

        Console.WriteLine("----------------------------------- Request -----------------------------------");        
        Console.WriteLine("");
        Console.WriteLine($"Received : {DateTimeOffset.Now.ToString()}");
        Console.WriteLine($"Method   : {HttpMethod}");
        Console.WriteLine($"Request  : {RequestRoot}");
        if (!string.IsNullOrWhiteSpace(QueryString))
          Console.WriteLine($"Query    : {QueryString}");
        Console.WriteLine("");
        Console.WriteLine("----------------------------------- Headers -----------------------------------");        
        Console.WriteLine("");
        foreach (var Head in HeaderDic)
        {
          Console.WriteLine($"{Head.Key.PadRight(16, ' ')}: {string.Join(",", Head.Value)}");
        }
        Console.WriteLine("");
        Console.WriteLine("-------------------------------------------------------------------------------");
        Console.WriteLine("");
        await next();        
        Console.WriteLine("----------------------------------- Response ----------------------------------");
        Console.WriteLine($"Response : {environment.Response.StatusCode} : {environment.Response.ReasonPhrase}");
        Console.WriteLine("-------------------------------------------------------------------------------");
      });

      HttpConfiguration = new HttpConfiguration();
      App_Start.SimpleInjectorWebApiInitializer.Initialize(HttpConfiguration);
      WebApiConfig.Register(HttpConfiguration);
      
      //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    
      //BundleConfig.RegisterBundles(BundleTable.Bundles);
      ConfigureAuth(app);
      
      app.UseWebApi(HttpConfiguration);
    }

    //Register the SignalR Hubs for notification messaging to background service.
    private void RegisterSignalRHubs(IAppBuilder app)
    {
      var hubConfiguration = new HubConfiguration
      {
        EnableDetailedErrors = true,
        EnableJavaScriptProxies = false
      };
      app.MapSignalR(hubConfiguration);
      
    }
    
  }
}
