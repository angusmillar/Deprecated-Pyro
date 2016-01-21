using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Interfaces
{
  public interface IResourceServices
  {
    // Get By id
    // GET URL/FhirApi/Patient/5    
    IFhirRestResponse Get(string FhirResourceId);

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    IFhirRestResponse Get(Uri uri, Hl7.Fhir.Rest.SearchParams searchParams);

    // Add
    // POST: URL/FhirApi/Patient
    IFhirRestResponse Post(Hl7.Fhir.Model.Resource resource);

    //Update
    // PUT: URL/FhirApi/Patient/5
    IFhirRestResponse Put(string FhirResourceId, Hl7.Fhir.Model.Resource resource);
    IFhirRestResponse Delete(string FhirResourceId);
  }

}
