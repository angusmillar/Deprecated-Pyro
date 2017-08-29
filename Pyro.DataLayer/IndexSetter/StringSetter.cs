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

    public IList<ResourceIndexStringType> Set<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
    {
      var ResourceIndexList = new List<ResourceIndexStringType>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirString FhirString)
        {
          SetFhirString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Address address)
        {
          SetAddress<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(address, ResourceIndexList);
        }
        else if (Poco.FhirValue is HumanName HumanName)
        {
          SetHumanName<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(HumanName, ResourceIndexList);
        }
        else if (Poco.FhirValue is Markdown Markdown)
        {
          SetMarkdown<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Markdown, ResourceIndexList);
        }
        else if (Poco.FhirValue is Annotation Annotation)
        {
          SetAnnotation<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Annotation, ResourceIndexList);
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
        var ResourceIndex = new ResourceIndexStringType();
        ResourceIndex.String = ConstantValue.Type.ToString();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (oElement.Value is bool Bool)
      {
        var ResourceIndex = new ResourceIndexStringType();
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

    private void SetFhirString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(FhirString FhirString, List<ResourceIndexStringType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new ResourceIndexStringType();
        ResourceIndex.String = FhirString.Value.TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength);
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAnnotation<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Annotation Annotation, List<ResourceIndexStringType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Annotation.Text))
      {
        var ResourceIndex = new ResourceIndexStringType();
        ResourceIndex.String = StringSupport.ToLowerAndRemoveDiacritics(Annotation.Text.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetMarkdown<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Markdown Markdown, List<ResourceIndexStringType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
    {
      if (!string.IsNullOrWhiteSpace(Markdown.Value))
      {
        var ResourceIndex = new ResourceIndexStringType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Markdown.Value.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetHumanName<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(HumanName HumanName, List<ResourceIndexStringType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
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
        var ResourceIndex = new ResourceIndexStringType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullName.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAddress<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>(Address Address, List<ResourceIndexStringType> ResourceIndexList)
      where ResourceCurrentBaseType : ResourceCurrentBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexBaseType : ResourceIndexBase<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>
      where ResourceIndexStringType : ResourceIndexString<ResourceCurrentBaseType, ResourceIndexBaseType, ResourceIndexStringType>, new()
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
        var ResourceIndex = new ResourceIndexStringType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullAdddress.Trim().TruncateLongString(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
