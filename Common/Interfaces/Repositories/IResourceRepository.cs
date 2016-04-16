using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.BusinessEntities;
using Hl7.Fhir.Model;

namespace Common.Interfaces.Repositories
{
  public interface IResourceRepository
  {
    string AddResource(DtoEnums.SupportedFhirResource SupportedFhirResource, Hl7.Fhir.Model.Resource Resource);
    string UpdateResource(int ResourceVersion, Hl7.Fhir.Model.Resource FhirResource);
    void UpdateResouceAsDeleted(string FhirResourceId);
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
