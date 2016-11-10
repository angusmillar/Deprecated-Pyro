using System.Collections.Generic;
using Pyro.Common.Enum;
using Hl7.Fhir.Model;

namespace Pyro.Common.BusinessEntities.Search
{
  public partial class DtoSupportedSearchParametersFactory
  {
    public static List<DtoSupportedSearchParameters> GetSupportedParametersForHistory()
    {
      var List = new List<DtoSupportedSearchParameters>();
      DtoSupportedSearchParameters SupportedSearchParameter = null;

      SupportedSearchParameter = new DtoSupportedSearchParameters();
      SupportedSearchParameter.Name = FhirSearchEnum.SearchParameterNameType.page;
      SupportedSearchParameter.Resource = null;
      SupportedSearchParameter.IsDbCollection = false;
      SupportedSearchParameter.DbPropertyName = string.Empty;
      SupportedSearchParameter.DbSearchParameterType = DatabaseEnum.DbIndexType.NumberIndex;
      SupportedSearchParameter.SearchParameterType = SearchParamType.Number;
      SupportedSearchParameter.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      SupportedSearchParameter.TypeModifierResourceList = new List<string>();
      SupportedSearchParameter.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(SupportedSearchParameter);

      return List;
    }
  }
}