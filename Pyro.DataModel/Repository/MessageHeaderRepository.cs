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
  public partial class MessageHeaderRepository : CommonRepository, IResourceRepository
  {
    public MessageHeaderRepository(DataModel.DatabaseModel.DatabaseContext Context) : base(Context) { }

    public IDatabaseOperationOutcome GetResourceBySearch(DtoSearchParameters DtoSearchParameters)
    {
      var Predicate = PredicateGenerator<Res_MessageHeader>(DtoSearchParameters);
      int TotalRecordCount = DbGetALLCount<Res_MessageHeader>(Predicate);
      var Query = DbGetAll<Res_MessageHeader>(Predicate);

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
      var ResourceTyped = Resource as MessageHeader;
      var ResourceEntity = new Res_MessageHeader();
      this.PopulateResourceEntity(ResourceEntity, "1", ResourceTyped, FhirRequestUri);
      this.DbAddEntity<Res_MessageHeader>(ResourceEntity);
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;     
      DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceEntity);
      DatabaseOperationOutcome.ReturnedResourceCount = 1;
      return DatabaseOperationOutcome;
    }

    public IDatabaseOperationOutcome UpdateResource(string ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as MessageHeader;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);
      var ResourceHistoryEntity = new Res_MessageHeader_History();  
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_MessageHeader_History_List.Add(ResourceHistoryEntity); 
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
      var ResourceHistoryEntity = new Res_MessageHeader_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_MessageHeader_History_List.Add(ResourceHistoryEntity);
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
      var ResourceHistoryEntity = DbGet<Res_MessageHeader_History>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      if (ResourceHistoryEntity != null)
      {
        DatabaseOperationOutcome.ReturnedResource = IndexSettingSupport.SetDtoResource(ResourceHistoryEntity);
      }
      else
      {
        var ResourceEntity = DbGet<Res_MessageHeader>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
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
        DtoResource = DbGetAll<Res_MessageHeader>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated, Xml = x.XmlBlob }).SingleOrDefault();       
      }
      else
      {
        DtoResource = DbGetAll<Res_MessageHeader>(x => x.FhirId == FhirResourceId).Select(x => new Blaze.Common.BusinessEntities.Dto.DtoResource { FhirId = x.FhirId, IsDeleted = x.IsDeleted, IsCurrent = true, Version = x.versionId, Received = x.lastUpdated }).SingleOrDefault();        
      }
      DatabaseOperationOutcome.ReturnedResource = DtoResource;
      return DatabaseOperationOutcome;
    }

    private Res_MessageHeader LoadCurrentResourceEntity(string FhirId)
    {

      var IncludeList = new List<Expression<Func<Res_MessageHeader, object>>>();
      IncludeList.Add(x => x.data_List);
      IncludeList.Add(x => x.destination_List);
      IncludeList.Add(x => x.destination_uri_List);
      IncludeList.Add(x => x.target_List);
      IncludeList.Add(x => x._profile_List);
      IncludeList.Add(x => x._security_List);
      IncludeList.Add(x => x._tag_List);
    
      var ResourceEntity = DbQueryEntityWithInclude<Res_MessageHeader>(x => x.FhirId == FhirId, IncludeList);

      return ResourceEntity;
    }


    private void ResetResourceEntity(Res_MessageHeader ResourceEntity)
    {
      ResourceEntity.author_VersionId = null;      
      ResourceEntity.author_FhirId = null;      
      ResourceEntity.author_Type = null;      
      ResourceEntity.author_Url = null;      
      ResourceEntity.author_ServiceRootURL_StoreID = null;      
      ResourceEntity.code_Code = null;      
      ResourceEntity.code_System = null;      
      ResourceEntity.enterer_VersionId = null;      
      ResourceEntity.enterer_FhirId = null;      
      ResourceEntity.enterer_Type = null;      
      ResourceEntity.enterer_Url = null;      
      ResourceEntity.enterer_ServiceRootURL_StoreID = null;      
      ResourceEntity.event_Code = null;      
      ResourceEntity.event_System = null;      
      ResourceEntity.receiver_VersionId = null;      
      ResourceEntity.receiver_FhirId = null;      
      ResourceEntity.receiver_Type = null;      
      ResourceEntity.receiver_Url = null;      
      ResourceEntity.receiver_ServiceRootURL_StoreID = null;      
      ResourceEntity.response_id_Code = null;      
      ResourceEntity.response_id_System = null;      
      ResourceEntity.responsible_VersionId = null;      
      ResourceEntity.responsible_FhirId = null;      
      ResourceEntity.responsible_Type = null;      
      ResourceEntity.responsible_Url = null;      
      ResourceEntity.responsible_ServiceRootURL_StoreID = null;      
      ResourceEntity.source_String = null;      
      ResourceEntity.source_uri_Uri = null;      
      ResourceEntity.timestamp_DateTimeOffset = null;      
      ResourceEntity.XmlBlob = null;      
 
      
      _Context.Res_MessageHeader_Index_data.RemoveRange(ResourceEntity.data_List);            
      _Context.Res_MessageHeader_Index_destination.RemoveRange(ResourceEntity.destination_List);            
      _Context.Res_MessageHeader_Index_destination_uri.RemoveRange(ResourceEntity.destination_uri_List);            
      _Context.Res_MessageHeader_Index_target.RemoveRange(ResourceEntity.target_List);            
      _Context.Res_MessageHeader_Index__profile.RemoveRange(ResourceEntity._profile_List);            
      _Context.Res_MessageHeader_Index__security.RemoveRange(ResourceEntity._security_List);            
      _Context.Res_MessageHeader_Index__tag.RemoveRange(ResourceEntity._tag_List);            
 
    }

    private void PopulateResourceEntity(Res_MessageHeader ResourseEntity, string ResourceVersion, MessageHeader ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
       IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

          if (ResourceTyped.Author != null)
      {
        if (ResourceTyped.Author is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Author, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.author_Type = Index.Type;
            ResourseEntity.author_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.author_Url = Index.Url;
            }
            else
            {
              ResourseEntity.author_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Response != null)
      {
        if (ResourceTyped.Response.Code != null)
        {
          if (ResourceTyped.Response.CodeElement is Hl7.Fhir.Model.Code<Hl7.Fhir.Model.MessageHeader.ResponseType>)
          {
            var Index = new TokenIndex();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Response.CodeElement, Index) as TokenIndex;
            if (Index != null)
            {
              ResourseEntity.code_Code = Index.Code;
              ResourseEntity.code_System = Index.System;
            }
          }
        }
      }

      if (ResourceTyped.Enterer != null)
      {
        if (ResourceTyped.Enterer is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Enterer, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.enterer_Type = Index.Type;
            ResourseEntity.enterer_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.enterer_Url = Index.Url;
            }
            else
            {
              ResourseEntity.enterer_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Event != null)
      {
        if (ResourceTyped.Event is Hl7.Fhir.Model.Coding)
        {
          var Index = new TokenIndex();
          Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Event, Index) as TokenIndex;
          if (Index != null)
          {
            ResourseEntity.event_Code = Index.Code;
            ResourseEntity.event_System = Index.System;
          }
        }
      }

      if (ResourceTyped.Receiver != null)
      {
        if (ResourceTyped.Receiver is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Receiver, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.receiver_Type = Index.Type;
            ResourseEntity.receiver_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.receiver_Url = Index.Url;
            }
            else
            {
              ResourseEntity.receiver_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Response != null)
      {
        if (ResourceTyped.Response.Identifier != null)
        {
          if (ResourceTyped.Response.IdentifierElement is Hl7.Fhir.Model.Id)
          {
            var Index = new TokenIndex();
            Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(ResourceTyped.Response.IdentifierElement, Index) as TokenIndex;
            if (Index != null)
            {
              ResourseEntity.response_id_Code = Index.Code;
              ResourseEntity.response_id_System = Index.System;
            }
          }
        }
      }

      if (ResourceTyped.Responsible != null)
      {
        if (ResourceTyped.Responsible is Hl7.Fhir.Model.ResourceReference)
        {
          var Index = new ReferenceIndex();
          Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceTyped.Responsible, Index, FhirRequestUri, this) as ReferenceIndex;
          if (Index != null)
          {
            ResourseEntity.responsible_Type = Index.Type;
            ResourseEntity.responsible_FhirId = Index.FhirId;
            if (Index.Url != null)
            {
              ResourseEntity.responsible_Url = Index.Url;
            }
            else
            {
              ResourseEntity.responsible_ServiceRootURL_StoreID = Index.ServiceRootURL_StoreID;
            }
          }
        }
      }

      if (ResourceTyped.Source != null)
      {
        if (ResourceTyped.Source.Name != null)
        {
          if (ResourceTyped.Source.NameElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new StringIndex();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(ResourceTyped.Source.NameElement, Index) as StringIndex;
            if (Index != null)
            {
              ResourseEntity.source_String = Index.String;
            }
          }
        }
      }

      if (ResourceTyped.Source != null)
      {
        if (ResourceTyped.Source.Endpoint != null)
        {
          if (ResourceTyped.Source.EndpointElement is Hl7.Fhir.Model.FhirUri)
          {
            var Index = new UriIndex();
            Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(ResourceTyped.Source.EndpointElement, Index) as UriIndex;
            if (Index != null)
            {
              ResourseEntity.source_uri_Uri = Index.Uri;
            }
          }
        }
      }

      if (ResourceTyped.Timestamp != null)
      {
        if (ResourceTyped.TimestampElement is Hl7.Fhir.Model.Instant)
        {
          var Index = new DateTimeIndex();
          Index = IndexSetterFactory.Create(typeof(DateTimeIndex)).Set(ResourceTyped.TimestampElement, Index) as DateTimeIndex;
          if (Index != null)
          {
            ResourseEntity.timestamp_DateTimeOffset = Index.DateTimeOffset;
          }
        }
      }

      if (ResourceTyped.Data != null)
      {
        foreach (var item in ResourceTyped.Data)
        {
          if (item is ResourceReference)
          {
            var Index = new Res_MessageHeader_Index_data();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item, Index, FhirRequestUri, this) as Res_MessageHeader_Index_data;
            if (Index != null)
            {
              ResourseEntity.data_List.Add(Index);
            }
          }
        }
      }

      foreach (var item1 in ResourceTyped.Destination)
      {
        if (item1.Name != null)
        {
          if (item1.NameElement is Hl7.Fhir.Model.FhirString)
          {
            var Index = new Res_MessageHeader_Index_destination();
            Index = IndexSetterFactory.Create(typeof(StringIndex)).Set(item1.NameElement, Index) as Res_MessageHeader_Index_destination;
            ResourseEntity.destination_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Destination)
      {
        if (item1.Endpoint != null)
        {
          if (item1.EndpointElement is Hl7.Fhir.Model.FhirUri)
          {
            var Index = new Res_MessageHeader_Index_destination_uri();
            Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item1.EndpointElement, Index) as Res_MessageHeader_Index_destination_uri;
            ResourseEntity.destination_uri_List.Add(Index);
          }
        }
      }

      foreach (var item1 in ResourceTyped.Destination)
      {
        if (item1.Target != null)
        {
          if (item1.Target is ResourceReference)
          {
            var Index = new Res_MessageHeader_Index_target();
            Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(item1.Target, Index, FhirRequestUri, this) as Res_MessageHeader_Index_target;
            if (Index != null)
            {
              ResourseEntity.target_List.Add(Index);
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
              var Index = new Res_MessageHeader_Index__profile();
              Index = IndexSetterFactory.Create(typeof(UriIndex)).Set(item4, Index) as Res_MessageHeader_Index__profile;
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
              var Index = new Res_MessageHeader_Index__security();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_MessageHeader_Index__security;
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
              var Index = new Res_MessageHeader_Index__tag();
              Index = IndexSetterFactory.Create(typeof(TokenIndex)).Set(item4, Index) as Res_MessageHeader_Index__tag;
              ResourseEntity._tag_List.Add(Index);
            }
          }
        }
      }


      

    }


  }
} 

