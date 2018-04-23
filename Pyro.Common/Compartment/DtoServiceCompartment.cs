using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Compartment
{
  public class DtoServiceCompartment
  {
    public int Id { get; set; }
    public string Url { get; set; }
    public string CompartmentDefinitionResourceId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public ICollection<DtoServiceCompartmentResource> ResourceList { get; set; }

    public DtoServiceCompartment()
    {
      this.ResourceList = new HashSet<DtoServiceCompartmentResource>();
    }
  }

  public class DtoServiceCompartmentResource
  {    
    public int Id { get; set; }
    public string Code { get; set; }
    public string Param { get; set; }
    public virtual DtoServiceCompartment ServiceCompartment { get; set; }
    public int _ServiceCompartmentId { get; set; }
  }
}
