using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceRequestDelete
  {
    string ResourceId { get; set; }
    IDtoFhirRequestUri FhirRequestUri { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
  }
}
