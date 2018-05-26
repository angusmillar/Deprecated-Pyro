using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Pyro.WebApi.Authorization
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
  public class SwitchableAuthorizationAttribute : AuthorizeAttribute
  {
    protected override bool IsAuthorized(HttpActionContext actionContext)
    {
      bool disableAuthentication = false;

      #if DEBUG
      disableAuthentication = true;
      #endif

      if (disableAuthentication)
        return true;

      return base.IsAuthorized(actionContext);
    }    
  }
}