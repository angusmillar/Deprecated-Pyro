using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.Support;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class ClinicalImpressionRepository : CommonRepository, IResourceRepository
  {

    public ClinicalImpressionRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ClinicalImpression;
      var ResourceEntity = new Res_ClinicalImpression();
      this.PopulateResourceEntity(ResourceEntity, 1, ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_ClinicalImpression>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(int ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as ClinicalImpression;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_ClinicalImpression_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ClinicalImpression_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_ClinicalImpression_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_ClinicalImpression_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, int ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId, bool WithXml = false)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      Blaze.Common.BusinessEntities.Dto.DtoResource DtoResource = null;
      if (WithXml)
      {        
        DtoResource = DbGetALL<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_ClinicalImpression>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_ClinicalImpression LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_ClinicalImpression, object>>>();
      IncludeList.Add(x => x.action_List);
      IncludeList.Add(x => x.finding_List);
      IncludeList.Add(x => x.investigation_List);
      IncludeList.Add(x => x.plan_List);
      IncludeList.Add(x => x.problem_List);
      IncludeList.Add(x => x.resolved_List);
      IncludeList.Add(x => x.ruledout_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_ClinicalImpression>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_ClinicalImpression ResourceEntity)
    {
      ResourceEntity.assessor_FhirId = null;      
      ResourceEntity.assessor_Type = null;      
      ResourceEntity.assessor_Url = null;      
      ResourceEntity.assessor_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.date_DateTimeOffset = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.previous_FhirId = null;      
      ResourceEntity.previous_Type = null;      
      ResourceEntity.previous_Url = null;      
      ResourceEntity.previous_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.trigger_FhirId = null;      
      ResourceEntity.trigger_Type = null;      
      ResourceEntity.trigger_Url = null;      
      ResourceEntity.trigger_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.trigger_code_Code = null;      
      ResourceEntity.trigger_code_System = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_ClinicalImpression_Index_action.RemoveRange(ResourceEntity.action_List);            
      _Context.Res_ClinicalImpression_Index_finding.RemoveRange(ResourceEntity.finding_List);            
      _Context.Res_ClinicalImpression_Index_investigation.RemoveRange(ResourceEntity.investigation_List);            
      _Context.Res_ClinicalImpression_Index_plan.RemoveRange(ResourceEntity.plan_List);            
      _Context.Res_ClinicalImpression_Index_problem.RemoveRange(ResourceEntity.problem_List);            
      _Context.Res_ClinicalImpression_Index_resolved.RemoveRange(ResourceEntity.resolved_List);            
      _Context.Res_ClinicalImpression_Index_ruledout.RemoveRange(ResourceEntity.ruledout_List);            
      _Context.Res_ClinicalImpression_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_ClinicalImpression_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_ClinicalImpression_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_ClinicalImpression ResourseEntity, int ResourceVersion, ClinicalImpression ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

