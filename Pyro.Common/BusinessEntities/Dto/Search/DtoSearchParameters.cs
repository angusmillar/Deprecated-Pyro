using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameters
  {
    public FHIRAllTypes? ResourceTarget { get; set; }
    public Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public List<DtoSearchParameterBase> SearchParametersList { get; set; }
    public List<DtoUnspportedSearchParameter> UnspportedSearchParameterList { get; set; }
    public List<Sort> SortList { get; set; }
    public int RequiredPageNumber { get; set; }
    public int? CountOfRecordsRequested { get; set; }
    public string Format { get; set; }
    public SummaryType Summary { get; set; }

    public class Sort
    {
      public DtoServiceSearchParameterLight Value { get; set; }
      public Hl7.Fhir.Rest.SortOrder SortOrderType { get; set; }
    }
  }
}
