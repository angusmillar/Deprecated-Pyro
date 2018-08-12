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
    private HttpStatusCode _HttpStatusCode;
    public FhirRestResponse(IFhirResourceNarrative IFhirResourceNarrative)
    {
      this.IFhirResourceNarrative = IFhirResourceNarrative;
    }

    public HttpResponseMessage GetHttpResponseMessage(IResourceServiceOutcome ResourceServiceOutcome, HttpRequestMessage Request, Hl7.Fhir.Rest.SummaryType? SummaryType)
    {
      _HttpStatusCode = ResourceServiceOutcome.HttpStatusCode;
      Resource Resource = ResourceServiceOutcome.ResourceResult;      
      HttpResponseMessage Response = Request.CreateResponse(_HttpStatusCode);

      if (Resource != null)
      {
        //If the Resource is an OperationOutcome then we auto generate its narrative here
        if (Resource.ResourceType == ResourceType.OperationOutcome)
          IFhirResourceNarrative.CreateNarrative(Resource as OperationOutcome);

        //Set the media formatter as per search parameter _format
        Response = ResolveReturnAcceptTypeJsonOrXml(ResourceServiceOutcome.FormatMimeType, Request, Resource);

        //Annotate the Resource with the _summary, will get the annotation in MediaTypeFormatter XML or JSON
        AnnotateResourceWithSummaryType(SummaryType, Resource);
      }

      switch (_HttpStatusCode)
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
        case HttpStatusCode.UnsupportedMediaType:
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
                Response = Request.CreateResponse(_HttpStatusCode, OpOutCome);
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

    private HttpResponseMessage ResolveReturnAcceptTypeJsonOrXml(string _FormatMimeType, HttpRequestMessage Request, Resource Resource)
    {
      HttpResponseMessage Response;      
      //If no _format=application/fhir%2Bjson parameter
      if (_FormatMimeType == null)
      {
        //below returns Null if ok or an Operationoutcome if not ok
        OperationOutcome FailedAcceptHeaderOperationOutcome = null;
        FailedAcceptHeaderOperationOutcome = CheckAcceptHeaderValid(Request);
        if (FailedAcceptHeaderOperationOutcome != null)
        {
          IFhirResourceNarrative.CreateNarrative(FailedAcceptHeaderOperationOutcome);
          _HttpStatusCode = HttpStatusCode.UnsupportedMediaType;
          Response = Request.CreateResponse(_HttpStatusCode, FailedAcceptHeaderOperationOutcome);
        }
        else
        {
          //Then send the Accept type as specified by the Accept Header, or the default of JSON if no header at all
          Response = Request.CreateResponse(_HttpStatusCode, Resource);
        }        
      }
      else
      {
        //Parse the _format=application/fhir%2Bjson parameter and switch formater if valid.
        _FhirMediaTypeFormatter = GetFhirMediaFormatter(_FormatMimeType);
        if (_FhirMediaTypeFormatter != null)
        {          
          Response = new HttpResponseMessage(_HttpStatusCode)
          {
            Content = new ObjectContent(typeof(Resource), Resource, _FhirMediaTypeFormatter)
          };
        }
        else
        {
          string Message = $"The _format search parameter value was {_FormatMimeType} which is not a supported media type. The simplest supported meda types to use are _format=xml or _format=json";
          var FaledFormatParameterOperationOutcome = FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
          IFhirResourceNarrative.CreateNarrative(FaledFormatParameterOperationOutcome);
          _HttpStatusCode = HttpStatusCode.UnsupportedMediaType;
          Response = Request.CreateResponse(_HttpStatusCode, FaledFormatParameterOperationOutcome);
        }
      }
      return Response;
    }

    private static OperationOutcome CheckAcceptHeaderValid(HttpRequestMessage Request)
    {
      //first test the Accept header is valid
      if (Request?.Headers?.Accept?.Count > 0)
      {
        bool IsOk = false;        
        foreach (var AcceptHeaderValue in Request.Headers.Accept)
        {
          if (!string.IsNullOrWhiteSpace(Common.Tools.HttpHeaderSupport.GetFhirMediaTypeString(AcceptHeaderValue.MediaType)))
          {
            IsOk = true;
            break;
          }          
        }
        if (!IsOk)
        {
          string Message = $"None of the Http Accept header values are suported by the server. The primary values that are supported are {Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER} and {Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER}";
          return FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.NotSupported, Message);
        }
      }
      return null;
    }

    private Pyro.Common.Formatters.FhirMediaTypeFormatter GetFhirMediaFormatter(string format)
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
