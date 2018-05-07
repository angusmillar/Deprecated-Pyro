using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.Dto;

namespace Pyro.Common.Search
{
  public class DtoServiceSearchParameterHeavy : DtoServiceSearchParameterLight, IServiceSearchParameter
  {
    public string Description { get; set; }
    public string Url { get; set; }
    public string XPath { get; set; }
    public string SearchParameterResourceId { get; set; }
    public string SearchParameterResourceVersion { get; set; }   
    public bool IsIndexed { get; set; }
    public PublicationStatus Status { get; set; }
    public DateTimeOffset LastUpdated { get; set; }

  }
}
