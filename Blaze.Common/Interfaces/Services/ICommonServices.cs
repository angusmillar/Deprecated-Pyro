using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.Common.Interfaces.Dto;

namespace Blaze.Common.Interfaces.Services
{
  public interface ICommonServices
  {
    IDtoRootUrlStore GetPrimaryServiceRootUrl();
    IDtoRootUrlStore SetPrimaryRootUrlStore(string RootUrl);
  }
}
