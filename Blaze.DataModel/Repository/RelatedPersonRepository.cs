using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class RelatedPersonRepository : CommonRepository, IResourceRepository
  {

    public RelatedPersonRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as RelatedPerson;
      var ResourceEntity = new Res_RelatedPerson();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_RelatedPerson>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as RelatedPerson;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_RelatedPerson_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_RelatedPerson_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_RelatedPerson_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_RelatedPerson_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_RelatedPerson_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_RelatedPerson>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);        
      }
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Blaze.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {        
        DtoResource = DbGetALL<Res_RelatedPerson>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_RelatedPerson>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_RelatedPerson LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_RelatedPerson, object>>>();
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.address_city_List);
      IncludeList.Add(x => x.address_country_List);
      IncludeList.Add(x => x.address_postalcode_List);
      IncludeList.Add(x => x.address_state_List);
      IncludeList.Add(x => x.address_use_List);
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.name_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.phonetic_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_RelatedPerson>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_RelatedPerson ResourceEntity)
    {
      ResourceEntity.birthdate_DateTimeOffset = null;      
      ResourceEntity.gender_Code = null;      
      ResourceEntity.gender_System = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_RelatedPerson_Index_address.RemoveRange(ResourceEntity.address_List);            
      _Context.Res_RelatedPerson_Index_address_city.RemoveRange(ResourceEntity.address_city_List);            
      _Context.Res_RelatedPerson_Index_address_country.RemoveRange(ResourceEntity.address_country_List);            
      _Context.Res_RelatedPerson_Index_address_postalcode.RemoveRange(ResourceEntity.address_postalcode_List);            
      _Context.Res_RelatedPerson_Index_address_state.RemoveRange(ResourceEntity.address_state_List);            
      _Context.Res_RelatedPerson_Index_address_use.RemoveRange(ResourceEntity.address_use_List);            
      _Context.Res_RelatedPerson_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_RelatedPerson_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_RelatedPerson_Index_name.RemoveRange(ResourceEntity.name_List);            
      _Context.Res_RelatedPerson_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_RelatedPerson_Index_phonetic.RemoveRange(ResourceEntity.phonetic_List);            
      _Context.Res_RelatedPerson_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_RelatedPerson_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_RelatedPerson_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_RelatedPerson_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_RelatedPerson ResourseEntity, string ResourceVersion, RelatedPerson ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.BirthDate != null)
      {
        if (ResourceTyped.BirthDateElement is Hl7.Fhir.Model.Date)
        {
          var Index = new DateIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.BirthDateElement) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.birthdate_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Gender != null)
      {
        if (ResourceTyped.GenderElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.AdministrativeGender>)
        {
          var Index = new TokenIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.GenderElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.gender_Code = Index.Code;
            ResourseEntity.gender_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Patient, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.patient_Type = Index.Type;
            ResourseEntity.patient_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.patient_Url = Index.Url;
            }
            else
            {
              ResourseEntity.patient_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Address != null)
      {
        foreach (var item2 in ResourceTyped.Address)
        {
          StringBuilder AddressTotal = new StringBuilder();
          foreach (var Line in item2.Line)
            AddressTotal.Append(Line).Append(" ");
          AddressTotal.Append(item2.City).Append(" ");
          AddressTotal.Append(item2.PostalCode).Append(" ");
          AddressTotal.Append(item2.State).Append(" ");
          AddressTotal.Append(item2.Country).Append(" ");
          var Index = new Res_RelatedPerson_Index_address();
          Index.String = AddressTotal.ToString();
          ResourseEntity.address_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.City != null)
        {
          if (item1.CityElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_RelatedPerson_Index_address_city();
            Index = IndexSettingSupport.SetIndex(Index, item1.CityElement) as Res_RelatedPerson_Index_address_city;
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
            var Index = new Res_RelatedPerson_Index_address_country();
            Index = IndexSettingSupport.SetIndex(Index, item1.CountryElement) as Res_RelatedPerson_Index_address_country;
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
            var Index = new Res_RelatedPerson_Index_address_postalcode();
            Index = IndexSettingSupport.SetIndex(Index, item1.PostalCodeElement) as Res_RelatedPerson_Index_address_postalcode;
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
            var Index = new Res_RelatedPerson_Index_address_state();
            Index = IndexSettingSupport.SetIndex(Index, item1.StateElement) as Res_RelatedPerson_Index_address_state;
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
            var Index = new Res_RelatedPerson_Index_address_use();
            Index = IndexSettingSupport.SetIndex(Index, item1.UseElement) as Res_RelatedPerson_Index_address_use;
            ResourseEntity.address_use_List.Add(Index);
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
              var Index = new Res_RelatedPerson_Index_email();
              Index = IndexSettingSupport.SetIndex(Index, item2) as Res_RelatedPerson_Index_email;
              ResourseEntity.email_List.Add(Index);
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
            var Index = new Res_RelatedPerson_Index_identifier();
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_RelatedPerson_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        StringBuilder NameTotal = new StringBuilder();
        foreach (var Given in ResourceTyped.Name.Given)
          NameTotal.Append(Given).Append(" ");
        foreach (var Family in ResourceTyped.Name.Family)
          NameTotal.Append(Family).Append(" ");
        if (NameTotal.Length > 0)
        {
          var Index = new Res_RelatedPerson_Index_name();
          Index.String = NameTotal.ToString();
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
              var Index = new Res_RelatedPerson_Index_phone();
              Index = IndexSettingSupport.SetIndex(Index, item2) as Res_RelatedPerson_Index_phone;
              ResourseEntity.phone_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        StringBuilder NameTotal = new StringBuilder();
        foreach (var Given in ResourceTyped.Name.Given)
          NameTotal.Append(Given).Append(" ");
        foreach (var Family in ResourceTyped.Name.Family)
          NameTotal.Append(Family).Append(" ");
        if (NameTotal.Length > 0)
        {
          var Index = new Res_RelatedPerson_Index_phonetic();
          Index.String = NameTotal.ToString();
          ResourseEntity.phonetic_List.Add(Index);
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2 is ContactPoint)
        {
          var Index = new Res_RelatedPerson_Index_telecom();
          Index = IndexSettingSupport.SetIndex(Index, item2) as Res_RelatedPerson_Index_telecom;
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
              var Index = new Res_RelatedPerson_Index_profile();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_RelatedPerson_Index_profile;
              ResourseEntity.profile_List.Add(Index);
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
              var Index = new Res_RelatedPerson_Index_security();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_RelatedPerson_Index_security;
              ResourseEntity.security_List.Add(Index);
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
              var Index = new Res_RelatedPerson_Index_tag();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_RelatedPerson_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

