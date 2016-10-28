using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.Search;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class ContractRepository : CommonRepository, IResourceRepository
  {
    public ContractRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_Contract>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_Contract>(Predicate);
      var Query = DbGetAll<Res_Contract>(Predicate);

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
      var ResourceTyped = Resource as Contract;
      var ResourceEntity = new Res_Contract();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Contract>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
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
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
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
      ResourceEntity.XmlBlob = string.Empty;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Contract_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Contract>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
        if (ResourceEntity != null)
          DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);        
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
        DtoResource = DbGetAll<Res_Contract>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_Contract>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
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
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
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
      _Context.Res_Contract_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_Contract_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_Contract_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Contract ResourseEntity, string ResourceVersion, Contract ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Identifier != null)
      {
        if (ResourceTyped.Identifier is Hl7.Fhir.Model.Identifier)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Identifier, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.identifier_Code = Index.Code;
            ResourseEntity.identifier_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Issued != null)
      {
        if (ResourceTyped.IssuedElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.IssuedElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.issued_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      foreach (var item1 in ResourceTyped.Agent)
      {
        if (item1.Actor != null)
        {
          if (item1.Actor is ResourceReference)
          {
            var Index = new Res_Contract_Index_agent();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Actor, Index, FhirRequestUri, this) as Res_Contract_Index_agent;
            if (Index != null)
            {
              ResourseEntity.agent_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Authority != null)
      {
        foreach (var item in ResourceTyped.Authority)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Contract_Index_authority();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Contract_Index_authority;
            if (Index != null)
            {
              ResourseEntity.authority_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Domain != null)
      {
        foreach (var item in ResourceTyped.Domain)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Contract_Index_domain();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Contract_Index_domain;
            if (Index != null)
            {
              ResourseEntity.domain_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        foreach (var item in ResourceTyped.Subject)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Contract_Index_patient();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Contract_Index_patient;
            if (Index != null)
            {
              ResourseEntity.patient_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Signer)
      {
        if (item1.Party != null)
        {
          if (item1.Party is ResourceReference)
          {
            var Index = new Res_Contract_Index_signer();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Party, Index, FhirRequestUri, this) as Res_Contract_Index_signer;
            if (Index != null)
            {
              ResourseEntity.signer_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Subject != null)
      {
        foreach (var item in ResourceTyped.Subject)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Contract_Index_subject();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Contract_Index_subject;
            if (Index != null)
            {
              ResourseEntity.subject_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Topic != null)
      {
        foreach (var item in ResourceTyped.Topic)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_Contract_Index_topic();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Contract_Index_topic;
            if (Index != null)
            {
              ResourseEntity.topic_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Term)
      {
        if (item1.Topic != null)
        {
          foreach (var item in item1.Topic)
          {
            if (item is ResourceReference)
            {
              var Index = new Res_Contract_Index_ttopic();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_Contract_Index_ttopic;
              if (Index != null)
              {
                ResourseEntity.ttopic_List.Add(Index);
              }
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
              var Index = new Res_Contract_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_Contract_Index__profile;
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
              var Index = new Res_Contract_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Contract_Index__security;
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
              var Index = new Res_Contract_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_Contract_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

