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
  public partial class LocationRepository : CommonRepository, IResourceRepository
  {

    public LocationRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Location;
      var ResourceEntity = new Res_Location();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Location>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Location;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Location_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Location_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Location_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Location_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Location_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Location>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Location>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Location>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Location LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Location, object>>>();
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Location>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Location ResourceEntity)
    {
      ResourceEntity.address_city_String = null;      
      ResourceEntity.address_country_String = null;      
      ResourceEntity.address_postalcode_String = null;      
      ResourceEntity.address_state_String = null;      
      ResourceEntity.address_use_Code = null;      
      ResourceEntity.address_use_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.near_Code = null;      
      ResourceEntity.near_System = null;      
      ResourceEntity.near_distance_Code = null;      
      ResourceEntity.near_distance_System = null;      
      ResourceEntity.organization_FhirId = null;      
      ResourceEntity.organization_Type = null;      
      ResourceEntity.organization_Url = null;      
      ResourceEntity.organization_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.partof_FhirId = null;      
      ResourceEntity.partof_Type = null;      
      ResourceEntity.partof_Url = null;      
      ResourceEntity.partof_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Location_Index_address.RemoveRange(ResourceEntity.address_List);            
      _Context.Res_Location_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_Location_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Location_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Location_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Location_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Location ResourseEntity, string ResourceVersion, Location ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Address != null)
      {
        if (ResourceTyped.Address.City != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.Address.CityElement);
          if (Index != null)
          {
            ResourseEntity.address_city_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Address != null)
      {
        if (ResourceTyped.Address.Country != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.Address.CountryElement);
          if (Index != null)
          {
            ResourseEntity.address_country_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Address != null)
      {
        if (ResourceTyped.Address.PostalCode != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.Address.PostalCodeElement);
          if (Index != null)
          {
            ResourseEntity.address_postalcode_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Address != null)
      {
        if (ResourceTyped.Address.State != null)
        {
          var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.Address.StateElement);
          if (Index != null)
          {
            ResourseEntity.address_state_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Address != null)
      {
        if (ResourceTyped.Address.Use != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Address.UseElement);
          if (Index != null)
          {
            ResourseEntity.address_use_Code = Index.Code;
            ResourseEntity.address_use_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.NameElement);
        if (Index != null)
        {
          ResourseEntity.name_String = Index.String;
        }
      }

      if (ResourceTyped.Position != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Position);
        if (Index != null)
        {
          ResourseEntity.near_Code = Index.Code;
          ResourseEntity.near_System = Index.System;
        }
      }

      if (ResourceTyped.Position != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Position);
        if (Index != null)
        {
          ResourseEntity.near_distance_Code = Index.Code;
          ResourseEntity.near_distance_System = Index.System;
        }
      }

      if (ResourceTyped.ManagingOrganization != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.ManagingOrganization, FhirRequestUri, this);
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
              ResourseEntity.organization_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.PartOf != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.PartOf, FhirRequestUri, this);
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

      if (ResourceTyped.Status != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.StatusElement);
        if (Index != null)
        {
          ResourseEntity.status_Code = Index.Code;
          ResourseEntity.status_System = Index.System;
        }
      }

      if (ResourceTyped.Address != null)
      {
        StringBuilder AddressTotal = new StringBuilder();
        foreach (var Line in ResourceTyped.Address.Line)
          AddressTotal.Append(Line).Append(" ");
        AddressTotal.Append(ResourceTyped.Address.City).Append(" ");
        AddressTotal.Append(ResourceTyped.Address.PostalCode).Append(" ");
        AddressTotal.Append(ResourceTyped.Address.State).Append(" ");
        AddressTotal.Append(ResourceTyped.Address.Country).Append(" ");
        var Index = new Res_Location_Index_address();
        Index.String = AddressTotal.ToString();
        ResourseEntity.address_List.Add(Index);
      }

      if (ResourceTyped.Identifier != null)
      {
        foreach (var item3 in ResourceTyped.Identifier)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Location_Index_identifier(), item3) as Res_Location_Index_identifier;
          ResourseEntity.identifier_List.Add(Index);
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Location_Index_type(), item3) as Res_Location_Index_type;
          ResourseEntity.type_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Location_Index_profile(), item4) as Res_Location_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Location_Index_security(), item4) as Res_Location_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Location_Index_tag(), item4) as Res_Location_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

