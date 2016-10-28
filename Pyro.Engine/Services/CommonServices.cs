using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.Dto;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Engine.Services
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



  }
}
