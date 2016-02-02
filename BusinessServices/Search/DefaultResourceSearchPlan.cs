using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Engine.Search.SearchTermTypes;
using Dip.Interfaces;
using Hl7.Fhir.Model;
using BusinessEntities;

namespace Blaze.Engine.Search
{
  class DefaultResourceSearchPlan : SearchPlanBase, Interfaces.ISearchPlan
  {
    public IBlazeServiceOperationOutcome Search(SearchTerms oSearchTerms, IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome, DtoEnums.SupportedFhirResource CurrentResourceType)
    {
        //The search plan;
      if (oSearchTerms.SearchTermList.Count == 1)
      {
        if (oSearchTerms.SearchTermList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchTerms.SearchTermList.Any(x => x.HasLogicalOrProperties == true))
          {
            //_Id
            if (oSearchTerms.SearchTermList[0].Name == Support.EnumSupport.SearchTermName._Id)
            {
              Search.SearchTermTypes.SearchTermString _Id = oSearchTerms.SearchTermList[0] as Search.SearchTermTypes.SearchTermString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.ResourceRepository.GetCurrentResourceList(_Id.Values[0], CurrentResourceType);
              return oBlazeServiceOperationOutcome;
            }
          }
        }
      }

      //No Search Plan match was found so create OperationOutcome to inform sender
      var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
      OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
      OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
      string ParameterListForErrorMessage = string.Empty;
      foreach (var item in oSearchTerms.SearchTermList)
      {
        ParameterListForErrorMessage += item.RawValue + " & ";
      }
      ParameterListForErrorMessage = ParameterListForErrorMessage.Substring(0, ParameterListForErrorMessage.Length - 3);
      OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_UNKNOWN", String.Format("Parameter '{0}' not understood", ParameterListForErrorMessage));
      OpOutComeIssueComp.Details.Text = String.Format("This search parameter combination provided is not supported by the server. Parameters were: {0}", ParameterListForErrorMessage);

      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome = new SearchPlanValidationOperationOutcome();
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;

      return oBlazeServiceOperationOutcome;
    
    }
  }
}
