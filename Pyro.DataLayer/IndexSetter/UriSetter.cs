﻿using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public class UriSetter : IUriSetter
  {
    public UriSetter() { }
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
          SetUri<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirUri, ResourceIndexList);
        }
        else if (Poco.FhirValue is Oid Oid)
        {
          SetOid<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Oid, ResourceIndexList);
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

    private void SetOid<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Oid Oid, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (!string.IsNullOrWhiteSpace(Oid.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Uri = Oid.Value;
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetUri<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirUri FhirUri, List<ResourceIndexBaseType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        var ResourceIndex = new ResourceIndexBaseType();
        ResourceIndex.Uri = StringSupport.ToLowerFast(FhirUri.Value.StripHttp());
        ResourceIndexList.Add(ResourceIndex);
      }
    }

  }
}
