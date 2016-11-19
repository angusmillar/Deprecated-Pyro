using System;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Service;
using System.Net.Http;
using System.Net;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Hl7.Fhir.Model;
using Pyro.Web.Formatters;

namespace Pyro.Web.Response
{
  public static class FhirRestResponse
  {    
    public static HttpResponseMessage GetHttpResponseMessage(IResourceServiceOutcome oPyroServiceOperationOutcome, HttpRequestMessage Request)
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
          if (oPyroServiceOperationOutcome.FormatMimeType != null)
          {            
            Formatters.FhirMediaTypeFormatter Formater = GetFhirMediaFormatter(Request, oPyroServiceOperationOutcome.FormatMimeType);
            if (Formater != null)
            {
              Response = new HttpResponseMessage(HttpStatusCode);
              Response.Content = new ObjectContent(typeof(Resource), Resource, Formater);
            }            
          }          
                    
          //LastModified Header & ETagVersion &Location Header          
          if (oPyroServiceOperationOutcome.LastModified.HasValue)
          {
            HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
            HttpHeaderSupport.AddResponseLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
            HttpHeaderSupport.AddResponseLocation(Response, Request, oPyroServiceOperationOutcome.FhirResourceId);
          }
          return Response;
        }
        else if (oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Update)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);
          if (oPyroServiceOperationOutcome.FormatMimeType != null)
          {
            Formatters.FhirMediaTypeFormatter Formater = GetFhirMediaFormatter(Request, oPyroServiceOperationOutcome.FormatMimeType);
            if (Formater != null)
            {
              Response = new HttpResponseMessage(HttpStatusCode);
              Response.Content = new ObjectContent(typeof(Resource), Resource, Formater);
            }
          }
          //Location Header
          HttpHeaderSupport.AddResponseLocation(Response, Request, oPyroServiceOperationOutcome.FhirResourceId);
          //LastModified Header && ETagVersion
          if (oPyroServiceOperationOutcome.LastModified.HasValue)
          {
            HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
            HttpHeaderSupport.AddResponseLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
          }
          return Response;
        }
        else if (oPyroServiceOperationOutcome.OperationType == RestEnum.CrudOperationType.Delete && oPyroServiceOperationOutcome.ResourceVersionNumber != null)
        {
          HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, Resource);
          if (oPyroServiceOperationOutcome.FormatMimeType != null)
          {
            Formatters.FhirMediaTypeFormatter Formater = GetFhirMediaFormatter(Request, oPyroServiceOperationOutcome.FormatMimeType);
            if (Formater != null)
            {
              Response = new HttpResponseMessage(HttpStatusCode);
              Response.Content = new ObjectContent(typeof(string), oPyroServiceOperationOutcome.FhirResourceId, Formater);
            }
          }

          //HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode, oPyroServiceOperationOutcome.FhirResourceId);
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
        if (oPyroServiceOperationOutcome.FormatMimeType != null)
        {
          Formatters.FhirMediaTypeFormatter Formater = GetFhirMediaFormatter(Request, oPyroServiceOperationOutcome.FormatMimeType);
          if (Formater != null)
          {
            Response = new HttpResponseMessage(HttpStatusCode);
            Response.Content = new ObjectContent(typeof(Resource), Resource, Formater);
          }
        }

        //Location Header
        HttpHeaderSupport.AddResponseLocation(Response, Request, oPyroServiceOperationOutcome.FhirResourceId);
        //LastModified Header && ETagVersion
        if (oPyroServiceOperationOutcome.LastModified.HasValue)
        {
          HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
          HttpHeaderSupport.AddResponseLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
        }

        return Response;
      }
      //Gone: 410 - Search for a resource that no longer there, it is deleted or has never existed. 
      else if (HttpStatusCode == HttpStatusCode.Gone)
      {
        //No need to process _format as not returning a body of type resource   
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
        //No need to process _format as not returning a body of type resource
        HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
        //LastModified Header && ETagVersion
        if (oPyroServiceOperationOutcome.LastModified.HasValue)
        {
          HttpHeaderSupport.AddVersionETag(Response, oPyroServiceOperationOutcome.ResourceVersionNumber);
          HttpHeaderSupport.AddResponseLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
        }
        return Response;
      }
      else if (HttpStatusCode == System.Net.HttpStatusCode.NotFound)
      {
        //No need to process _format as not returning a body of type resource
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

    private static Formatters.FhirMediaTypeFormatter GetFhirMediaFormatter(HttpRequestMessage request, string format)
    {
      if (!Common.Tools.HttpHeaderSupport.IsAcceptMediaTypeSetInRequest(request))
      {
        if (!string.IsNullOrWhiteSpace(format))
        {
          string MediaType = Common.Tools.HttpHeaderSupport.GetFhirMediaTypeString(format);
          if (MediaType == Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER)
          {            
            return new Formatters.FhirXmlMediaTypeFormatter();
          }
          else if (MediaType == Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER)
          {
            return new Formatters.FhirJsonMediaTypeFormatter();
          }          
        }        
      }
      return null;
    }



  }
}
