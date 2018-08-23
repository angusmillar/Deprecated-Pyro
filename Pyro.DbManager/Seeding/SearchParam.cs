using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.DataLayer;
using Pyro.Common.Service.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.Seeding
{
  public class SearchParam : I_ServiceSearchParameter
  {
    public SearchParam()
    {
      TargetResourceTypeList = new List<SParamResource>();
    }

    public string Description { get; set; }
    public string Url { get; set; }
    public string XPath { get; set; }
    public SearchParameterService.SearchParameterServiceType SearchParameterServiceType { get; set; }

    public int Id { get; set; }
    public string Resource { get; set; }
    public string Name { get; set; }
    public SearchParamType Type { get; set; }
    public string Expression { get; set; }    
    public bool IsIndexed { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public string SearchParameterResourceId { get; set; }
    public string SearchParameterResourceVersion { get; set; }
    public PublicationStatus Status { get; set; }

    public List<SParamResource> TargetResourceTypeList { get; set; }
  }
}
