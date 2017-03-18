using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Interfaces.Service
{
  public interface IResourceServiceRequestMetadata
  {
    string ApplicationVersion { get; set; }
    IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    IDtoRootUrlStore RootUrl { get; set; }
  }
}
