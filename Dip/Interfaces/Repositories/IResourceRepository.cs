using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace Dip.Interfaces.Repositories
{
  public interface IResourceRepository
  {
    
    int GetResourceCurrentVersion(string FhirResourceId);
    DtoResource GetCurrentResourceWithOutXml(string FhirResourceId);
    IDatabaseOperationOutcome GetCurrentResourceList(string FhirResourceId, DtoEnums.SupportedFhirResource CurrentResourceType);
    IDatabaseOperationOutcome GetCurrentResource(string FhirResourceId, DtoEnums.SupportedFhirResource CurrentResourceType);
    bool IsCurrentResourceDeleted(string FhirResourceId);
    int LastDeletedResourceVersion(string FhirResourceId);
    bool ResourceExists(string FhirResourceId);
    DtoEnums.SupportedFhirResource GetSupportedResourceTypeForFhirResourceId(string FhirResourceId);
  }
}
