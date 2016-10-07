using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterUriValue : DtoSearchParameterValueBase
  {
    public Uri Value { get; set; }
  }
}
