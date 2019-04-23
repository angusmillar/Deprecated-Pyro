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

    public IList<IUriIndex> Set(ITypedElement oElement, IServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<IUriIndex>();
      _SearchParameter = SearchParameter;

      FHIRAllTypes? FhirType = ModelInfo.FhirTypeNameToFhirType(oElement.InstanceType);
      if (FhirType.HasValue)
      {
        switch (FhirType.Value)
        {
          case FHIRAllTypes.Uri:
            if (oElement.Value is FhirUri FhirUri)
            {
              SetUri(FhirUri, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Oid:
            if (oElement.Value is Oid Oid)
            {
              SetOid(Oid, ResourceIndexList);
            }
            break;          
          default:
            throw new FormatException($"No cast for FhirType of : '{oElement.InstanceType}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        return ResourceIndexList;
      }
      else
      {
        throw new FormatException($"Unknown FhirType of: '{oElement.InstanceType}' for SearchParameterType: '{SearchParameter.Type}'");
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
