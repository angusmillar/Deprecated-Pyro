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
    public static T SetIndex<T>(ModelBase ModelBase, Element FhirElement, IDtoFhirRequestUri FhirRequestUri = null, CommonRepository CommonRepository = null) where T : ModelBase
    {
      if (typeof(T) == typeof(DateIndex))
      {
        return CreateDateTime(ModelBase, FhirElement) as T;
      }
      else if (typeof(T) == typeof(Duration))
      {
        return CreateNumber(ModelBase, FhirElement) as T;
      }
      else if (typeof(T) == typeof(NumberIndex))
      {
        return CreateNumber(ModelBase, FhirElement) as T;
      }
      else if (typeof(T) == typeof(QuantityIndex))
      {
        return CreateQuantity(ModelBase, FhirElement) as T;
      }
      else if (typeof(T) == typeof(ReferenceIndex))
      {
        if (CommonRepository == null)
          throw new NullReferenceException("CommonRepository can not be null when ModelBase is of type ReferenceIndex");
        if (FhirRequestUri == null)
          throw new NullReferenceException("FhirRequestUri can not be null when ModelBase is of type ReferenceIndex");
        return CreateResourceReference(ModelBase, FhirElement, FhirRequestUri, CommonRepository) as T;
      }
      else if (typeof(T) == typeof(StringIndex))
      {
        return CreateString(ModelBase, FhirElement) as T;
      }
      else if (typeof(T) == typeof(TokenIndex))
      {
        return CreateToken(ModelBase, FhirElement) as T;
      }
      else if (typeof(T) == typeof(UriIndex))
      {
        return CreateUri(ModelBase, FhirElement) as T;
      }
      else
      {
        throw new InvalidCastException("ModelBase type unable to be cast to a base Model index type instance.");
      }

    }
    
    public static TokenIndex CreateToken(ModelBase ModelBase, Element FhirElement)
    {
      TokenIndex TokenIndex = ModelBase as TokenIndex;
      if (FhirElement is Coding)
      {
        var Coding = FhirElement as Coding; 
        if (Coding.Code != string.Empty)
          TokenIndex.Code = Coding.Code;
        if (Coding.System != string.Empty)
          TokenIndex.System= Coding.System;
        return TokenIndex;
      }
      else if (FhirElement is Identifier)
      {
        var Identifier = FhirElement as Identifier;
        if (Identifier.Value != string.Empty)
          TokenIndex.Code = Identifier.Value;
        if (Identifier.System != string.Empty)
          TokenIndex.System = Identifier.System;
        return TokenIndex;
      }
      else if (FhirElement is PositiveInt)
      {
        var PositiveInt = FhirElement as PositiveInt;
        if (PositiveInt.Value != null)
          TokenIndex.Code = PositiveInt.Value.ToString();
        TokenIndex.System = null;
        return TokenIndex;
      }
      else if (FhirElement is ContactPoint)
      {
        var ContactPoint = FhirElement as ContactPoint;
        if (ContactPoint.Value != string.Empty)
          TokenIndex.Code = ContactPoint.Value;
        if (ContactPoint.Use != null)
          TokenIndex.System = ContactPoint.Use.ToString();
        return TokenIndex;
      }
      else if (FhirElement is Code)
      {
        var Code = FhirElement as Code;
        if (Code.Value != string.Empty)
          TokenIndex.Code = Code.Value;
        TokenIndex.System = null;
        return TokenIndex;
      }
      //ToDo: How do I make this generic or how do I code gen it in a separate file
      else if (FhirCodeDataTypeSupport.IsGenericCodeDataType(FhirElement))
      {
        if (FhirCodeDataTypeSupport.TokenIndexSetter(FhirElement, TokenIndex))
        {
          return TokenIndex;
        }
        else
        {
          throw new InvalidCastException(String.Format("A FHIR Code<T> data type was encountered which did not have a setter in CodeDataTypeSupport.TokenIndexSetter(FhirElement, TokenIndex)"));
        }
      }
      else if (FhirElement is FhirBoolean)
      {
        var FhirBoolean = FhirElement as FhirBoolean;
        if (FhirBoolean.Value != null)
        {
          if ((Boolean)FhirBoolean.Value)
          {
            TokenIndex.Code = "true";
          }
          else
          {
            TokenIndex.Code = "false";
          }
        }
        TokenIndex.System = null;
        return TokenIndex;
      }
      else if (FhirElement is FhirString)
      {
        var FhirString = FhirElement as FhirString;
        if (FhirString.Value != string.Empty)
          TokenIndex.Code = FhirString.Value;
        TokenIndex.System = null;
        return TokenIndex;
      }
      else if (FhirElement is CodeableConcept)
      {
        var CodeableConcept = FhirElement as CodeableConcept;
        foreach (Coding Code in CodeableConcept.Coding)
        {
          TokenIndex.Code = Code.Code;
          TokenIndex.System = Code.System;
        }
        return TokenIndex;                       
      }
      else
      {
        return null;
      }
    }

    public static DateIndex CreateDateTime(ModelBase ModelBase, Element FhirElement)
    {
      if(FhirElement is Date)
      {
        var FhirDate = FhirElement as Date;
        if (Date.IsValidValue(FhirDate.Value))
        {          
          var DateOnly = DateTime.Parse(FhirDate.Value);

          var DateIndex = ModelBase as DateIndex; 
          DateIndex.DateTimeOffset = new DateTimeOffset(DateOnly, new TimeSpan(0, 0, 0));
          return DateIndex;
        }
        else
        {
          throw new FormatException("Fhir Date is not valid in Data access layer, value was : " + FhirDate.Value);
        }
      }
      else if (FhirElement is FhirDateTime)
      {
        var FhirDateTime = FhirElement as FhirDateTime;
        if (FhirDateTime.IsValidValue(FhirDateTime.Value))
        {
          var DateIndex = new DateIndex(); 
          DateIndex.DateTimeOffset = FhirDateTime.ToDateTimeOffset();
          return DateIndex;
        }
        else
        {
          throw new FormatException("Fhir DateTime is not valid in Data access layer, value was : " + FhirDateTime.Value);
        }
      }      
      else
      {
        return null;
      }
    }    

    public static void SetResourceBaseAsDelete(ResourceIndexBase ResourceIndexBase, string FhirResourceId, string Version)
    {
      SetResourceBase(null, ResourceIndexBase, FhirResourceId, Version, true);
    }

    public static void SetResourceBaseAddOrUpdate(Resource Resource, ResourceIndexBase ResourceIndexBase, string Version, bool IsDeleted)
    {
      SetResourceBase(Resource, ResourceIndexBase, null, Version, false);
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


    private static NumberIndex CreateNumber(ModelBase ModelBase, Element FhirElementObject)
    {
      if (FhirElementObject is FhirDecimal)
      {
        if ((FhirElementObject as FhirDecimal).Value != null)
        {
          var NumberIndex = ModelBase as NumberIndex;
          NumberIndex.Number = (decimal)(FhirElementObject as FhirDecimal).Value;
          return NumberIndex;
        }
        return null;
      }
      else if (FhirElementObject is Duration)
      {
        if ((FhirElementObject as Duration).Value != null)
        {
          var NumberIndex = ModelBase as NumberIndex;
          NumberIndex.Number = (decimal)(FhirElementObject as Duration).Value;
          return NumberIndex;
        }
        return null;
      }
      else
      {
        return null;
      }
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

    private static QuantityIndex CreateQuantity(ModelBase ModelBase, Element FhirElement)
    {
      if (FhirElement is Quantity)
      {
        var Quantity = FhirElement as Quantity; 
        var QuantityIndex = ModelBase as QuantityIndex;        
        QuantityIndex.Comparator = Quantity.Comparator;
        QuantityIndex.Code = Quantity.Code;
        QuantityIndex.System = Quantity.System;
        QuantityIndex.Quantity = (decimal)Quantity.Value;
        return QuantityIndex;
      }
      else if (FhirElement is Money)
      {
        var Money = FhirElement as Money;
        var QuantityIndex = ModelBase as QuantityIndex;
        QuantityIndex.Comparator = Money.Comparator;
        QuantityIndex.Code = Money.Code;
        QuantityIndex.System = Money.System;
        QuantityIndex.Quantity = (decimal)Money.Value;
        return QuantityIndex;
      }
      else
      {
        return null;
      }
    }

    private static ReferenceIndex CreateResourceReference(ModelBase ModelBase, Element FhirElement, IDtoFhirRequestUri FhirRequestUri, CommonRepository CommonRepository)
    {
      if (FhirElement is ResourceReference)
      {
        var ResourceReference = FhirElement as ResourceReference;
        if (!ResourceReference.IsContainedReference && ResourceReference.Url != null)
        {
          var ReferenceIndex = ModelBase as ReferenceIndex;
          var ReferanceUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ResourceReference.Url);
          ReferenceIndex.Type = ReferanceUri.ResourseType;
          ReferenceIndex.VersionId = ReferanceUri.VersionId;
          ReferenceIndex.FhirId = ReferanceUri.FullResourceIdentity;
          if (ResourceReference.Url.IsAbsoluteUri)
          {
            ReferenceIndex.Url = CommonRepository.GetAndOrAddBlaze_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);
          }
          else
          {
            ReferenceIndex.Url_Blaze_RootUrlStoreID = FhirRequestUri.PrimaryRootUrlStore.Blaze_RootUrlStoreID;
          }
          return ReferenceIndex;
        }
        else
        {
          return null;
        }
      }
      else if (FhirElement is FhirUri)
      {
        //Check this logic works, do we need to check for absolute as seen above.
        var FhirUri = FhirElement as FhirUri;
        var ReferenceIndex = ModelBase as ReferenceIndex;
        Uri Uri = new System.Uri(FhirUri.Value);
        var ReferanceUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(Uri);
        ReferenceIndex.Type = ReferanceUri.ResourseType;
        ReferenceIndex.VersionId = ReferanceUri.VersionId;
        ReferenceIndex.FhirId = ReferanceUri.FullResourceIdentity;
        ReferenceIndex.Url = CommonRepository.GetAndOrAddBlaze_RootUrlStore(ReferanceUri.ServiceRootUrlForComparison);        
        return ReferenceIndex;      
      }      
      else
      {
        throw new InvalidCastException("Server Error: A non FHIR ResourceReference type was passed into the CreateResourceReference method.");
      }
    }
    
    private static StringIndex CreateString(ModelBase ModelBase, Element FhirElement)
    {
      if (FhirElement is FhirString)
      {
        var FhirString = FhirElement as FhirString;
        var StringIndex = ModelBase as StringIndex;
        StringIndex.String = FhirString.Value;
        return StringIndex;
      }
      else if (FhirElement is Markdown)
      {
        var Markdown = FhirElement as Markdown;
        var StringIndex = ModelBase as StringIndex;
        StringIndex.String = Markdown.Value;
        return StringIndex;
      }
      else if (FhirElement is Annotation)
      {
        var Annotation = FhirElement as Annotation;
        var StringIndex = ModelBase as StringIndex;
        StringIndex.String = Annotation.Text;
        return StringIndex;
      }
      else
      {
        return null;
      }
    }   

    private static UriIndex CreateUri(ModelBase ModelBase, Element FhirElement)
    {
      if (FhirElement is FhirUri)
      {
        var UriIndex = ModelBase as UriIndex;
        UriIndex.Uri = (FhirElement as FhirUri).Value;
        return UriIndex;
      }
      else
      {
        return null;
      }
    }

  }
}
