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
    // Get By id
    // GET URL/FhirApi/Patient/5
    FhirRestResponse Get(string type, string FhirResourceId);

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    FhirRestResponse Get(string type, Uri uri, Fhir.Rest.SearchParams searchParams);

    // Add
    // POST: URL/FhirApi/Patient
    FhirRestResponse Post(string type, Fhir.Model.Resource FhirResource);
    
    //Update
    // PUT: URL/FhirApi/Patient/5
    FhirRestResponse Put(string type, string FhirResourceId, Fhir.Model.Resource FhirResource);

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    FhirRestResponse Delete(string type, string FhirResourceId);
  }
}
