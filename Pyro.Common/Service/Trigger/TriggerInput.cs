using System.Collections.Generic;
using Hl7.Fhir.Model;
using Pyro.Common.DtoEntity;
using Pyro.Common.Enum;

namespace Pyro.Common.Service.Trigger
{
  public class TriggerInput : ITriggerInput
  {    
    public RestEnum.CrudOperationType CrudOperationType { get; set; }    
    public ResourceType ResourceType { get; set; }
    public string InboundResourceId { get; set; }
    public Resource InboundResource { get; set; }
    public List<DtoTokenIndex> DbTokenIndexList { get; set; }
  }
}
