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
    IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri);
    IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri);
    void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion);
    IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber);
    IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false);
  }
}
