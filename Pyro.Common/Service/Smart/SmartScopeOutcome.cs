using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Service.Smart
{
  public class SmartScopeOutcome : ISmartScopeOutcome
  {
    public OperationOutcome OperationOutcome { get; set; }
    public bool ScopesOK { get; set; }
  }
}
