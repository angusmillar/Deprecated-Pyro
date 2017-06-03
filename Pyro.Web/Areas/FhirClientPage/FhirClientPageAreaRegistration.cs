using System.Web.Mvc;

namespace Pyro.Web.Areas.FhirClientPage
{
    public class FhirClientPageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FhirClientPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FhirClientPage_default",
                "FhirClientPage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}