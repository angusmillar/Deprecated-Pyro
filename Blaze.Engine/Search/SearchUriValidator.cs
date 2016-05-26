using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Common.Interfaces;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.Engine.Search
{
  class SearchUriValidator
  {
    private static SearchParametersValidationOperationOutcome _SearchParametersValidationOperationOutcome;
    private static FHIRDefinedType _ResourceType;

    public static SearchParametersValidationOperationOutcome Validate(FHIRDefinedType ResourceType, SearchParams SearchParameter)
    {
      _ResourceType = ResourceType;
      _SearchParametersValidationOperationOutcome = new SearchParametersValidationOperationOutcome();
      _SearchParametersValidationOperationOutcome.SearchParameters = ParseToSupportedSearchParameters(SearchParameter);      
      return _SearchParametersValidationOperationOutcome;      
    }

    private static DtoSearchParameters ParseToSupportedSearchParameters(SearchParams FhirSearchParameter)
    {      
      var oInboundSearchParametersList = new List<DtoSearchParameterBase>();
      var oSupportedSearchParametersForResourceList = Search.SupportedSearchParameters.GetSupportedParametersForResourceTypeList(_ResourceType);
      var oSearchParameterNameDictionary = DtoEnums.Search.GetSearchParameterNameDictionary();
      
      foreach (var Parameter in FhirSearchParameter.Parameters)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          var SearchParameterNameType = DtoEnums.Search.SearchParameterName.None;
          var SearchParameterNameString = Parameter.Item1.Split(':')[0];
          if (oSearchParameterNameDictionary.ContainsKey(SearchParameterNameString))
          {
            SearchParameterNameType = oSearchParameterNameDictionary[SearchParameterNameString];

            var oSupportedSearchParameter = oSupportedSearchParametersForResourceList.SingleOrDefault(x => x.Name == SearchParameterNameType);
            if (oSupportedSearchParameter != null)
            {
              DtoSearchParameterBase oSearchParameter = SearchParameterFactory.CreateSearchParameter(oSupportedSearchParameter.Resource, SearchParameterNameType, Parameter, oSupportedSearchParameter.SearchParameterType);              
              ValidateSearchParameterSupported(oSupportedSearchParameter, oSearchParameter);              
              oInboundSearchParametersList.Add(oSearchParameter);
            }
            else
            {
              if (_SearchParametersValidationOperationOutcome.FhirOperationOutcome == null)
                _SearchParametersValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}={1}' content is invalid", Parameter.Item1, Parameter.Item2));
              OpOutComeIssueComp.Details.Text = String.Format("Unsupported search parameter for the resource '{0}' found in URL, parameter was: {1}={2}", _ResourceType.ToString(), Parameter.Item1, Parameter.Item2);
              _SearchParametersValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
              _SearchParametersValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;              
            }
          }
          else
          {
            if (_SearchParametersValidationOperationOutcome.FhirOperationOutcome == null)
              _SearchParametersValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}={1}' content is invalid", Parameter.Item1, Parameter.Item2));
            OpOutComeIssueComp.Details.Text = String.Format("Unsupported search parameter found in URL, term was: {0}={1}", Parameter.Item1, Parameter.Item2);
            _SearchParametersValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
            _SearchParametersValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;             
          }
        }
      }
      return new DtoSearchParameters() { ResourceTarget = _ResourceType, SearchParametersList = oInboundSearchParametersList };
    }

    private static void ValidateSearchParameterSupported(SupportedSearchParameters oSupported, DtoSearchParameterBase oInboundSearchParameter)
    {
      if (oInboundSearchParameter.Modifier != SearchModifierType.None)
      {
        if (!oSupported.ModifierList.Contains(oInboundSearchParameter.Modifier))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_MODIFIER_INVALID", String.Format("Parameter '{0}' modifier is invalid", oInboundSearchParameter.RawValue));      
          OpOutComeIssueComp.Details.Text = String.Format("Unsupported search Modifier found in URL, Modifier was: '{0}' in parameter '{1}'.", oInboundSearchParameter.Modifier.ToString(), oInboundSearchParameter.RawValue);
          if (_SearchParametersValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchParametersValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchParametersValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchParametersValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;          
        }
      }

      if (oInboundSearchParameter.Prefix != SearchPrefixType.None)
      {
        if (!oSupported.PrefixList.Contains(oInboundSearchParameter.Prefix))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}' content is invalid", oInboundSearchParameter.RawValue));
          OpOutComeIssueComp.Details.Text = String.Format(String.Format("Unsupported search Prefix found in URL, Prefix was: '{0}' in parameter '{1}'.", oInboundSearchParameter.Prefix.ToString(), oInboundSearchParameter.RawValue));
          if (_SearchParametersValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchParametersValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchParametersValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchParametersValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;      
        }
      }

      if (oInboundSearchParameter.TypeModifierResource != null)
      {
        if (oSupported.TypeModifierResourceList.Contains((Hl7.Fhir.Model.ResourceType)oInboundSearchParameter.TypeModifierResource))
        {          
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;          
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}' content is invalid", oInboundSearchParameter.RawValue));
          OpOutComeIssueComp.Details.Text = String.Format("Unsupported search, the 'Resource' type found in the 'Type[]' Modifier is not supported. 'Resource' type was: '{0}' in parameter '{1}'.", oInboundSearchParameter.TypeModifierResource.ToString(), oInboundSearchParameter.RawValue);
          if (_SearchParametersValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchParametersValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchParametersValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchParametersValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;      
        }
      }

      if (oInboundSearchParameter.Name == DtoEnums.Search.SearchParameterName.Active)
      {
        var oActive = oInboundSearchParameter as DtoSearchParameterToken;
        bool OutBool;
        if (!Boolean.TryParse(oActive.Values[0].Code, out OutBool))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}' content is invalid", oInboundSearchParameter.RawValue));
          OpOutComeIssueComp.Details.Text = String.Format("The parameter 'active' must be a boolean value either [true | false]. Value found was: '{0}'.", oActive.Values[0].Code);
          if (_SearchParametersValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchParametersValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchParametersValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchParametersValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;      
        }
      }
    }
  }
}
