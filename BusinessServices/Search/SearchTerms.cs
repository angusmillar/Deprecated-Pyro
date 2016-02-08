using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities;

namespace Blaze.Engine.Search
{
  public class SearchTerms
  {    
    public DtoEnums.SupportedFhirResource ResourceTarget { get; set; }
    public List<SearchTermTypes.SearchTermBase> SearchTermList { get; set; }
  }
}
