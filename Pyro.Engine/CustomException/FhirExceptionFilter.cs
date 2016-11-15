using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;

namespace Pyro.Engine.CustomException
{
  public class FhirExceptionFilter : ExceptionFilterAttribute
  {
    public override void OnException(HttpActionExecutedContext context)
    {
      HttpResponseMessage response = null; 
      
      if (context.Exception is DtoPyroException)
      {
        var oDtoPyroException = (DtoPyroException)context.Exception;
        if (oDtoPyroException.OperationOutcome != null)
        {                       
          FhirOperationOutcomeSupport.EscapeOperationOutComeContent(oDtoPyroException.OperationOutcome);
          response = context.Request.CreateResponse<Resource>(oDtoPyroException.HttpStatusCode, oDtoPyroException.OperationOutcome);                
        }
        else
        {
          OperationOutcome OpOutCome = new OperationOutcome();
          OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
          var oIssue = new OperationOutcome.IssueComponent();
          oIssue.Diagnostics = oDtoPyroException.Message;
          oIssue.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssue.Code = OperationOutcome.IssueType.Unknown;
          OpOutCome.Issue.Add(oIssue);
          FhirOperationOutcomeSupport.EscapeOperationOutComeContent(OpOutCome);
          response = context.Request.CreateResponse(oDtoPyroException.HttpStatusCode, OpOutCome);
        }          
      }
      else if (context.Exception is SqlException)
      {
          DtoPyroException oDtoPyroException = SqlExceptionSupport.GenerateDtoPyroException((SqlException)context.Exception, System.Diagnostics.Debugger.IsAttached);
          FhirOperationOutcomeSupport.EscapeOperationOutComeContent(oDtoPyroException.OperationOutcome);
          response = context.Request.CreateResponse<Resource>(oDtoPyroException.HttpStatusCode, oDtoPyroException.OperationOutcome);         
      }
      else if (context.Exception is Exception)
      {
        OperationOutcome OpOutCome = new OperationOutcome();
        OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
        var oIssue = new OperationOutcome.IssueComponent();
        oIssue.Diagnostics = context.Exception.ToString();
        oIssue.Severity = OperationOutcome.IssueSeverity.Fatal;
        oIssue.Code = OperationOutcome.IssueType.Unknown;
        OpOutCome.Issue.Add(oIssue);
        FhirOperationOutcomeSupport.EscapeOperationOutComeContent(OpOutCome);                
        response = context.Request.CreateResponse<Resource>(HttpStatusCode.InternalServerError, OpOutCome);        
      }
      
      throw new HttpResponseException(response);
    }
  }
}
