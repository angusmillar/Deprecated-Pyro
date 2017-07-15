using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Pyro.Common.Exceptions;
using Hl7.Fhir.Model;

namespace Pyro.Common.Tools
{
  public static class HttpHeaderSupport
  {

    public static Uri AddResponseLocation(Uri RequestUri, string FhirId = null)
    {
      string BaseURLPath = String.Format("{0}://{1}{2}", RequestUri.Scheme, RequestUri.Authority, RequestUri.LocalPath);
      if (string.IsNullOrWhiteSpace(FhirId))
      {
        return new Uri(BaseURLPath);
      }
      else
      {
        BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));
        return new Uri(String.Format("{0}/{1}", BaseURLPath, FhirId));
      }
    }

    /// <summary>
    /// Expects a value e.g ("5") and returns an Etag string e.g(W/"3141") 
    /// </summary>
    /// <param name="Version"></param>
    /// <returns></returns>
    public static string GetETagString(string Version)
    {
      //example: ETag: W/"3141"      
      return new EntityTagHeaderValue('\"' + Version + '\"', true).ToString();
    }

    /// <summary>
    /// Expects a value e.g ("5") and returns an EntityTagHeaderValue instance
    /// </summary>
    /// <param name="Version"></param>
    /// <returns></returns>
    public static EntityTagHeaderValue GetEntityTagHeaderValueFromVersion(string Version)
    {
      //example: ETag: W/"3141"      
      return new EntityTagHeaderValue('\"' + Version + '\"', true);
    }

    /// <summary>
    /// Expects a Etag string e.g(W/"3141") and returns an EntityTagHeaderValue instance
    /// </summary>
    /// <param name="ETag"></param>
    /// <returns>EntityTagHeaderValue</returns>
    public static EntityTagHeaderValue GetETagEntityTagHeaderValueFromETagString(string ETag)
    {
      EntityTagHeaderValue TempEtag;
      if (EntityTagHeaderValue.TryParse(ETag, out TempEtag))
      {
        return TempEtag;
      }
      throw new FormatException("ETag is not formated correctly, string was: " + ETag);
    }

    /// <summary>
    /// Expects a EntityTagHeaderValue instance and returns the Value e.g(5)
    /// </summary>
    /// <param name="ETag"></param>
    /// <returns>Value</returns>
    public static string GetVersionString(EntityTagHeaderValue ETag)
    {
      var Split = ETag.Tag.Split('\"');
      return Split[1];
    }


    public static bool IsAcceptMediaTypeSetInRequest(HttpRequestMessage Request)
    {
      if (Request.Headers.Accept.Count == 1)
      {
        foreach (var Accept in Request.Headers.Accept)
        {
          if (Accept.MediaType == "*/*")
          {
            return false;
          }
        }
      }
      return true;
    }

    public static string GetFhirMediaTypeString(string value)
    {
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADERS)
      {
        if (value == System.Net.WebUtility.UrlDecode(mediaType))
        {
          return Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER;
        }
      }
      foreach (var mediaType in Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADERS)
      {
        if (value == System.Net.WebUtility.UrlDecode(mediaType))
        {
          return Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER;
        }
      }
      return string.Empty;
    }

    public static bool IsModifiedOrNoneMatch(string ifNoneMatch, string ifModifiedSince, string resourceVersionNumber, DateTimeOffset? lastModified)
    {
      if (!string.IsNullOrWhiteSpace(ifNoneMatch))
      {
        if (resourceVersionNumber != ifNoneMatch.Trim())
        {
          return true;
        }
      }

      if (!string.IsNullOrWhiteSpace(ifModifiedSince))
      {
        DateTimeOffset? ifModifiedSinceDateTimeOffset = HttpHeaderSupport.ParseHttpDate(ifModifiedSince);
        if (!ifModifiedSinceDateTimeOffset.HasValue)
        {
          string ErrorMessage = "if-Modified-Since value could not be converted to a DateTime. The value found was: " + ifModifiedSince;
          var Operationoutcome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Exception, ErrorMessage);
          throw new PyroException(System.Net.HttpStatusCode.InternalServerError, Operationoutcome, ErrorMessage);
        }
        //Remove the milliseconds        
        lastModified = new DateTimeOffset(lastModified.Value.Year, lastModified.Value.Month, lastModified.Value.Day, lastModified.Value.Hour, lastModified.Value.Minute, lastModified.Value.Second, 0, lastModified.Value.Offset);
        ifModifiedSinceDateTimeOffset = new DateTimeOffset(ifModifiedSinceDateTimeOffset.Value.Year, ifModifiedSinceDateTimeOffset.Value.Month, ifModifiedSinceDateTimeOffset.Value.Day, ifModifiedSinceDateTimeOffset.Value.Hour, ifModifiedSinceDateTimeOffset.Value.Minute, ifModifiedSinceDateTimeOffset.Value.Second, 0, ifModifiedSinceDateTimeOffset.Value.Offset);
        if (lastModified > ifModifiedSinceDateTimeOffset)
        {
          return true;
        }
      }
      return false;
    }

    public static DateTimeOffset? ParseHttpDate(string value)
    {
      DateTimeOffset ValueDateTimeOffset = DateTimeOffset.MinValue;
      if (DateTimeOffset.TryParseExact(value.Trim(), "ddd, dd MMM yyyy HH:mm:ss 'GMT'", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal, out ValueDateTimeOffset))
      {
        return ValueDateTimeOffset;
      }
      else
      {
        return null;
      }
    }
  }
}
