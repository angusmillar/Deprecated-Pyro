using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FhirModel = Hl7.Fhir.Model;
using Dip.Interfaces;
using Blaze.Extensions;

namespace Blaze.Controllers
{
  [RoutePrefix("FhirApi")]
  public class FhirController : ApiController
  {
    private readonly IFhirServiceNegotiator _FhirServiceNegotiator;

    //Constructor for dependence injection 
    public FhirController(IFhirServiceNegotiator FhirServiceNegotiator)
    {
      _FhirServiceNegotiator = FhirServiceNegotiator;
    }

    // Get By id
    // GET URL/FhirApi/Patient/5
    [HttpGet, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Get(string ResourceName, string id)
    {
      IResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IFhirRestResponse Response = oService.Get(id);
      return Response.GetHttpResponseMessage(this.Request);     
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    [HttpGet, Route("{ResourceName}")]
    public HttpResponseMessage Search(string ResourceName)
    {
      IResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IFhirRestResponse Response = oService.Get(Request.RequestUri, Request.GetSearchParams());
      return Response.GetHttpResponseMessage(this.Request);     
    }

    // Add
    // POST: URL/FhirApi/Patient
    [HttpPost, Route("{ResourceName}")]
    public HttpResponseMessage Post(string ResourceName, FhirModel.Resource resource)
    {
      IResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IFhirRestResponse Response = oService.Post(resource);
      return Response.GetHttpResponseMessage(this.Request);              
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    [HttpPut, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Put(string ResourceName, string id, FhirModel.Resource resource)
    {
      IResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IFhirRestResponse Response = oService.Put(id, resource);
      return Response.GetHttpResponseMessage(this.Request);          
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    [HttpDelete, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Delete(string ResourceName, string id)
    {
      IResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IFhirRestResponse Response = oService.Delete(id);
      return Response.GetHttpResponseMessage(this.Request);
    }
  }
}
