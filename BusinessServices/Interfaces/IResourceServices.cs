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
    // Get By id
    // GET URL/FhirApi/Patient/5    
    Response.FhirRestResponse Get(string FhirResourceId);

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    Response.FhirRestResponse Get(Uri uri, Fhir.Rest.SearchParams searchParams);

    // Add
    // POST: URL/FhirApi/Patient
    Response.FhirRestResponse Post(Fhir.Model.Resource resource);

    //Update
    // PUT: URL/FhirApi/Patient/5
    Response.FhirRestResponse Put(string FhirResourceId, Fhir.Model.Resource resource);
    Response.FhirRestResponse Delete(string FhirResourceId);
  }
}
