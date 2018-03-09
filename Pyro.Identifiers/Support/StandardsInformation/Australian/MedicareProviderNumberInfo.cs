using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Support.StandardsInformation.Australian
{
  public class MedicareProviderNumberInfo
  {
    /// <summary>
    ///e.g: ORC-16.9.1 (Ordering Provider)
    /// </summary>
    public string AssigningAuthority { get { return "AUSHICPR"; } }
    
    /// <summary>
    /// System for a Medicare Number in a FHIR identitfer data type
    /// </summary>
    public string FhirSystemUri { get { return "http://ns.electronichealth.net.au/id/XXXXXX"; } }


  }
}
