using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameterGeneric
  {
    public IList<Tuple<string,string>> ParameterList { get; set; }
    public IList<Tuple<string, Hl7.Fhir.Rest.SortOrder>> Sort { get; }

    public DtoSearchParameterGeneric() { }
    public DtoSearchParameterGeneric(Hl7.Fhir.Rest.SearchParams SearchParams)
    {
      this.ParameterList = SearchParams.Parameters;
      this.Sort = SearchParams.Sort;
    }
  }
}
