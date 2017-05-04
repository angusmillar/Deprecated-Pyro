using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Pyro.DataLayer.IndexSetter
{
  public static class UriSetter<ResourceCurrentType, ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
  {
    private static List<ResourceIndexType> ResourceIndexList;
    private static int ServiceSearchParameterId;

    public static IList<ResourceIndexType> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      ResourceIndexList = new List<ResourceIndexType>();      
      ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {        
        if (Poco.FhirValue is FhirUri FhirUri)
        {
          SetUri(FhirUri);
        }  
        else if (Poco.FhirValue is Oid Oid)
        {
          SetOid(Oid);
        }
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
        ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
        return ResourceIndexList;
      }      
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
    }

    private static void SetOid(Oid Oid)
    {
      if (!string.IsNullOrWhiteSpace(Oid.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Uri = Oid.Value;
        ResourceIndexList.Add(ResourceIndex);
      }      
    }
    private static void SetUri(FhirUri FhirUri)
    {
      if (!string.IsNullOrWhiteSpace(FhirUri.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.Uri = FhirUri.Value;
        ResourceIndexList.Add(ResourceIndex);
      }     
    }

   
  }
}
