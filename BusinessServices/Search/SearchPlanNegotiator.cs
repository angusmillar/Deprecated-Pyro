using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Blaze.Engine.Interfaces;
using Dip.Interfaces;

namespace Blaze.Engine.Search
{
  public static class SearchPlanNegotiator
  {
    public static ISearchPlan GetSearchPlan(ResourceType ResourceType, IUnitOfWork UnitOfWork)
    {
      switch (ResourceType)
      {
        case ResourceType.Patient:
          {
            return new Search.PatientSearchPlan() { UnitOfWork = UnitOfWork };            
          }
        default:
          {
            var oIssueComponent = new OperationOutcome.IssueComponent();
            oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
            oIssueComponent.Code = OperationOutcome.IssueType.Exception;
            oIssueComponent.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "SEARCH_NONE", String.Format("Error: no processable search found for '{0}' search parameters '{1}", ResourceType.ToString(), "No search parameters are implemented"));
            oIssueComponent.Details.Text = String.Format("System Error: no SearchPlan has been implemented for ResourceType: " + ResourceType.ToString());
            oIssueComponent.Diagnostics = oIssueComponent.Details.Text;
            var oOperationOutcome = new OperationOutcome();
            oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
            throw new Blaze.Engine.CustomException.BlazeException(System.Net.HttpStatusCode.BadRequest, oOperationOutcome, oIssueComponent.Details.Text);                 
          }
      }      
    }
  }
}
