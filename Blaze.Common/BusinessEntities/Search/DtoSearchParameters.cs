using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameters
  {
    public DtoEnums.SupportedFhirResource ResourceTarget { get; set; }
    public List<DtoSearchParameterBase> SearchParametersList { get; set; }
  }
}
