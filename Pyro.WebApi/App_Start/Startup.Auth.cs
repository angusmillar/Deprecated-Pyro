using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Pyro.WebApi.Providers;
using Pyro.WebApi.Models;
using IdentityServer3.AccessTokenValidation;

namespace Pyro.WebApi
{
  public partial class Startup
  {
    //public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    //public static string PublicClientId { get; private set; }

    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureAuth(IAppBuilder app)
    {
      // Configure the db context and user manager to use a single instance per request
      //app.CreatePerOwinContext(ApplicationDbContext.Create);
      //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

      // Enable the application to use a cookie to store information for the signed in user
      // and to use a cookie to temporarily store information about a user logging in with a third party login provider

      //app.UseCookieAuthentication(new CookieAuthenticationOptions());
      //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

      app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
      {        
        ClientId = "PyroFhirApi",        
        ClientSecret = "prometheus.apiResource",
        Authority = "https://localhost:50000/",
        ValidationMode = ValidationMode.Both,
        RequiredScopes = new[]
        {
          "user/*.*",
          "user/*.read",
          "user/*.write",
          "patient/*.*",
          "patient/Patient.read",
          "patient/*.write"
        },
        
      });
      
    }
  }
}
