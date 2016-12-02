using System;
using System.Linq;
using System.Collections.Generic;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Service;
using Pyro.Common.Interfaces.Service;
using Hl7.Fhir.Model;

namespace Pyro.Common.BusinessEntities.Search
{
  public static class SearchParameterFactory
  {
    private static readonly char _ParameterNameParameterValueDilimeter = '=';
    private static readonly char _ParameterNameModifierDilimeter = ':';
    private static string _RawSearchParameterAndValueString = string.Empty;

    public static DtoSearchParameterBase CreateSearchParameter(DtoSupportedSearchParameters DtoSupportedSearchParametersResource, Tuple<string, string> Parameter)
    {
      DtoSearchParameterBase oSearchParameter = InitalizeSearchParameter(DtoSupportedSearchParametersResource.DbSearchParameterType);

      string ParameterName = Parameter.Item1;
      string ParameterValue = Parameter.Item2;
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

      if (oSearchParameter.Modifier == FhirSearchEnum.SearchModifierType.Type &&
        !string.IsNullOrWhiteSpace(oSearchParameter.TypeModifierResource) &&
        ParameterName.Contains(Hl7.Fhir.Rest.SearchParams.SEARCH_CHAINSEPARATOR))
      {
        //This is a resourceReferance with a Chained parameter, resolve that chained parameter to a search parameter here (is a recursive call).
        var SearchParameterGeneric = new Pyro.Common.BusinessEntities.Search.DtoSearchParameterGeneric();
        SearchParameterGeneric.ParameterList = new List<Tuple<string, string>>();
        var ChainedSearchParam = new Tuple<string, string>(ParameterName.Split('.')[1], ParameterValue);
        SearchParameterGeneric.ParameterList.Add(ChainedSearchParam);
        oSearchParameter.ChainedSearchParameter = SearchParameterService.ProcessSearchParameters(SearchParameterGeneric, SearchParameterService.SearchParameterServiceType.Resource, Hl7.Fhir.Model.ModelInfo.FhirTypeNameToFhirType(oSearchParameter.TypeModifierResource).Value);
        //oSearchParameter.ChainedSearchParameter = SearchParameterService.ProcessResourceSearchParameters((Hl7.Fhir.Model.FHIRAllTypes)Hl7.Fhir.Model.ModelInfo.FhirTypeNameToFhirType(oSearchParameter.TypeModifierResource), SearchParameterGeneric);
      }
      else
      {
        if (oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.ReferenceIndex)
        {
          (oSearchParameter as DtoSearchParameterReferance).AllowedReferanceResourceList = DtoSupportedSearchParametersResource.TypeModifierResourceList;
        }

        if (!oSearchParameter.TryParseValue(ParameterValue))
        {
          oSearchParameter.IsValid = false;
        }
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
        if (value.Contains("."))
        {
          char[] delimiters = { '.' };
          TypedResourceName = value.Split(delimiters)[0].Trim();
        }

        Type ResourceType = ModelInfo.GetTypeForFhirType(TypedResourceName);
        if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
        {
          SearchParameter.TypeModifierResource = TypedResourceName;
          SearchParameter.Modifier = FhirSearchEnum.SearchModifierType.Type;
          return true;
        }
        return false;
      }
    }

  }
}
