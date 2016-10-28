using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.Services;

namespace Blaze.Engine.Services
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
