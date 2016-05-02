using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces;
using System.Net.Http;
using System.Net;
using Blaze.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Blaze.Engine.Response
{
  public static class FhirRestResponse
  {    
    public static HttpResponseMessage GetHttpResponseMessage(IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome, HttpRequestMessage Request)
    {
      //Todo: to support CORS it appears I need to return this 'Access-Control-Allow-Origin' in the HTTP header


      HttpStatusCode HttpStatusCode = oBlazeServiceOperationOutcome.HttpStatusCodeToReturn;
      Resource Resource = oBlazeServiceOperationOutcome.ResourceToReturn; 
      
      //OK: 200
      if (HttpStatusCode == HttpStatusCode.OK)
      {
        if (Resource != null)
        {
          return Request.CreateResponse(HttpStatusCode, Resource);
        }
        else if (oBlazeServiceOperationOutcome.OperationType == DtoEnums.CrudOperationType.Update)
        {
          return Request.CreateResponse(HttpStatusCode);          
        }
        else if (oBlazeServiceOperationOutcome.OperationType == DtoEnums.CrudOperationType.Delete && oBlazeServiceOperationOutcome.ResourceVersionNumber != 0)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, oBlazeServiceOperationOutcome.FhirResourceId);
          if (oBlazeServiceOperationOutcome.LastModified != null)
          {
            Response.Content.Headers.LastModified = oBlazeServiceOperationOutcome.LastModified;
            Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oBlazeServiceOperationOutcome.ResourceVersionNumber.ToString() + "\"");
          }
          return Response;
        }
        else
        {
          var oIssueComponent = new OperationOutcome.IssueComponent();
          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
          oIssueComponent.Code = OperationOutcome.IssueType.Exception;
          oIssueComponent.Diagnostics = "Internal Error. FhirRestResponse contains no FHIR Resource or Id.";
          var oOperationOutcome = new OperationOutcome();
          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
          throw new DtoBlazeException(HttpStatusCode.InternalServerError, oOperationOutcome, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
        }
      }
      //Created: 201 
      else if (HttpStatusCode == HttpStatusCode.Created)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, oBlazeServiceOperationOutcome.FhirResourceId);

        string BaseURLPath = String.Format("{0}://{1}{2}", Request.RequestUri.Scheme, Request.RequestUri.Authority, Request.RequestUri.LocalPath);
        BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));

        Response.Headers.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, oBlazeServiceOperationOutcome.FhirResourceId));
        return Response;
      }
      //Gone: 410 - Search for a resource that no longer there, it is deleted or has never existed. 
      else if (HttpStatusCode == HttpStatusCode.Gone)
      {        
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        if (oBlazeServiceOperationOutcome.ResourceVersionNumber != 0)
        {
          Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oBlazeServiceOperationOutcome.ResourceVersionNumber.ToString() + "\"");          
        }
        return Response;
      }
      //No Content: 204
      else if (HttpStatusCode == HttpStatusCode.NoContent)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        if (oBlazeServiceOperationOutcome.ResourceVersionNumber != 0)
        {
          Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oBlazeServiceOperationOutcome.ResourceVersionNumber.ToString() + "\"");
        }
        return Response;
      }      
      //Forbidden: 403..and others
      else
      {
        if (Resource != null)
        {
          if (Resource is OperationOutcome)
            Support.FhirOperationOutComeSupport.EscapeOperationOutComeContent(Resource as OperationOutcome);
          return Request.CreateResponse(HttpStatusCode, Resource);
        }
        else
        {
          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
          OpOutComeIssueComp.Diagnostics = "Internal Server Error: An unexpected HttpStatusCode has been encountered with a null resource to return. This is most likely a server bug.";
          var OpOutCome = new OperationOutcome();
          OpOutCome.Issue.Add(OpOutComeIssueComp);
          Support.FhirOperationOutComeSupport.EscapeOperationOutComeContent(OpOutCome);
          return Request.CreateResponse(HttpStatusCode, OpOutCome);
        }
      }
      
    }
  }
}
