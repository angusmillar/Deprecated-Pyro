using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public interface IPyroHealth : IPyroCodeSystem
  {
    string GetCode(PyroHealth.Codes Code);    
    Coding GetCoding(PyroHealth.Codes Code);
    Identifier GetIdentifier(PyroHealth.Codes Code);    
  }
}