using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Search;

namespace Pyro.Engine.Services
{
  public class CommonServices : BaseServices, ICommonServices
  {
    public CommonServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork) { }

    public IDtoRootUrlStore GetPrimaryServiceRootUrl()
    {
      return _UnitOfWork.CommonRepository.GetPrimaryRootUrlStore();
    }

    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      return _UnitOfWork.CommonRepository.SetPrimaryRootUrlStore(RootUrl);
    }

    public List<ServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType)
    {
      return _UnitOfWork.CommonRepository.GetServiceSearchParametersLightForResource(ResourceType);
    }

    public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavy(bool CustomOnly = false)
    {
      return _UnitOfWork.CommonRepository.GetServiceSearchParametersHeavy(CustomOnly);
    }

    public List<ServiceSearchParameterHeavy> GetServiceSearchParametersHeavyForResource(string ResourceType)
    {
      return _UnitOfWork.CommonRepository.GetServiceSearchParametersHeavyForResource(ResourceType);
    }

    public ServiceSearchParameterHeavy AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      return _UnitOfWork.CommonRepository.AddServiceSearchParametersHeavy(ServiceSearchParameterHeavy);
    }

    public ServiceSearchParameterHeavy UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy ServiceSearchParameterHeavy)
    {
      return _UnitOfWork.CommonRepository.UpdateServiceSearchParametersHeavy(ServiceSearchParameterHeavy);
    }

    public void DeleteServiceSearchParameters(int Id)
    {
      _UnitOfWork.CommonRepository.DeleteServiceSearchParameters(Id);
    }

  }
}
