using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.DataLayer.IndexSetter
{
  public static class StringSetter
  {
    public static ResourceIndexType Set<ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight searchParameter)
      where ResourceIndexType : ResourceIndexBase, new()
    {
      var ResourceIndex = new ResourceIndexType();
      ResourceIndex.ServiceSearchParameterId = searchParameter.Id;
      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        string ItemDelimeter = " ";
        if (Poco.FhirValue is FhirString FhirString)
        {
          ResourceIndex.String = FhirString.Value;
          return ResourceIndex;
        }
        else if (Poco.FhirValue is Address address)
        {
          string FullAdddress = string.Empty;
          foreach (var Line in address.Line)
          {
            FullAdddress += Line + ItemDelimeter;
          }
          if (!string.IsNullOrWhiteSpace(address.City))
          {
            FullAdddress += address.City + ItemDelimeter;
          }
          if (!string.IsNullOrWhiteSpace(address.PostalCode))
          {
            FullAdddress += address.PostalCode + ItemDelimeter;
          }
          if (!string.IsNullOrWhiteSpace(address.State))
          {
            FullAdddress += address.State + ItemDelimeter;
          }
          if (!string.IsNullOrWhiteSpace(address.Country))
          {
            FullAdddress += address.Country + ItemDelimeter;
          }
          if (FullAdddress != string.Empty)
          {
            ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullAdddress.Trim());
            return ResourceIndex;
          }
        }
        else if (Poco.FhirValue is HumanName HumanName)
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
            ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(FullName.Trim());
            return ResourceIndex;
          }
        }
        else if (Poco.FhirValue is Markdown Markdown)
        {
          if (!string.IsNullOrWhiteSpace(Markdown.Value))
          {
            ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Markdown.Value.Trim());
            return ResourceIndex;
          }
        }
        else if (Poco.FhirValue is Annotation Annotation)
        {
          if (!string.IsNullOrWhiteSpace(Annotation.Text))
          {
            ResourceIndex.String = Pyro.Common.Tools.StringSupport.ToLowerAndRemoveDiacritics(Annotation.Text.Trim());
            return ResourceIndex;
          }
        }
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{searchParameter.Type}'");
        }
      }
      else if (oElement.Value is Hl7.FhirPath.ConstantValue ConstantValue)
      {
        ResourceIndex.String = ConstantValue.Type.ToString();
        return ResourceIndex;
      }
      else if (oElement.Value is bool Bool)
      {
        ResourceIndex.String = Bool.ToString();
        return ResourceIndex;
      }
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{searchParameter.Type}'");
      }
      return null;
    }

  }
}
