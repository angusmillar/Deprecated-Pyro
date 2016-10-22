using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blaze.Web.Models;

namespace Blaze.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Title = "Pyro Fhir Server";
      var HomeView = new HomeView();      
      HomeView.FhirApiEndpoint = "Test.STU3.PyroHealth.net/FhirApi";

      return View(HomeView);
    }
  }
}
