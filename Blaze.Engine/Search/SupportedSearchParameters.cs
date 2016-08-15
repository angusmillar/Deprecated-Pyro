using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Enum;

namespace Blaze.Engine.Search
{
  //This class holds the information about what Search parameters are supported
  //As new search functionality is added to the blaze server new instances 
  //of this object will be hard coded into the supported search parameters list
  //That list is always cross referenced against new search parameters that are sent into the server via URL
  //and parsed into DtoSearchParameterBase object instances.
  public class SupportedSearchParameters
  {
    public FhirSearchEnum.SearchParameterNameType Name { get; set; }
    public FHIRDefinedType Resource { get; set; }
    public SearchParamType SearchParameterType { get; set; }
    public bool IsCollection { get; set; }
    public bool DbPropertyName { get; set; }
    public List<FhirSearchEnum.SearchModifierType> ModifierList { get; set; }
    public List<ResourceType> TypeModifierResourceList { get; set; }
    public List<FhirSearchEnum.SearchPrefixType> PrefixList { get; set; }    

    private static void AddSupportedParametersForAllResources(List<SupportedSearchParameters> List)
    {
      var Page = new SupportedSearchParameters();
      Page.Name = FhirSearchEnum.SearchParameterNameType.page;
      Page.Resource = FHIRDefinedType.Resource;
      Page.SearchParameterType = SearchParamType.Number;
      Page.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      Page.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      Page.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(Page);

      var _Id = new SupportedSearchParameters();
      _Id.Name = FhirSearchEnum.SearchParameterNameType._id;
      _Id.Resource = FHIRDefinedType.Resource;
      _Id.SearchParameterType = SearchParamType.String;
      _Id.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
      _Id.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      _Id.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
      List.Add(_Id);

    }

    public static List<SupportedSearchParameters> GetSupportedParametersForResourceTypeList(FHIRDefinedType ResourceType)
    {
      var List = new List<SupportedSearchParameters>();
      AddSupportedParametersForAllResources(List);
      switch (ResourceType)
      {
        case FHIRDefinedType.Patient:
          {
            var Family = new SupportedSearchParameters();
            Family.Name = FhirSearchEnum.SearchParameterNameType.family;
            Family.Resource = ResourceType;
            Family.SearchParameterType = SearchParamType.String;
            Family.ModifierList = new List<FhirSearchEnum.SearchModifierType>();            
            Family.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();            
            Family.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();            
            List.Add(Family);

            var Given = new SupportedSearchParameters();
            Given.Name = FhirSearchEnum.SearchParameterNameType.given;
            Given.Resource = ResourceType;
            Given.SearchParameterType = SearchParamType.String;
            Given.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Given.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Given.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();            
            List.Add(Given);

            var Name = new SupportedSearchParameters();
            Name.Name = FhirSearchEnum.SearchParameterNameType.name;
            Name.Resource = ResourceType;
            Name.SearchParameterType = SearchParamType.String;
            Name.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Name.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Name.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Name);

            var Phonetic = new SupportedSearchParameters();
            Phonetic.Name = FhirSearchEnum.SearchParameterNameType.phonetic;
            Phonetic.Resource = ResourceType;
            Phonetic.SearchParameterType = SearchParamType.String;
            Phonetic.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Phonetic.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Phonetic.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Phonetic);

            var Identifier = new SupportedSearchParameters();
            Identifier.Name = FhirSearchEnum.SearchParameterNameType.identifier;
            Identifier.Resource = ResourceType;
            Identifier.SearchParameterType = SearchParamType.Token;
            Identifier.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Identifier.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Identifier.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Identifier);

            var Active = new SupportedSearchParameters();
            Active.Name = FhirSearchEnum.SearchParameterNameType.active;
            Active.Resource = ResourceType;
            Active.SearchParameterType = SearchParamType.Token;
            Active.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Active.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Active.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Active);

          }
          break;
        case FHIRDefinedType.ValueSet:
          {
            var Description = new SupportedSearchParameters();
            Description.Name = FhirSearchEnum.SearchParameterNameType.description;
            Description.Resource = ResourceType;
            Description.SearchParameterType = SearchParamType.String;
            Description.ModifierList = new List<FhirSearchEnum.SearchModifierType>() { FhirSearchEnum.SearchModifierType.Contains, FhirSearchEnum.SearchModifierType.Exact};
            Description.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Description.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Description);

            var Code = new SupportedSearchParameters();
            Code.Name = FhirSearchEnum.SearchParameterNameType.code;
            Code.Resource = ResourceType;
            Code.SearchParameterType = SearchParamType.Token;
            Code.ModifierList = new List<FhirSearchEnum.SearchModifierType>();
            Code.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Code.PrefixList = new List<FhirSearchEnum.SearchPrefixType>();
            List.Add(Code);

            var Date = new SupportedSearchParameters();
            Date.Name = FhirSearchEnum.SearchParameterNameType.date;
            Date.Resource = ResourceType;
            Date.SearchParameterType = SearchParamType.Date;
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

            var Context = new SupportedSearchParameters();
            Context.Name = FhirSearchEnum.SearchParameterNameType.context;
            Context.Resource = ResourceType;
            Context.SearchParameterType = SearchParamType.Token;
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
