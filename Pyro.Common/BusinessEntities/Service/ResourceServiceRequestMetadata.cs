using System;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceRequestMetadata : IResourceServiceRequestMetadata
  {
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    public IDtoRootUrlStore RootUrl { get; set; }
    public string ApplicationVersion { get; set; }

    public ResourceServiceRequestMetadata(string ApplicationVersion, IDtoRootUrlStore RootUrl, IDtoSearchParameterGeneric SearchParameterGeneric)
    {
      if (string.IsNullOrEmpty(ApplicationVersion))
        throw new NullReferenceException("ApplicationVersion can not be null or empty string.");
      if (RootUrl == null)
        throw new NullReferenceException("RootUrl can not be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric can not be null.");

      this.ApplicationVersion = ApplicationVersion;
      this.RootUrl = RootUrl;
      this.SearchParameterGeneric = SearchParameterGeneric;    
    }    
  }
}
