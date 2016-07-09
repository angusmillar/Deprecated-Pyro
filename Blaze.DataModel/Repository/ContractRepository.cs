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
  public partial class ContractRepository : CommonRepository, IResourceRepository
  {

    public ContractRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Contract;
      var ResourceEntity = new Res_Contract();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Contract>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Contract;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Contract_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Contract_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Contract_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Contract_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Contract_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Contract>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Contract>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Contract>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Contract LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Contract, object>>>();
      IncludeList.Add(x => x.agent_List);
      IncludeList.Add(x => x.authority_List);
      IncludeList.Add(x => x.domain_List);
      IncludeList.Add(x => x.patient_List);
      IncludeList.Add(x => x.signer_List);
      IncludeList.Add(x => x.subject_List);
      IncludeList.Add(x => x.topic_List);
      IncludeList.Add(x => x.ttopic_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Contract>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Contract ResourceEntity)
    {
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.issued_DateTimeOffset = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Contract_Index_agent.RemoveRange(ResourceEntity.agent_List);            
      _Context.Res_Contract_Index_authority.RemoveRange(ResourceEntity.authority_List);            
      _Context.Res_Contract_Index_domain.RemoveRange(ResourceEntity.domain_List);            
      _Context.Res_Contract_Index_patient.RemoveRange(ResourceEntity.patient_List);            
      _Context.Res_Contract_Index_signer.RemoveRange(ResourceEntity.signer_List);            
      _Context.Res_Contract_Index_subject.RemoveRange(ResourceEntity.subject_List);            
      _Context.Res_Contract_Index_topic.RemoveRange(ResourceEntity.topic_List);            
      _Context.Res_Contract_Index_ttopic.RemoveRange(ResourceEntity.ttopic_List);            
      _Context.Res_Contract_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Contract_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Contract_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Contract ResourseEntity, string ResourceVersion, Contract ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Identifier != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Identifier);
        if (Index != null)
        {
          ResourseEntity.identifier_Code = Index.Code;
          ResourseEntity.identifier_System = Index.System;
        }
      }

      if (ResourceTyped.Issued != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.IssuedElement);
        if (Index != null)
        {
          ResourseEntity.issued_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      foreach (var item1 in ResourceTyped.Agent)
      {
        if (item1.Actor != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_agent(), item1.Actor, FhirRequestUri, this) as Res_Contract_Index_agent;
          if (Index != null)
          {
            ResourseEntity.agent_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Authority != null)
      {
        foreach (var item in ResourceTyped.Authority)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_authority(), item, FhirRequestUri, this) as Res_Contract_Index_authority;
          if (Index != null)
          {
            ResourseEntity.authority_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Domain != null)
      {
        foreach (var item in ResourceTyped.Domain)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_domain(), item, FhirRequestUri, this) as Res_Contract_Index_domain;
          if (Index != null)
          {
            ResourseEntity.domain_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        foreach (var item in ResourceTyped.Subject)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_patient(), item, FhirRequestUri, this) as Res_Contract_Index_patient;
          if (Index != null)
          {
            ResourseEntity.patient_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Signer)
      {
        if (item1.Party != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_signer(), item1.Party, FhirRequestUri, this) as Res_Contract_Index_signer;
          if (Index != null)
          {
            ResourseEntity.signer_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        foreach (var item in ResourceTyped.Subject)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_subject(), item, FhirRequestUri, this) as Res_Contract_Index_subject;
          if (Index != null)
          {
            ResourseEntity.subject_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Topic != null)
      {
        foreach (var item in ResourceTyped.Topic)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_topic(), item, FhirRequestUri, this) as Res_Contract_Index_topic;
          if (Index != null)
          {
            ResourseEntity.topic_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Term)
      {
        if (item1.Topic != null)
        {
          foreach (var item in item1.Topic)
          {
            var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Contract_Index_ttopic(), item, FhirRequestUri, this) as Res_Contract_Index_ttopic;
            if (Index != null)
            {
              ResourseEntity.ttopic_List.Add(Index);
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
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Contract_Index_profile(), item4) as Res_Contract_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Contract_Index_security(), item4) as Res_Contract_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Contract_Index_tag(), item4) as Res_Contract_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

