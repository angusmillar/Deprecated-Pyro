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

    public IList<IStringIndex> Set(ITypedElement oElement, IServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<IStringIndex>();
      _SearchParameter = SearchParameter;

      FHIRAllTypes? FhirType = ModelInfo.FhirTypeNameToFhirType(oElement.InstanceType);
      if (FhirType.HasValue)
      {
        switch (FhirType.Value)
        {          
          case FHIRAllTypes.String:
            if (oElement.Value is FhirString FhirString)
            {
              SetFhirString(FhirString, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Address:
            if (oElement.Value is Address Address)
            {
              SetAddress(Address, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.HumanName:
            if (oElement.Value is HumanName HumanName)
            {
              SetHumanName(HumanName, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Markdown:
            if (oElement.Value is Markdown Markdown)
            {
              SetMarkdown(Markdown, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Annotation:
            if (oElement.Value is Annotation Annotation)
            {
              SetAnnotation(Annotation, ResourceIndexList);
            }
            break;
          case FHIRAllTypes.Base64Binary:
            if (oElement.Value is Base64Binary Base64Binary)
            {
              //No good purpose to index base64 content as a search index
            }
            break;
          //case FHIRAllTypes.Boolean:
          //  if (oElement.Value is FhirBoolean FhirBoolean)
          //  {
          //    var ResourceIndex = new StringIndex(_SearchParameter);
          //    ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(FhirBoolean.Value.ToString());
          //    ResourceIndexList.Add(ResourceIndex);
          //  }
          //  break;
          case FHIRAllTypes.Boolean:
            if (oElement.Value is bool Bool)
            {
              var ResourceIndex = new StringIndex(_SearchParameter);
              ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(Bool.ToString());
              ResourceIndexList.Add(ResourceIndex);
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
    
    private void SetFhirString(FhirString FhirString, IList<IStringIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(FhirString.Value);        
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAnnotation(Annotation Annotation, IList<IStringIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Annotation.Text.Value))
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(Annotation.Text.Value);        
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetMarkdown(Markdown Markdown, IList<IStringIndex> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Markdown.Value))
      {
        var ResourceIndex = new StringIndex(_SearchParameter);
        ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(Markdown.Value);
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
        ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(FullName);
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

        ResourceIndex.String = LowerTrimRemoveDiacriticsAndTruncate(FullAdddress);
        ResourceIndexList.Add(ResourceIndex);
      }
    }

    private string LowerTrimRemoveDiacriticsAndTruncate(string item)
    {
      return StringSupport.ToLowerTrimRemoveDiacriticsTruncate(item, StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength);      
    }
  }
}
