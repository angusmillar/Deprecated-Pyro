using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;

namespace Pyro.DataLayer.DbModel.Entity
{
  /// <summary>
  /// This class holds the servers active FHIR Compartments
  /// For example the Patient or Encounter Compartments
  /// </summary>
  public class _ServiceCompartment : ConfigEntityBase
  {
    public string Url { get; set; }
    public string CompartmentDefinitionResourceId { get; set; }
    public string CompartmentDefinitionResourceVersion { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }    
    public ICollection<_ServiceCompartmentResource> ResourceList { get; set; }

    public _ServiceCompartment()
    {
      this.ResourceList = new HashSet<_ServiceCompartmentResource>();
    }
  }
}
