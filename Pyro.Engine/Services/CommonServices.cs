using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Engine.Services
{
  public class CommonServices : BaseServices, ICommonServices 
  {     
    public CommonServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}

    public IDtoRootUrlStore GetPrimaryServiceRootUrl()
    { 
      return _UnitOfWork.CommonRepository.GetPrimaryRootUrlStore();            
    }

    public IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl)
    {
      return _UnitOfWork.CommonRepository.SetPrimaryRootUrlStore(RootUrl);
    }

    public IList<DtoServiceSearchParameterLight> GetServiceSearchParametersForResource(string ResourceType)
    {
      return _UnitOfWork.CommonRepository.GetServiceSearchParametersForResource(ResourceType);
    }


  }
}
