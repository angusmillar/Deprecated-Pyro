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
    //Blaze_RootUrlStore GetAndOrAddBlaze_RootUrlStore(string ServiceRootUrl)
    DtoRootUrlStore GetPrimaryRootUrlStore();
    DtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);    
  }
}
