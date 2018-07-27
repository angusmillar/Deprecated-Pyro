using Pyro.Common.Attributes;
using Pyro.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FhirModel = Hl7.Fhir.Model;
using Pyro.Common.PyroHealthInformation.Tasks;

namespace Pyro.Common.PyroHealthInformation
{
  public class Task : ITask
  {
    private readonly ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions;

    public Task(ILoadFhirSpecificationDefinitions ILoadFhirSpecificationDefinitions)
    {
      this.ILoadFhirSpecificationDefinitions = ILoadFhirSpecificationDefinitions;
    }

    public ILoadFhirSpecificationDefinitions LoadFhirSpecificationDefinitionsTask => ILoadFhirSpecificationDefinitions;

  }
}
