using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceRequestDelete
  {
    string ResourceId { get; set; }
    IDtoRequestUri RequestUri { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
  }
}
