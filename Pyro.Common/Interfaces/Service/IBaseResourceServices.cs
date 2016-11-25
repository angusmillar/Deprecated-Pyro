using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Service
{
  public interface IBaseResourceServices
  {

    FHIRAllTypes CurrentResourceType { get; }

    // Get By id
    // GET URL/FhirApi/Patient/5    
    //IServiceOperationOutcome Get(string FhirId);

    // Get By id and vid
    // GET URL/FhirApi/Patient/5/_history/2    
    //IServiceOperationOutcome Get(string FhirId, string FhirVId);

    //Search
    // GET: URL/FhirApi/Patient/5    
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    // GET: URL/FhirApi/Patient/5/_history    
    // GET: URL/FhirApi/Patient/5/_history/2    
    IResourceServiceOutcome Get(IResourceServiceRequest PyroServiceRequest);

    // Add
    // POST: URL/FhirApi/Patient
    IResourceServiceOutcome Post(IResourceServiceRequest PyroServiceRequest);

    //Update
    // PUT: URL/FhirApi/Patient/5
    IResourceServiceOutcome Put(IResourceServiceRequest PyroServiceRequest);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IResourceServiceOutcome Delete(IResourceServiceRequest PyroServiceRequest);

    //Conditional Delete
    // DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    IResourceServiceOutcome ConditionalDelete(IResourceServiceRequest PyroServiceRequest);

    //Conditional Update
    /// PUT: URL/FhirApi/Patient?given=angus
    IResourceServiceOutcome ConditionalPut(IResourceServiceRequest PyroServiceRequest);


  }

}
