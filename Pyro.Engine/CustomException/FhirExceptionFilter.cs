using System;
using System.Collections.Generic;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Engine.CustomException
{
  public class FhirExceptionFilter : ExceptionFilterAttribute
  {
    public override void OnException(HttpActionExecutedContext context)
    {
      //Log.Error(context.Exception, "Error caught at top layer FhirExceptionFilter");

      HttpResponseMessage response = null;

      if (context.Exception is DtoPyroException oDtoPyroException)
      {

        if (oDtoPyroException.OperationOutcome != null)
        {
          response = context.Request.CreateResponse<Resource>(oDtoPyroException.HttpStatusCode, oDtoPyroException.OperationOutcome);
        }
        else
        {
          OperationOutcome OpOutCome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Unknown, oDtoPyroException.Message);
          response = context.Request.CreateResponse(oDtoPyroException.HttpStatusCode, OpOutCome);
        }
      }
      else if (context.Exception is SqlException oSqlException)
      {
        DtoPyroException PyroSqlException = SqlExceptionSupport.GenerateDtoPyroException(oSqlException, System.Diagnostics.Debugger.IsAttached);
        FhirOperationOutcomeSupport.EscapeOperationOutComeContent(PyroSqlException.OperationOutcome);
        response = context.Request.CreateResponse<Resource>(PyroSqlException.HttpStatusCode, PyroSqlException.OperationOutcome);
      }
      else if (context.Exception is Exception)
      {
        OperationOutcome OpOutCome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Unknown, context.Exception.ToString());
        response = context.Request.CreateResponse<Resource>(HttpStatusCode.InternalServerError, OpOutCome);
      }

      throw new HttpResponseException(response);
    }
  }
}
