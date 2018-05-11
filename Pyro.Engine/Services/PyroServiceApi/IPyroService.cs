using System;
using System.Collections.Generic;
using System.Net.Http;
//using System.Net.Http.Formatting;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Service.ResourceService;

namespace Pyro.Engine.Services.PyroServiceApi
{
  public interface IPyroService
  {
    IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, Resource resource);
    IResourceServiceOutcome ConditionalDelete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName);
    IResourceServiceOutcome ConditionalPut(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource);
    IResourceServiceOutcome Delete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id);
    IResourceServiceOutcome Get(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id);
    IResourceServiceOutcome GetHistory(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, string vid = "");
    IResourceServiceOutcome Metadata(string BaseRequestUri, HttpRequestMessage Request);
    IResourceServiceOutcome Post(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource);
    IResourceServiceOutcome PostFormSearch(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, IEnumerable<Tuple<string, string>> FormParameterList);
    IResourceServiceOutcome Put(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, Resource resource);
    IResourceServiceOutcome Search(string BaseRequestUri, HttpRequestMessage Request, string ResourceName);
    IResourceServiceOutcome CompartmentSearch(string BaseRequestUri, HttpRequestMessage Request, string Compartment, string id, string ResourceName);
    
    IResourceServiceOutcome OperationPostResourceInstanceWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, string FhirId, Resource Resource);
    IResourceServiceOutcome OperationGetResourceInstanceWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, string FhirId);

    IResourceServiceOutcome OperationPostResourceWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, Resource Resource);
    IResourceServiceOutcome OperationGetBaseWithParameters(string BaseRequestUri, HttpRequestMessage Request, string OperationName);
    IResourceServiceOutcome OperationPostBaseWithParameters(string BaseRequestUri, HttpRequestMessage Request, string operation, Resource Resource);

  }
}