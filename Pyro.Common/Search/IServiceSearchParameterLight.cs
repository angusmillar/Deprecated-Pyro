using System.Collections.Generic;
using System.Runtime.Serialization;
using Hl7.Fhir.Model;
using Pyro.Common.ServiceRoot;

namespace Pyro.Common.Search
{
  public interface IServiceSearchParameterLight
  {
    string Expression { get; set; }
    int Id { get; set; }
    string Name { get; set; }
    string Resource { get; set; }
    List<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    List<DtoServiceSearchParameterComposite> CompositeList { get; set; }
    SearchParamType Type { get; set; }
    
  }
}