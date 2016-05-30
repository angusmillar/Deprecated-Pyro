using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;


namespace Blaze.DataModel.Support
{
  public static class IndexSettingSupport
  {
    public static TokenTransfer CreateToken(Element FhirElement)
    {
      if (FhirElement is Coding)
      {
        return new TokenTransfer(FhirElement as Coding);
      }
      else if (FhirElement is Identifier)
      {
        return new TokenTransfer(FhirElement as Identifier);
      }
      else if (FhirElement is ContactPoint)
      {
        return new TokenTransfer(FhirElement as ContactPoint);
      }
      else if (FhirElement is Code)
      {
        return new TokenTransfer(FhirElement as Code);
      }
      else if (FhirElement is FhirBoolean)
      {
        return new TokenTransfer(FhirElement as FhirBoolean);
      }
      else if (FhirElement is FhirString)
      {
        return new TokenTransfer(FhirElement as FhirString);
      }
      else
      {
        throw new InvalidCastException("CreateToken: Element type unable to be cast to a search parameter type instance.");
      }
    }
    public static DateTimeOffset CreateDateTime(Element FhirElement)
    {
      if(FhirElement is Date)
      {
        var FhirDate = FhirElement as Date;
        if (Date.IsValidValue(FhirDate.Value))
        {
          var DateOnly = DateTime.Parse(FhirDate.Value);
          var TestOffset = new DateTimeOffset(DateOnly, new TimeSpan(0, 0, 0));
          return TestOffset;
        }
        else
        {
          throw new FormatException("Fhir Date is not valid in Data access layer, value was : " + FhirDate.Value);
        }
      }
      else if (FhirElement is FhirDateTime)
      {
        var FhirDateTime = FhirElement as FhirDateTime;
        if (Date.IsValidValue(FhirDateTime.Value))
        {
          return FhirDateTime.ToDateTimeOffset();
        }
        else
        {
          throw new FormatException("Fhir DateTime is not valid in Data access layer, value was : " + FhirDateTime.Value);
        }
      }
      else
      {
        throw new InvalidCastException("CreateDate: Element type unable to be cast to a search parameter type instance.");
      }
    }

    private static decimal CreateNumber(Element FhirElementObject)
    {
      if (FhirElementObject is FhirDecimal)
      {
        return (decimal)(FhirElementObject as FhirDecimal).Value;
      }
      else
      {
        throw new InvalidCastException("CreateNumber: Element type unable to be cast to a search parameter type instance.");
      }
    }

    private static Quantity CreateQuantity(Element FhirElement)
    {
      if (FhirElement is Quantity)
      {
        return FhirElement as Quantity; ;
      }
      else
      {
        throw new InvalidCastException("CreateQuantity: Element type unable to be cast to a search parameter type instance.");
      }
    }

    private static ResourceReference CreateResourceReference(Element FhirElement)
    {
      if (FhirElement is ResourceReference)
      {
        return FhirElement as ResourceReference; ;
      }
      else
      {
        throw new InvalidCastException("CreateResourceReference: Element type unable to be cast to a search parameter type instance.");
      }
    }

    private static string CreateString(Element FhirElement)
    {
      if (FhirElement is FhirString)
      {
        return (FhirElement as FhirString).Value;
      }
      else
      {
        throw new InvalidCastException("CreateString: Element type unable to be cast to a search parameter type instance.");
      }
    }

    private static string CreateUri(Element FhirElement)
    {
      if (FhirElement is FhirUri)
      {
        return (FhirElement as FhirUri).Value;
      }
      else
      {
        throw new InvalidCastException("CreateUri: Element type unable to be cast to a search parameter type instance.");
      }
    }

    public static void SetIndex(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, CommonRepository CommonRepository = null)
    {             
      if (ModelBase is DateIndex)
      {        
        (ModelBase as DateIndex).DateTimeOffset = CreateDateTime(FhirElement);        
      } 
      else if (ModelBase is NumberIndex)
      {        
        (ModelBase as NumberIndex).Number = CreateNumber(FhirElement);        
      }
      else if (ModelBase is QuantityIndex)
      {
        var Quantity = CreateQuantity(FhirElement);
        var QuantityIndex = (ModelBase as QuantityIndex);
        QuantityIndex.Code = Quantity.Code;
        QuantityIndex.System = Quantity.System;
        QuantityIndex.Quantity = (decimal)Quantity.Value;
      }
      else if (ModelBase is ReferenceIndex)
      {
        if (CommonRepository == null)
          throw new NullReferenceException("CommonRepository can not be null when ModelBase is of type ReferenceIndex");
        if (FhirRequestUri == null)
          throw new NullReferenceException("FhirRequestUri can not be null when ModelBase is of type ReferenceIndex");        
        ResourceReferenceTransfer ResourceReferenceTransfer = SetResourceReferanceIndex(FhirElement, FhirRequestUri, CommonRepository);
        var ReferenceIndex = (ModelBase as ReferenceIndex);
        ReferenceIndex.Type = ResourceReferenceTransfer.Type;
        ReferenceIndex.FhirId = ResourceReferenceTransfer.FhirId;
        if (ResourceReferenceTransfer.Url != null)
        {
          ReferenceIndex.Url = ResourceReferenceTransfer.Url;
        }
        else
        {
          ReferenceIndex.Url_Blaze_RootUrlStoreID = ResourceReferenceTransfer.Blaze_RootUrlStoreID;
        }
      }
      else if (ModelBase is StringIndex)
      {
        (ModelBase as StringIndex).String = CreateString(FhirElement);
      }
      else if (ModelBase is TokenIndex)
      {
        TokenTransfer oToken = CreateToken(FhirElement);
        var TokenIndex = (ModelBase as TokenIndex);
        TokenIndex.Code = oToken.Code;
        TokenIndex.System = oToken.CodeSystem;
      }
      else if (ModelBase is UriIndex)
      {
        (ModelBase as UriIndex).Uri = CreateUri(FhirElement);
      }
      else
      {
        throw new InvalidCastException("ModelBase type unable to be cast to a base Model index type instance.");
      }

    }

    public static ResourceReferenceTransfer SetResourceReferanceIndex(Element FhirElement, IDtoFhirRequestUri FhirRequestUri, CommonRepository CommonRepository)
    {
      var ResourceReferenceTransfer = new  ResourceReferenceTransfer();

      var ResourceReference = CreateResourceReference(FhirElement);      
      var ReferanceUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ResourceReference.Url);
      ResourceReferenceTransfer.Type = ReferanceUri.ResourseType;
      ResourceReferenceTransfer.VersionId = ReferanceUri.VersionId;
      ResourceReferenceTransfer.FhirId = ReferanceUri.FullResourceIdentity;
      if (ResourceReference.Url.IsAbsoluteUri)
      {
        ResourceReferenceTransfer.Url = CommonRepository.GetAndOrAddBlaze_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
      }
      else
      {
        ResourceReferenceTransfer.Blaze_RootUrlStoreID = FhirRequestUri.PrimaryRootUrlStore.Blaze_RootUrlStoreID;
      }
      return ResourceReferenceTransfer;
    }

    public static void SetResourceBaseAsDelete(ResourceIndexBase ResourceIndexBase, string FhirResourceId, string Version)
    {
      SetResourceBase(null, ResourceIndexBase, FhirResourceId, Version, true);
    }

    public static void SetResourceBaseAddOrUpdate(Resource Resource, ResourceIndexBase ResourceIndexBase, string Version, bool IsDeleted)
    {
      SetResourceBase(Resource, ResourceIndexBase, null, Version, false);
    }

    private static void SetResourceBase(Resource Resource, ResourceIndexBase ResourceIndexBase, string FhirResourceId, string Version, bool IsDeleted)
    {
      if (!IsDeleted)
      {
        ResourceIndexBase.FhirId = Resource.Id;
        ResourceIndexBase.IsDeleted = IsDeleted;
        ResourceIndexBase.XmlBlob = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(Resource);
        ResourceIndexBase.lastUpdated = (DateTimeOffset)Resource.Meta.LastUpdated;
        ResourceIndexBase.versionId = Version;
      }
      else
      {
        ResourceIndexBase.FhirId = FhirResourceId;
        ResourceIndexBase.IsDeleted = IsDeleted;
        ResourceIndexBase.XmlBlob = "";
        ResourceIndexBase.lastUpdated = DateTimeOffset.Now;
        ResourceIndexBase.versionId = Version;
      }
    }
    
    public static void SetHistoryResourceEntity(DatabaseModel.Base.ResourceIndexBase ResourceEntity, DatabaseModel.Base.ResourceIndexBase HistoryResourceEntity)
    {      
      HistoryResourceEntity.FhirId = ResourceEntity.FhirId;
      HistoryResourceEntity.IsDeleted = ResourceEntity.IsDeleted;
      HistoryResourceEntity.XmlBlob = ResourceEntity.XmlBlob;
      HistoryResourceEntity.lastUpdated = ResourceEntity.lastUpdated;
      HistoryResourceEntity.versionId = ResourceEntity.versionId;      
    }

    public static DtoResource SetDtoResource(DatabaseModel.Base.ResourceIndexBase ResourceIndexBase)
    {      
      var DtoResource = new DtoResource();           
      DtoResource.FhirId = ResourceIndexBase.FhirId;
      DtoResource.IsCurrent = true;
      DtoResource.IsDeleted = ResourceIndexBase.IsDeleted;
      DtoResource.Received = ResourceIndexBase.lastUpdated;
      DtoResource.Version = ResourceIndexBase.versionId;
      DtoResource.Xml = ResourceIndexBase.XmlBlob;
      return DtoResource;
    }
  }
}
