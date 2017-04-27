using System.Collections.Generic;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSupportedSearchParameters
  {
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRAllTypes? Resource { get; set; }
    public DatabaseEnum.DbIndexType DbSearchParameterType { get; set; }
    public SearchParamType SearchParameterType { get; set; }
    public bool IsDbCollection { get; set; }
    public string DbPropertyName { get; set; }
    public List<SearchParameter.SearchModifierCode> ModifierList { get; set; }
    public List<string> TypeModifierResourceList { get; set; }
    public List<SearchParameter.SearchComparator> PrefixList { get; set; }
    
  }
}
