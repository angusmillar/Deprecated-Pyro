using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Runtime.Serialization;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Search
{
  
  public class DtoServiceSearchParameterLight : IServiceSearchParameterLight
  {
    public int Id { get; set; }
    public string Resource { get; set; }
    public string Name { get; set; }
    public SearchParamType Type { get; set; }
    public string Expression { get; set; }

    public List<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    public DtoServiceSearchParameterLight() { }

  }
}
