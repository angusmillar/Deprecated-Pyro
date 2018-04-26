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

    public DtoServiceCompartmentCached GetServiceCompartmentForCompartmentCodeAndResource(string CompartmentCode, string Resource)
    {      
      if (!IGlobalProperties.ApplicationCacheServicesActive)
      {
        return IServiceCompartmentRepository.GetServiceCompartmentResourceParameterListForCache(CompartmentCode, Resource);
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet($"{CacheKey}.{CompartmentCode}.{Resource}", () => IServiceCompartmentRepository.GetServiceCompartmentResourceParameterListForCache(CompartmentCode, Resource));
      }     
    }

    public void ClearServiceCompartmentForCompartmentCodeAndResource(string CompartmentCode, string Resource)
    {
      if (IGlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey($"{CacheKey}.{CompartmentCode}.{Resource}");
      }
    }
  }
}
