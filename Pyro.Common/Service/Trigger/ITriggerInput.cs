using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;

namespace Pyro.Common.Service.Trigger
{
  public interface ITriggerInput
  {
    RestEnum.CrudOperationType CrudOperationType { get; set; }
    List<DtoTokenIndex> DbTokenIndexList { get; set; }
    ResourceType ResourceType { get; set; }
    string InboundResourceId { get; set; }
    Resource InboundResource { get; set; }        
  }
}