using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthInformation.CodeSystems
{
  public interface IPyroHealth
  {
    string GetCode(PyroHealth.Codes Code);
    Hl7.Fhir.Model.CodeSystem GetCodeSystem();
    Coding GetCoding(PyroHealth.Codes Code);
    Identifier GetIdentifier(PyroHealth.Codes Code);
    string GetResourceId();
    string GetName();
    string GetSystem();
  }
}