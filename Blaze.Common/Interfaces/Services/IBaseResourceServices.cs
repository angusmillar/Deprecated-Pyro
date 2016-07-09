using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Blaze.Common.Interfaces.Services
{
  public interface IBaseResourceServices
  {

    FHIRDefinedType CurrentResourceType { get; }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    IBlazeServiceOperationOutcome Get(string FhirId);

    // Get By id and vid
    // GET URL/FhirApi/Patient/5/_history/2    
    IBlazeServiceOperationOutcome Get(string FhirId, string FhirVId);

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    IBlazeServiceOperationOutcome Get(Uri uri, Hl7.Fhir.Rest.SearchParams searchParams);

    // Add
    // POST: URL/FhirApi/Patient
    IBlazeServiceOperationOutcome Post(Common.Interfaces.Services.IBlazeServiceRequest BlazeServiceRequest);

    //Update
    // PUT: URL/FhirApi/Patient/5
    IBlazeServiceOperationOutcome Put(Common.Interfaces.Services.IBlazeServiceRequest BlazeServiceRequest);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IBlazeServiceOperationOutcome Delete(string FhirResourceId);
  }

}
