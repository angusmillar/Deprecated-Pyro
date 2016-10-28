using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameterUriValue : DtoSearchParameterValueBase
  {
    public Uri Value { get; set; }
  }
}
