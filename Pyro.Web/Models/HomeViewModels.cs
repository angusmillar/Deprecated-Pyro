using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blaze.Web.Models
{
  public class HomeViewModels
  {
    public string FhirApiEndpoint { get; set; }

    public string FhirSpecificationUrl { get; set; }
    public string FhirSpecificationName { get; set; }
    public string FhirSpecificationVersion { get; set; }
    public string FhirSpecificationReleaseName { get; set; }

    public Common.ExternalPageLink FhirSpecification { get; set; }
    public Common.ExternalPageLink FhirDotNetAPI { get; set; }
    

    public IList<Common.ExternalPageLink> InformationPageLinkList { get; set; }

    public HomeViewModels()
    {
      this.InformationPageLinkList = new List<Common.ExternalPageLink>();
    }
   
   
  }
}