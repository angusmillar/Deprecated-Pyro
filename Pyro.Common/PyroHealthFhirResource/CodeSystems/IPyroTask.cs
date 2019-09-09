using Hl7.Fhir.Model;

namespace Pyro.Common.PyroHealthFhirResource.CodeSystems
{
  public interface IPyroTask : IPyroCodeSystem
  {
    string GetCode(PyroTask.Codes Code);    
    Coding GetCoding(PyroTask.Codes Code);
    Identifier GetIdentifier(PyroTask.Codes Code);
    bool HasCode(string Code);    

  }
}