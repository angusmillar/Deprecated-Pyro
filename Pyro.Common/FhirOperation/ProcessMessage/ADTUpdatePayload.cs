using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.FhirOperation.ProcessMessage
{
  public class ADTUpdatePayload
  {
    public ADTUpdatePayload()
    {
      this.AllergyIntoleranceList = new List<AllergyIntolerance>();
    }
    public MessageHeader MessageHeader { get; set; }
    public Identifier PrimaryPatientIdentifer { get; set; }
    public Patient Patient { get; set; }
    public Identifier PrimaryEncounterIdentifer { get; set; }
    public Encounter Encounter { get; set; }
    public List<AllergyIntolerance> AllergyIntoleranceList { get; set; }
    public Provenance Provenance { get; set; }
  }
}
