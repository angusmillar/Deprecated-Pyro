using System.Collections.Generic;

namespace Pyro.Common.Compartment
{
  public class DtoServiceCompartmentResourceCached
  {
    public string CompartmentCode { get; set; }
    public string ResourceName { get; set; }
    public ICollection<DtoServiceCompartmentParameterCached> ParamList { get; set; }    
  }  
}
