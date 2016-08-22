using System.Collections.Generic;
using Blaze.Common.Enum;
using Hl7.Fhir.Model;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSupportedSearchParameters
  {
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRDefinedType Resource { get; set; }
    public DatabaseEnum.DbIndexType DbSearchParameterType { get; set; }
    public bool IsCollection { get; set; }
    public bool DbPropertyName { get; set; }
    public List<FhirSearchEnum.SearchModifierType> ModifierList { get; set; }
    public List<ResourceType> TypeModifierResourceList { get; set; }
    public List<FhirSearchEnum.SearchPrefixType> PrefixList { get; set; }

    public static void AddSupportedParametersForAllResources(List<DtoSupportedSearchParameters> List)
    {
      var Page = new DtoSupportedSearchParameters();
      Page.Name = FhirSearchEnum.SearchParameterNameType.page;
      Page.Resource = FHIRDefinedType.Resource;
      Page.DbSearchParameterType = DatabaseEnum.DbIndexType.NumberIndex;
      Page.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      Page.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      Page.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(Page);

      var _Id = new DtoSupportedSearchParameters();
      _Id.Name = FhirSearchEnum.SearchParameterNameType._id;
      _Id.Resource = FHIRDefinedType.Resource;
      _Id.DbSearchParameterType = DatabaseEnum.DbIndexType.StringIndex;
      _Id.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Id.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      _Id.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Id);

    }


  }
}
