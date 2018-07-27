using FhirModel = Hl7.Fhir.Model;
using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.PyroHealthInformation
{

  public class PyroFhirResource : IPyroFhirResource
  {

    private readonly IOrganization IOrganization;
    private readonly ICodeSystem ICodeSystem;
    private readonly ITask ITask;
    private readonly IDevice IDevice;

    public PyroFhirResource(IOrganization IOrganization, ICodeSystem ICodeSystem, ITask ITask, IDevice IDevice)
    {
      this.IOrganization = IOrganization;
      this.ICodeSystem = ICodeSystem;
      this.ITask = ITask;
      this.IDevice = IDevice;
    }
    
    public IOrganization Organization => IOrganization;
    public ICodeSystem CodeSystem => ICodeSystem;
    public ITask Task => ITask;
    public IDevice Device => IDevice;
  }
}
