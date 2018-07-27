using System.Collections.Generic;

namespace Pyro.Engine.Services.FhirTasks
{
  public interface ITaskRunner
  {
    void Run(IEnumerable<Common.PyroHealthInformation.CodeSystems.PyroFhirServer.Codes> TaskIdentifierToRunList);
  }
}