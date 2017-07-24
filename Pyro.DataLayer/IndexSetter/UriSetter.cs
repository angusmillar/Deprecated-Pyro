using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Tools;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class UriSetter : IUriSetter
  {
    public UriSetter() { }
    public IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      var ResourceIndexList = new List<ResourceIndexType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetUri<ResourceCurrentType, ResourceIndexType>(FhirUri, ResourceIndexList);
        }
        else if (Poco.FhirValue is Oid Oid)
        {
          SetOid<ResourceCurrentType, ResourceIndexType>(Oid, ResourceIndexList);
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

    private void SetOid<ResourceCurrentType, ResourceIndexType>(Oid Oid, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Oid.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Uri = Oid.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetUri<ResourceCurrentType, ResourceIndexType>(FhirUri FhirUri, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Uri = StringSupport.ToLowerFast(FhirUri.Value.StripHttp());
        ResourceIndexList.Add(ResourceIndex);
      }
    }

  }
}
