using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Search;
using Pyro.Common.Tools;
using System.Net;

namespace Pyro.Common.Service.SearchParameters
{
  public class SearchParametersServiceOutcome : ISearchParametersServiceOutcome
  {
    public HttpStatusCode HttpStatusCode { get; set; }
    public OperationOutcome FhirOperationOutcome { get; set; }
    public OperationOutcome FhirOperationOutcomeUnsupportedParameters
    {
      get
      {
        return GenerateUnsupportedParameterOperationOutcome();
      }
      set
      {
        this.FhirOperationOutcomeUnsupportedParameters = value;
      }
    }
    public PyroSearchParameters SearchParameters { get; set; }

    public SearchParametersServiceOutcome() { }
    private OperationOutcome GenerateUnsupportedParameterOperationOutcome()
    {
      if (this.SearchParameters == null || this.SearchParameters.UnspportedSearchParameterList == null || this.SearchParameters.UnspportedSearchParameterList.Count == 0)
      {
        string ExceptionMessage = "Server Internal Error: Attempt to generate unsupported search parameter OperationOutcome when there were no unsupported search parameters to process.";
        throw new Pyro.Common.Exceptions.PyroException(HttpStatusCode.Forbidden, FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ExceptionMessage), ExceptionMessage);
      }

      var OpOut = new OperationOutcome();
      foreach (UnspportedSearchParameter Parameter in SearchParameters.UnspportedSearchParameterList)
      {
        string Message = $"Unable to process a search parameter: {Parameter.ReasonMessage}";
        FhirOperationOutcomeSupport.Append(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Processing, Message, OpOut);
      }
      return OpOut;
    }
  }
}
