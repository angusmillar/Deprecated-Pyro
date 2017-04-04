using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServices
  {
    void BeginTransaction();
    void CommitTransaction();
    void RolbackTransaction();
    bool IsTransactional { get; }
     


    //Read
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetRead(IResourceServiceRequestGetRead PyroServiceRequestGetRead);

    //Search
    // GET: URL/FhirApi/Patient/5    
    IResourceServiceOutcome GetSearch(IResourceServiceRequestGetSearch PyroServiceRequestGetSearch);

    //History
    // GET: URL/FhirApi/Patient/5/_history    
    // GET: URL/FhirApi/Patient/5/_history/2    
    IResourceServiceOutcome GetHistory(IResourceServiceRequestGetHistory PyroServiceRequestGetHistory);

    // Add
    // POST: URL/FhirApi/Patient
    IResourceServiceOutcome Post(IResourceServiceRequestPost PyroServiceRequestPost);

    //Update
    // PUT: URL/FhirApi/Patient/5
    IResourceServiceOutcome Put(IResourceServiceRequestPut PyroServiceRequestPut);

    //Delete
    // DELETE: URL/FhirApi/Patient/5    
    IResourceServiceOutcome Delete(IResourceServiceRequestDelete PyroServiceRequestDelete);

    //Conditional Delete
    // DELETE: URL/FhirApi/Patient?identifier=12345&family=millar&given=angus 
    IResourceServiceOutcome ConditionalDelete(IResourceServiceRequestConditionalDelete PyroServiceRequestConditionalDelete);

    //Conditional Update
    /// PUT: URL/FhirApi/Patient?given=angus
    IResourceServiceOutcome ConditionalPut(IResourceServiceRequestConditionalPut PyroServiceRequestConditionalPut);


  }

}
