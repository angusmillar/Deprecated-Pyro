using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using Pyro.Common.Tools.UriSupport;
using Pyro.DataLayer.Repository.Interfaces;
using Pyro.Common.ServiceRoot;
using Pyro.Common.CompositionRoot;

namespace Pyro.DataLayer.IndexSetter
{
  public class ReferenceSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IReferenceSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    private readonly ICommonRepository ICommonRepository;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;

    public ReferenceSetter(ICommonRepository ICommonRepository, IPyroFhirUriFactory IPyroFhirUriFactory, IPrimaryServiceRootCache IPrimaryServiceRootCache, ICommonFactory ICommonFactory)
    {
      this.ICommonRepository = ICommonRepository;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
    }

    public IList<ResIndexReferenceType> Set(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResIndexReferenceType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetFhirUri(FhirUri, ResourceIndexList);
        }
        else if (Poco.FhirValue is ResourceReference ResourceReference)
        {
          SetResourcereference(ResourceReference, ResourceIndexList);
        }
        else if (Poco.FhirValue is Resource Resource)
        {
          SetResource(Resource, ResourceIndexList);
        }
        else if (Poco.FhirValue is Attachment Attachment)
        {
          SetUri(Attachment, ResourceIndexList);
        }
        else if (Poco.FhirValue is Identifier Identifier)
        {
          SetIdentifier(Identifier, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetIdentifier(Identifier Identifier, List<ResIndexReferenceType> ResourceIndexList)
    {
      if (Identifier != null && !string.IsNullOrWhiteSpace(Identifier.System) && !string.IsNullOrWhiteSpace(Identifier.Value))
      {
        string TempUrl = $"{Identifier.System}/{Identifier.Value}";
        SetReferance(TempUrl, ResourceIndexList);
      }
    }

    private static void SetResource(Resource resource, List<ResIndexReferenceType> ResourceIndexList)
    {
      if (resource.ResourceType == ResourceType.Composition || resource.ResourceType == ResourceType.MessageHeader)
      {
        //ToDo: What do we do with this Resource as a ResourceReferance??
        //FHIR Spec says:
        //The first resource in the bundle, if the bundle type is "document" - this is a composition, and this parameter provides access to searches its contents
        //and
        //The first resource in the bundle, if the bundle type is "message" - this is a message header, and this parameter provides access to search its contents

        //So the intent is that search parameter 'composition' and 'message' are to work like chain parameters yet the chain reaches into the 
        //first resource of the bundle which should be a Composition  Resource or and MessageHeader resource.
        //Yet, unlike chaining where the reference points to the endpoint for that Resource type, here the reference points to the first entry of the bundle endpoint.
        // It almost feels like we should index at the bundle endpoint all the search parameters for both the Composition  and MessageHeader resources.
        //Or maybe we do special processing on Bundle commits were we pull out the first resource and store it at the appropriate 
        //endpoint yet hind it from access, then provide a reference index type at the bundle endpoint that chains to these 
        //hidden resources
      }
    }

    private void SetResourcereference(ResourceReference ResourceReference, List<ResIndexReferenceType> ResourceIndexList)
    {
      //Check the Uri is actual a Fhir resource reference 
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(ResourceReference.Reference))
      {
        if (!ResourceReference.IsContainedReference && ResourceReference.Url != null)
        {
          SetReferance(ResourceReference.Url.OriginalString, ResourceIndexList);
        }
      }
    }

    private void SetUri(Attachment Attachment, List<ResIndexReferenceType> ResourceIndexList)
    {
      if (Attachment != null && string.IsNullOrWhiteSpace(Attachment.Url))
      {
        SetReferance(Attachment.Url, ResourceIndexList);
      }
    }

    private void SetFhirUri(FhirUri FhirUri, List<ResIndexReferenceType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        SetReferance(FhirUri.Value, ResourceIndexList);
      }
    }

    private void SetReferance(string UriString, List<ResIndexReferenceType> ResourceIndexList)
    {
      //Check the Uri is actual a Fhir resource reference         
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(UriString))
      {
        IPyroFhirUri ReferanceUri = IPyroFhirUriFactory.CreateFhirRequestUri();
        if (Uri.IsWellFormedUriString(UriString, UriKind.Relative))
        {
          if (ReferanceUri.Parse(UriString.Trim()))
          {
            var ResourceIndex = new ResIndexReferenceType();
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);
            ResourceIndex.ReferenceServiceBaseUrlId = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Id;
            ResourceIndexList.Add(ResourceIndex);
          }
        }
        else if (Uri.IsWellFormedUriString(UriString, UriKind.Absolute))
        {
          if (ReferanceUri.Parse(UriString.Trim()))
          {
            var ResourceIndex = new ResIndexReferenceType();
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);
            if (ReferanceUri.IsRelativeToServer)
            {
              ResourceIndex.ReferenceServiceBaseUrlId = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Id;
            }
            else
            {
              ResourceIndex.ReferenceUrl = ICommonRepository.GetAndOrAddService_RootUrlStore(ReferanceUri.UriPrimaryServiceRoot.OriginalString);
            }
            ResourceIndexList.Add(ResourceIndex);
          }
        }
      }
    }

    private void SetResourceIndentityElements(ResIndexReferenceType ResourceIndex, IPyroFhirUri FhirRequestUri)
    {
      ResourceIndex.ReferenceResourceType = FhirRequestUri.ResourseName;
      ResourceIndex.ReferenceVersionId = FhirRequestUri.VersionId;
      ResourceIndex.ReferenceFhirId = FhirRequestUri.ResourceId;
    }
  }
}
