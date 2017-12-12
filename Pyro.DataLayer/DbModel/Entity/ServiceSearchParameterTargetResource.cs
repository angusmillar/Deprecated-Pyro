using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.Interfaces.Dto;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.DbModel.Entity
{
  /// <summary>
  /// This class is a one-to-one match to the FHIR API SearchParamDefinition's 'Target'
  /// which is the ResourceType list for Reference type search parameters
  /// </summary>
  public class _ServiceSearchParameterTargetResource : ModelBase, IServiceSearchParameterTargetResource
  {
    public virtual _ServiceSearchParameter ServiceSearchParameter { get; set; }
    public int ServiceSearchParameterId { get; set; }

    public ResourceType ResourceType { get; set; }
  }
}
