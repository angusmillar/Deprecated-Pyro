using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Runtime.Serialization;
using Pyro.Common.ServiceRoot;

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
    public List<DtoServiceSearchParameterComposite> CompositeList { get; set; }

    public DtoServiceSearchParameterLight()
    {
      this.TargetResourceTypeList = new List<IServiceSearchParameterTargetResource>();
      this.CompositeList = new List<DtoServiceSearchParameterComposite>();
    }

  }
}
