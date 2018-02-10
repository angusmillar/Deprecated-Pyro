using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Smart.Scopes
{
  public class SmartScope : ISmartScope
  {    
    public SmartEnum.Entity Entity { get; set; }
    public FHIRAllTypes Resource { get; set; }
    public SmartEnum.Action Action { get; set; }
    
  }
}
