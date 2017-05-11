using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceRequestGetRead
  {    
    string ResourceId { get; set; }
    IDtoRequestUri RequestUri { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    IDtoRequestHeaders RequestHeaders { get; set; }
  }
}
