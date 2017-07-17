using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Common.BusinessEntities.Dto.Search
{
  public class SearchParameterInclude
  {
    public FHIRAllTypes SourceResourceType { get; set; }
    public DtoServiceSearchParameterLight SearchParameter { get; set; }
    public FHIRAllTypes? SearchParameterTargetResourceType { get; set; }
    public bool IsRecurse { get; set; }
  }
}
