using System.Collections.Generic;
using Hl7.Fhir.Model;


namespace Pyro.Common.Interfaces.Dto
{
  public interface IServiceSearchParameter
  {
    int Id { get; set; }
    string Description { get; set; }
    string Expression { get; set; }
    string Name { get; set; }
    string Resource { get; set; }
    SearchParamType Type { get; set; }
    string Url { get; set; }
    string XPath { get; set; }    
    ICollection<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
  }
}