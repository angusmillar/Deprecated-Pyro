using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Enum;


namespace Pyro.Common.BusinessEntities.FhirOperation
{
  public class OperationClass
  {
    public FhirOperationEnum.OperationScope Scope { get; set; }
    public FhirOperationEnum.OperationType Type { get; set; }
  }
}
