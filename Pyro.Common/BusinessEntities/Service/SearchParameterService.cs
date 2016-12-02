using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.Common.BusinessEntities.Service
{
  public class SearchParameterService
  {
    private static ISearchParametersServiceOutcome _SearchParametersServiceOutcome;
    private static FHIRAllTypes? _ResourceType;
    private static SearchParameterServiceType _SearchParameterServiceType;
    [Flags]
    public enum SearchParameterServiceType
    {
      None = 2,
      Base = 4,
      Bundle = 8,
      Resource = 16,
    };

    public static ISearchParametersServiceOutcome ProcessSearchParameters(IDtoSearchParameterGeneric SearchParameterGeneric, SearchParameterServiceType SearchParameterServiceType, FHIRAllTypes? ResourceType = null)
    {
      if (((SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource) && !ResourceType.HasValue)
        throw new NullReferenceException("Server error: _ResourceType can not be null when enum SearchParameterServiceType is set to Resource.");
      
      if (ResourceType.HasValue)
        _ResourceType = ResourceType.Value;
      _SearchParameterServiceType = SearchParameterServiceType;
      _SearchParametersServiceOutcome = new SearchParametersServiceOutcome();
      SearchParameterService.ParseSupportedSearchParameters(SearchParameterGeneric);
      return _SearchParametersServiceOutcome;
    }

    private static void ParseSupportedSearchParameters(IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      _SearchParametersServiceOutcome.SearchParameters = new DtoSearchParameters();
      _SearchParametersServiceOutcome.SearchParameters.ResourceTarget = _ResourceType;
      _SearchParametersServiceOutcome.SearchParameters.SearchParametersList = new List<DtoSearchParameterBase>();
      _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<DtoUnspportedSearchParameter>();

      var oSearchParameterNameDictionary = FhirSearchEnum.GetSearchParameterNameTypeDictionary();
      List<DtoSupportedSearchParameters> DtoSupportedSearchParametersList = GetSupportedSearchParameters();

      foreach (var Parameter in SearchParameterGeneric.ParameterList)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          FhirSearchEnum.SearchParameterNameType? SearchParameterNameType = null;
          var SearchParameterNameString = Parameter.Item1.Split(':')[0].Trim();
          if (oSearchParameterNameDictionary.ContainsKey(SearchParameterNameString))
          {
            SearchParameterNameType = oSearchParameterNameDictionary[SearchParameterNameString];

            DtoSupportedSearchParameters oSupportedSearchParameter = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterNameType);
            if (oSupportedSearchParameter != null)
            {
              DtoSearchParameterBase oSearchParameter = SearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, Parameter);
              if (oSearchParameter.DbSearchParameterType == DatabaseEnum.DbIndexType.ReferenceIndex)
              {
                oSearchParameter.PrimaryRootUrlStore = _SearchParametersServiceOutcome.SearchParameters.PrimaryRootUrlStore;
              }

              if (ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter))
              {
                if (!IsSingularSearchParameter(oSearchParameter))
                {
                  _SearchParametersServiceOutcome.SearchParameters.SearchParametersList.Add(oSearchParameter);
                }
              }
            }
            else
            {
              var DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
              DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
              DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{_ResourceType.ToString()}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
              _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
            }
          }
          else
          {
            var DtoUnspportedSearchParameter = new DtoUnspportedSearchParameter();
            DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
            DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for any resource type, the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
            _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
          }
        }
      }

      //resolve Sort order parameters
      if (SearchParameterGeneric.Sort != null)
      {
        _SearchParametersServiceOutcome.SearchParameters.SortList = new List<DtoSearchParameters.Sort>();
        foreach (var SortItem in SearchParameterGeneric.Sort)
        {
          if (oSearchParameterNameDictionary.ContainsKey(SortItem.Item1.Trim()))
          {
            var SearchParameterNameType = oSearchParameterNameDictionary[SortItem.Item1.Trim()];

            DtoSupportedSearchParameters oSupportedSearchParameter = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterNameType);

            _SearchParametersServiceOutcome.SearchParameters.SortList.Add(new DtoSearchParameters.Sort() { Value = oSupportedSearchParameter, SortOrderType = SortItem.Item2 });
          }
        }
      }
    }

    private static List<DtoSupportedSearchParameters> GetSupportedSearchParameters()
    {
      List<DtoSupportedSearchParameters> DtoSupportedSearchParametersList = new List<DtoSupportedSearchParameters>();

      if ((_SearchParameterServiceType & SearchParameterServiceType.Base) == SearchParameterServiceType.Base)
        DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      if ((_SearchParameterServiceType & SearchParameterServiceType.Bundle) == SearchParameterServiceType.Bundle)
        DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersForBundleReturn());
      if ((_SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource)
        DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersForResourceTypeList(_ResourceType.Value));

      return DtoSupportedSearchParametersList;

      //switch (_SearchParameterServiceType)
      //{

      //  case SearchParameterServiceType.None:
      //    DtoSupportedSearchParametersList.Clear();
      //    break;
      //  case SearchParameterServiceType.Resource:
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersForBundleReturn());
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersForResourceTypeList(_ResourceType));
      //    break;
      //  case SearchParameterServiceType.History:
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersForBundleReturn());
      //    break;
      //  case SearchParameterServiceType.Base:
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      //    break;
      //  case SearchParameterServiceType.Update:
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      //    break;
      //  case SearchParameterServiceType.Create:
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      //    break;
      //  case SearchParameterServiceType.Delete:
      //    DtoSupportedSearchParametersList.AddRange(DtoSupportedSearchParametersFactory.GetSupportedParametersBase());
      //    break;
      //  default:
      //    throw new System.ComponentModel.InvalidEnumArgumentException(_SearchParameterServiceType.ToString(), (int)_SearchParameterServiceType, typeof(SearchParameterServiceType));
      //}      
    }

    private static bool IsSingularSearchParameter(DtoSearchParameterBase oSearchParameter)
    {
      if (oSearchParameter.Name == FhirSearchEnum.SearchParameterNameType.page)
      {
        if (oSearchParameter is DtoSearchParameterNumber)
        {
          var PageSearchParameter = oSearchParameter as DtoSearchParameterNumber;
          _SearchParametersServiceOutcome.SearchParameters.RequiredPageNumber = Convert.ToInt32(PageSearchParameter.ValueList[0].Value);
          return true;
        }
      }

      if (oSearchParameter.Name == FhirSearchEnum.SearchParameterNameType._format)
      {
        if (oSearchParameter is DtoSearchParameterString)
        {
          var FormatSearchParameter = oSearchParameter as DtoSearchParameterString;
          _SearchParametersServiceOutcome.SearchParameters.Format = FormatSearchParameter.ValueList[0].Value.Trim();
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
        if (_SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList == null)
          _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<DtoUnspportedSearchParameter>();
        _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
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
