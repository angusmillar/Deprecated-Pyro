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
    public List<FhirSearchEnum.SearchModifierType> ModifierList { get; set; }
    public List<string> TypeModifierResourceList { get; set; }
    public List<FhirSearchEnum.SearchPrefixType> PrefixList { get; set; }

    public static void AddSupportedParametersForAllResources(List<DtoSupportedSearchParameters> List)
    {
      var Page = new DtoSupportedSearchParameters();
      Page.Name = FhirSearchEnum.SearchParameterNameType.page;
      Page.Resource = FHIRAllTypes.Resource;
      Page.DbSearchParameterType = DatabaseEnum.DbIndexType.NumberIndex;
      Page.SearchParameterType = SearchParamType.Number;
      Page.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      Page.TypeModifierResourceList = new List<string>();
      Page.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(Page);

      var _Id = new DtoSupportedSearchParameters();
      _Id.Name = FhirSearchEnum.SearchParameterNameType._id;
      _Id.Resource = FHIRAllTypes.Resource;
      _Id.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
      _Id.SearchParameterType = SearchParamType.String;
      _Id.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Id.TypeModifierResourceList = new List<string>();
      _Id.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Id);

      var _Sort = new DtoSupportedSearchParameters();
      _Sort.Name = FhirSearchEnum.SearchParameterNameType._sort;
      _Sort.Resource = FHIRAllTypes.Resource;
      _Sort.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
      _Sort.SearchParameterType = SearchParamType.String;
      _Sort.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Sort.TypeModifierResourceList = new List<string>();
      _Sort.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Sort);

    }


  }
}
