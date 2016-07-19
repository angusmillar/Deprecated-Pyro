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
  public partial class PractitionerRepository : CommonRepository, IResourceRepository
  {

    public PractitionerRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Practitioner;
      var ResourceEntity = new Res_Practitioner();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Practitioner>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Practitioner;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Practitioner_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Practitioner_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Practitioner_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Practitioner_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Practitioner_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Practitioner>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Practitioner>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Practitioner>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Practitioner LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Practitioner, object>>>();
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.address_city_List);
      IncludeList.Add(x => x.address_country_List);
      IncludeList.Add(x => x.address_postalcode_List);
      IncludeList.Add(x => x.address_state_List);
      IncludeList.Add(x => x.address_use_List);
      IncludeList.Add(x => x.communication_List);
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.family_List);
      IncludeList.Add(x => x.given_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.location_List);
      IncludeList.Add(x => x.name_List);
      IncludeList.Add(x => x.organization_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.phonetic_List);
      IncludeList.Add(x => x.role_List);
      IncludeList.Add(x => x.specialty_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Practitioner>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Practitioner ResourceEntity)
    {
      ResourceEntity.gender_Code = null;      
      ResourceEntity.gender_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Practitioner_Index_address.RemoveRange(ResourceEntity.address_List);            
      _Context.Res_Practitioner_Index_address_city.RemoveRange(ResourceEntity.address_city_List);            
      _Context.Res_Practitioner_Index_address_country.RemoveRange(ResourceEntity.address_country_List);            
      _Context.Res_Practitioner_Index_address_postalcode.RemoveRange(ResourceEntity.address_postalcode_List);            
      _Context.Res_Practitioner_Index_address_state.RemoveRange(ResourceEntity.address_state_List);            
      _Context.Res_Practitioner_Index_address_use.RemoveRange(ResourceEntity.address_use_List);            
      _Context.Res_Practitioner_Index_communication.RemoveRange(ResourceEntity.communication_List);            
      _Context.Res_Practitioner_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_Practitioner_Index_email.RemoveRange(ResourceEntity.email_List);            
      _Context.Res_Practitioner_Index_family.RemoveRange(ResourceEntity.family_List);            
      _Context.Res_Practitioner_Index_given.RemoveRange(ResourceEntity.given_List);            
      _Context.Res_Practitioner_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Practitioner_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Practitioner_Index_location.RemoveRange(ResourceEntity.location_List);            
      _Context.Res_Practitioner_Index_name.RemoveRange(ResourceEntity.name_List);            
      _Context.Res_Practitioner_Index_organization.RemoveRange(ResourceEntity.organization_List);            
      _Context.Res_Practitioner_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_Practitioner_Index_phone.RemoveRange(ResourceEntity.phone_List);            
      _Context.Res_Practitioner_Index_phonetic.RemoveRange(ResourceEntity.phonetic_List);            
      _Context.Res_Practitioner_Index_role.RemoveRange(ResourceEntity.role_List);            
      _Context.Res_Practitioner_Index_specialty.RemoveRange(ResourceEntity.specialty_List);            
      _Context.Res_Practitioner_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_Practitioner_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_Practitioner_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Practitioner_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Practitioner_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Practitioner ResourseEntity, string ResourceVersion, Practitioner ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Gender != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.GenderElement);
        if (Index != null)
        {
          ResourseEntity.gender_Code = Index.Code;
          ResourseEntity.gender_System = Index.System;
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
          var Index = new Res_Practitioner_Index_address();
          Index.String = AddressTotal.ToString();
          ResourseEntity.address_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.City != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Practitioner_Index_address_city(), item1.CityElement) as Res_Practitioner_Index_address_city;
          ResourseEntity.address_city_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.Country != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Practitioner_Index_address_country(), item1.CountryElement) as Res_Practitioner_Index_address_country;
          ResourseEntity.address_country_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.PostalCode != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Practitioner_Index_address_postalcode(), item1.PostalCodeElement) as Res_Practitioner_Index_address_postalcode;
          ResourseEntity.address_postalcode_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.State != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Practitioner_Index_address_state(), item1.StateElement) as Res_Practitioner_Index_address_state;
          ResourseEntity.address_state_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Address)
      {
        if (item1.Use != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_address_use(), item1.UseElement) as Res_Practitioner_Index_address_use;
          ResourseEntity.address_use_List.Add(Index);
        }
      }

      if (ResourceTyped.Communication != null)
      {
        foreach (var item3 in ResourceTyped.Communication)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_communication(), item4) as Res_Practitioner_Index_communication;
              ResourseEntity.communication_List.Add(Index);
            }
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2.System != null)
        {
          if ((ContactPoint.ContactPointSystem)item2.System == ContactPoint.ContactPointSystem.Email)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_email(), item2) as Res_Practitioner_Index_email;
            ResourseEntity.email_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        foreach (var item3 in item1.Telecom)
        {
          if (item3.System != null)
          {
            if ((ContactPoint.ContactPointSystem)item3.System == ContactPoint.ContactPointSystem.Email)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_email(), item3) as Res_Practitioner_Index_email;
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
            var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Practitioner_Index_family(), item4) as Res_Practitioner_Index_family;
            ResourseEntity.family_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Name)
      {
        if (item1.Given != null)
        {
          foreach (var item4 in item1.GivenElement)
          {
            var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Practitioner_Index_given(), item4) as Res_Practitioner_Index_given;
            ResourseEntity.given_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_identifier(), item3) as Res_Practitioner_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        if (item1.Identifier != null)
        {
          foreach (var item4 in item1.Identifier)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_identifier(), item4) as Res_Practitioner_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        if (item1.Location != null)
        {
          foreach (var item in item1.Location)
          {
            var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Practitioner_Index_location(), item, FhirRequestUri, this) as Res_Practitioner_Index_location;
            if (Index != null)
            {
              ResourseEntity.location_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        foreach (var item3 in ResourceTyped.Name)
        {
          StringBuilder NameTotal = new StringBuilder();
          foreach (var Given in item3.Given)
            NameTotal.Append(Given).Append(" ");
          foreach (var Family in item3.Family)
            NameTotal.Append(Family).Append(" ");
          if (NameTotal.Length > 0)
          {
             var Index = new Res_Practitioner_Index_name();
            Index.String = NameTotal.ToString();
            ResourseEntity.name_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        if (item1.Organization != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Practitioner_Index_organization(), item1.Organization, FhirRequestUri, this) as Res_Practitioner_Index_organization;
          if (Index != null)
          {
            ResourseEntity.organization_List.Add(Index);
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        if (item2.System != null)
        {
          if ((ContactPoint.ContactPointSystem)item2.System == ContactPoint.ContactPointSystem.Phone)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_phone(), item2) as Res_Practitioner_Index_phone;
            ResourseEntity.phone_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        foreach (var item3 in item1.Telecom)
        {
          if (item3.System != null)
          {
            if ((ContactPoint.ContactPointSystem)item3.System == ContactPoint.ContactPointSystem.Phone)
            {
              var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_phone(), item3) as Res_Practitioner_Index_phone;
              ResourseEntity.phone_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        foreach (var item3 in ResourceTyped.Name)
        {
          StringBuilder NameTotal = new StringBuilder();
          foreach (var Given in item3.Given)
            NameTotal.Append(Given).Append(" ");
          foreach (var Family in item3.Family)
            NameTotal.Append(Family).Append(" ");
          if (NameTotal.Length > 0)
          {
             var Index = new Res_Practitioner_Index_phonetic();
            Index.String = NameTotal.ToString();
            ResourseEntity.phonetic_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        if (item1.Role != null)
        {
          foreach (var item4 in item1.Role.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_role(), item4) as Res_Practitioner_Index_role;
            ResourseEntity.role_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        if (item1.Specialty != null)
        {
          foreach (var item4 in item1.Specialty)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_specialty(), item5) as Res_Practitioner_Index_specialty;
                ResourseEntity.specialty_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item2 in ResourceTyped.Telecom)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_telecom(), item2) as Res_Practitioner_Index_telecom;
        ResourseEntity.telecom_List.Add(Index);
      }

      foreach (var item1 in ResourceTyped.PractitionerRole)
      {
        foreach (var item3 in item1.Telecom)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_telecom(), item3) as Res_Practitioner_Index_telecom;
          ResourseEntity.telecom_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Practitioner_Index_profile(), item4) as Res_Practitioner_Index_profile;
            ResourseEntity.profile_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Security != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Security)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_security(), item4) as Res_Practitioner_Index_security;
            ResourseEntity.security_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Tag != null)
        {
          foreach (var item4 in ResourceTyped.Meta.Tag)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Practitioner_Index_tag(), item4) as Res_Practitioner_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

