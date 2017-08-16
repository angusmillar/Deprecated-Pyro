using System;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using Pyro.Common.Database;
using System.Collections.Generic;

namespace Pyro.DataLayer.IndexSetter
{
  public class StringSetter : IStringSetter
  {
    private const string ItemDelimeter = " ";
    public StringSetter() { }

    public IList<ResourceIndexType> Set<ResourceCurrentType, ResourceIndexType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      var ResourceIndexList = new List<ResourceIndexType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirString FhirString)
        {
          SetFhirString<ResourceCurrentType, ResourceIndexType>(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Address address)
        {
          SetAddress<ResourceCurrentType, ResourceIndexType>(address, ResourceIndexList);
        }
        else if (Poco.FhirValue is HumanName HumanName)
        {
          SetHumanName<ResourceCurrentType, ResourceIndexType>(HumanName, ResourceIndexList);
        }
        else if (Poco.FhirValue is Markdown Markdown)
        {
          SetMarkdown<ResourceCurrentType, ResourceIndexType>(Markdown, ResourceIndexList);
        }
        else if (Poco.FhirValue is Annotation Annotation)
        {
          SetAnnotation<ResourceCurrentType, ResourceIndexType>(Annotation, ResourceIndexList);
        }
        else if (Poco.FhirValue is Base64Binary Base64Binary)
        {
          //No good purpose to index base64 content as a search index          
        }
        else
        {
          throw new FormatException($"Unknown FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
        }
      }
      else if (oElement.Value is Hl7.FhirPath.ConstantValue ConstantValue)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = ConstantValue.Type.ToString();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (oElement.Value is bool Bool)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = Bool.ToString();
        ResourceIndexList.Add(ResourceIndex);
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
      ResourceIndexList.ForEach(x => x.ServiceSearchParameterId = ServiceSearchParameterId);
      return ResourceIndexList;
    }

    private void SetFhirString<ResourceCurrentType, ResourceIndexType>(FhirString FhirString, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = FhirString.Value.TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength);
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAnnotation<ResourceCurrentType, ResourceIndexType>(Annotation Annotation, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Annotation.Text))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Annotation.Text.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetMarkdown<ResourceCurrentType, ResourceIndexType>(Markdown Markdown, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Markdown.Value))
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Markdown.Value.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetHumanName<ResourceCurrentType, ResourceIndexType>(HumanName HumanName, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      string FullName = string.Empty;
      foreach (var Given in HumanName.Given)
      {
        FullName += Given + ItemDelimeter;
      }

      if (!string.IsNullOrWhiteSpace(HumanName.Family))
      {
        FullName += HumanName.Family + ItemDelimeter;
      }

      if (FullName != string.Empty)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullName.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAddress<ResourceCurrentType, ResourceIndexType>(Address Address, List<ResourceIndexType> ResourceIndexList)
      where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>, new()
      where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>, new()
    {
      string FullAdddress = string.Empty;
      foreach (var Line in Address.Line)
      {
        FullAdddress += Line + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.City))
      {
        FullAdddress += Address.City + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.PostalCode))
      {
        FullAdddress += Address.PostalCode + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.State))
      {
        FullAdddress += Address.State + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.Country))
      {
        FullAdddress += Address.Country + ItemDelimeter;
      }
      if (FullAdddress != string.Empty)
      {
        var ResourceIndex = new ResourceIndexType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullAdddress.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
