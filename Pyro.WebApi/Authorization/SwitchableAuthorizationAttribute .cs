using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Pyro.Common.Global;

namespace Pyro.WebApi.Authorization
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
  public class SwitchableAuthorizationAttribute : AuthorizeAttribute
  {
    protected override bool IsAuthorized(HttpActionContext actionContext)
    {
      //bool DisableAuthentication = false;

      ////#if DEBUG
      ////      disableAuthentication = true;
      ////#endif
      
      ////FHIRApiAuthentication is set in Web.Config file and defaults to True, meaning Authentication must occur, if false the their is open access to the FHIR API
      //var IGlobalProperties = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IGlobalProperties)) as IGlobalProperties;
      //if (!IGlobalProperties.FHIRApiAuthentication)
      //  DisableAuthentication = true;

      //if (DisableAuthentication)
      //  return true;

      
      return base.IsAuthorized(actionContext);
    }
  }
}