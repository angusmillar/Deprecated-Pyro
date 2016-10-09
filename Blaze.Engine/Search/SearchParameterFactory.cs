using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Enum;
using Blaze.Common.BusinessEntities.Search;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Search
{
  public static class SearchParameterFactory
  {
    private static readonly char _ParameterNameParameterValueDilimeter = '=';
    private static readonly char _ParameterNameModifierDilimeter = ':';
    private static string _CurrentResourceName = string.Empty;
    private static string _RawSearchParameterAndValueString = string.Empty;

    public static DtoSearchParameterBase CreateSearchParameter(DtoSupportedSearchParameters DtoSupportedSearchParametersResource, Tuple<string, string> Parameter)
    {
      DtoSearchParameterBase oSearchParameter = InitalizeSearchParameter(DtoSupportedSearchParametersResource.DbSearchParameterType);

      string ParameterName = Parameter.Item1;
      string ParameterValue = Parameter.Item2;
      _CurrentResourceName = ModelInfo.FhirTypeToFhirTypeName(DtoSupportedSearchParametersResource.Resource);
      oSearchParameter.Resource = DtoSupportedSearchParametersResource.Resource;
      oSearchParameter.Name = DtoSupportedSearchParametersResource.Name;
      oSearchParameter.IsDbCollection = DtoSupportedSearchParametersResource.IsDbCollection;
      oSearchParameter.DbPropertyName = DtoSupportedSearchParametersResource.DbPropertyName;
      oSearchParameter.RawValue = ParameterName + _ParameterNameParameterValueDilimeter + ParameterValue;
      _RawSearchParameterAndValueString = oSearchParameter.RawValue;
      oSearchParameter.DbSearchParameterType = DtoSupportedSearchParametersResource.DbSearchParameterType;
      if (!ParseModifier(ParameterName, oSearchParameter))
      {
        oSearchParameter.IsValid = false;
        oSearchParameter.InvalidMessage = $"Unable to parse the given search parameter's Modifier: {ParameterName}', ";
      }      
      if (!oSearchParameter.TryParseValue(ParameterValue))      
      {
        oSearchParameter.IsValid = false;
        oSearchParameter.InvalidMessage = $"Unable to parse the given search parameter value to the appropriate type of: {oSearchParameter.DbSearchParameterType.ToString()} for parameter = value: '{ParameterValue}', ";
      }
      return oSearchParameter;
    }

    private static DtoSearchParameterBase InitalizeSearchParameter(DatabaseEnum.DbIndexType DbSearchParameterType)
    {
      switch (DbSearchParameterType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          return new DtoSearchParameterDate();
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          return new DtoSearchParameterDateTime();
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          return new DtoSearchParameterDateTime();
        case DatabaseEnum.DbIndexType.NumberIndex:
          return new DtoSearchParameterNumber();
        case DatabaseEnum.DbIndexType.QuantityIndex:
          return new DtoSearchParameterQuantity();
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          return new DtoSearchParameterReferance();
        case DatabaseEnum.DbIndexType.StringIndex:
          return new DtoSearchParameterString();
        case DatabaseEnum.DbIndexType.TokenIndex:
          return new DtoSearchParameterToken();
        case DatabaseEnum.DbIndexType.UriIndex:
          return new DtoSearchParameterUri();
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          return new DtoSearchParameterQuantity();
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbSearchParameterType.ToString(), (int)DbSearchParameterType, typeof(DatabaseEnum.DbIndexType));
      }
    }
    private static bool ParseModifier(string Name, DtoSearchParameterBase oSearchParameter)
    {
      if (Name.Contains(_ParameterNameModifierDilimeter))
      {
        return ParseModifierType(oSearchParameter, Name.Split(_ParameterNameModifierDilimeter)[1]);
      }
      else
      {
        oSearchParameter.Modifier = FhirSearchEnum.SearchModifierType.None;
        oSearchParameter.TypeModifierResource = null;
        return true;
      }
    }
    private static bool ParseModifierType(DtoSearchParameterBase SearchParameter, string value)
    {
      var SearchModifierTypeDic = FhirSearchEnum.GetSearchModifierTypeDictionary();
      if (SearchModifierTypeDic.ContainsKey(value))
      {
        SearchParameter.Modifier = SearchModifierTypeDic[value];         
        return true;
      }
      else
      {
        string TypedResourceName = value;
        if (value.StartsWith("."))
        {
          char[] delimiters = { '.' };
          TypedResourceName = value.Split(delimiters)[1].Trim();
        }
        else
        {
          Type ResourceType = ModelInfo.GetTypeForFhirType(TypedResourceName);          
          if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
          {            
            SearchParameter.TypeModifierResource = TypedResourceName;
            SearchParameter.Modifier = FhirSearchEnum.SearchModifierType.Type;
            return true;
          }
        }
        return false;
      }
    }

  }
}
