using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;

namespace Pyro.Common.BusinessEntities.Service
{
  public class ResourceServiceDeleteHistoryIndexesRequest : IResourceServiceDeleteHistoryIndexesRequest
  {
    public IDtoFhirRequestUri FhirRequestUri { get; set; }
    public IDtoSearchParameterGeneric SearchParameterGeneric { get; set; }
    internal ResourceServiceDeleteHistoryIndexesRequest() { }
  }
}
