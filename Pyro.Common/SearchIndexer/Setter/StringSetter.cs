using System;

using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using Pyro.Common.Database;
using System.Collections.Generic;
using Pyro.Common.SearchIndexer.Index;

namespace Pyro.Common.SearchIndexer.Setter
{
  public class StringSetter : IStringSetter
  {
    private IServiceSearchParameterLight _SearchParameter;
    private const string ItemDelimeter = " ";
    public StringSetter() { }

    public IList<IStringIndex> Set(IElementNavigator oElement, DtoServiceSearchParameterLight SearchParameter)
    {
      _SearchParameter = SearchParameter;

      var ResourceIndexList = new List<IStringIndex>();
      var ServiceSearchParameterId = SearchParameter.Id;

      if (oElement is Hl7.Fhir.ElementModel.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is FhirString FhirString)
        {
          SetFhirString(FhirString, ResourceIndexList);
        }
        else if (Poco.FhirValue is Address address)
        {
          SetAddress(address, ResourceIndexList);
        }
        else if (Poco.FhirValue is HumanName HumanName)
        {
          SetHumanName(HumanName, ResourceIndexList);
        }
        else if (Poco.FhirValue is Markdown Markdown)
        {
          SetMarkdown(Markdown, ResourceIndexList);
        }
        else if (Poco.FhirValue is Annotation Annotation)
        {
          SetAnnotation(Annotation, ResourceIndexList);
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
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = ConstantValue.Type.ToString();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (oElement.Value is bool Bool)
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = Bool.ToString();
        ResourceIndexList.Add(ResourceIndex);
      }
      else
      {
        throw new FormatException($"Unknown Navigator FhirType: '{oElement.Type}' for SearchParameterType: '{SearchParameter.Type}'");
      }
      
      return ResourceIndexList;
    }

    private void SetFhirString(FhirString FhirString, IList<IStringIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = FhirString.Value.Truncate(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength);
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAnnotation(Annotation Annotation, IList<IStringIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Annotation.Text))
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = StringSupport.ToLowerAndRemoveDiacritics(Annotation.Text.Trim().Truncate(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetMarkdown(Markdown Markdown, IList<IStringIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Markdown.Value))
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Markdown.Value.Trim().Truncate(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetHumanName(HumanName HumanName, IList<IStringIndex> ResourceIndexList)
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
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullName.Trim().Truncate(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAddress(Address Address, IList<IStringIndex> ResourceIndexList)
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
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullAdddress.Trim().Truncate(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
