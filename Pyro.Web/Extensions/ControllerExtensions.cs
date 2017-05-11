using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pyro.Web.Extensions
{
  public static class ControllerTools
  {
    public static string CalculateBaseURI(this System.Web.Http.ApiController me, string resourceName)
    {
      System.Uri ri = me.ControllerContext.Request.RequestUri;
      if (resourceName == "metadata" || resourceName == "${operation}")
      {
        return System.String.Format("{0}://{1}{2}{3}{4}",
            ri.Scheme,
            ri.Host,
            ri.IsDefaultPort ? "" : ":" + ri.Port.ToString(),
            me.ControllerContext.RequestContext.VirtualPathRoot.TrimEnd('/') + '/',
            me.ControllerContext.RouteData.Route.RouteTemplate.Replace("/metadata", "").Replace("/${operation}", ""));
      }

      if (me.ControllerContext.RouteData.Route.RouteTemplate.Contains("{ResourceName}"))
        resourceName = "{ResourceName}";
      string baseUri = System.String.Format("{0}://{1}{2}{3}{4}",
          ri.Scheme,
          ri.Host,
          ri.IsDefaultPort ? "" : ":" + ri.Port.ToString(),
          me.ControllerContext.RequestContext.VirtualPathRoot.TrimEnd('/') + '/',
          me.ControllerContext.RouteData.Route.RouteTemplate.Substring(0, me.ControllerContext.RouteData.Route.RouteTemplate.LastIndexOf(resourceName)));

      return baseUri.TrimEnd('/');
    }
  }
}