using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pyro.Web.Models;

namespace Pyro.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Title = "Pyro Fhir Server";
      var HomeView = new HomeViewModels();
      var Cache = new Pyro.Common.Cache.CacheCommon();
      HomeView.FhirApiEndpoint = Cache.WebConfigServiceBaseURL();
      //HomeView.FhirApiEndpoint = "pyrohealth.net/test/stu3/fhir";
      HomeView.FhirSpecificationVersion = Hl7.Fhir.Model.ModelInfo.Version;
      HomeView.FhirSpecificationReleaseName = $"FHIR April 2017 V{ HomeView.FhirSpecificationVersion}";
      HomeView.FhirSpecificationName = "FHIR STU3";
      HomeView.FhirSpecification = new Models.Common.ExternalPageLink()
      {
        Description = $"{HomeView.FhirSpecificationReleaseName} specification release",
        Name = HomeView.FhirSpecificationName,
        Url = new Uri("http://hl7.org/fhir/STU3/index.html")
      };

      HomeView.FhirDotNetAPI = new Models.Common.ExternalPageLink()
      {
        Description = ".Net FHIR API",
        Name = ".NET FHIR API",
        Url = new Uri("http://ewoutkramer.github.io/fhir-net-api/")
      };

      //Informational links
      HomeView.InformationPageLinkList.Add(HomeView.FhirSpecification);
      HomeView.InformationPageLinkList.Add(HomeView.FhirDotNetAPI);

      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "FHIR tutorials",
        Name = "Fhir Drills",
        Url = new Uri("http://fhir-drills.github.io/")
      });

      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "Health interoperability blog by Grahame Grieve",
        Name = "Health Intersections",
        Url = new Uri("http://www.healthintersections.com.au/")
      });


      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "David Hay's FHIR Blog",
        Name = "Hay on FHIR",
        Url = new Uri("https://fhirblog.com/")
      });

      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "HL7 Australia",
        Name = "HL7 Australia",
        Url = new Uri("http://www.hl7.org.au/")
      });

      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "Publicly Available FHIR Servers for testing",
        Name = "Public test FHIR servers",
        Url = new Uri("http://wiki.hl7.org/index.php?title=Publicly_Available_FHIR_Servers_for_testing")
      });

      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "AEGIS FHIR Server testing service",
        Name = "AEGIS FHIR testing service",
        Url = new Uri("http://www.aegis.net/touchstone.html")
      });

      HomeView.InformationPageLinkList.Add(new Models.Common.ExternalPageLink()
      {
        Description = "AEGIS FHIR Server testing service",
        Name = "Crucible FHIR testing service",
        Url = new Uri("https://projectcrucible.org/")
      });





      return View(HomeView);
    }
  }
}
