using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Interfaces.Services;

namespace Pyro.Engine.Services
{
  public abstract class BaseServices: IBaseServices
  {
    protected readonly IUnitOfWork _UnitOfWork;

     //Constructor for dependency injection
    public BaseServices(IUnitOfWork IUnitOfWork)
    {
      _UnitOfWork = IUnitOfWork;
    }

  }
}
