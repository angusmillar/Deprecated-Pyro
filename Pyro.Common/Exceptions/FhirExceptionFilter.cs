using System;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using Pyro.Common.DtoEntity;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.Logging;
using Pyro.Common.Tools.FhirNarrative;

namespace Pyro.Common.Exceptions
{
  public class FhirExceptionFilter : ExceptionFilterAttribute, IFhirExceptionFilter, IFilter
  {
    private readonly ILog ILog;
    private readonly IFhirResourceNarrative IFhirResourceNarrative;
    public FhirExceptionFilter(ILog ILog, IFhirResourceNarrative IFhirResourceNarrative)
    {
      this.ILog = ILog;
      this.IFhirResourceNarrative = IFhirResourceNarrative;
    }

    public override void OnException(HttpActionExecutedContext context)
    {
      HttpResponseMessage response = null;

      if (context.Exception is PyroException PyroException)
      {
        if (PyroException.OperationOutcome != null)
        {
          IFhirResourceNarrative.CreateNarrative(PyroException.OperationOutcome);
          response = context.Request.CreateResponse<Resource>(PyroException.HttpStatusCode, PyroException.OperationOutcome);
        }
        else
        {
          OperationOutcome OpOutCome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Unknown, PyroException.Message);
          IFhirResourceNarrative.CreateNarrative(OpOutCome);
          response = context.Request.CreateResponse(PyroException.HttpStatusCode, OpOutCome);
        }
      }
      else if (context.Exception is SqlException oSqlException)
      {
        PyroException PyroSqlException = SqlExceptionSupport.GenerateDtoPyroException(oSqlException, System.Diagnostics.Debugger.IsAttached);
        IFhirResourceNarrative.CreateNarrative(PyroSqlException.OperationOutcome);
        response = context.Request.CreateResponse<Resource>(PyroSqlException.HttpStatusCode, PyroSqlException.OperationOutcome);
      }
      else if (context.Exception is Exception)
      {
        OperationOutcome OpOutCome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Unknown, context.Exception.ToString());
        IFhirResourceNarrative.CreateNarrative(OpOutCome);
        response = context.Request.CreateResponse<Resource>(HttpStatusCode.InternalServerError, OpOutCome);
      }

      throw new HttpResponseException(response);
    }
  }
}
