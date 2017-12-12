using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pyro.Web.Extensions
{
  public static class ControllerTools
  {
    /// <summary>
    /// This will return the portion of the URL to the left of the Mask token given.
    /// </summary>
    /// <param name="me">The Controller instance</param>
    /// <param name="Mask">The portion of the path directly after the service root base URL</param>
    /// <returns></returns>
    public static string CalculateBaseURI(this System.Web.Http.ApiController me, string Mask)
    {
      System.Uri ri = me.ControllerContext.Request.RequestUri;

      string baseUri = System.String.Format("{0}://{1}{2}{3}{4}",
          ri.Scheme,
          ri.Host,
          ri.IsDefaultPort ? "" : ":" + ri.Port.ToString(),
          me.ControllerContext.RequestContext.VirtualPathRoot.TrimEnd('/') + '/',
          me.ControllerContext.RouteData.Route.RouteTemplate.Substring(0, me.ControllerContext.RouteData.Route.RouteTemplate.LastIndexOf(Mask)));
      return baseUri.TrimEnd('/');
    }
  }
}