using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Common.Interfaces.Repositories
{
  public interface ICommonRepository
  {
    DtoRootUrlStore GetPrimaryRootUrlStore();
    DtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
  }
}
