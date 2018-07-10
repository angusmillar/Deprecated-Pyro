using Hl7.Fhir.Model;
using System.Net;

namespace Pyro.Common.Service.Trigger
{
  public interface ITriggerOutcome
  {
    bool Report { get; set; }
    HttpStatusCode HttpStatusCode { get; set; }
    Resource Resource { get; set; }
  }
}
