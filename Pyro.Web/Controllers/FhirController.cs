using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FhirModel = Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces;
using Pyro.Web.Extensions;
using Pyro.Engine.Response;
using Pyro.Web.ApplicationCache;

namespace Pyro.Web.Controllers
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
      Common.Interfaces.Dto.IDtoRootUrlStore RootUrl = oService.GetPrimaryServiceRootUrl();            
      var MetadataService = new Pyro.Engine.Services.MetadataService();
      string ApplicationVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(Pyro.Web.WebApiApplication).Assembly.Location).ProductVersion;
      IServiceOperationOutcome oPyroServiceOperationOutcome = MetadataService.GetServersConformanceResource(RootUrl, ApplicationVersion);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);      
    }


    // Get By id
    // GET URL/FhirApi/Patient/5
    /// <summary>
    /// Get a Resource by the Resource name and the id of the required resource instance.
    /// For example:
    /// http://SomeServer.net/fhirapi/Patient/123456
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>
    /// <param name="id">The FHIR Resource's id</param>
    /// <returns>Returns the single FHIR Resource identified by the id given or status code 400 (Not found) </returns>
    [HttpGet, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Get(string ResourceName, string id)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oPyroServiceOperationOutcome = oService.Get(id);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
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
      IDtoFhirRequestUri DtoFhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);

      IPyroServiceRequest PyroServiceRequest = Services.PyroServiceRequestFactory.Create(DtoFhirRequestUri, Request.GetSearchParams());
      IServiceOperationOutcome oPyroServiceOperationOutcome = oService.Get(PyroServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
    }

    // Get By id and _history vid
    // GET URL/FhirApi/Patient/5/_history/2
    /// <summary>
    /// Get a Resource's history instance by version number (This is known as a vread in FHIR).
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient/123456/_history/5
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>
    /// <param name="id">The FHIR Resource's id</param>
    /// <param name="vid">The version number being requested</param>
    /// <returns>Returns the single FHIR Resource identified by the id and the vid (Version Number) or status code 400 (Not found) </returns>
    [HttpGet, Route("{ResourceName}/{id}/_history/{vid}")]
    public HttpResponseMessage Get(string ResourceName, string id, string vid)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oPyroServiceOperationOutcome = oService.Get(id, vid);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
    }


    // Add
    // POST: URL/FhirApi/Patient
    /// <summary>
    /// Creates a new Resource in the server. The server will assign its own id and that id will be a GUID.
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient
    /// Where the HTTP body is a FHIR Patient resource instance in JSON or XML format.
    /// If the client wishes to have control over the id of a newly submitted Resource, it should use the PUT (update) interaction instead.     
    /// </summary>
    /// <param name="ResourceName">The name of the FHIR resource that is contained in the HTTP body</param>
    /// <param name="resource">The actual Resource in the HTTP body</param>
    /// <returns>Status Code 200 (OK) and an echo of the created FHIR resource or an OperationOutcome resource if an error has been encountered.</returns>
    [HttpPost, Route("{ResourceName}")]
    public HttpResponseMessage Post(string ResourceName, [FromBody] FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri DtoFhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IPyroServiceRequest PyroServiceRequest = Services.PyroServiceRequestFactory.Create(resource, DtoFhirRequestUri);
      IServiceOperationOutcome oPyroServiceOperationOutcome = oService.Post(PyroServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
    }

    //Update
    // PUT: URL/FhirApi/Patient/5
    /// <summary>
    /// Updates creates a new current version for an existing resource or creates an initial version if no resource already exists for the given id.
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient/123456
    /// Where the HTTP body is a FHIR Patient resource instance in JSON or XML format and the id in the resource equals the [id] in the URL, 123456 in this case.
    /// </summary>
    /// <param name="ResourceName">The name of the FHIR resource that is contained in the HTTP body</param>
    /// <param name="id">The FHIR Resource's id</param>
    /// <param name="resource">The actual Resource in the HTTP body</param>
    /// <returns>Status Code 200 (OK) and an echo of the created FHIR resource in the HTTP body or an OperationOutcome resource if an error has been encountered.</returns>
    [HttpPut, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Put(string ResourceName, string id, [FromBody] FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri DtoFhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      var PyroServiceRequest = Services.PyroServiceRequestFactory.Create(id, resource, DtoFhirRequestUri);
      IServiceOperationOutcome oPyroServiceOperationOutcome = oService.Put(PyroServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
    }

    //Delete
    // DELETE: URL/FhirApi/Patient/5
    /// <summary>
    /// Deletes removes an existing resource at the given id.
    /// This server supports version history. 
    /// The delete interaction does not remove a resource's version history. From a version history respect, deleting a resource is the equivalent of creating a special kind of history entry that has no content and is marked as deleted. 
    /// </summary>
    /// <param name="ResourceName">The name of the FHIR resource that is being removed.</param>
    /// <param name="id">The FHIR Resource's id to be removed.</param>
    /// <returns>HTTP Status code 204 (No Content)</returns>
    [HttpDelete, Route("{ResourceName}/{id}")]
    public HttpResponseMessage Delete(string ResourceName, string id)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IServiceOperationOutcome oPyroServiceOperationOutcome = oService.Delete(id);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
    }
  }
}
