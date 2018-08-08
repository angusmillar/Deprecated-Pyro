using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Pyro.Common.Enum;
using Pyro.Common.Tools;
using Pyro.Common.Exceptions;
using Hl7.Fhir.Model;
using Pyro.Common.Tools.FhirNarrative;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Common.FhirHttpResponse
{
  public class FhirRestResponse : IFhirRestResponse
  {
    private readonly IFhirResourceNarrative IFhirResourceNarrative;
    private Formatters.FhirMediaTypeFormatter _FhirMediaTypeFormatter = null;
    public FhirRestResponse(IFhirResourceNarrative IFhirResourceNarrative)
    {
      this.IFhirResourceNarrative = IFhirResourceNarrative;
    }

    public HttpResponseMessage GetHttpResponseMessage(IResourceServiceOutcome ResourceServiceOutcome, HttpRequestMessage Request, Hl7.Fhir.Rest.SummaryType? SummaryType)
    {
      HttpStatusCode HttpStatusCode = ResourceServiceOutcome.HttpStatusCode;
      Resource Resource = ResourceServiceOutcome.ResourceResult;      
      HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode);

      if (Resource != null)
      {
        //Set the media formatter as per search parameter _format
        Response = ResolveReturnAcceptTypeJsonOrXml(ResourceServiceOutcome.FormatMimeType, Request, HttpStatusCode, Resource);

        //Annotate the Resource with the _summary, will get the annotation in MediaTypeFormatter XML or JSON
        AnnotateResourceWithSummaryType(SummaryType, Resource);
      }

      switch (HttpStatusCode)
      {        
        case HttpStatusCode.OK:
          {
            switch (ResourceServiceOutcome.OperationType)
            {
              case RestEnum.CrudOperationType.None:
                break;
              case RestEnum.CrudOperationType.Create:
                {
                  //LastModified Header && ETag Version
                  if (ResourceServiceOutcome.LastModified != null)
                  {
                    Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                    //If we have a conditional Create where the Resource is found then we return OK but no Resource so no Content
                    if (Response.Content != null)
                      Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
                  }
                  return Response;
                }                
              case RestEnum.CrudOperationType.Read:
                {
                  //LastModified Header & ETagVersion &Location Header                    
                  if (ResourceServiceOutcome.LastModified.HasValue)
                  {
                    Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                    if (Response.Content != null && ResourceServiceOutcome.IsDeleted.HasValue && !ResourceServiceOutcome.IsDeleted.Value)
                      Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
                    Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri);
                  }
                  return Response;
                }
              case RestEnum.CrudOperationType.Update:
                {
                  //Location Header
                  if (Response.Content != null)
                    Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri);
                  //LastModified Header && ETagVersion
                  if (ResourceServiceOutcome.LastModified.HasValue)
                  {
                    Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                    Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
                  }
                  return Response;
                }                
              case RestEnum.CrudOperationType.Delete:
                {
                  //LastModified Header && ETag Version
                  if (ResourceServiceOutcome.LastModified != null)
                  {
                    if (!string.IsNullOrWhiteSpace(ResourceServiceOutcome.ResourceVersionNumber))
                    {
                      Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                    }
                    Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
                  }
                  return Response;
                }
              default:
                {
                  var oIssueComponent = new OperationOutcome.IssueComponent
                  {
                    Severity = OperationOutcome.IssueSeverity.Fatal,
                    Code = OperationOutcome.IssueType.Exception,
                    Diagnostics = "Internal Error. FhirRestResponse contains no FHIR Resource or Id."
                  };
                  var oOperationOutcome = new OperationOutcome
                  {
                    Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent }
                  };
                  throw new PyroException(HttpStatusCode.InternalServerError, oOperationOutcome, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
                }
            }
            if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Read)
            {
              //LastModified Header & ETagVersion &Location Header                    
              if (ResourceServiceOutcome.LastModified.HasValue)
              {
                Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                if (Response.Content != null && ResourceServiceOutcome.IsDeleted.HasValue && !ResourceServiceOutcome.IsDeleted.Value)
                  Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
                Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri);
              }
              return Response;
            }
            else if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Update)
            {
              //Location Header
              if (Response.Content != null)
                Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri);
              //LastModified Header && ETagVersion
              if (ResourceServiceOutcome.LastModified.HasValue)
              {
                Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
              }
              return Response;
            }
            else if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Delete && ResourceServiceOutcome.ResourceVersionNumber != null)
            {
              //LastModified Header && ETag Version
              if (ResourceServiceOutcome.LastModified != null)
              {
                Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
              }
              return Response;
            }
            else if (ResourceServiceOutcome.OperationType == RestEnum.CrudOperationType.Create)
            {
              //LastModified Header && ETag Version
              if (ResourceServiceOutcome.LastModified != null)
              {
                Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
                //If we have a conditional Create where the Resource is found then we return OK but no Resource so no Content
                if (Response.Content != null)
                  Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
              }
              return Response;
            }
            else
            {

              var oIssueComponent = new OperationOutcome.IssueComponent
              {
                Severity = OperationOutcome.IssueSeverity.Fatal,
                Code = OperationOutcome.IssueType.Exception,
                Diagnostics = "Internal Error. FhirRestResponse contains no FHIR Resource or Id."
              };
              var oOperationOutcome = new OperationOutcome
              {
                Issue = new List<OperationOutcome.IssueComponent>() { oIssueComponent }
              };
              throw new PyroException(HttpStatusCode.InternalServerError, oOperationOutcome, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
            }
          }
        case HttpStatusCode.Created:
          {
            //Location Header
            if (Response.Content != null)
              Response.Headers.Location = HttpHeaderSupport.AddResponseLocation(Request.RequestUri, ResourceServiceOutcome.FhirResourceId);

            //LastModified Header && ETagVersion
            if (ResourceServiceOutcome.LastModified.HasValue)
            {
              Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
              Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
            }          
            return Response;
          }
        case HttpStatusCode.Gone:
          {
            //LastModified Header && ETagVersion
            if (ResourceServiceOutcome.LastModified.HasValue)
            {
              Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);              
            }
            return Response;
          }
        case HttpStatusCode.NoContent:
          {
            //LastModified Header && ETagVersion
            if (ResourceServiceOutcome.LastModified.HasValue)
            {
              Response.Headers.ETag = HttpHeaderSupport.GetEntityTagHeaderValueFromVersion(ResourceServiceOutcome.ResourceVersionNumber);
              if (Response.Content != null)
                Response.Content.Headers.LastModified = ResourceServiceOutcome.LastModified;
            }
            return Response;
          }
        case HttpStatusCode.NotFound:
          {
            //No need to process _format as not returning a body of type resource
            return Response;
          }
        case HttpStatusCode.PreconditionFailed:
          {
            return Response;
          }
        case HttpStatusCode.NotModified:
          {
            return Response;
          }
        default:
          {
            if (Resource != null)
            {
              return Response;
            }
            else
            {
              var OpOutComeIssueComp = new OperationOutcome.IssueComponent
              {
                Severity = OperationOutcome.IssueSeverity.Fatal,
                Code = OperationOutcome.IssueType.Exception,
                Diagnostics = "Internal Server Error: An unexpected HttpStatusCode has been encountered with a null resource to return. This is most likely a server bug."
              };
              var OpOutCome = new OperationOutcome();
              OpOutCome.Issue.Add(OpOutComeIssueComp);
              FhirOperationOutcomeSupport.EscapeOperationOutComeContent(OpOutCome);
              IFhirResourceNarrative.CreateNarrative(OpOutCome);
              if (_FhirMediaTypeFormatter != null)
                Response.Content = new ObjectContent(typeof(Resource), OpOutCome, _FhirMediaTypeFormatter);
              else
                Response = Request.CreateResponse(HttpStatusCode, OpOutCome);
              return Response;
            }
          }       
      }      
    }

    private static void AnnotateResourceWithSummaryType(Hl7.Fhir.Rest.SummaryType? SummaryType, Resource Resource)
    {
      if (Resource is Hl7.Fhir.Utility.IAnnotatable AnnotatableResource)
      {
        if (SummaryType.HasValue)
          AnnotatableResource.AddAnnotation(SummaryType.Value);
        else
          AnnotatableResource.AddAnnotation(Hl7.Fhir.Rest.SummaryType.False);
      }
    }

    private HttpResponseMessage ResolveReturnAcceptTypeJsonOrXml(string _FormatMimeType, HttpRequestMessage Request, HttpStatusCode HttpStatusCode, Resource Resource)
    {
      HttpResponseMessage Response;
      if (Resource.ResourceType == ResourceType.OperationOutcome)
        IFhirResourceNarrative.CreateNarrative(Resource as OperationOutcome);

      //If no _format=application/fhir%2Bjson parameter
      if (_FormatMimeType == null)
      {
        //Then send the Accept type as specified by the Accept Header, or the default of JSON if no header at all
        Response = Request.CreateResponse(HttpStatusCode, Resource);
      }
      else
      {
        //Parse the _format=application/fhir%2Bjson parameter and switch formater if valid.
        _FhirMediaTypeFormatter = GetFhirMediaFormatter(Request, _FormatMimeType);
        if (_FhirMediaTypeFormatter != null)
        {          
          Response = new HttpResponseMessage(HttpStatusCode)
          {
            Content = new ObjectContent(typeof(Resource), Resource, _FhirMediaTypeFormatter)
          };
        }
        else
        {
          //Unable to parse so send the Accept type as specified by the Accept Header, or the default of JSON if no header at all
          Response = Request.CreateResponse(HttpStatusCode, Resource);
        }
      }

      return Response;
    }

    private Pyro.Common.Formatters.FhirMediaTypeFormatter GetFhirMediaFormatter(HttpRequestMessage request, string format)
    {
      if (!string.IsNullOrWhiteSpace(format))
      {
        string MediaType = Common.Tools.HttpHeaderSupport.GetFhirMediaTypeString(format);
        if (MediaType == Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER)
        {
          return new Pyro.Common.Formatters.FhirXmlMediaTypeFormatter();
        }
        else if (MediaType == Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER)
        {
          return new Pyro.Common.Formatters.FhirJsonMediaTypeFormatter();
        }
      }
      return null;        
    }
    
  }
}
