using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Services;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;
using Pyro.Engine.RepositorySupport;

namespace Pyro.Engine.Services
{
  public class DefaultResourceServices : BaseResourceServices, IDefaultResourceServices, IBaseResourceServices
  {
    //Constructor for dependency injection
    public DefaultResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}

    public new FHIRAllTypes SetCurrentResourceType
    {
      set
      {
        _CurrentResourceType = value;
        _ResourceRepository = RepositorySwitcher.GetRepository(_CurrentResourceType, _UnitOfWork);
      }
    }
  }
}
