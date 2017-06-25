using System.Net.Http;
using System.Net.Http.Formatting;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;

namespace Pyro.Engine.Services
{
  public interface IPyroService
  {
    IResourceServiceOutcome Base(string BaseRequestUri, HttpRequestMessage Request, Resource resource);
    IResourceServiceOutcome BaseOperationWithOutParameters(string BaseRequestUri, HttpRequestMessage Request, string OperationName);
    IResourceServiceOutcome BaseOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, string operation, Resource Resource);
    IResourceServiceOutcome ConditionalDelete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName);
    IResourceServiceOutcome ConditionalPut(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource);
    IResourceServiceOutcome Delete(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id);
    IResourceServiceOutcome Get(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id);
    IResourceServiceOutcome GetHistory(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, string vid = "");
    IResourceServiceOutcome Metadata(string BaseRequestUri, HttpRequestMessage Request);
    IResourceServiceOutcome Post(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, Resource resource);
    IResourceServiceOutcome PostFormSearch(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, FormDataCollection FormDataCollection);
    IResourceServiceOutcome Put(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string id, Resource resource);
    IResourceServiceOutcome ResourceInstanceOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, Resource Resource, string FhirId);
    IResourceServiceOutcome ResourceOperationWithParameters(string BaseRequestUri, HttpRequestMessage Request, string ResourceName, string operation, Resource Resource);
    IResourceServiceOutcome Search(string BaseRequestUri, HttpRequestMessage Request, string ResourceName);
  }
}