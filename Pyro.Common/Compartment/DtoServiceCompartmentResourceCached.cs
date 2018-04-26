using System.Collections.Generic;

namespace Pyro.Common.Compartment
{
  public class DtoServiceCompartmentCached
  {
    public string CompartmentCode { get; set; }
    public string ResourceName { get; set; }
    public ICollection<DtoServiceCompartmentResourceCached> ParamList { get; set; }    
  }

  public class DtoServiceCompartmentResourceCached
  {
    public string Param { get; set; }
  }
}
