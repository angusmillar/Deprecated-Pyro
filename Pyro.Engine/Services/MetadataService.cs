using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.Engine.Services
{
  public class MetadataService
  {
    public Resource GetServersConformanceResource(IDtoFhirRequestUri DtoFhirRequestUri)
    {
      var Conformance = new Conformance();
      Conformance.Url = DtoFhirRequestUri.FhirUri.Uri.ToString();
      //Conformance.



      return Conformance;
    }


  }
}
