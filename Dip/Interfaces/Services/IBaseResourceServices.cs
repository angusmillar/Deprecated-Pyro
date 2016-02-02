using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace Dip.Interfaces.Services
{
  public interface IBaseResourceServices
  {

    DtoEnums.SupportedFhirResource CurrentResourceType { get; }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    IBlazeServiceOperationOutcome Get(string FhirResourceId);

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    IBlazeServiceOperationOutcome Get(Uri uri, Hl7.Fhir.Rest.SearchParams searchParams);

    // Add
    // POST: URL/FhirApi/Patient
    IBlazeServiceOperationOutcome Post(Hl7.Fhir.Model.Resource resource);

    //Update
    // PUT: URL/FhirApi/Patient/5
    IBlazeServiceOperationOutcome Put(string FhirResourceId, Hl7.Fhir.Model.Resource resource);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IBlazeServiceOperationOutcome Delete(string FhirResourceId);
  }

}
