using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Search.SearchTermTypes;
using Dip.Interfaces;

namespace Blaze.Engine.Search
{
  class SearchUriValidator
  {
    private static SearchTermValidationOperationOutcome _SearchTermValidationOperationOutcome;
    private static ResourceType _ResourceType;

    public static SearchTermValidationOperationOutcome Validate(ResourceType ResourceType, SearchParams SearchParameter)
    {
      _ResourceType = ResourceType;
      _SearchTermValidationOperationOutcome = new SearchTermValidationOperationOutcome();
      _SearchTermValidationOperationOutcome.SearchTerms = ParseToSupportedSearchTerms(SearchParameter);      
      return _SearchTermValidationOperationOutcome;      
    }

    private static SearchTerms ParseToSupportedSearchTerms(SearchParams SearchParameter)
    {      
      var oInboundSearchTermList = new List<SearchTermBase>();
      var oSupportedSearchTermList = Search.SupportedSearchTerm.GetSupportedTermList(_ResourceType);
      var oSearchTermNameDictionary = Support.EnumSupport.GetSearchTermNameDictionary();

      foreach (var Parameter in SearchParameter.Parameters)
      {
        //We will just ignore an empty parameter such as this last '&' URL?family=Smith&given=John&
        if (Parameter.Item1 + Parameter.Item2 != string.Empty)
        {
          var SearchTermName = Support.EnumSupport.SearchTermName.None;
          var SearchParameterName = Parameter.Item1.Split(':')[0];
          if (oSearchTermNameDictionary.ContainsKey(SearchParameterName))
          {
            SearchTermName = oSearchTermNameDictionary[SearchParameterName];

            var oSupportedSearchTerm = oSupportedSearchTermList.SingleOrDefault(x => x.Name == SearchTermName);
            if (oSupportedSearchTerm != null)
            {
              var oSearchTerm = SearchTermBase.CreateSearchTerm(oSupportedSearchTerm.Resource, SearchTermName, Parameter, oSupportedSearchTerm.SearchParameterType);
              ValidateSearchTermSupported(oSupportedSearchTerm, oSearchTerm);              
              oInboundSearchTermList.Add(oSearchTerm);
            }
            else
            {
              if (_SearchTermValidationOperationOutcome.FhirOperationOutcome == null)
                _SearchTermValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}={1}' content is invalid", Parameter.Item1, Parameter.Item2));
              OpOutComeIssueComp.Details.Text = String.Format("Unsupported search parameter for the resource '{0}' found in URL, parameter was: {1}={2}", _ResourceType.ToString(), Parameter.Item1, Parameter.Item2);
              _SearchTermValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
              _SearchTermValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;              
            }
          }
          else
          {
            if (_SearchTermValidationOperationOutcome.FhirOperationOutcome == null)
              _SearchTermValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}={1}' content is invalid", Parameter.Item1, Parameter.Item2));
            OpOutComeIssueComp.Details.Text = String.Format("Unsupported search parameter found in URL, term was: {0}={1}", Parameter.Item1, Parameter.Item2);
            _SearchTermValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
            _SearchTermValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;             
          }
        }
      }
      return new SearchTerms() { ResourceTarget = _ResourceType, SearchTermList = oInboundSearchTermList };
    }

    private static void ValidateSearchTermSupported(SupportedSearchTerm oSupported, SearchTermBase oInboundSearch)
    {
      if (oInboundSearch.Modifier != SearchModifierType.None)
      {
        if (!oSupported.ModifierList.Contains(oInboundSearch.Modifier))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_MODIFIER_INVALID", String.Format("Parameter '{0}' modifier is invalid", oInboundSearch.RawValue));      
          OpOutComeIssueComp.Details.Text = String.Format("Unsupported search Modifier found in URL, Modifier was: '{0}' in parameter '{1}'.", oInboundSearch.Modifier.ToString(), oInboundSearch.RawValue);
          if (_SearchTermValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchTermValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchTermValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchTermValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;          
        }
      }

      if (oInboundSearch.Prefix != SearchPrefixType.None)
      {
        if (!oSupported.PrefixList.Contains(oInboundSearch.Prefix))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}' content is invalid", oInboundSearch.RawValue));
          OpOutComeIssueComp.Details.Text = String.Format(String.Format("Unsupported search Prefix found in URL, Prefix was: '{0}' in parameter '{1}'.", oInboundSearch.Prefix.ToString(), oInboundSearch.RawValue));
          if (_SearchTermValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchTermValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchTermValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchTermValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;      
        }
      }

      if (oInboundSearch.TypeModifierResource != null)
      {
        if (oSupported.TypeModifierResourceList.Contains((Hl7.Fhir.Model.ResourceType)oInboundSearch.TypeModifierResource))
        {          
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;          
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}' content is invalid", oInboundSearch.RawValue));
          OpOutComeIssueComp.Details.Text = String.Format("Unsupported search, the 'Resource' type found in the 'Type[]' Modifier is not supported. 'Resource' type was: '{0}' in parameter '{1}'.", oInboundSearch.TypeModifierResource.ToString(), oInboundSearch.RawValue);
          if (_SearchTermValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchTermValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchTermValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchTermValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;      
        }
      }

      if (oInboundSearch.Name == Support.EnumSupport.SearchTermName.Active)
      {
        var oActive = oInboundSearch as Search.SearchTermTypes.SearchTermToken;
        bool OutBool;
        if (!Boolean.TryParse(oActive.Values[0].Code, out OutBool))
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
          OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}' content is invalid", oInboundSearch.RawValue));
          OpOutComeIssueComp.Details.Text = String.Format("The parameter 'active' must be a boolean value either [true | false]. Value found was: '{0}'.", oActive.Values[0].Code);
          if (_SearchTermValidationOperationOutcome.FhirOperationOutcome == null)
            _SearchTermValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
          _SearchTermValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
          _SearchTermValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;      
        }
      }
    }
  }
}
