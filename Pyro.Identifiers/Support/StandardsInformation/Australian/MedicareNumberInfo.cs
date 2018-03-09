using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Support.StandardsInformation.Australian
{
  public class MedicareNumberInfo
  {
    /// <summary>
    ///Assigning Authority code for MedicareNumber in a HL7 V2 CX data type,(i.e PID-3.4 for instance)
    /// </summary>
    public string HL7V2AssigningAuthority { get { return "AUSHIC"; } }
    
    /// <summary>
    ///Identifier Type Code for MedicareNumber in a HL7 V2 CX data type,(i.e PID-3.5 for instance)
    /// </summary>
    public string HL7V2IdentifierTypeCode { get { return "MC"; } }

    /// <summary>
    /// System for a Medicare Number in a FHIR identitfer data type
    /// </summary>
    public string FhirSystemUri { get { return "http://ns.electronichealth.net.au/id/medicare-number"; } }

    
  }
}
