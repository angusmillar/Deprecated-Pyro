using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Search;

namespace Pyro.Common.BusinessEntities.Service
{
  public class SearchParameterService
  {
    private static ISearchParametersServiceRequest _SearchParametersServiceRequest;
    private static ISearchParametersServiceOutcome _SearchParametersServiceOutcome;

    [Flags]
    public enum SearchParameterServiceType
    {
      None = 2,
      Base = 4,
      Bundle = 8,
      Resource = 16,     
    };
                                                                         
    public static ISearchParametersServiceOutcome ProcessSearchParameters(ISearchParametersServiceRequest SearchParametersServiceRequest)
    {
      _SearchParametersServiceRequest = SearchParametersServiceRequest;
      if (_SearchParametersServiceRequest.SearchParameterServiceType == SearchParameterServiceType.None)
        throw new NullReferenceException("Server error: SearchParameterServiceType can not be 'None'.");
      if (((_SearchParametersServiceRequest.SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource) && _SearchParametersServiceRequest.ResourceType == null)
        throw new NullReferenceException("Server error: ResourceType can not be null when enum SearchParameterServiceType is set to Resource.");
      if (((_SearchParametersServiceRequest.SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource) && _SearchParametersServiceRequest.CommonServices == null)
        throw new NullReferenceException("Server error: CommonServices can not be null when enum SearchParameterServiceType is set to Resource.");
      if (((_SearchParametersServiceRequest.SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource) && _SearchParametersServiceRequest.RequestUri == null)
        throw new NullReferenceException("Server error: RequestUri can not be null when enum SearchParameterServiceType is set to Resource.");      
      if (_SearchParametersServiceRequest.SearchParameterGeneric == null)
        throw new NullReferenceException("Server error: SearchParameterGeneric can not be null.");
      
      _SearchParametersServiceOutcome = Common.CommonFactory.GetSearchParametersServiceOutcome();
      SearchParameterService.ParseSupportedSearchParameters(SearchParametersServiceRequest.SearchParameterGeneric);
      return _SearchParametersServiceOutcome;
    }

    private static void ParseSupportedSearchParameters(IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      _SearchParametersServiceOutcome.SearchParameters = new DtoSearchParameters();
      _SearchParametersServiceOutcome.SearchParameters.ResourceTarget = _SearchParametersServiceRequest.ResourceType;
      _SearchParametersServiceOutcome.SearchParameters.SearchParametersList = new List<DtoSearchParameterBase>();
      _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<DtoUnspportedSearchParameter>();
      _SearchParametersServiceOutcome.SearchParameters.CountOfRecordsRequested = SearchParameterGeneric.Count;

      //var oSearchParameterNameDictionary = FhirSearchEnum.GetSearchParameterNameTypeDictionary();
      List<DtoServiceSearchParameterLight> DtoSupportedSearchParametersList = GetSupportedSearchParameters();

      foreach (var Parameter in SearchParameterGeneric.ParameterList)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {          
          var SearchParameterNameString = Parameter.Item1.Split(':')[0].Trim();
          DtoServiceSearchParameterLight oSupportedSearchParameter = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterNameString);
          if (oSupportedSearchParameter != null)
          {
            DtoSearchParameterBase oSearchParameter = SearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, Parameter, _SearchParametersServiceRequest.CommonServices, _SearchParametersServiceRequest.RequestUri);
            if (oSearchParameter.Type == SearchParamType.Reference)
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
            string ResourceName = string.Empty;
            if (_SearchParametersServiceRequest.ResourceType.HasValue)
              ResourceName = _SearchParametersServiceRequest.ResourceType.Value.ToString();
            DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
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
          //if (oSearchParameterNameDictionary.ContainsKey(SortItem.Item1.Trim()))
          //{
            //var SearchParameterNameType = oSearchParameterNameDictionary[SortItem.Item1.Trim()];
            string SearchParameterName = SortItem.Item1.Trim();
            DtoServiceSearchParameterLight oSupportedSearchParameter = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterName);

            _SearchParametersServiceOutcome.SearchParameters.SortList.Add(new DtoSearchParameters.Sort() { Value = oSupportedSearchParameter, SortOrderType = SortItem.Item2 });
        }
      }
    }

    private static List<DtoServiceSearchParameterLight> GetSupportedSearchParameters()
    {
      List<DtoServiceSearchParameterLight> DtoSupportedServiceSearchParameterList = new List<DtoServiceSearchParameterLight>();
      //List<DtoSupportedSearchParameters> DtoSupportedSearchParametersList = new List<DtoSupportedSearchParameters>();

      //For non Resource URL values, e.g _format, _summary
      if ((_SearchParametersServiceRequest.SearchParameterServiceType & SearchParameterServiceType.Base) == SearchParameterServiceType.Base)
      {
        DtoSupportedServiceSearchParameterList.AddRange(Pyro.Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.BaseSearchParameters());
      }
      //For Bundle URL Parameters e.g page, _sort
      if ((_SearchParametersServiceRequest.SearchParameterServiceType & SearchParameterServiceType.Bundle) == SearchParameterServiceType.Bundle)
      {
        DtoSupportedServiceSearchParameterList.AddRange(Pyro.Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.BundleSearchParameters());
      }

      //For Resource search parameyters
      if ((_SearchParametersServiceRequest.SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource)
      {
        //DtoSupportedServiceSearchParameterList.AddRange(Pyro.Common.BusinessEntities.Dto.Search.ServiceSearchParameterFactory.BaseResourceSearchParameters());
        DtoSupportedServiceSearchParameterList.AddRange(Cache.StaticCacheCommon.GetSearchParameterForResource(_SearchParametersServiceRequest.CommonServices, _SearchParametersServiceRequest.ResourceType.GetLiteral()));        
      }

      return DtoSupportedServiceSearchParameterList;      
    }

    private static bool IsSingularSearchParameter(DtoSearchParameterBase oSearchParameter)
    {
      if (oSearchParameter.Name == "page")
      {
        if (oSearchParameter is DtoSearchParameterNumber)
        {
          var PageSearchParameter = oSearchParameter as DtoSearchParameterNumber;
          _SearchParametersServiceOutcome.SearchParameters.RequiredPageNumber = Convert.ToInt32(PageSearchParameter.ValueList[0].Value);
          return true;
        }
      }

      if (oSearchParameter.Name == Hl7.Fhir.Rest.HttpUtil.RESTPARAM_FORMAT)
      {
        if (oSearchParameter is DtoSearchParameterString)
        {
          var FormatSearchParameter = oSearchParameter as DtoSearchParameterString;
          _SearchParametersServiceOutcome.SearchParameters.Format = FormatSearchParameter.ValueList[0].Value.Trim();
          return true;
        }
      }

      if (oSearchParameter.Name == Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_SUMMARY)
      {
        if (oSearchParameter is DtoSearchParameterToken FormatSearchParameter)
        {
          var SummaryDic = Common.Enum.FhirSearchEnum.GetSummaryTypeDictionary();
          if (SummaryDic.ContainsKey(FormatSearchParameter.ValueList[0].Code.Trim()))
          {
            _SearchParametersServiceOutcome.SearchParameters.SummaryType = SummaryDic[FormatSearchParameter.ValueList[0].Code.Trim()];            
          }                    
        }
        return true;
      }

      return false;
    }

    private static bool ValidateSearchParameterSupported(DtoServiceSearchParameterLight oSupported, DtoSearchParameterBase oInboundSearchParameter)
    {
      DtoUnspportedSearchParameter DtoUnspportedSearchParameter = null;

      if (!oInboundSearchParameter.IsValid)
      {
        DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
        DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + oInboundSearchParameter.InvalidMessage + ", ";
      }

      if (oInboundSearchParameter.Modifier.HasValue)
      {        
        IList<SearchParameter.SearchModifierCode> oSupportedModifierList = Common.Tools.SearchParameterTools.GetModifiersForSearchType(oInboundSearchParameter.Type);
        if (!oSupportedModifierList.Contains(oInboundSearchParameter.Modifier.Value))          
        {
          DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
          DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + $"The parameter's modifier: '{oInboundSearchParameter.Modifier.ToString()}' is not supported by this server for the resource type '{oInboundSearchParameter.Resource.ToString()}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}', ";
        }
        if (oInboundSearchParameter.Modifier == SearchParameter.SearchModifierCode.Type)
        {
           
          if (!Dto.Search.ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oInboundSearchParameter.TypeModifierResource, oInboundSearchParameter.Name).Contains(oInboundSearchParameter.TypeModifierResource))
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
        Common.Tools.SearchParameterTools.GetPrefixListForSearchType(oSupported.Type).ForEach(x => PreFixListString = PreFixListString + "," + x);
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
        if (!Dto.Search.ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oInboundSearchParameter.TypeModifierResource, oInboundSearchParameter.Name).Contains(oInboundSearchParameter.TypeModifierResource))
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
