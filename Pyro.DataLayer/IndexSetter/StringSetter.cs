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
  public class StringSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> :
    IStringSetter<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>, new()
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    
  {
    private const string ItemDelimeter = " ";
    public StringSetter() { }

    public IList<ResIndexStringType> Set(IElementNavigator oElement, ServiceSearchParameterLight SearchParameter)
    {
      var ResourceIndexList = new List<ResIndexStringType>();
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
        var ResourceIndex = new ResIndexStringType();
        ResourceIndex.String = ConstantValue.Type.ToString();
        ResourceIndexList.Add(ResourceIndex);
      }
      else if (oElement.Value is bool Bool)
      {
        var ResourceIndex = new ResIndexStringType();
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

    private void SetFhirString(FhirString FhirString, List<ResIndexStringType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        var ResourceIndex = new ResIndexStringType();
        ResourceIndex.String = FhirString.Value.TruncateLongString(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength);
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAnnotation(Annotation Annotation, List<ResIndexStringType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Annotation.Text))
      {
        var ResourceIndex = new ResIndexStringType();
        ResourceIndex.String = StringSupport.ToLowerAndRemoveDiacritics(Annotation.Text.Trim().TruncateLongString(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetMarkdown(Markdown Markdown, List<ResIndexStringType> ResourceIndexList)
    {
      if (!string.IsNullOrWhiteSpace(Markdown.Value))
      {
        var ResourceIndex = new ResIndexStringType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Markdown.Value.Trim().TruncateLongString(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetHumanName(HumanName HumanName, List<ResIndexStringType> ResourceIndexList)
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
        var ResourceIndex = new ResIndexStringType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullName.Trim().TruncateLongString(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
    private void SetAddress(Address Address, List<ResIndexStringType> ResourceIndexList)
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
        var ResourceIndex = new ResIndexStringType();
        ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullAdddress.Trim().TruncateLongString(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength));
        ResourceIndexList.Add(ResourceIndex);
      }
    }
  }
}
