using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Support;
using Blaze.DataModel.IndexSetter;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class MedicationDispenseRepository : CommonRepository, IResourceRepository
  {

    public MedicationDispenseRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      throw new NotImplementedException("Resource Search not implemented in Db layer");
    }

    public IDatabaseOperationOutcome AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as MedicationDispense;
      var ResourceEntity = new Res_MedicationDispense();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_MedicationDispense>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as MedicationDispense;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_MedicationDispense_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_MedicationDispense_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_MedicationDispense_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_MedicationDispense_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_MedicationDispense_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_MedicationDispense>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetALL<Res_MedicationDispense>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetALL<Res_MedicationDispense>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ResourceMatchingSearch = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_MedicationDispense LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_MedicationDispense, object>>>();
      IncludeList.Add(x => x.code_List);
      IncludeList.Add(x => x.prescription_List);
      IncludeList.Add(x => x.receiver_List);
      IncludeList.Add(x => x.responsibleparty_List);
      IncludeList.Add(x => x.type_List);
      IncludeList.Add(x => x.profile_List);
      IncludeList.Add(x => x.security_List);
      IncludeList.Add(x => x.tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_MedicationDispense>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_MedicationDispense ResourceEntity)
    {
      ResourceEntity.destination_FhirId = null;      
      ResourceEntity.destination_Type = null;      
      ResourceEntity.destination_Url = null;      
      ResourceEntity.destination_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.dispenser_FhirId = null;      
      ResourceEntity.dispenser_Type = null;      
      ResourceEntity.dispenser_Url = null;      
      ResourceEntity.dispenser_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.identifier_Code = null;      
      ResourceEntity.identifier_System = null;      
      ResourceEntity.medication_FhirId = null;      
      ResourceEntity.medication_Type = null;      
      ResourceEntity.medication_Url = null;      
      ResourceEntity.medication_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.patient_FhirId = null;      
      ResourceEntity.patient_Type = null;      
      ResourceEntity.patient_Url = null;      
      ResourceEntity.patient_Url_Blaze_RootUrlStoreID = null;      
      ResourceEntity.status_Code = null;      
      ResourceEntity.status_System = null;      
      ResourceEntity.whenhandedover_DateTimeOffset = null;      
      ResourceEntity.whenprepared_DateTimeOffset = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_MedicationDispense_Index_code.RemoveRange(ResourceEntity.code_List);            
      _Context.Res_MedicationDispense_Index_prescription.RemoveRange(ResourceEntity.prescription_List);            
      _Context.Res_MedicationDispense_Index_receiver.RemoveRange(ResourceEntity.receiver_List);            
      _Context.Res_MedicationDispense_Index_responsibleparty.RemoveRange(ResourceEntity.responsibleparty_List);            
      _Context.Res_MedicationDispense_Index_type.RemoveRange(ResourceEntity.type_List);            
      _Context.Res_MedicationDispense_Index_profile.RemoveRange(ResourceEntity.profile_List);            
      _Context.Res_MedicationDispense_Index_security.RemoveRange(ResourceEntity.security_List);            
      _Context.Res_MedicationDispense_Index_tag.RemoveRange(ResourceEntity.tag_List);            
 
    }

    private void PopulateResourceEntity(Res_MedicationDispense ResourseEntity, string ResourceVersion, MedicationDispense ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Destination != null)
      {
        if (ResourceTyped.Destination is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Destination, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.destination_Type = Index.Type;
            ResourseEntity.destination_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.destination_Url = Index.Url;
            }
            else
            {
              ResourseEntity.destination_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Dispenser != null)
      {
        if (ResourceTyped.Dispenser is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Dispenser, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.dispenser_Type = Index.Type;
            ResourseEntity.dispenser_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.dispenser_Url = Index.Url;
            }
            else
            {
              ResourseEntity.dispenser_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

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

      if (ResourceTyped.Medication != null)
      {
        if (ResourceTyped.Medication is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Medication, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.medication_Type = Index.Type;
            ResourseEntity.medication_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.medication_Url = Index.Url;
            }
            else
            {
              ResourseEntity.medication_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
            }
          }
        }
      }

      if (ResourceTyped.Patient != null)
      {
        if (ResourceTyped.Patient is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Patient, Index, FhirRequestUri, this) as ReferenceIndex;
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
        if (ResourceTyped.StatusElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.MedicationDispense.MedicationDispenseStatus>)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.StatusElement, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.status_Code = Index.Code;
            ResourseEntity.status_System = Index.System;
          }
        }
      }

      if (ResourceTyped.WhenHandedOver != null)
      {
        if (ResourceTyped.WhenHandedOverElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateIndex();
          Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(ResourceTyped.WhenHandedOverElement, Index) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.whenhandedover_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.WhenPrepared != null)
      {
        if (ResourceTyped.WhenPreparedElement is Hl7.Fhir.Model.FhirDateTime)
        {
          var Index = new DateIndex();
          Index = IndexSetterFactory.Create(typeof(DateIndex)).Set(ResourceTyped.WhenPreparedElement, Index) as DateIndex;
          if (Index != null)
          {
            ResourseEntity.whenprepared_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Medication != null)
      {
        if (ResourceTyped.Medication is CodeableConcept)
        {
          CodeableConcept CodeableConcept = ResourceTyped.Medication as CodeableConcept;
          foreach (var item3 in CodeableConcept.Coding)
          {
            var Index = new Res_MedicationDispense_Index_code();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_MedicationDispense_Index_code;
            ResourseEntity.code_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.AuthorizingPrescription != null)
      {
        foreach (var item in ResourceTyped.AuthorizingPrescription)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_MedicationDispense_Index_prescription();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_MedicationDispense_Index_prescription;
            if (Index != null)
            {
              ResourseEntity.prescription_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Receiver != null)
      {
        foreach (var item in ResourceTyped.Receiver)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_MedicationDispense_Index_receiver();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_MedicationDispense_Index_receiver;
            if (Index != null)
            {
              ResourseEntity.receiver_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Substitution != null)
      {
        if (ResourceTyped.Substitution.ResponsibleParty != null)
        {
          foreach (var item in ResourceTyped.Substitution.ResponsibleParty)
          {
            if (item is ResourceReference)
            {
              var Index = new Res_MedicationDispense_Index_responsibleparty();
              Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_MedicationDispense_Index_responsibleparty;
              if (Index != null)
              {
                ResourseEntity.responsibleparty_List.Add(Index);
              }
            }
          }
        }
      }

      if (ResourceTyped.Type != null)
      {
        foreach (var item3 in ResourceTyped.Type.Coding)
        {
          var Index = new Res_MedicationDispense_Index_type();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item3, Index) as Res_MedicationDispense_Index_type;
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
              var Index = new Res_MedicationDispense_Index_profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_MedicationDispense_Index_profile;
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
              var Index = new Res_MedicationDispense_Index_security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_MedicationDispense_Index_security;
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
              var Index = new Res_MedicationDispense_Index_tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_MedicationDispense_Index_tag;
              ResourseEntity.tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

