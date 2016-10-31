using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pyro.DataModel.DatabaseModel;
using Pyro.DataModel.DatabaseModel.Base;
using Pyro.DataModel.Support;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.Search;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Search;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Pyro.DataModel.Repository
{
  public partial class PatientRepository : CommonRepository, IResourceRepository
  {
    public PatientRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_Patient>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_Patient>(Predicate);
      var Query = DbGetAll<Res_Patient>(Predicate);

      //Todo: Sort not implemented just defaulting to last update order
      Query = Query.OrderBy(x => x.lastUpdated);      
      int ClaculatedPageRequired = PaginationSupport.CalculatePageRequired(DtoSearchParameters.RequiredPageNumber, _NumberOfRecordsPerPage, TotalRecordCount);
      
      Query = Query.Paging(ClaculatedPageRequired, _NumberOfRecordsPerPage);
      var DtoResourceList = new List<Common.BusinessEntities.Dto.DtoResource>();
      Query.ToList().ForEach(x => DtoResourceList.Add(IndexSettingSupport.SetDtoResource(x)));

      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = false;
      DatabaseOperationOutcome.PagesTotal = PaginationSupport.CalculateTotalPages(_NumberOfRecordsPerPage, TotalRecordCount); ;
      DatabaseOperationOutcome.PageRequested = ClaculatedPageRequired;
      DatabaseOperationOutcome.ReturnedResourceCount = TotalRecordCount;
      DatabaseOperationOutcome.ReturnedResourceList = DtoResourceList;


      return DatabaseOperationOutcome;  
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Patient;
      var ResourceEntity = new Res_Patient();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Patient>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Patient;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Patient_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Patient_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_Patient_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Patient_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      ResourceEntity.XmlBlob = string.Empty;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Patient_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Patient>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);        
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Pyro.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {        
        DtoResource = DbGetAll<Res_Patient>(x => x.FhirId == FhirResourceId).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_Patient>(x => x.FhirId == FhirResourceId).Select(x => new Pyro.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Patient LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Patient, object>>>();
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.address_city_List);
      IncludeList.Add(x => x.address_country_List);
      IncludeList.Add(x => x.address_postalcode_List);
      IncludeList.Add(x => x.address_state_List);
      IncludeList.Add(x => x.address_use_List);
      IncludeList.Add(x => x.animal_breed_List);
      IncludeList.Add(x => x.animal_species_List);
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.family_List);
      IncludeList.Add(x => x.general_practitioner_List);
      IncludeList.Add(x => x.given_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.language_List);
      IncludeList.Add(x => x.link_List);
      IncludeList.Add(x => x.name_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.phonetic_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Patient>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Patient ResourceEntity)
    {
      ResourceEntity.active_Code = null;      
      ResourceEntity.active_System = null;      
      ResourceEntity.birthdate_Date = null;      
      ResourceEntity.death_date_DateTimeOffset = null;      
      ResourceEntity.deceased_Code = null;      
      ResourceEntity.deceased_System = null;      
      ResourceEntity.deceased_Code = null;      
      ResourceEntity.deceased_System = null;      
      ResourceEntity.gender_Code = null;      
      ResourceEntity.gender_System = null;      
      ResourceEntity.organization_VersionId = null;      
      ResourceEntity.organization_FhirId = null;      
      ResourceEntity.organization_Type = null;      
      ResourceEntity.organization_Url = null;      
      ResourceEntity.organization_ServiceRootURL_StoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Patient_Index_address.RemoveRange(ResourceEntity.address_List);            
      _Context.Res_Patient_Index_address_city.RemoveRange(ResourceEntity.address_city_List);            
      _Context.Res_Patient_Index_address_country.RemoveRange(ResourceEntity.address_country_List);            
      _Context.Res_Patient_Index_address_postalcode.RemoveRange(ResourceEntity.address_postalcode_List);            
      _Context.Res_Patient_Index_address_state.RemoveRange(ResourceEntity.address_state_List);            
      _Context.Res_Patient_Index_address_use.RemoveRange(ResourceEntity.address_use_List);            
      _Context.Res_Patient_Index_animal_breed.RemoveRange(ResourceEntity.animal_breed_List);            
      _Context.Res_Patient_Index_animal_species.RemoveRange(ResourceEntity.animal_species_List);            
      _Context.Res_Patient_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_Patient_Index_family.RemoveRange(ResourceEntity.family_List);            
      _Context.Res_Patient_Index_general_practitioner.RemoveRange(ResourceEntity.general_practitioner_List);            
      _Context.Res_Patient_Index_given.RemoveRange(ResourceEntity.given_List);            
      _Context.Res_Patient_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Patient_Index_language.RemoveRange(ResourceEntity.language_List);            
      _Context.Res_Patient_Index_link.RemoveRange(ResourceEntity.link_List);            
      _Context.Res_Patient_Index_name.RemoveRange(ResourceEntity.name_List);            
      _Context.Res_Patient_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_Patient_Index_phonetic.RemoveRange(ResourceEntity.phonetic_List);            
      _Context.Res_Patient_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_Patient_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_Patient_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_Patient_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Patient ResourseEntity, string ResourceVersion, Patient ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Active != null)
      {
        if (ResourceTyped.ActiveElement is Hl7.Fhir.Model.FhirBoolean)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.ActiveElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.active_Code = Index.Code;
            ResourseEntity.active_System = Index.System;
          }
        }
      }

      if (ResourceTyped.BirthDate != null)
      {
        if (ResourceTyped.BirthDateElement is Hl7.Fhir.Model.Date)
        {
          var Index = new DateIndex();
          Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(ResourceTyped.BirthDateElement, Index) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.birthdate_Date = Index.Date;
          }
        }
      }

      if (ResourceTyped.Deceased != null)
      {
        if (ResourceTyped.Deceased is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.Deceased, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.death_date_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Deceased != null)
      {
        if (ResourceTyped.Deceased is Hl7.Fhir.Model.FhirBoolean)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Deceased, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.deceased_Code = Index.Code;
            ResourseEntity.deceased_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Deceased != null)
      {
        if (ResourceTyped.Deceased is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Deceased, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.deceased_Code = Index.Code;
            ResourseEntity.deceased_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Gender != null)
      {
        if (ResourceTyped.GenderElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.AdministrativeGender>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.GenderElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.gender_Code = Index.Code;
            ResourseEntity.gender_System = Index.System;
          }
        }
      }

      if (ResourceTyped.ManagingOrganization != null)
      {
        if (ResourceTyped.ManagingOrganization is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.ManagingOrganization, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.organization_Type = Index.Type;
            ResourseEntity.organization_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.organization_Url = Index.Url;
            }
            else
            {
              ResourseEntity.organization_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Address != null)
      {
        foreach (var item2 in ResourceTyped.Address)
        {
          var Index = new Res_Patient_Index_address();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item2, Index) as Res_Patient_Index_address;
          ResourseEntity.address_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.City != null)
        {
          if (item1.CityElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_Patient_Index_address_city();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item1.CityElement, Index) as Res_Patient_Index_address_city;
            ResourseEntity.address_city_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.Country != null)
        {
          if (item1.CountryElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_Patient_Index_address_country();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item1.CountryElement, Index) as Res_Patient_Index_address_country;
            ResourseEntity.address_country_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.PostalCode != null)
        {
          if (item1.PostalCodeElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_Patient_Index_address_postalcode();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item1.PostalCodeElement, Index) as Res_Patient_Index_address_postalcode;
            ResourseEntity.address_postalcode_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.State != null)
        {
          if (item1.StateElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_Patient_Index_address_state();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item1.StateElement, Index) as Res_Patient_Index_address_state;
            ResourseEntity.address_state_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.Use != null)
        {
          if (item1.UseElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.Address.AddressUse>)
          {
            var Index = new Res_Patient_Index_address_use();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item1.UseElement, Index) as Res_Patient_Index_address_use;
            ResourseEntity.address_use_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Animal != null)
      {
        if (ResourceTyped.Animal.Breed != null)
        {
          foreach (var item4 in ResourceTyped.Animal.Breed.Coding)
          {
            var Index = new Res_Patient_Index_animal_breed();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Patient_Index_animal_breed;
            ResourseEntity.animal_breed_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Animal != null)
      {
        if (ResourceTyped.Animal.Species != null)
        {
          foreach (var item4 in ResourceTyped.Animal.Species.Coding)
          {
            var Index = new Res_Patient_Index_animal_species();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Patient_Index_animal_species;
            ResourseEntity.animal_species_List.Add(Index);
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2.System != null)
        {
          if ((ContactPoint.ContactPointSystem)item2.System == ContactPoint.ContactPointSystem.Email)
          {
            if (item2 is ContactPoint)
            {
              var Index = new Res_Patient_Index_email();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2, Index) as Res_Patient_Index_email;
              ResourseEntity.email_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Name)
      {
        if (item1.Family != null)
        {
          foreach (var item4 in item1.FamilyElement)
          {
            if (item4 is Hl7.Fhir.Model.FhirString)
            {
              var Index = new Res_Patient_Index_family();
              Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item4, Index) as Res_Patient_Index_family;
              ResourseEntity.family_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.GeneralPractitioner != null)
      {
        foreach (var item in ResourceTyped.GeneralPractitioner)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Patient_Index_general_practitioner();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Patient_Index_general_practitioner;
            if (Index != null)
            {
              ResourseEntity.general_practitioner_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Name)
      {
        if (item1.Given != null)
        {
          foreach (var item4 in item1.GivenElement)
          {
            if (item4 is Hl7.Fhir.Model.FhirString)
            {
              var Index = new Res_Patient_Index_given();
              Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item4, Index) as Res_Patient_Index_given;
              ResourseEntity.given_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            var Index = new Res_Patient_Index_identifier();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_Patient_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Communication)
      {
        if (item1.Language != null)
        {
          foreach (var item4 in item1.Language.Coding)
          {
            var Index = new Res_Patient_Index_language();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Patient_Index_language;
            ResourseEntity.language_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Link)
      {
        if (item1.Other != null)
        {
          if (item1.Other is ResourceReference)
          {
            var Index = new Res_Patient_Index_link();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Other, Index, FhirRequestUri, this) as Res_Patient_Index_link;
            if (Index != null)
            {
              ResourseEntity.link_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        foreach (var item3 in ResourceTyped.Name)
        {
          var Index = new Res_Patient_Index_name();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item3, Index) as Res_Patient_Index_name;
          ResourseEntity.name_List.Add(Index);
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2.System != null)
        {
          if ((ContactPoint.ContactPointSystem)item2.System == ContactPoint.ContactPointSystem.Phone)
          {
            if (item2 is ContactPoint)
            {
              var Index = new Res_Patient_Index_phone();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2, Index) as Res_Patient_Index_phone;
              ResourseEntity.phone_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        foreach (var item3 in ResourceTyped.Name)
        {
          var Index = new Res_Patient_Index_phonetic();
          Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item3, Index) as Res_Patient_Index_phonetic;
          ResourseEntity.phonetic_List.Add(Index);
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2 is ContactPoint)
        {
          var Index = new Res_Patient_Index_telecom();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item2, Index) as Res_Patient_Index_telecom;
          ResourseEntity.telecom_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            if (item4 is Hl7.Fhir.Model.FhirUri)
            {
              var Index = new Res_Patient_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Patient_Index__profile;
              ResourseEntity._profile_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Security != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Security)
          {
            if (item4 is Hl7.Fhir.Model.Coding)
            {
              var Index = new Res_Patient_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Patient_Index__security;
              ResourseEntity._security_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Tag != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Tag)
          {
            if (item4 is Hl7.Fhir.Model.Coding)
            {
              var Index = new Res_Patient_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Patient_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

