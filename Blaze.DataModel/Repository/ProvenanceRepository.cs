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
  public partial class ProvenanceRepository : CommonRepository, IResourceRepository
  {

    public ProvenanceRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Provenance;
      var ResourceEntity = new Res_Provenance();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Provenance>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Provenance;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Provenance_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Provenance_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Provenance_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Provenance_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Provenance_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Provenance>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Provenance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Provenance>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Provenance LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Provenance, object>>>();
      IncludeList.Add(x => x.agent_List);
      IncludeList.Add(x => x.entity_List);
      IncludeList.Add(x => x.entity_type_List);
      IncludeList.Add(x => x.patient_List);
      IncludeList.Add(x => x.sig_List);
      IncludeList.Add(x => x.target_List);
      IncludeList.Add(x => x.userid_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Provenance>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Provenance ResourceEntity)
    {
      ResourceEntity.end_DateTimeOffset = null;      
      ResourceEntity.location_FhirId = null;      
      ResourceEntity.location_Type = null;      
      ResourceEntity.location_Url = null;      
      ResourceEntity.location_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.start_DateTimeOffset = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Provenance_Index_agent.RemoveRange(ResourceEntity.agent_List);            
      _Context.Res_Provenance_Index_entity.RemoveRange(ResourceEntity.entity_List);            
      _Context.Res_Provenance_Index_entity_type.RemoveRange(ResourceEntity.entity_type_List);            
      _Context.Res_Provenance_Index_patient.RemoveRange(ResourceEntity.patient_List);            
      _Context.Res_Provenance_Index_sig.RemoveRange(ResourceEntity.sig_List);            
      _Context.Res_Provenance_Index_target.RemoveRange(ResourceEntity.target_List);            
      _Context.Res_Provenance_Index_userid.RemoveRange(ResourceEntity.userid_List);            
      _Context.Res_Provenance_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Provenance_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Provenance_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Provenance ResourseEntity, string ResourceVersion, Provenance ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Period != null)
      {
        if (ResourceTyped.Period.End != null)
        {
          var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.Period.EndElement);
          if (Index != null)
          {
            ResourseEntity.end_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Location != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Location, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.location_Type = Index.Type;
            ResourseEntity.location_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.location_Url = Index.Url;
            }
            else
            {
              ResourseEntity.location_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Period != null)
      {
        if (ResourceTyped.Period.Start != null)
        {
          var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.Period.StartElement);
          if (Index != null)
          {
            ResourseEntity.start_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      foreach (var item1 in ResourceTyped.Agent)
      {
        if (item1.Actor != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Provenance_Index_agent(), item1.Actor, FhirRequestUri, this) as Res_Provenance_Index_agent;
          if (Index != null)
          {
            ResourseEntity.agent_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Entity)
      {
        if (item1.Reference != null)
        {
          var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Provenance_Index_entity(), item1.ReferenceElement) as Res_Provenance_Index_entity;
          ResourseEntity.entity_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Entity)
      {
        if (item1.Type != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Provenance_Index_entity_type(), item1.Type) as Res_Provenance_Index_entity_type;
          ResourseEntity.entity_type_List.Add(Index);
        }
      }

      if (ResourceTyped.Target != null)
      {
        foreach (var item in ResourceTyped.Target)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Provenance_Index_patient(), item, FhirRequestUri, this) as Res_Provenance_Index_patient;
          if (Index != null)
          {
            ResourseEntity.patient_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Signature)
      {
        if (item1.Type != null)
        {
          foreach (var item4 in item1.Type)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Provenance_Index_sig(), item4) as Res_Provenance_Index_sig;
            ResourseEntity.sig_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Target != null)
      {
        foreach (var item in ResourceTyped.Target)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Provenance_Index_target(), item, FhirRequestUri, this) as Res_Provenance_Index_target;
          if (Index != null)
          {
            ResourseEntity.target_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Agent)
      {
        if (item1.UserId != null)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Provenance_Index_userid(), item1.UserId) as Res_Provenance_Index_userid;
          ResourseEntity.userid_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Provenance_Index_profile(), item4) as Res_Provenance_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Provenance_Index_security(), item4) as Res_Provenance_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Provenance_Index_tag(), item4) as Res_Provenance_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

