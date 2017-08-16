using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Search
{
  public class DtoServiceSearchParameterTargetResource : IServiceSearchParameterTargetResource
  {
    public ResourceType ResourceType { get; set; }
  }
}
