using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FhirModel = Hl7.Fhir.Model;
using Common.Interfaces.Services;
using Common.Interfaces;
using Blaze.Extensions;
using Blaze.Engine.Response;

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
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(id);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);      
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    [HttpGet, Route("{ResourceName}")]
    public HttpResponseMessage Search(string ResourceName)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(Request.RequestUri, Request.GetSearchParams());
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);   
    }

    // Add
    // POST: URL/FhirApi/Patient
    [HttpPost, Route("{ResourceName}")]
    public HttpResponseMessage Post(string ResourceName, FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      var BlazeServiceRequest = BlazeService.BlazeServiceRequestFactory.Create(resource, Request.RequestUri);
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Post(BlazeServiceRequest);      
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);                        
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    [HttpPut, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Put(string ResourceName, string id, FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      var BlazeServiceRequest = BlazeService.BlazeServiceRequestFactory.Create(id, resource, Request.RequestUri);
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Put(BlazeServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);                        
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    [HttpDelete, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Delete(string ResourceName, string id)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Delete(id);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);                        
    }
  }
}
