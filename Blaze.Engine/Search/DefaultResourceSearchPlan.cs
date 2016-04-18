using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.BusinessEntities.Search;

namespace Blaze.Engine.Search
{
  class DefaultResourceSearchPlan : SearchPlanBase, Interfaces.ISearchPlan
  {
    public IBlazeServiceOperationOutcome Search(DtoSearchParameters oSearchParameters, IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome, DtoEnums.SupportedFhirResource CurrentResourceType)
    {
        //The search plan;
      if (oSearchParameters.SearchParametersList.Count == 1)
      {
        if (oSearchParameters.SearchParametersList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchParameters.SearchParametersList.Any(x => x.HasLogicalOrProperties == true))
          {
            //_Id
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName._Id)
            {
              DtoSearchParameterString _Id = oSearchParameters.SearchParametersList[0] as DtoSearchParameterString;
              //oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.ResourceRepository.GetCurrentResourceList(_Id.Values[0], CurrentResourceType);
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
      foreach (var item in oSearchParameters.SearchParametersList)
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
