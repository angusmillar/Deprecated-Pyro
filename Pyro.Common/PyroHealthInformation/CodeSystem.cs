using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;
using Pyro.Common.PyroHealthInformation.CodeSystems;

namespace Pyro.Common.PyroHealthInformation
{
  public class CodeSystem : ICodeSystem
  {
    private readonly IPyroFhirServer IPyroFhirServer;
    private readonly IPyroTask IPyroTask;
    private readonly IPyroHealth IPyroHealth;

    public CodeSystem(IPyroFhirServer IPyroFhirServer, IPyroTask IPyroTask, IPyroHealth IPyroHealth)
    {
      this.IPyroFhirServer = IPyroFhirServer;
      this.IPyroTask = IPyroTask;
      this.IPyroHealth = IPyroHealth;
    }

    public IPyroFhirServer PyroFhirServerCodeSystem => IPyroFhirServer;
    public IPyroTask PyroTaskCodeSystem => IPyroTask;
    public IPyroHealth PyroHealthCodeSystem => IPyroHealth;    
  }
}
