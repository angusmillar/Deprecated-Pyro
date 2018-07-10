using Hl7.Fhir.Model;

namespace Pyro.Common.Service.Trigger
{
  public class TriggerOutcome : ITriggerOutcome
  {
    public bool Report { get; set; }
    public System.Net.HttpStatusCode HttpStatusCode { get; set; }
    public Resource Resource { get; set; }    
  }
}
