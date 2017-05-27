using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.BusinessEntities.Dto
{
  public class DtoServiceSearchParameterHeavy : DtoServiceSearchParameterLight, IServiceSearchParameter
  {
    //public int Id { get; set; }
    public string Description { get; set; }
    //public string Expression { get; set; }
    //public string Name { get; set; }
    //public string Resource { get; set; }
    //public SearchParamType Type { get; set; }
    public string Url { get; set; }
    public string XPath { get; set; }
    public string SearchParameterResourceId { get; set; }
    public string SearchParameterResourceVersion { get; set; }
    //public List<IServiceSearchParameterTargetResource> TargetResourceTypeList { get; set; }
    public bool IsIndexed { get; set; }
    public PublicationStatus Status { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    
  }
}
