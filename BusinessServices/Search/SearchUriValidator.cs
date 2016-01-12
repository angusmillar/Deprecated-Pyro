using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Search.SearchTermTypes;

namespace Blaze.Engine.Search
{
  class SearchUriValidator
  {
    public static SearchTerms Validate(ResourceType ResourceType, SearchParams SearchParameter)
    {
      var Result = new SearchTerms();
      Result.ResourceTarget = ResourceType;      
      ParseToSupportedSearchTerms(SearchParameter, Result);
      return Result;
    }

    private static void ParseToSupportedSearchTerms(SearchParams SearchParameter, SearchTerms Result)
    {
      var oInboundSearchTermList = new List<SearchTermBase>();
      var oSupportedSearchTermList = Search.SupportedSearchTerm.GetSupportedTermList(Result.ResourceTarget);
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
              ValidateSearchTermSupported(oSupportedSearchTerm, oSearchTerm, Result);
              oInboundSearchTermList.Add(oSearchTerm);
            }
            else
            {              
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
              OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
              OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
              OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}={1}' content is invalid", Parameter.Item1, Parameter.Item2));
              OpOutComeIssueComp.Details.Text = String.Format("Unsupported search parameter for the resource '{0}' found in URL, parameter was: {1}={2}", Result.ResourceTarget.ToString(), Parameter.Item1, Parameter.Item2);             
              Result.AddOperationOutcomeIssue(OpOutComeIssueComp, System.Net.HttpStatusCode.Forbidden);
            }
          }
          else
          {
            var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
            OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
            OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
            OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_INVALID", String.Format("Parameter '{0}={1}' content is invalid", Parameter.Item1, Parameter.Item2));
            OpOutComeIssueComp.Details.Text = String.Format("Unsupported search parameter found in URL, term was: {0}={1}", Parameter.Item1, Parameter.Item2);            
            Result.AddOperationOutcomeIssue(OpOutComeIssueComp, System.Net.HttpStatusCode.Forbidden);           
          }
        }
      }

      Result.SearchTermList = oInboundSearchTermList;
    }
    private static void ValidateSearchTermSupported(SupportedSearchTerm oSupported, SearchTermBase oInboundSearch, SearchTerms oSearchTerms)
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
          oSearchTerms.AddOperationOutcomeIssue(OpOutComeIssueComp, System.Net.HttpStatusCode.Forbidden);                     
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
          oSearchTerms.AddOperationOutcomeIssue(OpOutComeIssueComp, System.Net.HttpStatusCode.Forbidden);                     
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
          oSearchTerms.AddOperationOutcomeIssue(OpOutComeIssueComp, System.Net.HttpStatusCode.Forbidden);                     
        }
      }
    }
  }
}
