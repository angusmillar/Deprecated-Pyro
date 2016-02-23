using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.Model;
using Hl7.Fhir.Model;
using DataModel.ModelExtend;
using BusinessEntities;
using Dip.Interfaces;
using Dip.Interfaces.Repositories;

namespace DataModel.BlazeRepository
{  
  public class ResourceRepositoryBase : RepositoryBase , IResourceRepository
  {

    string IResourceRepository.AddResource(DtoEnums.SupportedFhirResource SupportedFhirResource, Hl7.Fhir.Model.Resource Resource)
    {      
      throw new NotImplementedException();
    }

    string IResourceRepository.UpdateResource(int ResourceVersion, Hl7.Fhir.Model.Resource FhirResource)
    {
      throw new NotImplementedException();
    }

    void IResourceRepository.UpdateResouceAsDeleted(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    int IResourceRepository.GetResourceCurrentVersion(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    DtoResource IResourceRepository.GetCurrentResourceWithOutXml(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    IDatabaseOperationOutcome IResourceRepository.GetCurrentResourceList(string FhirResourceId, DtoEnums.SupportedFhirResource CurrentResourceType)
    {
      throw new NotImplementedException();
    }

    IDatabaseOperationOutcome IResourceRepository.GetCurrentResource(string FhirResourceId, DtoEnums.SupportedFhirResource CurrentResourceType)
    {
      throw new NotImplementedException();
    }

    bool IResourceRepository.IsCurrentResourceDeleted(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    int IResourceRepository.LastDeletedResourceVersion(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    bool IResourceRepository.ResourceExists(string FhirResourceId)
    {
      throw new NotImplementedException();
    }

    DtoEnums.SupportedFhirResource IResourceRepository.GetSupportedResourceTypeForFhirResourceId(string FhirResourceId)
    {
      throw new NotImplementedException();
    }
  }
}
