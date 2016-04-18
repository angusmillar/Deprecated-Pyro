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
using Blaze.Common.BusinessEntities;
using Hl7.Fhir.Model;

namespace Blaze.Engine.CustomException
{
  public class FhirExceptionFilter : ExceptionFilterAttribute
  {
    public override void OnException(HttpActionExecutedContext context)
    {
      HttpResponseMessage response = null; 
      
      if (context.Exception is DtoBlazeException)
      {
        var oDtoBlazeException = (DtoBlazeException)context.Exception;
        if (oDtoBlazeException.OperationOutcome != null)
        {
          Support.FhirOperationOutComeSupport.EscapeOperationOutComeContent(oDtoBlazeException.OperationOutcome);
          response = context.Request.CreateResponse<Resource>(oDtoBlazeException.HttpStatusCode, oDtoBlazeException.OperationOutcome);                
        }
        else
        {
          OperationOutcome OpOutCome = new OperationOutcome();
          OpOutCome.Issue = new List<OperationOutcome.IssueComponent>();
          var oIssue = new OperationOutcome.IssueComponent();
          oIssue.Diagnostics = oDtoBlazeException.Message;
          oIssue.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssue.Code = OperationOutcome.IssueType.Unknown;
          OpOutCome.Issue.Add(oIssue);
          Support.FhirOperationOutComeSupport.EscapeOperationOutComeContent(OpOutCome);
          response = context.Request.CreateResponse(oDtoBlazeException.HttpStatusCode, OpOutCome);
        }          
      }
      else if (context.Exception is SqlException)
      {
          DtoBlazeException oDtoBlazeException = SqlExceptionSupport.GenerateDtoBlazeException((SqlException)context.Exception, System.Diagnostics.Debugger.IsAttached);
          Support.FhirOperationOutComeSupport.EscapeOperationOutComeContent(oDtoBlazeException.OperationOutcome);
          response = context.Request.CreateResponse<Resource>(oDtoBlazeException.HttpStatusCode, oDtoBlazeException.OperationOutcome);         
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
        Support.FhirOperationOutComeSupport.EscapeOperationOutComeContent(OpOutCome);                
        response = context.Request.CreateResponse<Resource>(HttpStatusCode.InternalServerError, OpOutCome);        
      }
      
      throw new HttpResponseException(response);
    }
  }
}
