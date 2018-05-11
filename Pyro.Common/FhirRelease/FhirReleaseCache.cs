using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Search;
using Pyro.Common.Global;
using Pyro.Common.Cache;
using Pyro.Common.Compartment;
using Pyro.Common.Tools;
using Pyro.Common.Interfaces.Service;
using System.Collections.Generic;
using Pyro.Common.Interfaces.Repositories;

namespace Pyro.Common.FhirRelease
{
  public class FhirReleaseCache : IFhirReleaseCache
  {
    private readonly IGlobalProperties IGlobalProperties;
    private readonly IFhirReleaseRepository IFhirReleaseRepository;    
    private readonly IApplicationCacheSupport IApplicationCacheSupport;

    private readonly string CacheKey = "GetFhirReleaseByFhirVersion";
    
    public FhirReleaseCache(IFhirReleaseRepository IFhirReleaseRepository, IApplicationCacheSupport IApplicationCacheSupport, IGlobalProperties IGlobalProperties)
    {
      this.IFhirReleaseRepository = IFhirReleaseRepository;      
      this.IApplicationCacheSupport = IApplicationCacheSupport;
      this.IGlobalProperties = IGlobalProperties;
    }

    public DtoFhirRelease GetFhirReleaseByFhirVersion(string FhirVersion)
    {
      if (!IGlobalProperties.ApplicationCacheServicesActive)
      {
        return IFhirReleaseRepository.GetFhirReleaseByFhirVersion(FhirVersion);
      }
      else
      {
        return IApplicationCacheSupport.GetOrSet($"{CacheKey}.{FhirVersion}", () => IFhirReleaseRepository.GetFhirReleaseByFhirVersion(FhirVersion));
      }
    }
    
    public void ClearFhirReleaseForFhirVersion(string FhirVersion)
    {
      if (IGlobalProperties.ApplicationCacheServicesActive)
      {
        IApplicationCacheSupport.RemoveKey($"{CacheKey}.{FhirVersion}");
      }
    }
    
  }
}
