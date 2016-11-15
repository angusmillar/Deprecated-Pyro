using System;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Services;
using System.Net.Http;
using System.Net;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;

namespace Pyro.Web.Response
{
  public static class FhirRestResponse
  {
    public static HttpResponseMessage GetHttpResponseMessage(IServiceOperationOutcome oPyroServiceOperationOutcome, HttpRequestMessage Request)
    {
      //Todo: to support CORS it appears I need to return this 'Access-Control-Allow-Origin' in the HTTP header


      HttpStatusCode HttpStatusCode = oPyroServiceOperationOutcome.HttpStatusCode;
      Resource Resource = oPyroServiceOperationOutcome.ResourceResult;

      //OK: 200
      if (HttpStatusCode == HttpStatusCode.OK)
      {
        if (Resource != null && oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Read)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);
          if (oPyroServiceOperationOutcome.LastModified != null)
          {
            Response.Content.Headers.LastModified = oPyroServiceOperationOutcome.LastModified;
            Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oPyroServiceOperationOutcome.ResourceVersionNumber + "\"");
          }
          return Response;
        }
        else if (oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Update)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);
          string BaseURLPath = String.Format("{0}://{1}{2}", Request.RequestUri.Scheme, Request.RequestUri.Authority, Request.RequestUri.LocalPath);
          BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));
          Response.Headers.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, oPyroServiceOperationOutcome.FhirResourceId));
          return Response;

        }
        else if (oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Delete && oPyroServiceOperationOutcome.ResourceVersionNumber != null)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, oPyroServiceOperationOutcome.FhirResourceId);
          if (oPyroServiceOperationOutcome.LastModified != null)
          {
            Response.Content.Headers.LastModified = oPyroServiceOperationOutcome.LastModified;
            Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oPyroServiceOperationOutcome.ResourceVersionNumber + "\"");
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
          throw new DtoPyroException(HttpStatusCode.InternalServerError, oOperationOutcome, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
        }
      }
      //Created: 201 
      else if (HttpStatusCode == HttpStatusCode.Created)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);

        string BaseURLPath = String.Format("{0}://{1}{2}", Request.RequestUri.Scheme, Request.RequestUri.Authority, Request.RequestUri.LocalPath);
        BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));

        Response.Headers.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, oPyroServiceOperationOutcome.FhirResourceId));
        return Response;
      }
      //Gone: 410 - Search for a resource that no longer there, it is deleted or has never existed. 
      else if (HttpStatusCode == HttpStatusCode.Gone)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        if (oPyroServiceOperationOutcome.ResourceResult == null)
          Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oPyroServiceOperationOutcome.ResourceVersionNumber + "\"");
        return Response;
      }
      //No Content: 204
      else if (HttpStatusCode == HttpStatusCode.NoContent)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        if (oPyroServiceOperationOutcome.ResourceVersionNumber != null)
        {
          Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oPyroServiceOperationOutcome.ResourceVersionNumber + "\"");
        }
        return Response;
      }
      else if (HttpStatusCode == System.Net.HttpStatusCode.NotFound)
      {
        return Request.CreateResponse(HttpStatusCode);
      }
      //Forbidden: 403..and others
      else
      {
        if (Resource != null)
        {
          if (Resource is OperationOutcome)
            FhirOperationOutcomeSupport.EscapeOperationOutComeContent(Resource as OperationOutcome);
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
          FhirOperationOutcomeSupport.EscapeOperationOutComeContent(OpOutCome);
          return Request.CreateResponse(HttpStatusCode, OpOutCome);
        }
      }

    }

    public static HttpResponseMessage GetHttpResponseMessage2(IServiceOperationOutcome oPyroServiceOperationOutcome, HttpRequestMessage Request)
    {
      //Todo: to support CORS it appears I need to return this 'Access-Control-Allow-Origin' in the HTTP header


      HttpStatusCode HttpStatusCode = oPyroServiceOperationOutcome.HttpStatusCode;
      Resource Resource = oPyroServiceOperationOutcome.ResourceResult;

      //OK: 200
      if (HttpStatusCode == HttpStatusCode.OK)
      {
        if (Resource != null && oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Read)
        {

          //This below works fine for switching or overriding the Content-Type for return:
          //var Response = Request.CreateResponse(HttpStatusCode);
          //Response.Content = new ObjectContent(typeof(Resource), Resource, new Formatters.FhirJsonMediaTypeFormatter());


          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);

          //LastModified Header & ETagVersion &Location Header          
          if (oPyroServiceOperationOutcome.LastModified.HasValue)
          {
            HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
            HttpHeaderSupport.AddLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
            HttpHeaderSupport.AddLocation(Response, Request, oPyroServiceOperationOutcome.FhirResourceId);
          }
          return Response;
        }
        else if (oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Update)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);
          //Location Header
          HttpHeaderSupport.AddLocation(Response, Request, oPyroServiceOperationOutcome.FhirResourceId);
          //LastModified Header && ETagVersion
          if (oPyroServiceOperationOutcome.LastModified.HasValue)
          {
            HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
            HttpHeaderSupport.AddLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
          }
          return Response;
        }
        else if (oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Delete && oPyroServiceOperationOutcome.ResourceVersionNumber != null)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, oPyroServiceOperationOutcome.FhirResourceId);
          //LastModified Header && ETag Version
          if (oPyroServiceOperationOutcome.LastModified != null)
          {
            Response.Content.Headers.LastModified = oPyroServiceOperationOutcome.LastModified;
            Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + oPyroServiceOperationOutcome.ResourceVersionNumber + "\"");
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
          throw new DtoPyroException(HttpStatusCode.InternalServerError, oOperationOutcome, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
        }
      }
      //Created: 201 
      else if (HttpStatusCode == HttpStatusCode.Created)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);

        //Location Header
        HttpHeaderSupport.AddLocation(Response, Request, oPyroServiceOperationOutcome.FhirResourceId);
        //LastModified Header && ETagVersion
        if (oPyroServiceOperationOutcome.LastModified.HasValue)
        {
          HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
          HttpHeaderSupport.AddLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
        }

        return Response;
      }
      //Gone: 410 - Search for a resource that no longer there, it is deleted or has never existed. 
      else if (HttpStatusCode == HttpStatusCode.Gone)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        //LastModified Header && ETagVersion
        if (oPyroServiceOperationOutcome.LastModified.HasValue)
        {
          HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
          //Support.HttpHeaderSupport.AddLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
        }
        return Response;
      }
      //No Content: 204
      else if (HttpStatusCode == HttpStatusCode.NoContent)
      {
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        //LastModified Header && ETagVersion
        if (oPyroServiceOperationOutcome.LastModified.HasValue)
        {
          HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
          HttpHeaderSupport.AddLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
        }
        return Response;
      }
      else if (HttpStatusCode == System.Net.HttpStatusCode.NotFound)
      {
        return Request.CreateResponse(HttpStatusCode);
      }
      //Forbidden: 403..and others
      else
      {
        if (Resource != null)
        {
          if (Resource is OperationOutcome)
            FhirOperationOutcomeSupport.EscapeOperationOutComeContent(Resource as OperationOutcome);
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
          FhirOperationOutcomeSupport.EscapeOperationOutComeContent(OpOutCome);
          return Request.CreateResponse(HttpStatusCode, OpOutCome);
        }
      }

    }
  }
}
