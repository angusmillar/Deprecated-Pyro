using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;
using Pyro.Common.Enum;
using Pyro.Common.DtoEntity;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Search;
using Pyro.Common.FhirOperation;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.CompositionRoot;
using Pyro.Common.ServiceSearchParameter;
using Pyro.Common.Search.SearchParameterEntity;

namespace Pyro.Common.Service.SearchParameters
{
  public class SearchParameterService : ISearchParameterService
  {
    private readonly ISearchParametersServiceOutcomeFactory ISearchParametersServiceOutcomeFactory;
    private readonly ISearchParameterFactory ISearchParameterFactory;
    private readonly IServiceSearchParameterCache IServiceSearchParameterCache;

    private List<DtoServiceSearchParameterLight> _DtoSupportedSearchParametersList = null;
    private ISearchParametersServiceOutcome _SearchParametersServiceOutcome = null;
    private FHIRAllTypes? _ResourceType = null;
    private OperationClass _OperationClass = null;
    private SearchParameterServiceType _SearchParameterServiceType;

    public SearchParameterService(ISearchParametersServiceOutcomeFactory ISearchParametersServiceOutcomeFactory, ISearchParameterFactory ISearchParameterFactory, IServiceSearchParameterCache IServiceSearchParameterCache)
    {
      this.ISearchParametersServiceOutcomeFactory = ISearchParametersServiceOutcomeFactory;
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

      _ResourceType = ResourceType;
      _OperationClass = OperationClass;
      _SearchParameterServiceType = SearchParameterServiceType;

      _SearchParametersServiceOutcome = ISearchParametersServiceOutcomeFactory.CreateSearchParametersServiceOutcome();
      _SearchParametersServiceOutcome.SearchParameters = new PyroSearchParameters();
      _SearchParametersServiceOutcome.SearchParameters.ResourceTarget = _ResourceType;
      _SearchParametersServiceOutcome.SearchParameters.SearchParametersList = new List<ISearchParameterBase>();
      _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
      _SearchParametersServiceOutcome.SearchParameters.CountOfRecordsRequested = SearchParameterGeneric.Count;
      _SearchParametersServiceOutcome.SearchParameters.SummaryType = SearchParameterGeneric.SummaryType;

      //Parse Include and RevInclude parameters
      ProcessIncludeSearchParameters(SearchParameterGeneric.Include);
      ProcessIncludeSearchParameters(SearchParameterGeneric.RevInclude);

      foreach (var Parameter in SearchParameterGeneric.ParameterList)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          if (Parameter.Item1.Contains(SearchParams.SEARCH_CHAINSEPARATOR))
          {
            ChainSearchProcessing(Parameter);
          }
          else
          {
            NormalSearchProcessing(Parameter);
          }
        }
      }

      //resolve Sort order parameters
      if (SearchParameterGeneric.Sort != null)
      {
        _SearchParametersServiceOutcome.SearchParameters.SortList = new List<PyroSearchParameters.Sort>();
        foreach (var SortItem in SearchParameterGeneric.Sort)
        {
          string SearchParameterName = SortItem.Item1.Trim();
          DtoServiceSearchParameterLight oSupportedSearchParameter = _DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterName);
          _SearchParametersServiceOutcome.SearchParameters.SortList.Add(new PyroSearchParameters.Sort() { Value = oSupportedSearchParameter, SortOrderType = SortItem.Item2 });
        }
      }

      return _SearchParametersServiceOutcome;
    }

    private void ChainSearchProcessing(Tuple<string, string> Parameter)
    {
      _DtoSupportedSearchParametersList = GetSupportedSearchParameters(_SearchParameterServiceType, _OperationClass, _ResourceType);

      ISearchParameterBase ParentChainSearchParameter = null;
      ISearchParameterBase PreviousChainSearchParameter = null;

      string[] ChaimedParameterSplit = Parameter.Item1.Split(SearchParams.SEARCH_CHAINSEPARATOR);
      bool ErrorInSearchParameterProcessing = false;
      for (int i = 0; i < ChaimedParameterSplit.Length; i++)
      {
        DtoServiceSearchParameterLight oSupportedSearchParameter = null;
        string ParameterName = Parameter.Item1.Split(SearchParams.SEARCH_CHAINSEPARATOR)[i];
        string ParameterValue = string.Empty;
        //There is no valid Value for a chained reference parameter unless it is the last in a series 
        //of chains, so don't set it. 
        //Only set the last parameter 
        if (i == ChaimedParameterSplit.Count() - 1)
          ParameterValue = Parameter.Item2;

        var SingleChainedParameter = new Tuple<string, string>(ParameterName, ParameterValue);

        string ParameterNameNoModifier = ParameterName;
        string ParameterModifierTypedResource = string.Empty;

        //Check for and deal with modifiers e.g 'Patient' in th example: subject:Patient.family=millar
        if (ParameterName.Contains(SearchParams.SEARCH_MODIFIERSEPARATOR))
        {
          string[] ParameterModifierSplit = ParameterName.Split(SearchParams.SEARCH_MODIFIERSEPARATOR);
          ParameterNameNoModifier = ParameterModifierSplit[0].Trim();

          if (ParameterModifierSplit.Length > 1)
          {
            Type ModifierResourceType = ModelInfo.GetTypeForFhirType(ParameterModifierSplit[1].Trim());
            if (ModifierResourceType != null && ModelInfo.IsKnownResource(ModifierResourceType))
            {
              ParameterModifierTypedResource = ParameterModifierSplit[1].Trim();
            }
          }
        }

        if (PreviousChainSearchParameter == null)
        {
          oSupportedSearchParameter = _DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == ParameterNameNoModifier);
        }
        else
        {
          if (string.IsNullOrWhiteSpace(PreviousChainSearchParameter.TypeModifierResource))
          {
            if (PreviousChainSearchParameter.TargetResourceTypeList != null)
            {
              if (PreviousChainSearchParameter.TargetResourceTypeList.Count == 1)
              {
                List<DtoServiceSearchParameterLight> _DtoSupportedSearchParametersListForTarget = GetSupportedSearchParameters(_SearchParameterServiceType, _OperationClass, PreviousChainSearchParameter.TargetResourceTypeList[0].ResourceType.GetLiteral());
                DtoServiceSearchParameterLight oSupportedSearchParameterForTarget = _DtoSupportedSearchParametersListForTarget.SingleOrDefault(x => x.Name == ParameterNameNoModifier);
                PreviousChainSearchParameter.TypeModifierResource = oSupportedSearchParameterForTarget.Resource;
                oSupportedSearchParameter = oSupportedSearchParameterForTarget;

              }
              else
              {
                List<DtoServiceSearchParameterLight> oMultiChainedSupportedSearchParameter = new List<DtoServiceSearchParameterLight>();
                foreach (var TargetResourceType in PreviousChainSearchParameter.TargetResourceTypeList)
                {
                  FHIRAllTypes TargetResource = Tools.ResourceNameResolutionSupport.GetResourceFhirAllType(TargetResourceType.ResourceType);
                  List<DtoServiceSearchParameterLight> _DtoSupportedSearchParametersListForTarget = GetSupportedSearchParameters(SearchParameterServiceType.Resource, null, TargetResource);
                  DtoServiceSearchParameterLight oSupportedSearchParameterForTarget = _DtoSupportedSearchParametersListForTarget.SingleOrDefault(x => x.Name == ParameterNameNoModifier);
                  if (oSupportedSearchParameterForTarget != null)
                  {
                    oMultiChainedSupportedSearchParameter.Add(oSupportedSearchParameterForTarget);
                  }
                }
                if (oMultiChainedSupportedSearchParameter.Count() == 1)
                {
                  PreviousChainSearchParameter.TypeModifierResource = oMultiChainedSupportedSearchParameter[0].Resource;
                  oSupportedSearchParameter = oMultiChainedSupportedSearchParameter[0];
                }
                else
                {
                  //Need to do work here!!
                  //oSupportedSearchParameter this needs to be set but we now have many!
                  //the many is the list in oMultiChainedSupportedSearchParameter
                  //PreviousChainSearchParameter.Modifier = SearchParameter.SearchModifierCode.Type;
                  //PreviousChainSearchParameter.TypeModifierResource = oMultiChainedSupportedSearchParameter[0].Resource;
                  string RefResources = string.Empty;
                  oMultiChainedSupportedSearchParameter.ForEach(x => RefResources += ", " + x.Resource);
                  //var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
                  //DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
                  string ResourceName = string.Empty;
                  if (_ResourceType.HasValue)
                    ResourceName = _ResourceType.Value.ToString();
                  string Message = string.Empty;
                  Message = $"The chained search parameter '{Parameter.Item1}' is ambiguous. ";
                  Message += $"Additional information: ";
                  Message += $"The search parameter '{oMultiChainedSupportedSearchParameter[0].Name}' can referance the following resource types ({RefResources.TrimStart(',').Trim()}). ";
                  Message += $"To correct this you must prefix the search parameter with a Type modifier, for example: '{PreviousChainSearchParameter.Name}:{oMultiChainedSupportedSearchParameter[0].Resource}.{oMultiChainedSupportedSearchParameter[0].Name}' ";
                  Message += $"If the '{oMultiChainedSupportedSearchParameter[0].Resource}' resource was the intended referance for the search parameter '{oMultiChainedSupportedSearchParameter[0].Name}'.";
                  if (_SearchParametersServiceOutcome.FhirOperationOutcome == null)
                  {
                    _SearchParametersServiceOutcome.FhirOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
                  }
                  else
                  {
                    Common.Tools.FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message, _SearchParametersServiceOutcome.FhirOperationOutcome);
                  }
                  _SearchParametersServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                  ErrorInSearchParameterProcessing = true;
                }
              }
            }
            else
            {
              //Error that we have no target resource list on the previous parameter, must have not been a references type?
              var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
              DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
              string ResourceName = string.Empty;
              if (_ResourceType.HasValue)
                ResourceName = _ResourceType.Value.ToString();
              DtoUnspportedSearchParameter.ReasonMessage = $"The search parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}'. ";
              DtoUnspportedSearchParameter.ReasonMessage += $"Additional information: ";
              DtoUnspportedSearchParameter.ReasonMessage += $"This search parameter was a chained search parameter. The part that was not recognised was '{PreviousChainSearchParameter.Name}.{ParameterName}'";
              _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
              ErrorInSearchParameterProcessing = true;
              break;
            }
          }
          else if (CheckModifierTypeResourceValidForSearchParameter(PreviousChainSearchParameter.TypeModifierResource, PreviousChainSearchParameter.TargetResourceTypeList))
          {
            _DtoSupportedSearchParametersList = GetSupportedSearchParameters(_SearchParameterServiceType, _OperationClass, PreviousChainSearchParameter.TypeModifierResource);
            oSupportedSearchParameter = _DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == ParameterNameNoModifier);
            if (oSupportedSearchParameter.Resource == FHIRAllTypes.Resource.GetLiteral())
            {
              oSupportedSearchParameter.Resource = PreviousChainSearchParameter.TypeModifierResource;
            }
            PreviousChainSearchParameter.TypeModifierResource = oSupportedSearchParameter.Resource;
          }
          else
          {
            //The modifier target resource provided is not valid for the previous reference, e.g subject:DiagnosticReport.family=millar 
            var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
            DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
            string ResourceName = string.Empty;
            if (_ResourceType.HasValue)
              ResourceName = _ResourceType.Value.ToString();
            DtoUnspportedSearchParameter.ReasonMessage = $"The search parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}'. ";
            DtoUnspportedSearchParameter.ReasonMessage += $"Additional information: ";
            DtoUnspportedSearchParameter.ReasonMessage += $"This search parameter was a chained search parameter. The part that was not recognised was '{PreviousChainSearchParameter.Name}.{ParameterName}', The search parameter modifier given '{PreviousChainSearchParameter.TypeModifierResource}' is not valid for the search parameter {PreviousChainSearchParameter.Name}. ";
            _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
            ErrorInSearchParameterProcessing = true;
            break;
          }
        }



        _DtoSupportedSearchParametersList.Clear();



        if (oSupportedSearchParameter != null)
        {
          ISearchParameterBase oSearchParameter = null;
          if (i >= ChaimedParameterSplit.Length - 1)
          {
            oSearchParameter = ISearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, SingleChainedParameter, false);
          }
          else
          {
            oSearchParameter = ISearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, SingleChainedParameter, true);
          }
          var UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
          if (ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter, UnspportedSearchParameterList))
          {
            if (!IsSingularSearchParameter(oSearchParameter, _SearchParametersServiceOutcome))
            {
              ISearchParameterBase Temp = oSearchParameter.CloneDeep() as ISearchParameterBase;

              if (ParentChainSearchParameter == null)
              {
                ParentChainSearchParameter = Temp;
              }
              else
              {
                if (ParentChainSearchParameter.ChainedSearchParameter == null)
                {
                  ParentChainSearchParameter.ChainedSearchParameter = Temp;
                }
                PreviousChainSearchParameter.ChainedSearchParameter = Temp;
              }

              PreviousChainSearchParameter = Temp;
              if (i != ChaimedParameterSplit.Count() - 1)
                PreviousChainSearchParameter.Modifier = SearchParameter.SearchModifierCode.Type;
            }
          }
          else
          {
            var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
            DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
            string ResourceName = string.Empty;
            if (_ResourceType.HasValue)
              ResourceName = _ResourceType.Value.ToString();
            DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'. ";
            DtoUnspportedSearchParameter.ReasonMessage += $"Additional information: ";
            foreach (var UnspportedSearchParameter in UnspportedSearchParameterList)
            {
              DtoUnspportedSearchParameter.ReasonMessage += UnspportedSearchParameter.ReasonMessage;
            }
            _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
            ErrorInSearchParameterProcessing = true;
            break;
          }
        }
        else
        {
          var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
          DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
          string ResourceName = string.Empty;
          if (_ResourceType.HasValue)
            ResourceName = _ResourceType.Value.ToString();
          DtoUnspportedSearchParameter.ReasonMessage = $"The search parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'. ";
          DtoUnspportedSearchParameter.ReasonMessage += $"Additional information: ";
          DtoUnspportedSearchParameter.ReasonMessage += $"This search parameter was a chained search parameter. The part that was not recognised was '{ParameterNameNoModifier}'";
          _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
          ErrorInSearchParameterProcessing = true;
          break;
        }
      }


      if (!ErrorInSearchParameterProcessing)
        _SearchParametersServiceOutcome.SearchParameters.SearchParametersList.Add(ParentChainSearchParameter);
    }


    private void NormalSearchProcessing(Tuple<string, string> Parameter)
    {
      _DtoSupportedSearchParametersList = GetSupportedSearchParameters(_SearchParameterServiceType, _OperationClass, _ResourceType);

      DtoServiceSearchParameterLight oSupportedSearchParameter;
      //Remove modifiers
      var SearchParameterNameString = Parameter.Item1.Split(SearchParams.SEARCH_MODIFIERSEPARATOR)[0].Trim();
      oSupportedSearchParameter = _DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchParameterNameString);

      if (oSupportedSearchParameter != null)
      {
        ISearchParameterBase oSearchParameter = ISearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter, Parameter);

        if (oSearchParameter is SearchParameterReferance SearchParameterReferance)
        {
          foreach (var x in SearchParameterReferance.ValueList)
          {
            if (x.FhirRequestUri != null && string.IsNullOrWhiteSpace(x.FhirRequestUri.ResourseName))
            {
              //After parsing the search parameter of type reference thewre is no Resource Type for the reference
              //e.g no Patient is the example 'Patient/123456'
              string RefResources = string.Empty;
              SearchParameterReferance.TargetResourceTypeList.ForEach(v => RefResources += ", " + v.ResourceType.GetLiteral());
              string ResourceName = string.Empty;
              if (_ResourceType.HasValue)
                ResourceName = _ResourceType.Value.ToString();
              string Message = string.Empty;
              Message = $"The search parameter '{Parameter.Item1}' is ambiguous. ";
              Message += $"Additional information: ";
              Message += $"The search parameter '{SearchParameterReferance.Name}' can referance the following resource types ({RefResources.TrimStart(',').Trim()}). ";
              Message += $"To correct this you must prefix the search parameter with a Type modifier, for example: '{SearchParameterReferance.Name}={SearchParameterReferance.TargetResourceTypeList[0].ResourceType.GetLiteral()}/{x.FhirRequestUri.ResourceId}' ";
              Message += $"or: '{SearchParameterReferance.Name}:{SearchParameterReferance.TargetResourceTypeList[0].ResourceType.GetLiteral()}={x.FhirRequestUri.ResourceId}' ";
              Message += $"If the '{SearchParameterReferance.TargetResourceTypeList[0].ResourceType.GetLiteral()}' resource was the intended referance for the search parameter '{SearchParameterReferance.Name}'.";
              if (_SearchParametersServiceOutcome.FhirOperationOutcome == null)
              {
                _SearchParametersServiceOutcome.FhirOperationOutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message);
              }
              else
              {
                Common.Tools.FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message, _SearchParametersServiceOutcome.FhirOperationOutcome);
              }
              _SearchParametersServiceOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }
          }
        }

        var UnspportedSearchParameterList = new List<UnspportedSearchParameter>();
        if (ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter, UnspportedSearchParameterList))
        {
          if (!IsSingularSearchParameter(oSearchParameter, _SearchParametersServiceOutcome))
          {
            _SearchParametersServiceOutcome.SearchParameters.SearchParametersList.Add(oSearchParameter);
          }
        }
        else
        {
          var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
          DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
          string ResourceName = string.Empty;
          if (_ResourceType.HasValue)
            ResourceName = _ResourceType.Value.ToString();
          DtoUnspportedSearchParameter.ReasonMessage = $"The search parameter '{Parameter.Item1}' for the resource type '{ResourceName}', was unable to be processed as expected, the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'.";
          DtoUnspportedSearchParameter.ReasonMessage += $"Additional information: ";
          foreach (var UnspportedSearchParameter in UnspportedSearchParameterList)
          {
            DtoUnspportedSearchParameter.ReasonMessage += UnspportedSearchParameter.ReasonMessage;
          }
          _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
        }

      }
      else
      {
        var DtoUnspportedSearchParameter = new UnspportedSearchParameter();
        DtoUnspportedSearchParameter.RawParameter = $"{Parameter.Item1}={Parameter.Item2}";
        string ResourceName = string.Empty;
        if (_ResourceType.HasValue)
          ResourceName = _ResourceType.Value.ToString();
        DtoUnspportedSearchParameter.ReasonMessage = $"The parameter '{Parameter.Item1}' is not supported by this server for the resource type '{ResourceName}', the whole parameter was : '{DtoUnspportedSearchParameter.RawParameter}'";
        _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
      }
    }

    private void ProcessIncludeSearchParameters(IList<Tuple<string, string>> IncludeList)
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
            _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
            {
              RawParameter = $"{Key}",
              ReasonMessage = $"{Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_INCLUDE} or {Hl7.Fhir.Rest.SearchParams.SEARCH_PARAM_REVINCLUDE} parameter is not recognised."
            });
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
            _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
            {
              RawParameter = $"{Key}={Value}",
              ReasonMessage = "The source Resource of the _includes parameter is not recognised."
            });
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
                _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                {
                  RawParameter = $"{Key}={Value}",
                  ReasonMessage = "The target Resource of the _includes parameter is not recognised."
                });
              }
            }
          }

          if (valueSplitArray.Count() > 1)
          {
            string SearchTerm = valueSplitArray[1].Trim();
            List<DtoServiceSearchParameterLight> DtoSupportedSearchParametersList = GetSupportedSearchParameters(SearchParameterServiceType.Resource, null, SearchParameterInclude.SourceResourceType.GetLiteral());
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
              DtoServiceSearchParameterLight DtoServiceSearchParameterLight = DtoSupportedSearchParametersList.SingleOrDefault(x => x.Name == SearchTerm);
              if (DtoServiceSearchParameterLight != null)
              {
                if (DtoServiceSearchParameterLight.Type == SearchParamType.Reference)
                {
                  if (DtoServiceSearchParameterLight.TargetResourceTypeList != null && SearchParameterInclude.SearchParameterTargetResourceType.HasValue)
                  {
                    if (DtoServiceSearchParameterLight.TargetResourceTypeList.SingleOrDefault(x => x.ResourceType.GetLiteral() == SearchParameterInclude.SearchParameterTargetResourceType.Value.GetLiteral()) == null)
                    {
                      ParseOk = false;
                      _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                      {
                        RawParameter = $"{Key}={Value}",
                        ReasonMessage = $"The target Resource '{SearchParameterInclude.SearchParameterTargetResourceType.Value.GetLiteral()}' of the _includes parameter is not recognised for the source '{SearchParameterInclude.SourceResourceType.GetLiteral()}' Resource's search parameter {DtoServiceSearchParameterLight.Name}."
                      });
                    }
                  }
                  SearchParameterInclude.SearchParameterList = new List<DtoServiceSearchParameterLight>();
                  SearchParameterInclude.SearchParameterList.Add(DtoServiceSearchParameterLight);
                }
                else
                {
                  ParseOk = false;
                  _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                  {
                    RawParameter = $"{Key}={Value}",
                    ReasonMessage = $"The source Resource '{SearchParameterInclude.SourceResourceType.GetLiteral()}' search parameter '{DtoServiceSearchParameterLight.Name}' of the _includes parameter is not of search parameter of type Reference, found search parameter type of '{DtoServiceSearchParameterLight.Type.ToString()}'."
                  });
                }
              }
              else
              {
                ParseOk = false;
                _SearchParametersServiceOutcome.SearchParameters.UnspportedSearchParameterList.Add(new UnspportedSearchParameter()
                {
                  RawParameter = $"{Key}={Value}",
                  ReasonMessage = $"The source Resource '{SearchParameterInclude.SourceResourceType.GetLiteral()}' search parameter '{SearchTerm}' is not a valid search parameter for the source Resource type."
                });
              }
            }
          }

          //All ok so add as valid include
          if (ParseOk)
          {
            if (_SearchParametersServiceOutcome.SearchParameters.IncludeList == null)
              _SearchParametersServiceOutcome.SearchParameters.IncludeList = new List<SearchParameterInclude>();
            _SearchParametersServiceOutcome.SearchParameters.IncludeList.Add(SearchParameterInclude);
          }

        }
      }
    }
    private List<DtoServiceSearchParameterLight> GetSupportedSearchParameters(SearchParameterServiceType SearchParameterServiceType, OperationClass OperationClass, string ResourceType)
    {
      List<DtoServiceSearchParameterLight> DtoSupportedServiceSearchParameterList = new List<DtoServiceSearchParameterLight>();
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
    private List<DtoServiceSearchParameterLight> GetSupportedSearchParameters(SearchParameterServiceType SearchParameterServiceType, OperationClass OperationClass, FHIRAllTypes? ResourceType)
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
    private bool ValidateSearchParameterSupported(DtoServiceSearchParameterLight oSupported, ISearchParameterBase oInboundSearchParameter, IList<UnspportedSearchParameter> UnspportedSearchParameterList)
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
        //I feel we already do this when parseing the Referance Paramerter
        //if (oInboundSearchParameter.Modifier == SearchParameter.SearchModifierCode.Type)
        //{

        //  if (!ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oInboundSearchParameter).Contains(oInboundSearchParameter.TypeModifierResource))
        //  {
        //    DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
        //    DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + $"The search parameter modifier was expected to be a Fhir resource type that is supported for this search parameter. The Resource given was: {oInboundSearchParameter.TypeModifierResource} which is not supported for the search parameter '{oInboundSearchParameter.Name}.', ";
        //  }
        //}
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

      //I feel we already do this when parseing the Referance Paramerter
      //if (oInboundSearchParameter.TypeModifierResource != null)
      //{
      //  if (!ServiceSearchParameterFactory.GetSearchParameterTargetResourceList(oInboundSearchParameter).Contains(oInboundSearchParameter.TypeModifierResource))
      //  {
      //    DtoUnspportedSearchParameter = InitaliseUnspportedParamerter(oInboundSearchParameter, DtoUnspportedSearchParameter);
      //    DtoUnspportedSearchParameter.ReasonMessage = DtoUnspportedSearchParameter.ReasonMessage + String.Format("Unsupported search, the Resource type given as the Modifier is not supported. Resource type: '{0}' in parameter '{1}'., ", oInboundSearchParameter.TypeModifierResource.ToString(), oInboundSearchParameter.RawValue);
      //  }
      //}

      if (DtoUnspportedSearchParameter != null)
      {
        UnspportedSearchParameterList.Add(DtoUnspportedSearchParameter);
        return false;
      }
      else
      {
        UnspportedSearchParameterList.Clear();
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
    private bool CheckModifierTypeResourceValidForSearchParameter(string ModifierTypeResource, List<IServiceSearchParameterTargetResource> TargetResourceTypeList)
    {
      if (TargetResourceTypeList == null)
        return false;

      return TargetResourceTypeList.Any(x => x.ResourceType.GetLiteral() == ModifierTypeResource);
    }
  }
}
