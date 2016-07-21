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
  public partial class ConformanceRepository : CommonRepository, IResourceRepository
  {

    public ConformanceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Conformance;
      var ResourceEntity = new Res_Conformance();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Conformance>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Conformance;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Conformance_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Conformance_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Conformance_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Conformance_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Conformance_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Conformance>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Conformance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Conformance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Conformance LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Conformance, object>>>();
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.event_List);
      IncludeList.Add(x => x.format_List);
      IncludeList.Add(x => x.mode_List);
      IncludeList.Add(x => x.resource_List);
      IncludeList.Add(x => x.resourceprofile_List);
      IncludeList.Add(x => x.securityservice_List);
      IncludeList.Add(x => x.supported_profile_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Conformance>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Conformance ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.description_String = null;      
      ResourceEntity.fhirversion_Code = null;      
      ResourceEntity.fhirversion_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.publisher_String = null;      
      ResourceEntity.software_String = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.url_Uri = null;      
      ResourceEntity.version_Code = null;      
      ResourceEntity.version_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Conformance_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_Conformance_Index_event.RemoveRange(ResourceEntity.event_List);            
      _Context.Res_Conformance_Index_format.RemoveRange(ResourceEntity.format_List);            
      _Context.Res_Conformance_Index_mode.RemoveRange(ResourceEntity.mode_List);            
      _Context.Res_Conformance_Index_resource.RemoveRange(ResourceEntity.resource_List);            
      _Context.Res_Conformance_Index_resourceprofile.RemoveRange(ResourceEntity.resourceprofile_List);            
      _Context.Res_Conformance_Index_securityservice.RemoveRange(ResourceEntity.securityservice_List);            
      _Context.Res_Conformance_Index_supported_profile.RemoveRange(ResourceEntity.supported_profile_List);            
      _Context.Res_Conformance_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Conformance_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Conformance_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Conformance ResourseEntity, string ResourceVersion, Conformance ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Date != null)
      {
        if (ResourceTyped.DateElement is Hl7.Fhir.Model.FhirDateTime)
        {
          DateIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DateElement) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Description != null)
      {
        if (ResourceTyped.DescriptionElement is Hl7.Fhir.Model.FhirString)
        {
          StringIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DescriptionElement) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.description_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Version != null)
      {
        if (ResourceTyped.VersionElement is Hl7.Fhir.Model.FhirString)
        {
          TokenIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.VersionElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.fhirversion_Code = Index.Code;
            ResourseEntity.fhirversion_System = Index.System;
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

      if (ResourceTyped.Publisher != null)
      {
        if (ResourceTyped.PublisherElement is Hl7.Fhir.Model.FhirString)
        {
          StringIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.PublisherElement) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.publisher_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Software != null)
      {
        if (ResourceTyped.Software.Name != null)
        {
          if (ResourceTyped.Software.NameElement is Hl7.Fhir.Model.FhirString)
          {
            StringIndex Index = null;
            Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.Software.NameElement) as StringIndex;
            if (Index != null)
            {
              ResourseEntity.software_String = Index.String;
            }
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.ConformanceResourceStatus>)
        {
          TokenIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.StatusElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.status_Code = Index.Code;
            ResourseEntity.status_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Url != null)
      {
        if (ResourceTyped.UrlElement is Hl7.Fhir.Model.FhirUri)
        {
          UriIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.UrlElement) as UriIndex;
          if (Index != null)
          {
            ResourseEntity.url_Uri = Index.Uri;
          }
        }
      }

      if (ResourceTyped.Version != null)
      {
        if (ResourceTyped.VersionElement is Hl7.Fhir.Model.FhirString)
        {
          TokenIndex Index = null;
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.VersionElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.version_Code = Index.Code;
            ResourseEntity.version_System = Index.System;
          }
        }
      }

      if (ResourceTyped.UseContext != null)
      {
        foreach (var item3 in ResourceTyped.UseContext)
        {
          if (item3 != null)
          {
            foreach (var item4 in item3.Coding)
            {
              Res_Conformance_Index_context Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Conformance_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Messaging)
      {
        foreach (var item2 in item1.Event)
        {
          if (item2.Code != null)
          {
            if (item2.Code is Hl7.Fhir.Model.Coding)
            {
              Res_Conformance_Index_event Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item2.Code) as Res_Conformance_Index_event;
              ResourseEntity.event_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Format != null)
      {
        foreach (var item3 in ResourceTyped.FormatElement)
        {
          if (item3 is Hl7.Fhir.Model.Code)
          {
            Res_Conformance_Index_format Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_Conformance_Index_format;
            ResourseEntity.format_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Rest)
      {
        if (item1.Mode != null)
        {
          if (item1.ModeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.Conformance.RestfulConformanceMode>)
          {
            Res_Conformance_Index_mode Index = null;
            Index = IndexSettingSupport.SetIndex(Index, item1.ModeElement) as Res_Conformance_Index_mode;
            ResourseEntity.mode_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Rest)
      {
        foreach (var item2 in item1.Resource)
        {
          if (item2.Type != null)
          {
            if (item2.TypeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.ResourceType>)
            {
              Res_Conformance_Index_resource Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item2.TypeElement) as Res_Conformance_Index_resource;
              ResourseEntity.resource_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Rest)
      {
        foreach (var item2 in item1.Resource)
        {
          if (item2.Profile != null)
          {
            if (item2.Profile is ResourceReference)
            {
              var Index = new Res_Conformance_Index_resourceprofile();
              IndexSettingSupport.SetIndex(Index, item2.Profile, FhirRequestUri, this);
              if (Index != null)
              {
                ResourseEntity.resourceprofile_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Rest)
      {
        if (item1.Security != null)
        {
          if (item1.Security.Service != null)
          {
            foreach (var item5 in item1.Security.Service)
            {
              if (item5 != null)
              {
                foreach (var item6 in item5.Coding)
                {
                  Res_Conformance_Index_securityservice Index = null;
                  Index = IndexSettingSupport.SetIndex(Index, item6) as Res_Conformance_Index_securityservice;
                  ResourseEntity.securityservice_List.Add(Index);
                }
              }
            }
          }
        }
      }

      if (ResourceTyped.Profile != null)
      {
        foreach (var item in ResourceTyped.Profile)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Conformance_Index_supported_profile();
            IndexSettingSupport.SetIndex(Index, item, FhirRequestUri, this);
            if (Index != null)
            {
              ResourseEntity.supported_profile_List.Add(Index);
            }
          }
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
              Res_Conformance_Index_profile Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Conformance_Index_profile;
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
              Res_Conformance_Index_security Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Conformance_Index_security;
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
              Res_Conformance_Index_tag Index = null;
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_Conformance_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

