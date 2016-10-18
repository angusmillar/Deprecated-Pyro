using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FhirModel = Hl7.Fhir.Model;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.Common.Interfaces;
using Blaze.Web.Extensions;
using Blaze.Engine.Response;
using Blaze.Web.ApplicationCache;

namespace Blaze.Web.Controllers
{
  [RoutePrefix("fhirapi")]
  public class FhirController : ApiController
  {
    private readonly IFhirServiceNegotiator _FhirServiceNegotiator;
    //Constructor for dependence injection 
    public FhirController(IFhirServiceNegotiator FhirServiceNegotiator)
    {
      _FhirServiceNegotiator = FhirServiceNegotiator;
    }


    //Metadata 
    // GET: URL//FhirApi/metadata
    [HttpGet, Route("metadata")]
    public HttpResponseMessage Metadata()
    {

      throw new NotImplementedException();
    }


    // Get By id
    // GET URL/FhirApi/Patient/5
    [HttpGet, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Get(string ResourceName, string id)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(id);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    //Search
    // GET: URL//FhirApi/Patient&family=Smith&given=John
    [HttpGet, Route("{ResourceName}")]
    public HttpResponseMessage Search(string ResourceName)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri DtoFhirRequestUri = BlazeService.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);

      IBlazeServiceRequest BlazeServiceRequest = BlazeService.BlazeServiceRequestFactory.Create(DtoFhirRequestUri, Request.GetSearchParams());
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(BlazeServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    // Get By id and _history vid
    // GET URL/FhirApi/Patient/5/_history/2
    [HttpGet, Route("{ResourceName}/{id}/_history/{vid}")]
    public HttpResponseMessage Get(string ResourceName, string id, string vid)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(id, vid);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    // Add
    // POST: URL/FhirApi/Patient
    [HttpPost, Route("{ResourceName}")]
    public HttpResponseMessage Post(string ResourceName, FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri DtoFhirRequestUri = BlazeService.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IBlazeServiceRequest BlazeServiceRequest = BlazeService.BlazeServiceRequestFactory.Create(resource, DtoFhirRequestUri);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Post(BlazeServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    [HttpPut, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Put(string ResourceName, string id, FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri DtoFhirRequestUri = BlazeService.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      var BlazeServiceRequest = BlazeService.BlazeServiceRequestFactory.Create(id, resource, DtoFhirRequestUri);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Put(BlazeServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    [HttpDelete, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Delete(string ResourceName, string id)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Delete(id);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }
  }
}
