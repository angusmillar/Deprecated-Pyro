//using Hl7.Fhir.Model;
//using Pyro.Common.Interfaces.Dto;
//using Pyro.Common.Interfaces.Dto.Headers;
//using Pyro.Common.Interfaces.UriSupport;
//using Pyro.Common.Interfaces.Service;
//using Pyro.Common.BusinessEntities.FhirOperation;
//using System;

//namespace Pyro.Common.BusinessEntities.Service
//{
//  public class ResourceInstanceOperationsServiceRequest : ResourceOperationsServiceRequest,
//    IResourceInstanceOperationsServiceRequest, IResourceOperationsServiceRequest
//  {
//    public string FhirId { get; set; }

//    internal ResourceInstanceOperationsServiceRequest(string OperationName, OperationClass OperationClass, Resource Resource, string FhirId, IResourceServices ResourceServices, IDtoRequestUri FhirRequestUri, IDtoSearchParameterGeneric SearchParameterGeneric, IDtoRequestHeaders RequestHeaders)
//      : base(OperationName, OperationClass, Resource, ResourceServices, FhirRequestUri, SearchParameterGeneric, RequestHeaders)
//    {
//      this.FhirId = FhirId;
//    }
//  }
//}
