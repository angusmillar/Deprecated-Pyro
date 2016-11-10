using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.Common.BusinessEntities.Search.Validation
{
  public class SearchParameterValidator
  {
    private static SearchParametersValidationOperationOutcome _SearchParametersValidationOperationOutcome;
    private static FHIRAllTypes _ResourceType;

    public static SearchParametersValidationOperationOutcome ValidateHistoryParameters(DtoSearchParameterGeneric SearchParameterGeneric)
    {
      _SearchParametersValidationOperationOutcome = new SearchParametersValidationOperationOutcome();
      SearchParameterValidator.ParseToHistorySupportedSearchParameters(SearchParameterGeneric, _SearchParametersValidationOperationOutcome);
      return _SearchParametersValidationOperationOutcome;
    }

    private static void ParseToHistorySupportedSearchParameters(DtoSearchParameterGeneric SearchParameterGeneric, SearchParametersValidationOperationOutcome _SearchParametersValidationOperationOutcome)
    {
      _SearchParametersValidationOperationOutcome.SearchParameters = new DtoSearchParameters();
      //_SearchParametersValidationOperationOutcome.SearchParameters.ResourceTarget =  FHIRAllTypes.
      _SearchParametersValidationOperationOutcome.SearchParameters.SearchParametersList = new List<DtoSearchParameterBase>();
      _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList = new List<DtoUnspportedSearchParameter>();
      _SearchParametersValidationOperationOutcome.SearchParameters.CountOfRecordsRequested = SearchParameterGeneric.Count;
      var oSupportedSearchParametersForHistoryList = DtoSupportedSearchParametersFactory.GetSupportedParametersForHistory();
      var oSearchParameterNameDictionary = FhirSearchEnum.GetSearchParameterNameType();

      foreach (var Parameter in SearchParameterGeneric.ParameterList)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          FhirSearchEnum.SearchParameterNameType? SearchParameterNameType = null;
          var SearchParameterNameString = Parameter.Item1.Split(':')[0];
          if (oSearchParameterNameDictionary.ContainsKey(SearchParameterNameString))
          {
            SearchParameterNameType = oSearchParameterNameDictionary[SearchParameterNameString];

            DtoSupportedSearchParameters oSupportedSearchParameter = oSupportedSearchParametersForHistoryList.SingleOrDefault(x => x.Name == SearchParameterNameType);
            if (oSupportedSearchParameter != null)
            {
              DtoSearchParameterBase oSearchParameter = SearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, Parameter);
              if (oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.ReferenceIndex)
              {
                oSearchParameter.PrimaryRootUrlStore = _SearchParametersValidationOperationOutcome.SearchParameters.PrimaryRootUrlStore;
              }

              if (ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter))
              {
                if (!IsPageingParameter(oSearchParameter))
                {
                  _SearchParametersValidationOperationOutcome.SearchParameters.SearchParametersList.Add(oSearchParameter);
                }
              }
            }
            else
            {
              var DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
              DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
              DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{_ResourceType.ToString()}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
              _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
            }
          }
          else
          {
            var DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
            DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
            DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for any resource type, the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
            _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
          }
        }
      }


      //if (SearchParameterGeneric.Sort != null)
      //{
      //  _SearchParametersValidationOperationOutcome.SearchParameters.SortList = new List<DtoSearchParameters.Sort>();
      //  foreach (var SortItem in SearchParameterGeneric.Sort)
      //  {
      //    if (oSearchParameterNameDictionary.ContainsKey(SortItem.Item1.Trim()))
      //    {
      //      var SearchParameterNameType = oSearchParameterNameDictionary[SortItem.Item1.Trim()];

      //      DtoSupportedSearchParameters oSupportedSearchParameter = oSupportedSearchParametersForResourceList.SingleOrDefault(x => x.Name == SearchParameterNameType);

      //      _SearchParametersValidationOperationOutcome.SearchParameters.SortList.Add(new DtoSearchParameters.Sort() { Value = oSupportedSearchParameter, SortOrderType = SortItem.Item2 });
      //    }
      //  }
      //}
    }



    public static SearchParametersValidationOperationOutcome Validate(FHIRAllTypes ResourceType, DtoSearchParameterGeneric SearchParameterGeneric)
    {
      _ResourceType = ResourceType;
      _SearchParametersValidationOperationOutcome = new SearchParametersValidationOperationOutcome();
      SearchParameterValidator.ParseToResourceSupportedSearchParameters(SearchParameterGeneric, _SearchParametersValidationOperationOutcome);
      return _SearchParametersValidationOperationOutcome;
    }

    private static void ParseToResourceSupportedSearchParameters(DtoSearchParameterGeneric SearchParameterGeneric, SearchParametersValidationOperationOutcome _SearchParametersValidationOperationOutcome)
    {
      _SearchParametersValidationOperationOutcome.SearchParameters = new DtoSearchParameters();
      _SearchParametersValidationOperationOutcome.SearchParameters.ResourceTarget = _ResourceType;
      _SearchParametersValidationOperationOutcome.SearchParameters.SearchParametersList = new List<DtoSearchParameterBase>();
      _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList = new List<DtoUnspportedSearchParameter>();

      var oSupportedSearchParametersForResourceList = DtoSupportedSearchParametersFactory.GetSupportedParametersForResourceTypeList(_ResourceType);
      var oSearchParameterNameDictionary = FhirSearchEnum.GetSearchParameterNameType();

      foreach (var Parameter in SearchParameterGeneric.ParameterList)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          FhirSearchEnum.SearchParameterNameType? SearchParameterNameType = null;
          var SearchParameterNameString = Parameter.Item1.Split(':')[0];
          if (oSearchParameterNameDictionary.ContainsKey(SearchParameterNameString))
          {
            SearchParameterNameType = oSearchParameterNameDictionary[SearchParameterNameString];

            DtoSupportedSearchParameters oSupportedSearchParameter = oSupportedSearchParametersForResourceList.SingleOrDefault(x => x.Name == SearchParameterNameType);
            if (oSupportedSearchParameter != null)
            {
              DtoSearchParameterBase oSearchParameter = SearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, Parameter);
              if (oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.ReferenceIndex)
              {
                oSearchParameter.PrimaryRootUrlStore = _SearchParametersValidationOperationOutcome.SearchParameters.PrimaryRootUrlStore;
              }

              if (ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter))
              {
                if (!IsPageingParameter(oSearchParameter))
                {
                  _SearchParametersValidationOperationOutcome.SearchParameters.SearchParametersList.Add(oSearchParameter);
                }
              }
            }
            else
            {
              var DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
              DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
              DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{_ResourceType.ToString()}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
              _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
            }
          }
          else
          {
            var DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
            DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
            DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for any resource type, the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
            _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
          }
        }
      }


      if (SearchParameterGeneric.Sort != null)
      {
        _SearchParametersValidationOperationOutcome.SearchParameters.SortList = new List<DtoSearchParameters.Sort>();
        foreach (var SortItem in SearchParameterGeneric.Sort)
        {
          if (oSearchParameterNameDictionary.ContainsKey(SortItem.Item1.Trim()))
          {
            var SearchParameterNameType = oSearchParameterNameDictionary[SortItem.Item1.Trim()];

            DtoSupportedSearchParameters oSupportedSearchParameter = oSupportedSearchParametersForResourceList.SingleOrDefault(x => x.Name == SearchParameterNameType);

            _SearchParametersValidationOperationOutcome.SearchParameters.SortList.Add(new DtoSearchParameters.Sort() { Value = oSupportedSearchParameter, SortOrderType = SortItem.Item2 });
          }
        }
      }
    }

    private static bool IsPageingParameter(DtoSearchParameterBase oSearchParameter)
    {
      if (oSearchParameter.Name == FhirSearchEnum.SearchParameterNameType.page)
      {
        if (oSearchParameter is DtoSearchParameterNumber)
        {
          DtoSearchParameterNumber PageSearchParameter = oSearchParameter as DtoSearchParameterNumber;
          _SearchParametersValidationOperationOutcome.SearchParameters.RequiredPageNumber = Convert.ToInt32(PageSearchParameter.ValueList[0].Value);
          return true;
        }
      }
      return false;
    }

    private static bool ValidateSearchParameterSupported(DtoSupportedSearchParameters oSupported, DtoSearchParameterBase oInboundSearchParameter)
    {
      DtoUnspportedSearchParameter DtoUnspportedSearchParameter = null;

      if (!oInboundSearchParameter.IsValid)
      {
        DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
        DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + oInboundSearchParameter.InvalidMessage + ", ";
      }

      if (oInboundSearchParameter.Modifier != FhirSearchEnum.SearchModifierType.None)
      {
        if (!oSupported.ModifierList.Contains(oInboundSearchParameter.Modifier))
        {
          DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
          DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + $"The parameter's modifier: '{oInboundSearchParameter.Modifier.ToString()}' is not supported by this server for the resource type '{oInboundSearchParameter.Resource.ToString()}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}', ";
        }
        if (oInboundSearchParameter.Modifier == FhirSearchEnum.SearchModifierType.Type)
        {
          if (!oSupported.TypeModifierResourceList.Contains(oInboundSearchParameter.TypeModifierResource))
          {
            DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
            DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + $"The reference search parameter modifier was expected to be a Fhir resource type that is supported for this search parameter. The Resource given was: {oInboundSearchParameter.TypeModifierResource} which is not supported for this search parameter.', ";
          }
        }
      }

      if (!oInboundSearchParameter.ValidatePrefixes(oSupported))
      {
        DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
        string PreFixListString = string.Empty;
        oSupported.PrefixList.ForEach(x => PreFixListString = PreFixListString + "," + x);
        if (PreFixListString == string.Empty)
        {
          PreFixListString = "(none)";
        }
        else
        {
          PreFixListString = $"({PreFixListString})";
        }
        DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + $"The one or more of the search parameter prefixes are not supported by this server against resource type of :'{oInboundSearchParameter.Resource.ToString()}', the whole parameter given was : '{DtoUnspportedSearchParameter.RawParameter}'. The prefixes that are supported are: {PreFixListString}, ";
      }

      if (oInboundSearchParameter.TypeModifierResource != null)
      {
        if (!oSupported.TypeModifierResourceList.Contains(oInboundSearchParameter.TypeModifierResource))
        {
          DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
          DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + String.Format("Unsupported search, the 'Resource' type found in the '[ResourceType]' Modifier is not supported. 'Resource' type was: '{0}' in parameter '{1}'., ", oInboundSearchParameter.TypeModifierResource.ToString(), oInboundSearchParameter.RawValue);
        }
      }


      if (DtoUnspportedSearchParameter != null)
      {
        if (_SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList == null)
          _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList = new List<DtoUnspportedSearchParameter>();
        _SearchParametersValidationOperationOutcome.SearchParameters.DtoUnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
        return false;
      }
      else
      {
        return true;
      }
    }

    private static DtoUnspportedSearchParameter InitaliseUnspportedParamerter(DtoSearchParameterBase oInboundSearchParameter, DtoUnspportedSearchParameter DtoUnspportedSearchParameter)
    {
      if (DtoUnspportedSearchParameter == null)

        DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
      if (string.IsNullOrWhiteSpace(DtoUnspportedSearchParameter.RawParameter))
        DtoUnspportedSearchParameter.RawParameter = $"{oInboundSearchParameter.RawValue}";
      return DtoUnspportedSearchParameter;
    }
  }
}
