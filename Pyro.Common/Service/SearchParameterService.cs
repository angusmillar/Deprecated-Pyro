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
using Pyro.Common.Search;
using Pyro.Common.FhirOperation;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceSearchParameter;

namespace Pyro.Common.Service
{
  public class SearchParameterService : ISearchParameterService
  {
    //private ISearchParametersServiceRequest _SearchParametersServiceRequest;
    private readonly ICommonFactory ICommonFactory;
    private readonly ISearchParameterFactory ISearchParameterFactory;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;

    public SearchParameterService(ICommonFactory ICommonFactory, ISearchParameterFactory ISearchParameterFactory, IServiceSearchParameterCache IServiceSearchParameterCache)
    {
      this.ICommonFactory = ICommonFactory;
      this.ISearchParameterFactory = ISearchParameterFactory;
      this.IServiceSearchParameterCache = IServiceSearchParameterCache;
    }

    [Flags]
    public enum SearchParameterServiceType
    {
      None = 2,
      Base = 4,
      Bundle = 8,
      Resource = 16,
      Operation = 32,
    };

    public ISearchParametersServiceOutcome ProcessResourceSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric,
      SearchParameterServiceType SearchParameterServiceType,
      FHIRAllTypes? ResourceType)
    {
      return ProcessSearchParameters(SearchParameterGeneric, SearchParameterServiceType, ResourceType, null);
    }

    public ISearchParametersServiceOutcome ProcessOperationSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric,
      SearchParameterServiceType SearchParameterServiceType,
      OperationClass OperationClass)
    {
      return ProcessSearchParameters(SearchParameterGeneric, SearchParameterServiceType, null, OperationClass);
    }

    public ISearchParametersServiceOutcome ProcessBaseSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric)
    {
      return ProcessSearchParameters(SearchParameterGeneric, SearchParameterServiceType.Base, null, null);
    }

    public ISearchParametersServiceOutcome ProcessBundleSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric)
    {
      return ProcessSearchParameters(SearchParameterGeneric, SearchParameterServiceType.Base | SearchParameterServiceType.Bundle, null, null);
    }


    public ISearchParametersServiceOutcome ProcessSearchParameters(
      ISearchParameterGeneric SearchParameterGeneric,
      SearchParameterServiceType SearchParameterServiceType,
      FHIRAllTypes? ResourceType,
      OperationClass OperationClass)
    {
      //_SearchParametersServiceRequest = SearchParametersServiceRequest;
      if (SearchParameterServiceType == SearchParameterServiceType.None)
        throw new NullReferenceException("Server error: SearchParameterServiceType can not be 'None'.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("Server error: SearchParameterGeneric can not be null.");

      if (((SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource)
        && ResourceType == null)
        throw new NullReferenceException("Server error: ResourceType can not be null when enum SearchParameterServiceType is set to Resource.");

      if (((SearchParameterServiceType & SearchParameterServiceType.Operation) == SearchParameterServiceType.Operation)
        && OperationClass == null)
        throw new NullReferenceException("Server error: OperationClass can not be null when enum SearchParameterServiceType is set to Operation.");


      ISearchParametersServiceOutcome SearchParametersServiceOutcome = ICommonFactory.CreateSearchParametersServiceOutcome();
      SearchParametersServiceOutcome.SearchParameters = new PyroSearchParameters();
      SearchParametersServiceOutcome.SearchParameters.ResourceTarget = ResourceType;
      SearchParametersServiceOutcome.SearchParameters.SearchParametersList = new List<ISearchParameterBase>();
      SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
      SearchParametersServiceOutcome.SearchParameters.CountOfRecordsRequested = SearchParameterGeneric.Count;

      List<ServiceSearchParameterLight> DtoSupportedSearchParametersList = GetSupportedSearchParameters(SearchParameterServiceType, OperationClass, ResourceType);

      //Parse Include and RevInclude parameters
      ProcessIncludeSearchParameters(SearchParameterGeneric.Include, SearchParametersServiceOutcome);
      ProcessIncludeSearchParameters(SearchParameterGeneric.RevInclude, SearchParametersServiceOutcome);

      foreach (var Parameter in SearchParameterGeneric.ParameterList)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          var SearchParameterNameString = Parameter.Item1.Split(':')[0].Trim();
          ServiceSearchParameterLight oSupportedSearchParameter = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterNameString);
          if (oSupportedSearchParameter != null)
          {

            ISearchParameterBase oSearchParameter = ISearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, Parameter);
            if (ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter, SearchParametersServiceOutcome))
            {
              if (!IsSingularSearchParameter(oSearchParameter, SearchParametersServiceOutcome))
              {
                SearchParametersServiceOutcome.SearchParameters.SearchParametersList.Add(oSearchParameter);
              }
            }
          }
          else
          {
            var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
            DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
            string ResourceName = string.Empty;
            if (ResourceType.HasValue)
              ResourceName = ResourceType.Value.ToString();
            DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
            SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
          }
        }
      }

      //resolve Sort order parameters
      if (SearchParameterGeneric.Sort != null)
      {
        SearchParametersServiceOutcome.SearchParameters.SortList = new List<PyroSearchParameters.Sort>();
        foreach (var SortItem in SearchParameterGeneric.Sort)
        {
          string SearchParameterName = SortItem.Item1.Trim();
          ServiceSearchParameterLight oSupportedSearchParameter = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterName);
          SearchParametersServiceOutcome.SearchParameters.SortList.Add(new PyroSearchParameters.Sort() { Value = oSupportedSearchParameter, SortOrderType = SortItem.Item2 });
        }
      }

      return SearchParametersServiceOutcome;
    }

    private void ProcessIncludeSearchParameters(IList<Tuple<string, string>> IncludeList, ISearchParametersServiceOutcome SearchParametersServiceOutcome)
    {
      if (IncludeList != null)
      {
        foreach (var Include in IncludeList)
        {
          bool ParseOk = true;

          SearchParameterInclude SearchParameterInclude = null;
          var Key = Include.Item1;
          var KeySplitArray = Key.Split(':'); //_includes:recurse

          if (KeySplitArray[0].ToLower() == Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_INCLUDE.ToLower())
          {
            SearchParameterInclude = new SearchParameterInclude(SearchParameterInclude.IncludeType.Include);
          }
          else if (KeySplitArray[0].ToLower() == Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_REVINCLUDE.ToLower())
          {
            SearchParameterInclude = new SearchParameterInclude(SearchParameterInclude.IncludeType.RevInclude);
          }
          else
          {
            ParseOk = false;
            if (SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList == null)
              SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
            SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
            { RawParameter = $"{Key}", ReasonMessage = $"{Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_INCLUDE} or {Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_REVINCLUDE} parameter is not recognised." });
          }

          SearchParameterInclude.IsRecurse = false;
          if (KeySplitArray.Count() > 1)
          {
            if (KeySplitArray[1].ToLower() == "recurse")
            {
              SearchParameterInclude.IsRecurse = true;
            }
          }

          var Value = Include.Item2;
          var valueSplitArray = Value.Split(':');
          string ScourceResource = valueSplitArray[0].Trim();
          if (ModelInfo.IsKnownResource(ScourceResource))
          {
            SearchParameterInclude.SourceResourceType = ModelInfo.FhirTypeNameToFhirType(ScourceResource).Value;
          }
          else
          {
            ParseOk = false;
            if (SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList == null)
              SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
            SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
            { RawParameter = $"{Key}={Value}", ReasonMessage = "The source Resource of the _includes parameter is not recognised." });

          }

          if (valueSplitArray.Count() > 2)
          {
            string TargetResourceType = valueSplitArray[2].Trim();
            //checked we have a something if we don't then that is fine just a syntax error of the callers part 
            //i.e _includes=Patient:subject:
            if (!string.IsNullOrWhiteSpace(TargetResourceType))
            {
              if (ModelInfo.IsKnownResource(TargetResourceType))
              {
                SearchParameterInclude.SearchParameterTargetResourceType = ModelInfo.FhirTypeNameToFhirType(TargetResourceType).Value;
              }
              else
              {
                ParseOk = false;
                SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                { RawParameter = $"{Key}={Value}", ReasonMessage = "The target Resource of the _includes parameter is not recognised." });
              }
            }
          }

          if (valueSplitArray.Count() > 1)
          {
            string SearchTerm = valueSplitArray[1].Trim();
            List<ServiceSearchParameterLight> DtoSupportedSearchParametersList = GetSupportedSearchParameters(SearchParameterServiceType.Resource, null, SearchParameterInclude.SourceResourceType.GetLiteral());
            if (SearchTerm == "*")
            {
              if (SearchParameterInclude.SearchParameterTargetResourceType != null)
              {
                SearchParameterInclude.SearchParameterList = DtoSupportedSearchParametersList.Where(x => x.Type == SearchParamType.Reference && x.TargetResourceTypeList.Any(v => v.ResourceType.GetLiteral() == SearchParameterInclude.SearchParameterTargetResourceType.Value.GetLiteral())).ToList();
              }
              else
              {
                SearchParameterInclude.SearchParameterList = DtoSupportedSearchParametersList.Where(x => x.Type == SearchParamType.Reference).ToList();
              }
            }
            else
            {
              ServiceSearchParameterLight DtoServiceSearchParameterLight = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchTerm);
              if (DtoServiceSearchParameterLight != null)
              {
                if (DtoServiceSearchParameterLight.Type == SearchParamType.Reference)
                {
                  if (DtoServiceSearchParameterLight.TargetResourceTypeList != null && SearchParameterInclude.SearchParameterTargetResourceType.HasValue)
                  {
                    if (DtoServiceSearchParameterLight.TargetResourceTypeList.SingleOrDefault(x => x.ResourceType.GetLiteral() == SearchParameterInclude.SearchParameterTargetResourceType.Value.GetLiteral()) == null)
                    {
                      ParseOk = false;
                      SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                      { RawParameter = $"{Key}={Value}", ReasonMessage = $"The target Resource '{SearchParameterInclude.SearchParameterTargetResourceType.Value.GetLiteral()}' of the _includes parameter is not recognised for the source '{SearchParameterInclude.SourceResourceType.GetLiteral()}' Resource's search parameter {DtoServiceSearchParameterLight.Name}." });
                    }
                  }
                  SearchParameterInclude.SearchParameterList = new List<ServiceSearchParameterLight>();
                  SearchParameterInclude.SearchParameterList.Add(DtoServiceSearchParameterLight);
                }
                else
                {
                  ParseOk = false;
                  SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                  { RawParameter = $"{Key}={Value}", ReasonMessage = $"The source Resource '{SearchParameterInclude.SourceResourceType.GetLiteral()}' search parameter '{DtoServiceSearchParameterLight.Name}' of the _includes parameter is not of search parameter of type Reference, found search parameter type of '{DtoServiceSearchParameterLight.Type.ToString()}'." });
                }
              }
              else
              {
                ParseOk = false;
                SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                { RawParameter = $"{Key}={Value}", ReasonMessage = $"The source Resource '{SearchParameterInclude.SourceResourceType.GetLiteral()}' search parameter '{SearchTerm}' is not a valid search parameter for the source Resource type." });
              }
            }
          }

          //All ok so add as valid include
          if (ParseOk)
          {
            if (SearchParameterInclude.Type == SearchParameterInclude.IncludeType.Include)
            {
              if (SearchParametersServiceOutcome.SearchParameters.IncludeList == null)
                SearchParametersServiceOutcome.SearchParameters.IncludeList = new List<SearchParameterInclude>();
              SearchParametersServiceOutcome.SearchParameters.IncludeList.Add(SearchParameterInclude);
            }
            else if (SearchParameterInclude.Type == SearchParameterInclude.IncludeType.RevInclude)
            {
              if (SearchParametersServiceOutcome.SearchParameters.RevIncludeList == null)
                SearchParametersServiceOutcome.SearchParameters.RevIncludeList = new List<SearchParameterInclude>();
              SearchParametersServiceOutcome.SearchParameters.RevIncludeList.Add(SearchParameterInclude);
            }
            else
            {
              ParseOk = false;
              SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
              { RawParameter = $"{SearchParameterInclude.Type.ToString()}", ReasonMessage = $"The include parameter  Type {SearchParameterInclude.Type.ToString()} was unknown. This is an internal server error" });
            }
          }

        }
      }
    }

    private List<ServiceSearchParameterLight> GetSupportedSearchParameters(SearchParameterServiceType SearchParameterServiceType, OperationClass OperationClass, string ResourceType)
    {
      List<ServiceSearchParameterLight> DtoSupportedServiceSearchParameterList = new List<ServiceSearchParameterLight>();
      //For non Resource URL values, e.g _format, _summary
      if ((SearchParameterServiceType & SearchParameterServiceType.Base) == SearchParameterServiceType.Base)
      {
        DtoSupportedServiceSearchParameterList.AddRange(ServiceSearchParameterFactory.BaseSearchParameters());
      }
      //For Bundle URL Parameters e.g page, _sort
      if ((SearchParameterServiceType & SearchParameterServiceType.Bundle) == SearchParameterServiceType.Bundle)
      {
        DtoSupportedServiceSearchParameterList.AddRange(ServiceSearchParameterFactory.BundleSearchParameters());
      }

      //For $Operation URL Parameters e.g profile, mode
      if ((SearchParameterServiceType & SearchParameterServiceType.Operation) == SearchParameterServiceType.Operation)
      {
        DtoSupportedServiceSearchParameterList.AddRange(ServiceSearchParameterFactory.OperationSearchParameters(OperationClass));
      }

      //For Resource search parameters
      if ((SearchParameterServiceType & SearchParameterServiceType.Resource) == SearchParameterServiceType.Resource)
      {
        DtoSupportedServiceSearchParameterList.AddRange(IServiceSearchParameterCache.GetSearchParameterForResource(ResourceType));
      }

      return DtoSupportedServiceSearchParameterList;
    }

    private List<ServiceSearchParameterLight> GetSupportedSearchParameters(SearchParameterServiceType SearchParameterServiceType, OperationClass OperationClass, FHIRAllTypes? ResourceType)
    {
      string ResourceString = string.Empty;
      if (ResourceType.HasValue)
        ResourceString = ResourceType.Value.GetLiteral();
      return GetSupportedSearchParameters(SearchParameterServiceType, OperationClass, ResourceString);
    }


    private bool IsSingularSearchParameter(ISearchParameterBase oSearchParameter, ISearchParametersServiceOutcome _SearchParametersServiceOutcome)
    {
      if (oSearchParameter.Name == "page")
      {
        if (oSearchParameter is SearchParameterNumber)
        {
          var PageSearchParameter = oSearchParameter as SearchParameterNumber;
          _SearchParametersServiceOutcome.SearchParameters.RequiredPageNumber = Convert.ToInt32(PageSearchParameter.ValueList[0].Value);
          return true;
        }
      }

      if (oSearchParameter.Name == Hl7.Fhir.Rest.HttpUtil.RESTPARAM_FORMAT)
      {
        if (oSearchParameter is SearchParameterString)
        {
          var FormatSearchParameter = oSearchParameter as SearchParameterString;
          _SearchParametersServiceOutcome.SearchParameters.Format = FormatSearchParameter.ValueList[0].Value.Trim();
          return true;
        }
      }

      if (oSearchParameter.Name == Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_SUMMARY)
      {
        if (oSearchParameter is SearchParameterToken FormatSearchParameter)
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
    private bool ValidateSearchParameterSupported(ServiceSearchParameterLight oSupported, ISearchParameterBase oInboundSearchParameter, ISearchParametersServiceOutcome _SearchParametersServiceOutcome)
    {
      UnspportedSearchParameter DtoUnspportedSearchParameter = null;

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

          if (!ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oInboundSearchParameter).Contains(oInboundSearchParameter.TypeModifierResource))
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
        if (!ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oInboundSearchParameter).Contains(oInboundSearchParameter.TypeModifierResource))
        {
          DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
          DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + String.Format("Unsupported search, the 'Resource' type found in the '[ResourceType]' Modifier is not supported. 'Resource' type was: '{0}' in parameter '{1}'., ", oInboundSearchParameter.TypeModifierResource.ToString(), oInboundSearchParameter.RawValue);
        }
      }


      if (DtoUnspportedSearchParameter != null)
      {
        if (_SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList == null)
          _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
        _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
        return false;
      }
      else
      {
        return true;
      }
    }
    private UnspportedSearchParameter InitaliseUnspportedParamerter(ISearchParameterBase oInboundSearchParameter, UnspportedSearchParameter DtoUnspportedSearchParameter)
    {
      if (DtoUnspportedSearchParameter == null)

        DtoUnspportedSearchParameter = new UnspportedSearchParameter();
      if (string.IsNullOrWhiteSpace(DtoUnspportedSearchParameter.RawParameter))
        DtoUnspportedSearchParameter.RawParameter = $"{oInboundSearchParameter.RawValue}";
      return DtoUnspportedSearchParameter;
    }

  }
}
