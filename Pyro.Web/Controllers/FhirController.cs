using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FhirModel = Hl7.Fhir.Model;
using Pyro.Web.Response;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces;
using Pyro.Common.Enum;
using Pyro.Web.Extensions;
using Pyro.Web.ApplicationCache;

namespace Pyro.Web.Controllers
{
  [RoutePrefix(Pyro.Common.Web.StaticWebInfo.ServiceRoute)]  
  public class FhirController : ApiController
  {
    private readonly IServiceNegotiator _FhirServiceNegotiator;
    //Constructor for dependence injection 
    public FhirController(IServiceNegotiator FhirServiceNegotiator)
    {
      _FhirServiceNegotiator = FhirServiceNegotiator;
    }
    //public FhirController()
    //{
      
    //}

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
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Metadata, Request.GetSearchParams());
      IResourceServiceOutcome oPyroServiceOperationOutcome = MetadataService.GetServersConformanceResource(ResourceServiceRequest, RootUrl, ApplicationVersion);
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
      IDtoFhirRequestUri FhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IResourceServiceRequest PyroServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Read, id, FhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome oPyroServiceOperationOutcome = oService.Get(PyroServiceRequest);
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
      IDtoFhirRequestUri FhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Search, FhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome oPyroServiceOperationOutcome = oService.Get(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(oPyroServiceOperationOutcome, Request);
    }

    // Get By id and _history vid
    // GET URL/FhirApi/Patient/5/_history/2
    // GET URL/FhirApi/Patient/5/_history
    /// <summary>
    /// Get a Resource's entire history or an given history instance for the Resource by its version id (vid)
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient/123456/_history/5
    /// </summary>
    /// <param name="ResourceName">The name of a FHIR Resource, for example 'Patient'</param>
    /// <param name="id">The FHIR Resource's id</param>
    /// <param name="vid">The version id if requesting a single version instance, leave empty if you require the entire history for the resource instance.</param>
    /// <returns>Returns the single FHIR Resource identified by the id and the vid (Version Number) or returns the entire history for the resource instance as a history bundle if vid is empty or status code 400 (Not found) </returns>
    [HttpGet, Route("{ResourceName}/{id}/_history/{vid?}")]
    public HttpResponseMessage Get(string ResourceName, string id, string vid = "")
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri FhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.History, id, vid, FhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome ResourceServiceOutcome = oService.Get(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(ResourceServiceOutcome, Request);
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
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Create, resource, DtoFhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome ResourceServiceOutcome = oService.Post(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(ResourceServiceOutcome, Request);
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
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Update, id, resource, DtoFhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome ResourceServiceOutcome = oService.Put(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(ResourceServiceOutcome, Request);
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
      IDtoFhirRequestUri DtoFhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Delete, id, DtoFhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome ResourceServiceOutcome = oService.Delete(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(ResourceServiceOutcome, Request);
    }



    //Conditional Update
    // PUT: URL/FhirApi/Patient/5
    /// <summary>
    /// Updates creates a new current version for an existing resource or creates an initial version if no resource already exists for the given id.
    /// For example: 
    /// http://SomeServer.net/fhirapi/Patient/123456
    /// Where the HTTP body is a FHIR Patient resource instance in JSON or XML format and the id in the resource equals the [id] in the URL, 123456 in this case.
    /// </summary>
    /// <param name="ResourceName">The name of the FHIR resource that is contained in the HTTP body</param>    
    /// <param name="resource">The actual Resource in the HTTP body</param>
    /// <returns>Status Code 200 (OK) and an echo of the created FHIR resource in the HTTP body or an OperationOutcome resource if an error has been encountered.</returns>
    [HttpPut, Route("{ResourceName}")]
    public HttpResponseMessage ConditionalPut(string ResourceName, [FromBody] FhirModel.Resource resource)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri DtoFhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Search, resource, DtoFhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome ResourceServiceOutcome = oService.ConditionalPut(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(ResourceServiceOutcome, Request);
    }


    //Delete
    // DELETE: URL/FhirApi/Patient/5
    /// <summary>
    /// Conditional Delete removes an existing resource or set of Resources given a set of the Resources defined search parameters.
    /// This operation must be given at least one Resources defined search parameter to work and all parameter must be understood by this server.
    /// If not a HTTP status code of 412 Precondition Failed will be returned. 
    /// This server supports version history. 
    /// The delete interaction does not remove a resource's version history. From a version history respect, deleting a resource is the equivalent of creating a special kind of history entry that has no content and is marked as deleted. 
    /// </summary>
    /// <param name="ResourceName">The name of the FHIR resource that is being removed.</param>    
    /// <returns>HTTP Status codes: 204 (No Content) or 404 Not Found or 412 Precondition Failed</returns>
    [HttpDelete, Route("{ResourceName}")]
    public HttpResponseMessage ConditionalDelete(string ResourceName)
    {
      IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceName);
      IDtoFhirRequestUri FhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, Request.RequestUri);
      IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Search, FhirRequestUri, Request.GetSearchParams());
      IResourceServiceOutcome ResourceServiceOutcome = oService.ConditionalDelete(ResourceServiceRequest);
      return FhirRestResponse.GetHttpResponseMessage(ResourceServiceOutcome, Request);
    }
  }
}
