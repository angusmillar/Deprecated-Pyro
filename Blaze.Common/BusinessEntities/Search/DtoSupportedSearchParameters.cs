using System;
using System.Collections.Generic;
using System.Linq;
using Blaze.Common.Enum;
using Hl7.Fhir.Model;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSupportedSearchParameters
  {
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRDefinedType Resource { get; set; }
    public DatabaseEnum.BlazeIndexType DbSearchParameterType { get; set; }
    public bool IsCollection { get; set; }
    public bool DbPropertyName { get; set; }
    public List<FhirSearchEnum.SearchModifierType> ModifierList { get; set; }
    public List<ResourceType> TypeModifierResourceList { get; set; }
    public List<FhirSearchEnum.SearchPrefixType> PrefixList { get; set; }

    private static void AddSupportedParametersForAllResources(List<DtoSupportedSearchParameters> List)
    {
      var Page = new DtoSupportedSearchParameters();
      Page.Name = FhirSearchEnum.SearchParameterNameType.page;
      Page.Resource = FHIRDefinedType.Resource;
      Page.DbSearchParameterType = DatabaseEnum.BlazeIndexType.NumberIndex;
      Page.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      Page.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      Page.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(Page);

      var _Id = new DtoSupportedSearchParameters();
      _Id.Name = FhirSearchEnum.SearchParameterNameType._id;
      _Id.Resource = FHIRDefinedType.Resource;
      _Id.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
      _Id.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Id.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      _Id.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Id);

    }

    public static List<DtoSupportedSearchParameters> GetSupportedParametersForResourceTypeList(FHIRDefinedType ResourceType)
    {
      var List = new List<DtoSupportedSearchParameters>();
      AddSupportedParametersForAllResources(List);
      switch (ResourceType)
      {
        case FHIRDefinedType.Patient:
          {
            var Family = new DtoSupportedSearchParameters();
            Family.Name = FhirSearchEnum.SearchParameterNameType.family;
            Family.Resource = ResourceType;
            Family.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
            Family.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Family.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Family.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Family);

            var Given = new DtoSupportedSearchParameters();
            Given.Name = FhirSearchEnum.SearchParameterNameType.given;
            Given.Resource = ResourceType;
            Given.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
            Given.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Given.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Given.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Given);

            var Name = new DtoSupportedSearchParameters();
            Name.Name = FhirSearchEnum.SearchParameterNameType.name;
            Name.Resource = ResourceType;
            Name.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
            Name.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Name.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Name.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Name);

            var Phonetic = new DtoSupportedSearchParameters();
            Phonetic.Name = FhirSearchEnum.SearchParameterNameType.phonetic;
            Phonetic.Resource = ResourceType;
            Phonetic.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
            Phonetic.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Phonetic.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Phonetic.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Phonetic);

            var Identifier = new DtoSupportedSearchParameters();
            Identifier.Name = FhirSearchEnum.SearchParameterNameType.identifier;
            Identifier.Resource = ResourceType;
            Identifier.DbSearchParameterType = DatabaseEnum.BlazeIndexType.TokenIndex;
            Identifier.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Identifier.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Identifier.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Identifier);

            var Active = new DtoSupportedSearchParameters();
            Active.Name = FhirSearchEnum.SearchParameterNameType.active;
            Active.Resource = ResourceType;
            Active.DbSearchParameterType = DatabaseEnum.BlazeIndexType.TokenIndex;
            Active.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Active.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Active.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Active);

          }
          break;
        case FHIRDefinedType.ValueSet:
          {
            var Description = new DtoSupportedSearchParameters();
            Description.Name = FhirSearchEnum.SearchParameterNameType.description;
            Description.Resource = ResourceType;
            Description.DbSearchParameterType = DatabaseEnum.BlazeIndexType.StringIndex;
            Description.ModifierList = new List<FhirSearchEnum.SearchModifierType>() { FhirSearchEnum.SearchModifierType.Contains, FhirSearchEnum.SearchModifierType.Exact };
            Description.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Description.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Description);

            var Code = new DtoSupportedSearchParameters();
            Code.Name = FhirSearchEnum.SearchParameterNameType.code;
            Code.Resource = ResourceType;
            Code.DbSearchParameterType = DatabaseEnum.BlazeIndexType.TokenIndex;
            Code.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Code.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Code.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Code);

            var Date = new DtoSupportedSearchParameters();
            Date.Name = FhirSearchEnum.SearchParameterNameType.date;
            Date.Resource = ResourceType;
            Date.DbSearchParameterType = DatabaseEnum.BlazeIndexType.DateIndex;
            Date.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Date.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Date.PrefixList = new List<FhirSearchEnum.SearchPrefixType>()
            {
              FhirSearchEnum.SearchPrefixType.Equal,
              FhirSearchEnum.SearchPrefixType.Greater,
              FhirSearchEnum.SearchPrefixType.GreaterOrEqual,
              FhirSearchEnum.SearchPrefixType.Less,
              FhirSearchEnum.SearchPrefixType.LessOrEqual,
              FhirSearchEnum.SearchPrefixType.NotEqual
            };
            List.Add(Date);

            var Context = new DtoSupportedSearchParameters();
            Context.Name = FhirSearchEnum.SearchParameterNameType.context;
            Context.Resource = ResourceType;
            Context.DbSearchParameterType = DatabaseEnum.BlazeIndexType.TokenIndex;
            Context.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Context.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Context.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Context);
          }
          break;
        default:
          break;
      }
      return List;
    }
  }
}
