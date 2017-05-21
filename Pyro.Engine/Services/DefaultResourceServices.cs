using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Engine.Services
{
  public class DefaultResourceServices : ResourceServices, IDefaultResourceServices, IResourceServices, ICommonServices
  {
    //Constructor for dependency injection
    public DefaultResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}
    
    public new FHIRAllTypes SetCurrentResourceType
    {
      set
      {        
        _CurrentResourceType = value;
        _ResourceRepository = Pyro.Common.Tools.RepositorySwitcher.GetRepository(_CurrentResourceType, _UnitOfWork);        
      }
    }
  }
}
