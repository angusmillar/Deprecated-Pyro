using System.Collections.Generic;

namespace Pyro.Engine.Services.FhirTasks
{
  public interface ITaskRunner
  {
    void Run(IEnumerable<Common.PyroHealthFhirResource.CodeSystems.PyroFhirServer.Codes> TaskIdentifierToRunList);
  }
}