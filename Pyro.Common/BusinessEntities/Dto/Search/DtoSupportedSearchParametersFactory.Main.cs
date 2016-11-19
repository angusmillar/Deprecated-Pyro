using System.Collections.Generic;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;

namespace Pyro.Common.BusinessEntities.Search
{
  public partial class DtoSupportedSearchParametersFactory
  {

    public static List<DtoSupportedSearchParameters> GetSupportedParametersBase()
    {
      var List = new List<DtoSupportedSearchParameters>();
      DtoSupportedSearchParameters SupportedSearchParameter = null;

      SupportedSearchParameter = new DtoSupportedSearchParameters();
      SupportedSearchParameter.Name = FhirSearchEnum.SearchParameterNameType._format;
      SupportedSearchParameter.Resource = null;
      SupportedSearchParameter.IsDbCollection = false;
      SupportedSearchParameter.DbPropertyName = string.Empty;
      SupportedSearchParameter.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
      SupportedSearchParameter.SearchParameterType = SearchParamType.String;
      SupportedSearchParameter.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      SupportedSearchParameter.TypeModifierResourceList = new List<string>();
      SupportedSearchParameter.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(SupportedSearchParameter);

      return List;
    }

    public static List<DtoSupportedSearchParameters> GetSupportedParametersForBundleReturn()
    {
      var List = new List<DtoSupportedSearchParameters>();

      var Page = new DtoSupportedSearchParameters();
      Page.Name = FhirSearchEnum.SearchParameterNameType.page;
      Page.Resource = null;
      Page.IsDbCollection = false;
      Page.DbPropertyName = string.Empty;
      Page.DbSearchParameterType = DatabaseEnum.DbIndexType.NumberIndex;
      Page.SearchParameterType = SearchParamType.Number;
      Page.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      Page.TypeModifierResourceList = new List<string>();
      Page.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(Page);

      var _Sort = new DtoSupportedSearchParameters();
      _Sort.Name = FhirSearchEnum.SearchParameterNameType._sort;
      _Sort.Resource = FHIRAllTypes.Resource;
      _Sort.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
      _Sort.SearchParameterType = SearchParamType.String;
      _Sort.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Sort.TypeModifierResourceList = new List<string>();
      _Sort.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Sort);

      return List;
    }

    public static List<DtoSupportedSearchParameters> GetSupportedParametersForBaseResource()
    {
      var List = new List<DtoSupportedSearchParameters>();

      var _Id = new DtoSupportedSearchParameters();
      _Id.Name = FhirSearchEnum.SearchParameterNameType._id;
      _Id.Resource = FHIRAllTypes.Resource;
      _Id.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
      _Id.SearchParameterType = SearchParamType.String;
      _Id.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Id.TypeModifierResourceList = new List<string>();
      _Id.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Id);

      return List;
    }


  }
}