using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.DbModel.Entity
{
  /// <summary>
  /// This class holds the servers active FHIR Compartment Resource list and the 
  /// Search parameters that define that Compartment for each resource
  /// </summary>
  public class _ServiceCompartmentResource : ModelBase
  {
    public virtual _ServiceCompartment ServiceCompartment { get; set; }
    public string Code { get; set; }
    public string Param { get; set; }
    public int _ServiceCompartmentId { get; set; }
  }
}
