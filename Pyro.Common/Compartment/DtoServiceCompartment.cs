using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Compartment
{
  public class DtoServiceCompartment : DtoEntity.DtoConfigEntityBase
  {    
    public string Url { get; set; }
    public string CompartmentDefinitionResourceId { get; set; }
    public string CompartmentDefinitionResourceVersion { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }    
    public ICollection<DtoServiceCompartmentResource> ResourceList { get; set; }

    public DtoServiceCompartment()
    {
      this.ResourceList = new HashSet<DtoServiceCompartmentResource>();
    }
  }
  
}
