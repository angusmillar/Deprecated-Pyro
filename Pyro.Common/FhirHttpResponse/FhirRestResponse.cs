//using System;
//using System.Collections.Generic;
//using Pyro.Common.Interfaces.Service;
//using System.Net.Http;
//using System.Net;
//using Pyro.Common.BusinessEntities.Dto;
//using Pyro.Common.Enum;
//using Pyro.Common.Tools;
//using Hl7.Fhir.Model;
//using Pyro.Web.Formatters;

//namespace Pyro.Common.FhirHttpResponse
//{
//  public static class FhirRestResponse
//  {
//    public static HttpResponseMessage GetHttpResponseMessage(IResourceServiceOutcome ResourceServiceOutcome, HttpRequestMessage Request, Hl7.Fhir.Rest.SummaryType? SummaryType)
//    {
//      //Todo: to support CORS it appears I need to return this 'Access-Control-Allow-Origin' in the HTTP header

//      HttpStatusCode HttpStatusCode = ResourceServiceOutcome.HttpStatusCode;
//      Resource Resource = ResourceServiceOutcome.ResourceResult;
//      //FhirMediaTypeFormatter FhirMediaTypeFormatter = null;

//      HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);
//      if (Resource != null)
//      {
//        if (ResourceServiceOutcome.FormatMimeType == null)
//        {
//          Response = Request.CreateResponse(HttpStatusCode, Resource);
//        }
//        else
//        {
//          Formatters.FhirMediaTypeFormatter Formater = GetFhirMediaFormatter(Request, ResourceServiceOutcome.FormatMimeType);
//          if (Formater != null)
//          {
//            FhirMediaTypeFormatter = Formater;
//            Response = new HttpResponseMessage(HttpStatusCode);
//            Response.Content = new ObjectContent(typeof(Resource), Resource, Formater);
//          }
//          else
//          {
//            Response = Request.CreateResponse(HttpStatusCode, Resource);
//          }
//        }

//        //Annotate the Resource wiht the _summary, will get the annotation in MediaTypeFormatter XML or JSON
//        if (Resource is Hl7.Fhir.Utility.IAnnotatable AnnotatableResource)
//        {
//          if (SummaryType.HasValue)
//            AnnotatableResource.AddAnnotation(SummaryType.Value);
//          else
//            AnnotatableResource.AddAnnotation(Hl7.Fhir.Rest.SummaryType.False);
//        }
//      }

//      //OK: 200
//      if (HttpStatusCode == HttpStatusCode.OK)
//      {
//        if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Read)
//        {
//          //LastModified Header & ETagVersion &Location Header                    
//          if (ResourceServiceOutcome.LastModified.HasValue)
//          {
//            Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//            if (Response.Content != null && ResourceServiceOutcome.IsDeleted.HasValue && !ResourceServiceOutcome.IsDeleted.Value)
//              Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
//            Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri);
//          }
//          return Response;
//        }
//        else if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Update)
//        {
//          //Location Header
//          if (Response.Content != null)
//            Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri);
//          //LastModified Header && ETagVersion
//          if (ResourceServiceOutcome.LastModified.HasValue)
//          {
//            Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//            Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
//          }
//          return Response;
//        }
//        else if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Delete && ResourceServiceOutcome.ResourceVersionNumber != null)
//        {
//          //LastModified Header && ETag Version
//          if (ResourceServiceOutcome.LastModified != null)
//          {
//            Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//            Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
//          }
//          return Response;
//        }
//        else if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Create)
//        {
//          //LastModified Header && ETag Version
//          if (ResourceServiceOutcome.LastModified != null)
//          {
//            Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//            //If we have a conditional Create where the Resource is found then we return OK but no Resource so no Content
//            if (Response.Content != null)
//              Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
//          }
//          return Response;
//        }
//        else
//        {

//          var oIssueComponent = new OperationOutcome.IssueComponent();
//          oIssueComponent.Severity = OperationOutcome.IssueSeverity.Fatal;
//          oIssueComponent.Code = OperationOutcome.IssueType.Exception;
//          oIssueComponent.Diagnostics = "Internal Error. FhirRestResponse contains no FHIR Resource or Id.";
//          var oOperationOutcome = new OperationOutcome();
//          oOperationOutcome.Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent };
//          throw new DtoPyroException(HttpStatusCode.InternalServerError, oOperationOutcome, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
//        }
//      }
//      //Created: 201 
//      else if (HttpStatusCode == HttpStatusCode.Created)
//      {
//        //Location Header
//        if (Response.Content != null)
//          Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri, ResourceServiceOutcome.FhirResourceId);

//        //LastModified Header && ETagVersion
//        if (ResourceServiceOutcome.LastModified.HasValue)
//        {
//          Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//          Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
//        }

//        return Response;
//      }
//      //Gone: 410 - Search for a resource that no longer there, it is deleted or has never existed. 
//      else if (HttpStatusCode == HttpStatusCode.Gone)
//      {
//        //LastModified Header && ETagVersion
//        if (ResourceServiceOutcome.LastModified.HasValue)
//        {
//          Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//          //Support.HttpHeaderSupport.AddLastModified(Response, oPyroServiceOperationOutcome.LastModified.Value);
//        }
//        return Response;
//      }
//      //No Content: 204
//      else if (HttpStatusCode == HttpStatusCode.NoContent)
//      {
//        //LastModified Header && ETagVersion
//        if (ResourceServiceOutcome.LastModified.HasValue)
//        {
//          Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
//          if (Response.Content != null)
//            Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
//        }
//        return Response;
//      }
//      else if (HttpStatusCode == System.Net.HttpStatusCode.NotFound)
//      {
//        //No need to process _format as not returning a body of type resource
//        return Response;
//      }
//      else if (HttpStatusCode == System.Net.HttpStatusCode.PreconditionFailed)
//      {
//        return Response;
//      }
//      else if (HttpStatusCode == System.Net.HttpStatusCode.NotModified)
//      {
//        return Response;
//      }
//      //Forbidden: 403..and others
//      else
//      {
//        if (Resource != null)
//        {
//          return Response;
//        }
//        else
//        {
//          var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
//          OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Fatal;
//          OpOutComeIssueComp.Code = OperationOutcome.IssueType.Exception;
//          OpOutComeIssueComp.Diagnostics = "Internal Server Error: An unexpected HttpStatusCode has been encountered with a null resource to return. This is most likely a server bug.";
//          var OpOutCome = new OperationOutcome();
//          OpOutCome.Issue.Add(OpOutComeIssueComp);
//          FhirOperationOutcomeSupport.EscapeOperationOutComeContent(OpOutCome);
//          if (FhirMediaTypeFormatter != null)
//            Response.Content = new ObjectContent(typeof(Resource), OpOutCome, FhirMediaTypeFormatter);
//          else
//            Response = Request.CreateResponse(HttpStatusCode, OpOutCome);
//          return Response;
//        }
//      }

//    }

//    private static Formatters.FhirMediaTypeFormatter GetFhirMediaFormatter(HttpRequestMessage request, string format)
//    {
//      if (!Common.Tools.HttpHeaderSupport.IsAcceptMediaTypeSetInRequest(request))
//      {
//        if (!string.IsNullOrWhiteSpace(format))
//        {
//          string MediaType = Common.Tools.HttpHeaderSupport.GetFhirMediaTypeString(format);
//          if (MediaType == Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER)
//          {
//            return new Formatters.FhirXmlMediaTypeFormatter();
//          }
//          else if (MediaType == Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER)
//          {
//            return new Formatters.FhirJsonMediaTypeFormatter();
//          }
//        }
//      }
//      return null;
//    }

//  }
//}
