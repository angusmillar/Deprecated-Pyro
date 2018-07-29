using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public interface IPyroFhirServer : IPyroCodeSystem
  {    
    string GetCode(PyroFhirServer.Codes Code);
    Coding GetCoding(PyroFhirServer.Codes Code);
    Identifier GetIdentifier(PyroFhirServer.Codes Code);
    void SetProtectedMetaTag(Resource Resource);
    
  }
}