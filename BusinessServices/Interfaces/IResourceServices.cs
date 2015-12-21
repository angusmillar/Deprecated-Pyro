using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir;

namespace Blaze.Engine.Interfaces
{
  public interface IResourceServices
  {
    Response.FhirRestResponse Get(string FhirResourceId);
    Response.FhirRestResponse Get(Uri uri, Fhir.Rest.SearchParams searchParams);
    Response.FhirRestResponse Post(Fhir.Model.Resource resource);
    Response.FhirRestResponse Put(string FhirResourceId, Fhir.Model.Resource resource);
    Response.FhirRestResponse Delete(string FhirResourceId);
  }
}
