using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public interface IPyroTask
  {
    string GetCode(PyroTask.Codes Code);
    Hl7.Fhir.Model.CodeSystem GetCodeSystem();
    Coding GetCoding(PyroTask.Codes Code);
    Identifier GetIdentifier(PyroTask.Codes Code);
    string GetSystem();
    string GetResourceId();
    string GetName();
  }
}