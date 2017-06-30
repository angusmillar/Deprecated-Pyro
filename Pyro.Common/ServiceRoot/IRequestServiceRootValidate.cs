using Pyro.Common.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.ServiceRoot
{
  public interface IRequestServiceRootValidate
  {
    IDtoRootUrlStore Validate(string RequestServiceRoot);
  }
}
