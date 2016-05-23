using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Model;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface IResourceRepository
  {
    string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri);
    string UpdateResource(int ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri);
    void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion);
    IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, int ResourceVersionNumber);
    IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId);    
  }
}
