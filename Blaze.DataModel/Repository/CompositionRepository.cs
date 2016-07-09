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
  public partial class CompositionRepository : CommonRepository, IResourceRepository
  {

    public CompositionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Composition;
      var ResourceEntity = new Res_Composition();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_Composition>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Composition;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_Composition_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Composition_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_Composition_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Composition_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceHistoryEntity = DbGet<Res_Composition_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_Composition>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_Composition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_Composition>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_Composition LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_Composition, object>>>();
      IncludeList.Add(x => x.attester_List);
      IncludeList.Add(x => x.author_List);
      IncludeList.Add(x => x.class_List);
      IncludeList.Add(x => x.context_List);
      IncludeList.Add(x => x.entry_List);
      IncludeList.Add(x => x.period_List);
      IncludeList.Add(x => x.section_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_Composition>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_Composition ResourceEntity)
    {
      ResourceEntity.confidentiality_Code = null;      
      ResourceEntity.confidentiality_System = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.encounter_FhirId = null;      
      ResourceEntity.encounter_Type = null;      
      ResourceEntity.encounter_Url = null;      
      ResourceEntity.encounter_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.subject_FhirId = null;      
      ResourceEntity.subject_Type = null;      
      ResourceEntity.subject_Url = null;      
      ResourceEntity.subject_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.title_String = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_Composition_Index_attester.RemoveRange(ResourceEntity.attester_List);            
      _Context.Res_Composition_Index_author.RemoveRange(ResourceEntity.author_List);            
      _Context.Res_Composition_Index_class.RemoveRange(ResourceEntity.class_List);            
      _Context.Res_Composition_Index_context.RemoveRange(ResourceEntity.context_List);            
      _Context.Res_Composition_Index_entry.RemoveRange(ResourceEntity.entry_List);            
      _Context.Res_Composition_Index_period.RemoveRange(ResourceEntity.period_List);            
      _Context.Res_Composition_Index_section.RemoveRange(ResourceEntity.section_List);            
      _Context.Res_Composition_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_Composition_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_Composition_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_Composition_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_Composition ResourseEntity, string ResourceVersion, Composition ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Confidentiality != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.ConfidentialityElement);
        if (Index != null)
        {
          ResourseEntity.confidentiality_Code = Index.Code;
          ResourseEntity.confidentiality_System = Index.System;
        }
      }

      if (ResourceTyped.Date != null)
      {
        var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.DateElement);
        if (Index != null)
        {
          ResourseEntity.date_DateTimeOffset = Index.DateTimeOffset;
        }
      }

      if (ResourceTyped.Encounter != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Encounter, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.encounter_Type = Index.Type;
            ResourseEntity.encounter_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.encounter_Url = Index.Url;
            }
            else
            {
              ResourseEntity.encounter_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Identifier != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Identifier);
        if (Index != null)
        {
          ResourseEntity.identifier_Code = Index.Code;
          ResourseEntity.identifier_System = Index.System;
        }
      }

      if (ResourceTyped.Subject != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Subject, FhirRequestUri, this);
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

      if (ResourceTyped.Status != null)
      {
        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.StatusElement);
        if (Index != null)
        {
          ResourseEntity.status_Code = Index.Code;
          ResourseEntity.status_System = Index.System;
        }
      }

      if (ResourceTyped.Subject != null)
      {
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.Subject, FhirRequestUri, this);
          if (Index != null)
          {
            ResourseEntity.subject_Type = Index.Type;
            ResourseEntity.subject_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.subject_Url = Index.Url;
            }
            else
            {
              ResourseEntity.subject_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Title != null)
      {
        var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped.TitleElement);
        if (Index != null)
        {
          ResourseEntity.title_String = Index.String;
        }
      }

      foreach (var item1 in ResourceTyped.Attester)
      {
        if (item1.Party != null)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Composition_Index_attester(), item1.Party, FhirRequestUri, this) as Res_Composition_Index_attester;
          if (Index != null)
          {
            ResourseEntity.attester_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Author != null)
      {
        foreach (var item in ResourceTyped.Author)
        {
          var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Composition_Index_author(), item, FhirRequestUri, this) as Res_Composition_Index_author;
          if (Index != null)
          {
            ResourseEntity.author_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Class != null)
      {
        foreach (var item3 in ResourceTyped.Class.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Composition_Index_class(), item3) as Res_Composition_Index_class;
          ResourseEntity.class_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Event)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code)
          {
            if (item4 != null)
            {
              foreach (var item5 in item4.Coding)
              {
                var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Composition_Index_context(), item5) as Res_Composition_Index_context;
                ResourseEntity.context_List.Add(Index);
              }
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Section)
      {
        if (item1.Entry != null)
        {
          foreach (var item in item1.Entry)
          {
            var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Composition_Index_entry(), item, FhirRequestUri, this) as Res_Composition_Index_entry;
            if (Index != null)
            {
              ResourseEntity.entry_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Event)
      {
        if (item1.Period != null)
        {
          var Index = IndexSettingSupport.SetIndex<DatePeriodIndex>(new Res_Composition_Index_period(), item1.Period) as Res_Composition_Index_period;
          ResourseEntity.period_List.Add(Index);
        }
      }

      foreach (var item1 in ResourceTyped.Section)
      {
        if (item1.Code != null)
        {
          foreach (var item4 in item1.Code.Coding)
          {
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Composition_Index_section(), item4) as Res_Composition_Index_section;
            ResourseEntity.section_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Composition_Index_type(), item3) as Res_Composition_Index_type;
          ResourseEntity.type_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        if (ResourceTyped.Meta.Profile != null)
        {
          foreach (var item4 in ResourceTyped.Meta.ProfileElement)
          {
            var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Composition_Index_profile(), item4) as Res_Composition_Index_profile;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Composition_Index_security(), item4) as Res_Composition_Index_security;
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
            var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Composition_Index_tag(), item4) as Res_Composition_Index_tag;
            ResourseEntity.tag_List.Add(Index);
          }
        }
      }


      

    }


  }
} 

