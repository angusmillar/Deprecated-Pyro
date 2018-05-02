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

    private readonly string CacheKeyCompartmentResource = "GetServiceCompartmentResource";
    private readonly string CacheKeyCompartment = "GetServiceCompartment";

    public ServiceCompartmentCache(IServiceCompartmentRepository IServiceCompartmentRepository, IApplicationCacheSupport IApplicationCacheSupport, IGlobalProperties IGlobalProperties)
    {
      this.IServiceCompartmentRepository = IServiceCompartmentRepository;      
      this.IApplicationCacheSupport = IApplicationCacheSupport;
      this.IGlobalProperties = IGlobalProperties;
    }

    public DtoServiceCompartmentCached GetServiceCompartmentForCompartmentCode(string CompartmentCode)
    {
      if (!IGlobalProperties.ApplicationCacheServicesActive)
      {
        return IServiceCompartmentRepository.GetServiceCompartmentForCache(CompartmentCode);
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet($"{CacheKeyCompartment}.{CompartmentCode}", () => IServiceCompartmentRepository.GetServiceCompartmentForCache(CompartmentCode));
      }
    }

    public DtoServiceCompartmentResourceCached GetServiceCompartmentResourceForCompartmentCodeAndResource(string CompartmentCode, string Resource)
    {      
      if (!IGlobalProperties.ApplicationCacheServicesActive)
      {
        return IServiceCompartmentRepository.GetServiceCompartmentResourceParameterListForCache(CompartmentCode, Resource);
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet($"{CacheKeyCompartmentResource}.{CompartmentCode}.{Resource}", () => IServiceCompartmentRepository.GetServiceCompartmentResourceParameterListForCache(CompartmentCode, Resource));
      }     
    }

    public void ClearServiceCompartmentForCompartmentCode(string CompartmentCode)
    {
      if (IGlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey($"{CacheKeyCompartment}.{CompartmentCode}");
      }
    }

    public void ClearServiceCompartmentResourceForCompartmentCodeAndResource(string CompartmentCode, string Resource)
    {
      if (IGlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey($"{CacheKeyCompartmentResource}.{CompartmentCode}.{Resource}");
      }
    }

  }
}
