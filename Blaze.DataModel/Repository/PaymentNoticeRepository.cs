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
  public partial class PaymentNoticeRepository : CommonRepository, IResourceRepository
  {

    public PaymentNoticeRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as PaymentNotice;
      var ResourceEntity = new Res_PaymentNotice();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_PaymentNotice>(ResourceEntity);
      return ResourceTyped.Id;
    }

    public string UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as PaymentNotice;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_PaymentNotice_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_PaymentNotice_History_List.Add(ResourceHistoryEntity); 
      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);            
      this.Save();            
      return ResourceTyped.Id;
    }

    public void UpdateResouceAsDeleted(string FhirResourceId, string ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);
      var ResourceHistoryEntity = new Res_PaymentNotice_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_PaymentNotice_History_List.Add(ResourceHistoryEntity);
      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;
      this.Save();      
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, string ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_PaymentNotice>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_PaymentNotice>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_PaymentNotice>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_PaymentNotice LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_PaymentNotice, object>>>();
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_PaymentNotice>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_PaymentNotice ResourceEntity)
    {
      ResourceEntity.created_DateTimeOffset = null;      
      ResourceEntity.organizationidentifier_Code = null;      
      ResourceEntity.organizationidentifier_System = null;      
      ResourceEntity.organizationreference_FhirId = null;      
      ResourceEntity.organizationreference_Type = null;      
      ResourceEntity.organizationreference_Url = null;      
      ResourceEntity.organizationreference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.paymentstatus_Code = null;      
      ResourceEntity.paymentstatus_System = null;      
      ResourceEntity.provideridentifier_Code = null;      
      ResourceEntity.provideridentifier_System = null;      
      ResourceEntity.providerreference_FhirId = null;      
      ResourceEntity.providerreference_Type = null;      
      ResourceEntity.providerreference_Url = null;      
      ResourceEntity.providerreference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.requestidentifier_Code = null;      
      ResourceEntity.requestidentifier_System = null;      
      ResourceEntity.requestreference_FhirId = null;      
      ResourceEntity.requestreference_Type = null;      
      ResourceEntity.requestreference_Url = null;      
      ResourceEntity.requestreference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.responseidentifier_Code = null;      
      ResourceEntity.responseidentifier_System = null;      
      ResourceEntity.responsereference_FhirId = null;      
      ResourceEntity.responsereference_Type = null;      
      ResourceEntity.responsereference_Url = null;      
      ResourceEntity.responsereference_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.statusdate_DateTimeOffset = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_PaymentNotice_Index_identifier.RemoveRange(ResourceEntity.identifier_List);            
      _Context.Res_PaymentNotice_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_PaymentNotice_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_PaymentNotice_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_PaymentNotice ResourseEntity, string ResourceVersion, PaymentNotice ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);
    }


  }
} 

