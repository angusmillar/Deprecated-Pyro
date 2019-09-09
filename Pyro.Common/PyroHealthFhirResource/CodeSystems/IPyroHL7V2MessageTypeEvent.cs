using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public interface IPyroHL7V2MessageTypeEvent : IPyroCodeSystem
  {
    string GetCode(PyroHL7V2MessageTypeEvent.Codes Code);
    Coding GetCoding(PyroHL7V2MessageTypeEvent.Codes Code);
    Identifier GetIdentifier(PyroHL7V2MessageTypeEvent.Codes Code);
    bool HasCode(string Code);
    
  }
}