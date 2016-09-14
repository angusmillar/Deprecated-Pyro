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
      //string Value = ParsePrefix(ParameterValue, oSearchParameter);
      if (oSearchParameter.TryParseValue(ParameterValue))
      {
        oSearchParameter.IsValid = true;
      }
      else
      {
        oSearchParameter.IsValid = false;
        oSearchParameter.InvalidMessage = $"Unable to parse the given search parameter value to the appropriate type of: {oSearchParameter.DbSearchParameterType.ToString()} for parameter = value: '{ParameterValue}', ";
      }
      return oSearchParameter;
    }


    private static DtoSearchParameterBase InitalizeSearchParameter(DatabaseEnum.DbIndexType DbSearchParameterType)
    {
      DtoSearchParameterBase oSearchParameter = null;
      switch (DbSearchParameterType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          oSearchParameter = new DtoSearchParameterDate();
          break;
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          oSearchParameter = new DtoSearchParameterDateTime();
          break;
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          throw new NotImplementedException("DatabaseEnum.BlazeIndexType.DatePeriodIndex");
        case DatabaseEnum.DbIndexType.NumberIndex:
          //oSearchParameter = new DtoSearchParameterNumberValue();
          oSearchParameter = new DtoSearchParameterNumber();
          break;
        case DatabaseEnum.DbIndexType.QuantityIndex:
          throw new NotImplementedException("DatabaseEnum.BlazeIndexType.QuantityIndex");
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          throw new NotImplementedException("DatabaseEnum.BlazeIndexType.ReferenceIndex");
        case DatabaseEnum.DbIndexType.StringIndex:
          oSearchParameter = new DtoSearchParameterString();
          break;
        case DatabaseEnum.DbIndexType.TokenIndex:
          oSearchParameter = new DtoSearchParameterToken();
          break;
        case DatabaseEnum.DbIndexType.UriIndex:
          throw new NotImplementedException("SearchParamType.UriDatabaseEnum.BlazeIndexType.UriIndex");
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          throw new NotImplementedException("DatabaseEnum.BlazeIndexType.QuantityRangeIndex");
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbSearchParameterType.ToString(), (int)DbSearchParameterType, typeof(DatabaseEnum.DbIndexType));
      }
      return oSearchParameter;
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
        if (value.StartsWith("."))
        {
          char[] delimiters = { '.' };
          string TypedResourceName = value.Split(delimiters)[1].Trim();

          Type ResourceType = ModelInfo.GetTypeForFhirType(TypedResourceName);
          //Type ResourceType = ModelInfo.GetTypeForResourceName(TypedResourceName);

          if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
          {
            FHIRDefinedType FHIRDefinedType = (FHIRDefinedType)ModelInfo.FhirTypeNameToFhirType(TypedResourceName);
            SearchParameter.TypeModifierResource = FHIRDefinedType;
            SearchParameter.Modifier = FhirSearchEnum.SearchModifierType.Type;
            return true;
          }
        }
        return false;
      }
    }

    //private static string ParsePrefix(string Value, DtoSearchParameterBase oSearchParameter)
    //{
    //  if (oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.DateIndex ||
    //    oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.DatePeriodIndex ||
    //    oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.NumberIndex ||
    //    oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.QuantityRangeIndex ||        
    //    oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.QuantityIndex)
    //  {
    //    if (Value.Length > 2)
    //    {
    //      //Are the first two char Alpha characters 
    //      if (Regex.IsMatch(Value.Substring(0, 2), @"^[a-zA-Z]+$"))
    //      {
    //        var SearchPrefixTypeDictionary = FhirSearchEnum.GetSearchPrefixTypeDictionary();
    //        if (SearchPrefixTypeDictionary.ContainsKey(Value.Substring(0, 2)))
    //        {
    //          oSearchParameter.Prefix = SearchPrefixTypeDictionary[Value.Substring(0, 2)];
    //          Value = Value.Substring(2);
    //        }
    //      }
    //      else
    //      {
    //        oSearchParameter.Prefix = FhirSearchEnum.SearchPrefixType.None;
    //      }
    //    }
    //  }
    //  return Value;
    //}
  }
}
