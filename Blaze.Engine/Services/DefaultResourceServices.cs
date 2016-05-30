using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.Services;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Engine.RepositorySupport;

namespace Blaze.Engine.Services
{
  public class DefaultResourceServices : BaseResourceServices, IDefaultResourceServices, IBaseResourceServices
  {
    //Constructor for dependency injection
    public DefaultResourceServices(IUnitOfWork IUnitOfWork)
      : base(IUnitOfWork){}

    public new FHIRDefinedType SetCurrentResourceType
    {
      set
      {
        _CurrentResourceType = value;
        _ResourceRepository = RepositorySwitcher.GetRepository(_CurrentResourceType, _UnitOfWork);
      }
    }
  }
}
