using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Response;
using System.Net.Http;

using Fhir = Hl7.Fhir;

namespace Blaze.Engine.Interfaces
{
  public interface IFhirServiceNegotiator
  {        
    FhirRestResponse Get(string type, string FhirResourceId);
    FhirRestResponse Get(string type, Uri uri, Fhir.Rest.SearchParams searchParams);
    FhirRestResponse Post(string type, Fhir.Model.Resource FhirResource);
    FhirRestResponse Put(string type, string FhirResourceId, Fhir.Model.Resource FhirResource);
    FhirRestResponse Delete(string type, string FhirResourceId);
  }
}
