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
using DataModel.BlazeDbModel2;

namespace DataModel.BlazeRepository
{  
  public class ResourceRepositoryBase : RepositoryBase , IResourceRepository
  {

    string IResourceRepository.AddResource(DtoEnums.SupportedFhirResource SupportedFhirResource, Hl7.Fhir.Model.Resource Resource)
    {
      
      //ResourceType ResourceType = 
 
      var DbPatient = new Resource_Patient();
      DbPatient.FhirId = Resource.Id;
      Patient PatientResource = Resource as Patient;

      if (PatientResource.Active != null)
      {
        DbPatient.active_Code = PatientResource.Active.ToString();
        DbPatient.active_System = "http://hl7.org/fhir/special-values";
      }

      if (PatientResource.Address != null)
      {
        foreach(var Address in PatientResource.Address)
        {
          if (Address.City != null)
          {
            if (DbPatient.address_city_List == null)
              DbPatient.address_city_List = new List<Resource_Patient_Search_address_city>();
            DbPatient.address_city_List.Add(new Resource_Patient_Search_address_city() { String = Address.City });
          }
          if (Address.Country != null)
          {
            if (DbPatient.address_country_List == null)
              DbPatient.address_country_List = new List<Resource_Patient_Search_address_country>();
            DbPatient.address_country_List.Add(new Resource_Patient_Search_address_country(){ String = Address.Country});            
          }
          if (Address.PostalCode != null)
          {
            if (DbPatient.address_postalcode_List == null)
              DbPatient.address_postalcode_List = new List<Resource_Patient_Search_address_postalcode>();
            DbPatient.address_postalcode_List.Add(new Resource_Patient_Search_address_postalcode() { String = Address.PostalCode});
          }
          if (Address.State != null)
          {
            if (DbPatient.address_state_List == null)
              DbPatient.address_state_List = new List<Resource_Patient_Search_address_state>();
            DbPatient.address_state_List.Add(new Resource_Patient_Search_address_state() { String = Address.State });
          }
          if (Address.Use != null)
          {
            if (DbPatient.address_use_List == null)
              DbPatient.address_use_List = new List<Resource_Patient_Search_address_use>();
            DbPatient.address_use_List.Add(new Resource_Patient_Search_address_use() { Code = Address.Use.ToString()});
          }
          if (Address.Text != null)
          {
            if (DbPatient.address_List == null)
              DbPatient.address_List = new List<Resource_Patient_Search_address>();
            DbPatient.address_List.Add(new Resource_Patient_Search_address() { String = Address.Text});
          }
        }
        
        if (PatientResource.Animal != null)
        {
          if (PatientResource.Animal.Breed != null)
          {
            if (PatientResource.Animal.Breed.Coding != null)
            {
              //PatientResource.Animal.Breed.Coding
              //DbPatient.animal_breed_Code = 
            }            
          }
        }
        



      }


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
