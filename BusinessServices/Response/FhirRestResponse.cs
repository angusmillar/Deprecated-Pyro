using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net;



using Hl7.Fhir.Model;

namespace Blaze.Engine.Response
{
  public class FhirRestResponse
  {
    public HttpStatusCode StatusCode { get; set; }
    public int Version { get; set; }
    public Resource Resource { get; set; }
    public string FhirResourceId { get; set; }
    public string ErrorMessage { get; set; }
    public DateTimeOffset? LastModified { get; set; }

    public FhirRestResponse()
    {
      this.StatusCode = HttpStatusCode.InternalServerError;
      this.Version = 0;
      this.Resource = null;
      this.FhirResourceId = string.Empty;
      this.ErrorMessage = string.Empty;
      this.LastModified = null;
    }

    public FhirRestResponse(HttpStatusCode code, Resource resource)
    {
      this.StatusCode = code;
      this.Version = 0;
      this.Resource = resource;
      this.FhirResourceId = resource.Id;
      this.ErrorMessage = string.Empty;
      this.LastModified = null;
    }

    public FhirRestResponse(HttpStatusCode code, Resource resource, int version, string errormessage)
    {
      this.StatusCode = code;
      this.Version = version;
      this.Resource = resource;
      this.FhirResourceId = resource.Id;
      this.ErrorMessage = errormessage;
      this.LastModified = null;
    }

    public FhirRestResponse(HttpStatusCode code, int version, string errormessage)
    {
      this.StatusCode = code;
      this.Version = version;
      this.Resource = null;
      this.FhirResourceId = string.Empty;
      this.ErrorMessage = errormessage;
      this.LastModified = null;
    }

    public FhirRestResponse(HttpStatusCode code, string errormessage)
    {
      this.StatusCode = code;
      this.Version = 0;
      this.Resource = null;
      this.FhirResourceId = string.Empty;
      this.ErrorMessage = errormessage;
      this.LastModified = null;
    }

    public FhirRestResponse(HttpStatusCode code, string fhirResourceId, int version, DateTimeOffset? lastModified)
    {
      this.StatusCode = code;
      this.Version = version;
      this.Resource = null;
      this.FhirResourceId = fhirResourceId;
      this.ErrorMessage = string.Empty;
      this.LastModified = lastModified;
    }    

    public HttpResponseMessage GetHttpResponseMessage(HttpRequestMessage request)
    {
      //OK: 200
      if (this.StatusCode == HttpStatusCode.OK)
      {
        if (this.Resource != null)
          return request.CreateResponse(this.StatusCode, this.Resource);
        else if (this.Version != 0)
        {
          HttpResponseMessage Response = request.CreateResponse(this.StatusCode, this.FhirResourceId);
          if (this.LastModified != null)
          {
            Response.Content.Headers.LastModified = this.LastModified;
            Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + this.Version.ToString() + "\"");
          }
          return Response;
        }
        else
          throw new Blaze.Engine.CustomException.BlazeException(HttpStatusCode.InternalServerError, "Internal Error. FhirRestResponse contains no FHIR Resource or Id.");
      }
      //Created: 201
      else if (this.StatusCode == HttpStatusCode.Created)
      {
        HttpResponseMessage Response = request.CreateResponse(this.StatusCode, this.Resource.Id);

        string BaseURLPath = String.Format("{0}://{1}{2}", request.RequestUri.Scheme, request.RequestUri.Authority, request.RequestUri.LocalPath);
        BaseURLPath = BaseURLPath.Substring(0, BaseURLPath.LastIndexOf('/'));

        Response.Headers.Location = new Uri(String.Format("{0}/{1}", BaseURLPath, this.Resource.Id));
        return Response;
      }
      //Gone: 410
      else if (this.StatusCode == HttpStatusCode.Gone)
      {
        HttpResponseMessage Response = request.CreateResponse(this.StatusCode, this.ErrorMessage);
        if (this.Version != 0)
        {                 
          Response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue("\"" + this.Version.ToString() + "\"");          
        }
        return Response;
      }
      //No Content: 204
      else if (this.StatusCode == HttpStatusCode.NoContent)
      {
        return request.CreateResponse(this.StatusCode, this.FhirResourceId);
      }
      //Forbidden: 403
      else if (this.StatusCode == HttpStatusCode.Forbidden)
      {
        return request.CreateResponse(this.StatusCode, this.ErrorMessage);
      }
      else
        return request.CreateResponse(this.StatusCode, this.ErrorMessage);
    }

  }
}
