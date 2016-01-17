using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FhirModel = Hl7.Fhir.Model;
using Blaze.Engine.Interfaces;
using Blaze.Engine.Services;
using Blaze.Engine.Response;
using Blaze.Extensions;

namespace Blaze.Controllers
{
  [RoutePrefix("FhirApi")]
  public class FhirController : ApiController
  {

    private readonly IFhirServiceNegotiator _FhirServiceNegotiator;

    public FhirController()
    {
      _FhirServiceNegotiator = new FhirServiceNegotiator();
    }

    //Constructor for dependence injection 
    public FhirController(IFhirServiceNegotiator FhirServiceNegotiator)
    {
      _FhirServiceNegotiator = FhirServiceNegotiator;
    }


    // Get By id
    // GET URL/FhirApi/Patient/5
    [HttpGet, Route("{type}/{id}")]
    public HttpResponseMessage Get(string type, string id)
    {      
      FhirRestResponse Response = _FhirServiceNegotiator.Get(type, id);
      return Response.GetHttpResponseMessage(this.Request);     
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    [HttpGet, Route("{type}")]
    public HttpResponseMessage Search(string type)
    {
      FhirRestResponse Response = _FhirServiceNegotiator.Get(type, Request.RequestUri, Request.GetSearchParams());
      return Response.GetHttpResponseMessage(this.Request);     
    }

    // Add
    // POST: URL/FhirApi/Patient
    [HttpPost, Route("{type}")]
    public HttpResponseMessage Post(string type, FhirModel.Resource resource)
    {
      FhirRestResponse Response = _FhirServiceNegotiator.Post(type, resource);
      return Response.GetHttpResponseMessage(this.Request);              
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    [HttpPut, Route("{type}/{id}")]
    public HttpResponseMessage Put(string type, string id, FhirModel.Resource resource)
    {
      FhirRestResponse Response = _FhirServiceNegotiator.Put(type, id, resource);
      return Response.GetHttpResponseMessage(this.Request);          

    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    [HttpDelete, Route("{type}/{id}")]
    public HttpResponseMessage Delete(string type, string id)
    {
      FhirRestResponse Response = _FhirServiceNegotiator.Delete(type, id);
      return Response.GetHttpResponseMessage(this.Request);

    }
  }
}
