using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Compartment
{
  public class DtoServiceCompartmentCached
  {
    public int Id { get; set; }    
    public string CompartmentDefinitionResourceId { get; set; }
    public string CompartmentDefinitionResourceVersion { get; set; }
    public string Code { get; set; }    
  }
}
