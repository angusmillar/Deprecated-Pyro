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

    FHIRAllTypes CurrentResourceType { get; }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    IServiceOperationOutcome Get(string FhirId);

    // Get By id and vid
    // GET URL/FhirApi/Patient/5/_history/2    
    IServiceOperationOutcome Get(string FhirId, string FhirVId);

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    IServiceOperationOutcome Get(IBlazeServiceRequest BlazeServiceRequest);

    // Add
    // POST: URL/FhirApi/Patient
    IServiceOperationOutcome Post(IBlazeServiceRequest BlazeServiceRequest);

    //Update
    // PUT: URL/FhirApi/Patient/5
    IServiceOperationOutcome Put(IBlazeServiceRequest BlazeServiceRequest);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IServiceOperationOutcome Delete(string FhirResourceId);
  }

}
