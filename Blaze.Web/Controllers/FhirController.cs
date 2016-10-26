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
    /// <summary>
    /// Get the FHIR Conformance Resource for this Server.
    /// </summary>
    /// <returns>Conformance Resource</returns>
    [HttpGet, Route("metadata")]
    public HttpResponseMessage Metadata()
    {
      ICommonServices oService = _FhirServiceNegotiator.GetService();
      IDtoFhirRequestUri DtoFhirRequestUri = BlazeService.PrimaryServiceRootFactory.Create(oService, Request.RequestUri);
      var Testing = new Blaze.Engine.Services.MetadataService();
      Hl7.Fhir.Model.Resource ResourceMetaData = Testing.GetServersConformanceResource(DtoFhirRequestUri);
      throw new NotImplementedException();
    }


    // Get By id
    // GET URL/FhirApi/Patient/5
    /// <summary>
    /// Get a Resource by the Resource name and the id of the required resource instance.
    /// For example:
    /// http://SomeServer.net/fhirapi/Patient/e2688fc7-1c37-4023-a4ab-7dba0670fa45
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>
    /// <param name="id">The FHIR Resource's id</param>
    /// <returns>Returns the single FHIR Resource identified by the id given or status code 400 (Not found) </returns>
    [HttpGet, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Get(string ResourceName, string id)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(id);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    //Search
    // GET: URL//FhirApi/Patient?family=Smith&given=John
    /// <summary>
    /// Search for a FHIR resource using the Resources defined search parameters.
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient?family=Smith&amp;given=John
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>
    /// <returns>Returns a bundle containing all resource that match the search criteria.</returns>
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
    /// <summary>
    /// Get a Resource's history instance by version number (This is known as a vread in FHIR).
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient/e2688fc7-1c37-4023-a4ab-7dba0670fa45/_history/5
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>
    /// <param name="id">The FHIR Resource's id</param>
    /// <param name="vid">The version number being requested</param>
    /// <returns>Returns the single FHIR Resource identified by the id and the vid (Version Number) or status code 400 (Not found) </returns>
    [HttpGet, Route("{ResourceName}/{id}/_history/{vid}")]
    public HttpResponseMessage Get(string ResourceName, string id, string vid)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oBlazeServiceOperationOutcome = oService.Get(id, vid);
      return FhirRestResponse.GetHttpResponseMessage(oBlazeServiceOperationOutcome, Request);
    }

    // Add
    // POST: URL/FhirApi/Patient
    /// <summary>
    /// Add a new FHIR Resource to the server, the server will assign it a new id if no id is found in the Resource. 
    /// If a Resource of this type with the same id in already on the server then a 
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>    
    /// <returns></returns>
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
