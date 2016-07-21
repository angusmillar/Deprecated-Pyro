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
  public partial class OrganizationRepository : CommonRepository, IResourceRepository
  {

    public OrganizationRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Organization;
      var ResourceEntity = new Res_Organization();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Organization>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Organization;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Organization_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Organization_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Organization_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Organization_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Organization_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Organization>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Organization>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Organization>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Organization LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Organization, object>>>();
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.address_city_List);
      IncludeList.Add(x => x.address_country_List);
      IncludeList.Add(x => x.address_postalcode_List);
      IncludeList.Add(x => x.address_state_List);
      IncludeList.Add(x => x.address_use_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Organization>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Organization ResourceEntity)
    {
      ResourceEntity.active_Code = null;      
      ResourceEntity.active_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.partof_FhirId = null;      
      ResourceEntity.partof_Type = null;      
      ResourceEntity.partof_Url = null;      
      ResourceEntity.partof_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.phonetic_String = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Organization_Index_address.RemoveRange(ResourceEntity.address_List);            
      _Context.Res_Organization_Index_address_city.RemoveRange(ResourceEntity.address_city_List);            
      _Context.Res_Organization_Index_address_country.RemoveRange(ResourceEntity.address_country_List);            
      _Context.Res_Organization_Index_address_postalcode.RemoveRange(ResourceEntity.address_postalcode_List);            
      _Context.Res_Organization_Index_address_state.RemoveRange(ResourceEntity.address_state_List);            
      _Context.Res_Organization_Index_address_use.RemoveRange(ResourceEntity.address_use_List);            
      _Context.Res_Organization_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Organization_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Organization_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Organization_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Organization_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Organization ResourseEntity, string ResourceVersion, Organization ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Active != null)
      {
        if (ResourceTyped.ActiveElement is Hl7.Fhir.Model.FhirBoolean)
        {
          TokenIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.ActiveElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.active_Code = Index.Code;
            ResourseEntity.active_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        if (ResourceTyped.NameElement is Hl7.Fhir.Model.FhirString)
        {
          StringIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.NameElement) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.name_String = Index.String;
          }
        }
      }

      if (ResourceTyped.PartOf != null)
      {
        if (ResourceTyped.PartOf is ResourceReference)
        {
          ReferenceIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.PartOf, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.partof_Type = Index.Type;
            ResourseEntity.partof_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.partof_Url = Index.Url;
            }
            else
            {
              ResourseEntity.partof_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        if (ResourceTyped.NameElement is Hl7.Fhir.Model.FhirString)
        {
          StringIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.NameElement) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.phonetic_String = Index.String;
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
          var Index = new Res_Organization_Index_address();
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
            Res_Organization_Index_address_city Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item1.CityElement) as Res_Organization_Index_address_city;
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
            Res_Organization_Index_address_country Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item1.CountryElement) as Res_Organization_Index_address_country;
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
            Res_Organization_Index_address_postalcode Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item1.PostalCodeElement) as Res_Organization_Index_address_postalcode;
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
            Res_Organization_Index_address_state Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item1.StateElement) as Res_Organization_Index_address_state;
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
            Res_Organization_Index_address_use Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item1.UseElement) as Res_Organization_Index_address_use;
            ResourseEntity.address_use_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          if (item3 is Hl7.Fhir.Model.Identifier)
          {
            Res_Organization_Index_identifier Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Organization_Index_identifier;
            ResourseEntity.identifier_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          Res_Organization_Index_type Index = null;
          Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Organization_Index_type;
          ResourseEntity.type_List.Add(Index);
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
              Res_Organization_Index_profile Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Organization_Index_profile;
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
              Res_Organization_Index_security Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Organization_Index_security;
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
              Res_Organization_Index_tag Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Organization_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

