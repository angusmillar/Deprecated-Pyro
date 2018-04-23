using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.Global;
using Pyro.Common.Cache;
using Pyro.Common.Compartment;
using Pyro.Common.Interfaces.ITools;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.Compartment
{
  public class ServiceCompartmentCache : IServiceCompartmentCache
  {
    private readonly IGlobalProperties IGlobalProperties;
    private readonly IServiceCompartmentRepository IServiceCompartmentRepository;    
    private readonly IApplicationCacheSupport IApplicationCacheSupport;

    private readonly string CacheKey = "GetServiceCompartmentForCode";

    public ServiceCompartmentCache(IServiceCompartmentRepository IServiceCompartmentRepository, IApplicationCacheSupport IApplicationCacheSupport, IGlobalProperties IGlobalProperties)
    {
      this.IServiceCompartmentRepository = IServiceCompartmentRepository;      
      this.IApplicationCacheSupport = IApplicationCacheSupport;
      this.IGlobalProperties = IGlobalProperties;
    }

    public DtoServiceCompartment GetServiceCompartmentForCode(string Code)
    {      
      if (!IGlobalProperties.ApplicationCacheServicesActive)
      {
        return IServiceCompartmentRepository.GetServiceCompartment(Code);
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet($"{CacheKey}.{Code}", () => IServiceCompartmentRepository.GetServiceCompartment(Code));
      }     
    }

    public void ClearServiceCompartmentForCode(string Code)
    {
      if (IGlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey($"{CacheKey}.{Code}");
      }
    }
  }
}
