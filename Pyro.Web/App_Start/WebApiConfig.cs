using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Pyro.Web
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      // Configure Web API to use only bearer token authentication.
      config.SuppressDefaultHostAuthentication();
      config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
      
      //Add the Fhir Media Formatters to the Web API Pipeline
      //The order matters here, and remember the requester asks for the format they want in the request header with:
        //Content-Type: application/fhir+xml
        //Accept: application/fhir+xml

      config.Formatters.Clear();
      config.Formatters.Add(new Formatters.FhirJsonMediaTypeFormatter());
      config.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());
      config.Formatters.Add(new Formatters.FhirXmlMediaTypeFormatter());
      config.Formatters.Add(new System.Net.Http.Formatting.XmlMediaTypeFormatter());
      config.Formatters.Add(new System.Net.Http.Formatting.FormUrlEncodedMediaTypeFormatter());

      




      //Add Exception Handler
      config.Filters.Add(new Pyro.Engine.CustomException.FhirExceptionFilter());      

      // Web API routes
      config.MapHttpAttributeRoutes();

      //config.Routes.MapHttpRoute(
      //    name: "DefaultApi",
      //    routeTemplate: "api/{controller}/{id}",
      //    defaults: new { id = RouteParameter.Optional }
      //);
    }
  }
}
