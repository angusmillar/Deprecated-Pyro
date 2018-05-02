using System.Net;
using Hl7.Fhir.Model;

namespace Pyro.Engine.TriggerServices
{
  public interface ITriggerOutcome
  {
    TriggerOutcome.TriggerOutcomeType TriggerOutcomeResult { get; set; }
    HttpStatusCode HttpStatusCode { get; set; }
    Resource Resource { get; set; }
  }
}