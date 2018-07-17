using System;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using System.Collections.Generic;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.ServiceRoot;
using Pyro.Common.CompositionRoot;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Setter
{
  public class ReferenceSetter : IReferenceSetter
  {    
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private IServiceSearchParameterLight _SearchParameter;

    public ReferenceSetter(IPyroFhirUriFactory IPyroFhirUriFactory, IPrimaryServiceRootCache IPrimaryServiceRootCache, ICommonFactory ICommonFactory)
    {      
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
    }

    public IList<IReferenceIndex> Set(IElementNavigator oElement, IServiceSearchParameterLight SearchParameter)
    {
      List<IReferenceIndex> ResourceIndexList = new List<IReferenceIndex>();
      _SearchParameter = SearchParameter;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
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
        //ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetIdentifier(Identifier Identifier, IList<IReferenceIndex> ResourceIndexList)
    {
      if (Identifier != null && !string.IsNullOrWhiteSpace(Identifier.System) && !string.IsNullOrWhiteSpace(Identifier.Value))
      {
        string TempUrl = $"{Identifier.System}/{Identifier.Value}";
        SetReferance(TempUrl, ResourceIndexList);
      }
    }

    private static void SetResource(Resource resource, IList<IReferenceIndex> ResourceIndexList)
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

    private void SetResourcereference(ResourceReference ResourceReference, IList<IReferenceIndex> ResourceIndexList)
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

    private void SetUri(Attachment Attachment, IList<IReferenceIndex> ResourceIndexList)
    {
      if (Attachment != null && string.IsNullOrWhiteSpace(Attachment.Url))
      {
        SetReferance(Attachment.Url, ResourceIndexList);
      }
    }

    private void SetFhirUri(FhirUri FhirUri, IList<IReferenceIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        SetReferance(FhirUri.Value, ResourceIndexList);
      }
    }

    private void SetReferance(string UriString, IList<IReferenceIndex> ResourceIndexList)
    {
      //Check the Uri is actual a Fhir resource reference         
      if (Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(UriString))
      {
        IPyroFhirUri ReferanceUri = IPyroFhirUriFactory.CreateFhirRequestUri();
        if (Uri.IsWellFormedUriString(UriString, UriKind.Relative))
        {
          if (ReferanceUri.Parse(UriString.Trim()))
          {
            var ResourceIndex = new ReferenceIndex(_SearchParameter);
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);            
            ResourceIndexList.Add(ResourceIndex);
          }
        }
        else if (Uri.IsWellFormedUriString(UriString, UriKind.Absolute))
        {
          if (ReferanceUri.Parse(UriString.Trim()))
          {
            var ResourceIndex = new ReferenceIndex(_SearchParameter);
            SetResourceIndentityElements(ResourceIndex, ReferanceUri);            
            ResourceIndexList.Add(ResourceIndex);
          }
        }
      }
    }

    private void SetResourceIndentityElements(IReferenceIndex ResourceIndex, IPyroFhirUri FhirRequestUri)
    {
      ResourceIndex.ResourceType = FhirRequestUri.ResourseName;
      ResourceIndex.VersionId = FhirRequestUri.VersionId;
      ResourceIndex.FhirId = FhirRequestUri.ResourceId;
      ResourceIndex.BaseUrl = FhirRequestUri.UriPrimaryServiceRoot.OriginalString;
      ResourceIndex.IsRelativeToServer = FhirRequestUri.IsRelativeToServer;
    }
  }
}
