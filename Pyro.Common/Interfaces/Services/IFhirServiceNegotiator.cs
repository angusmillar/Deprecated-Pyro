using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pyro.Common.Interfaces.Services
{
  public interface IFhirServiceNegotiator
  {
    IBaseResourceServices GetService(string type);
    ICommonServices GetService();
  }
}
