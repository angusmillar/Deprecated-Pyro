using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.SearchIndexer.Index;
using Pyro.Common.Tools;
using System;
using System.Collections.Generic;

namespace Pyro.Common.SearchIndexer.Setter
{
  public class UriSetter : IUriSetter
  {
    private IServiceSearchParameterLight _SearchParameter;
    public UriSetter() { }
    public IList<IUriIndex> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      _SearchParameter = SearchParameter;

      var ResourceIndexList = new List<IUriIndex>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetUri(FhirUri, ResourceIndexList);
        }
        else if (Poco.FhirValue is Oid Oid)
        {
          SetOid(Oid, ResourceIndexList);
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }        
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private void SetOid(Oid Oid, IList<IUriIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Oid.Value))
      {
        var ResourceIndex = new UriIndex(_SearchParameter);
        ResourceIndex.Uri = Oid.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetUri(FhirUri FhirUri, IList<IUriIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        var ResourceIndex = new UriIndex(_SearchParameter);
        ResourceIndex.Uri = StringSupport.ToLowerFast(FhirUri.Value.StripHttp());
        ResourceIndexList.Add(ResourceIndex);
      }
    }

  }
}
