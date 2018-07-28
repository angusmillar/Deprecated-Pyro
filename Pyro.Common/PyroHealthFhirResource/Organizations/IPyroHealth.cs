using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.Organizations
{
  public interface IPyroHealth
  {
    Hl7.Fhir.Model.Organization GetOrganization();
    string GetResourceId();
    string GetName();
  }
}