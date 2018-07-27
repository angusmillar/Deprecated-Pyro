using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthInformation.Organizations
{
  public interface IPyroHealth
  {
    Hl7.Fhir.Model.Organization GetOrganization();
    string GetResourceId();
    string GetName();
  }
}