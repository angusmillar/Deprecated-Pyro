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
  public class ReferenceSetter : IReferenceSetter
  {
    private readonly ICommonRepository ICommonRepository;
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly ICommonFactory ICommonFactory;

    public ReferenceSetter(ICommonRepository ICommonRepository, IPrimaryServiceRootCache IPrimaryServiceRootCache, ICommonFactory ICommonFactory)
    {
      this.ICommonRepository = ICommonRepository;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      this.ICommonFactory = ICommonFactory;
    }

    public IList<ResourceIndexBaseType> Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      var ResourceIndexList = new List<ResourceIndexBaseType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetFhirUri<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirUri, ResourceIndexList);
        }
        else if (Poco.FhirValue is ResourceReference ResourceReference)
        {
          SetResourcereference<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceReference, ResourceIndexList);
        }
        else if (Poco.FhirValue is Resource Resource)
        {
          SetResource<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Resource, ResourceIndexList);
        }
        else if (Poco.FhirValue is Attachment Attachment)
        {
          SetUri<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Attachment, ResourceIndexList);
        }
        else if (Poco.FhirValue is Identifier Identifier)
        {
          SetIdentifier<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Identifier, ResourceIndexList);
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

    private void SetIdentifier<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Identifier Identifier, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Identifier != null && !string.IsNullOrWhiteSpace(Identifier.System) && !string.IsNullOrWhiteSpace(Identifier.Value))
      {
        string TempUrl = $"{Identifier.System}/{Identifier.Value}";
        SetReferance<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(TempUrl, ResourceIndexList);
      }
    }

    private static void SetResource<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Resource resource, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (resource.ResourceType == ResourceType.Composition || resource.ResourceType == ResourceType.MessageHeader)
      {
        //ToDo: What do we do with this Resource as a ResourceReferance??
        //FHIR Spec says:
        //The first resource in the bundle, if the bundle type is "document" - this is a composition, and this parameter provides access to searches its contents
        //and
        //The first resource in the bundle, if the bundle type is "message" - this is a message header, and this parameter provides access to search its contents
      }
    }

    private void SetResourcereference<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceReference ResourceReference, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //Check the Uri is actual a Fhir resource reference 
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(ResourceReference.Reference))
      {
        if (!ResourceReference.IsContainedReference && ResourceReference.Url != null)
        {
          SetReferance<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceReference.Url.OriginalString, ResourceIndexList);
        }
      }
    }

    private void SetUri<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Attachment Attachment, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (Attachment != null && string.IsNullOrWhiteSpace(Attachment.Url))
      {
        SetReferance<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Attachment.Url, ResourceIndexList);
      }
    }

    private void SetFhirUri<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirUri FhirUri, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        SetReferance<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirUri.Value, ResourceIndexList);
      }
    }

    private void SetReferance<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(string UriString, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      //Check the Uri is actual a Fhir resource reference         
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(UriString))
      {
        IPyroFhirUri ReferanceUri = ICommonFactory.CreateFhirRequestUri();
        if (Uri.IsWellFormedUriString(UriString, UriKind.Relative))
        {
          if (ReferanceUri.Parse(UriString.Trim()))
          {
            var ResourceIndex = new ResourceIndexBaseType();
            SetResourceIndentityElements<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceIndex, ReferanceUri);
            ResourceIndex.ReferenceServiceBaseUrlId = IPrimaryServiceRootCache.GetPrimaryRootUrlFromDatabase().Id;
            ResourceIndexList.Add(ResourceIndex);
          }
        }
        else if (Uri.IsWellFormedUriString(UriString, UriKind.Absolute))
        {
          if (ReferanceUri.Parse(UriString.Trim()))
          {
            var ResourceIndex = new ResourceIndexBaseType();
            SetResourceIndentityElements<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceIndex, ReferanceUri);
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

    private void SetResourceIndentityElements<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(ResourceIndexBaseType ResourceIndex, IPyroFhirUri FhirRequestUri)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      ResourceIndex.ReferenceResourceType = FhirRequestUri.ResourseName;
      ResourceIndex.ReferenceVersionId = FhirRequestUri.VersionId;
      ResourceIndex.ReferenceFhirId = FhirRequestUri.ResourceId;
    }
  }
}
