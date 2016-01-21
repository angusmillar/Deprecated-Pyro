using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dip.Interfaces
{
  public interface IFhirServiceNegotiator
  {
    IResourceServices GetService(string type);
  }
}
