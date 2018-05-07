using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Search;
using System.Collections.Generic;

namespace Pyro.Engine.Services
{
  public class ServiceSearchParameterService : IServiceSearchParameterService
  {
    private readonly IServiceSearchParameterRepository IServiceSearchParameterRepository;

    public ServiceSearchParameterService(IServiceSearchParameterRepository IServiceSearchParameterRepository)
    {
      this.IServiceSearchParameterRepository = IServiceSearchParameterRepository;
    }

    public List<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType)
    {
      return IServiceSearchParameterRepository.GetServiceSearchParametersLightForResource(ResourceType);
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false)
    {
      return IServiceSearchParameterRepository.GetServiceSearchParametersHeavy(CustomOnly);
    }

    public List<DtoServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      return IServiceSearchParameterRepository.GetServiceSearchParametersHeavyForResource(ResourceType);
    }

    public DtoServiceSearchParameterHeavy AddServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      return IServiceSearchParameterRepository.AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy);
    }

    public DtoServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(DtoServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      return IServiceSearchParameterRepository.UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy);
    }

    public void DeleteServiceSearchParameters(int Id)
    {
      IServiceSearchParameterRepository.DeleteServiceSearchParameters(Id);
    }
  }
}
