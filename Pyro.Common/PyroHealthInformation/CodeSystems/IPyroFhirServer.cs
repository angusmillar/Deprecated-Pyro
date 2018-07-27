using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthInformation.CodeSystems
{
  public interface IPyroFhirServer
  {
    string GetCode(PyroFhirServer.Codes Code);
    Hl7.Fhir.Model.CodeSystem GetCodeSystem();
    Coding GetCoding(PyroFhirServer.Codes Code);
    Identifier GetIdentifier(PyroFhirServer.Codes Code);
    string GetSystem();
    string GetResourceId();
    string GetName();
    void SetProtectedMetaTag(Resource Resource);

  }
}