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
  public partial class NamingSystemRepository : CommonRepository, IResourceRepository
  {

    public NamingSystemRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as NamingSystem;
      var ResourceEntity = new Res_NamingSystem();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_NamingSystem>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as NamingSystem;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_NamingSystem_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_NamingSystem_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_NamingSystem_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_NamingSystem_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_NamingSystem_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_NamingSystem>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_NamingSystem>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_NamingSystem>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_NamingSystem LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_NamingSystem, object>>>();
      IncludeList.Add(x => x.contact_List);
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.id_type_List);
      IncludeList.Add(x => x.period_List);
      IncludeList.Add(x => x.telecom_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.value_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_NamingSystem>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_NamingSystem ResourceEntity)
    {
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.kind_Code = null;      
      ResourceEntity.kind_System = null;      
      ResourceEntity.name_String = null;      
      ResourceEntity.publisher_String = null;      
      ResourceEntity.replaced_by_FhirId = null;      
      ResourceEntity.replaced_by_Type = null;      
      ResourceEntity.replaced_by_Url = null;      
      ResourceEntity.replaced_by_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.responsible_String = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_NamingSystem_Index_contact.RemoveRange(ResourceEntity.contact_List);            
      _Context.Res_NamingSystem_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_NamingSystem_Index_id_type.RemoveRange(ResourceEntity.id_type_List);            
      _Context.Res_NamingSystem_Index_period.RemoveRange(ResourceEntity.period_List);            
      _Context.Res_NamingSystem_Index_telecom.RemoveRange(ResourceEntity.telecom_List);            
      _Context.Res_NamingSystem_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_NamingSystem_Index_value.RemoveRange(ResourceEntity.value_List);            
      _Context.Res_NamingSystem_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_NamingSystem_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_NamingSystem_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_NamingSystem ResourseEntity, string ResourceVersion, NamingSystem ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Date != null)
      {
        if (ResourceTyped.DateElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.DateElement) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Kind != null)
      {
        if (ResourceTyped.KindElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.NamingSystem.NamingSystemType>)
        {
          var Index = new TokenIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.KindElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.kind_Code = Index.Code;
            ResourseEntity.kind_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Name != null)
      {
        if (ResourceTyped.NameElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
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
          var Index = new StringIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.PublisherElement) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.publisher_String = Index.String;
          }
        }
      }

      if (ResourceTyped.ReplacedBy != null)
      {
        if (ResourceTyped.ReplacedBy is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.ReplacedBy, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.replaced_by_Type = Index.Type;
            ResourseEntity.replaced_by_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.replaced_by_Url = Index.Url;
            }
            else
            {
              ResourseEntity.replaced_by_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Responsible != null)
      {
        if (ResourceTyped.ResponsibleElement is Hl7.Fhir.Model.FhirString)
        {
          var Index = new StringIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.ResponsibleElement) as StringIndex;
          if (Index != null)
          {
            ResourseEntity.responsible_String = Index.String;
          }
        }
      }

      if (ResourceTyped.Status != null)
      {
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.ConformanceResourceStatus>)
        {
          var Index = new TokenIndex();
          Index = IndexSettingSupport.SetIndex(Index, ResourceTyped.StatusElement) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.status_Code = Index.Code;
            ResourseEntity.status_System = Index.System;
          }
        }
      }

      foreach (var item1 in ResourceTyped.Contact)
      {
        if (item1.Name != null)
        {
          if (item1.NameElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_NamingSystem_Index_contact();
            Index = IndexSettingSupport.SetIndex(Index, item1.NameElement) as Res_NamingSystem_Index_contact;
            ResourseEntity.contact_List.Add(Index);
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
              var Index = new Res_NamingSystem_Index_context();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_NamingSystem_Index_context;
              ResourseEntity.context_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.UniqueId)
      {
        if (item1.Type != null)
        {
          if (item1.TypeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.NamingSystem.NamingSystemIdentifierType>)
          {
            var Index = new Res_NamingSystem_Index_id_type();
            Index = IndexSettingSupport.SetIndex(Index, item1.TypeElement) as Res_NamingSystem_Index_id_type;
            ResourseEntity.id_type_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.UniqueId)
      {
        if (item1.Period != null)
        {
          if (item1.Period is Period)
          {
            var Index = new Res_NamingSystem_Index_period();
            Index = IndexSettingSupport.SetIndex(Index, item1.Period) as Res_NamingSystem_Index_period;
            ResourseEntity.period_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Contact)
      {
        foreach (var item3 in item1.Telecom)
        {
          if (item3 is ContactPoint)
          {
            var Index = new Res_NamingSystem_Index_telecom();
            Index = IndexSettingSupport.SetIndex(Index, item3) as Res_NamingSystem_Index_telecom;
            ResourseEntity.telecom_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = new Res_NamingSystem_Index_type();
          Index = IndexSettingSupport.SetIndex(Index, item3) as Res_NamingSystem_Index_type;
          ResourseEntity.type_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.UniqueId)
      {
        if (item1.Value != null)
        {
          if (item1.ValueElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_NamingSystem_Index_value();
            Index = IndexSettingSupport.SetIndex(Index, item1.ValueElement) as Res_NamingSystem_Index_value;
            ResourseEntity.value_List.Add(Index);
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
              var Index = new Res_NamingSystem_Index_profile();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_NamingSystem_Index_profile;
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
              var Index = new Res_NamingSystem_Index_security();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_NamingSystem_Index_security;
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
              var Index = new Res_NamingSystem_Index_tag();
              Index = IndexSettingSupport.SetIndex(Index, item4) as Res_NamingSystem_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

