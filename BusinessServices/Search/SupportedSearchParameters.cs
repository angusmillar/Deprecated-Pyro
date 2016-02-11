using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using BusinessEntities;
using BusinessEntities.Search;

namespace Blaze.Engine.Search
{
  //This class holds the information about what Search parameters are supported
  //As new search functionality is added to the blaze server new instances 
  //of this object will be hard coded into the supported search parameters list
  //That list is always cross referenced against new search parameters that are sent into the server via URL
  //and parsed into DtoSearchParameterBase object instances.
  public class SupportedSearchParameters
  {
    public DtoEnums.Search.SearchParameterName Name { get; set; }
    public DtoEnums.SupportedFhirResource Resource { get; set; }
    public SearchParamType SearchParameterType { get; set; }
    public List<SearchModifierType> ModifierList { get; set; }
    public List<ResourceType> TypeModifierResourceList { get; set; }
    public List<SearchPrefixType> PrefixList { get; set; }    

    private static void AddSupportedParametersForAllResources(List<SupportedSearchParameters> List)
    {
      var Page = new SupportedSearchParameters();
      Page.Name = DtoEnums.Search.SearchParameterName.Page;
      Page.Resource = DtoEnums.SupportedFhirResource.Resource;
      Page.SearchParameterType = SearchParamType.Number;
      Page.ModifierList = new List<SearchModifierType>();
      Page.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      Page.PrefixList = new List<SearchPrefixType>();
      List.Add(Page);

      var _Id = new SupportedSearchParameters();
      _Id.Name = DtoEnums.Search.SearchParameterName._Id;
      _Id.Resource = DtoEnums.SupportedFhirResource.Resource;
      _Id.SearchParameterType = SearchParamType.String;
      _Id.ModifierList = new List<SearchModifierType>();
      _Id.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      _Id.PrefixList = new List<SearchPrefixType>();
      List.Add(_Id);

    }

    public static List<SupportedSearchParameters> GetSupportedParametersForResourceTypeList(DtoEnums.SupportedFhirResource ResourceType)
    {
      var List = new List<SupportedSearchParameters>();
      AddSupportedParametersForAllResources(List);
      switch (ResourceType)
      {
        case DtoEnums.SupportedFhirResource.Patient:
          {
            var Family = new SupportedSearchParameters();
            Family.Name = DtoEnums.Search.SearchParameterName.Family;
            Family.Resource = ResourceType;
            Family.SearchParameterType = SearchParamType.String;
            Family.ModifierList = new List<SearchModifierType>();
            Family.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Family.PrefixList = new List<SearchPrefixType>();
            List.Add(Family);

            var Given = new SupportedSearchParameters();
            Given.Name = DtoEnums.Search.SearchParameterName.Given;
            Given.Resource = ResourceType;
            Given.SearchParameterType = SearchParamType.String;
            Given.ModifierList = new List<SearchModifierType>();
            Given.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Given.PrefixList = new List<SearchPrefixType>();            
            List.Add(Given);

            var Name = new SupportedSearchParameters();
            Name.Name = DtoEnums.Search.SearchParameterName.Name;
            Name.Resource = ResourceType;
            Name.SearchParameterType = SearchParamType.String;
            Name.ModifierList = new List<SearchModifierType>();
            Name.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Name.PrefixList = new List<SearchPrefixType>();
            List.Add(Name);

            var Phonetic = new SupportedSearchParameters();
            Phonetic.Name = DtoEnums.Search.SearchParameterName.Phonetic;
            Phonetic.Resource = ResourceType;
            Phonetic.SearchParameterType = SearchParamType.String;
            Phonetic.ModifierList = new List<SearchModifierType>();
            Phonetic.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Phonetic.PrefixList = new List<SearchPrefixType>();
            List.Add(Phonetic);

            var Identifier = new SupportedSearchParameters();
            Identifier.Name = DtoEnums.Search.SearchParameterName.Identifier;
            Identifier.Resource = ResourceType;
            Identifier.SearchParameterType = SearchParamType.Token;
            Identifier.ModifierList = new List<SearchModifierType>();
            Identifier.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Identifier.PrefixList = new List<SearchPrefixType>();
            List.Add(Identifier);

            var Active = new SupportedSearchParameters();
            Active.Name = DtoEnums.Search.SearchParameterName.Active;
            Active.Resource = ResourceType;
            Active.SearchParameterType = SearchParamType.Token;
            Active.ModifierList = new List<SearchModifierType>();
            Active.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Active.PrefixList = new List<SearchPrefixType>();
            List.Add(Active);

          }
          break;
        case DtoEnums.SupportedFhirResource.ValueSet:
          {
            var Description = new SupportedSearchParameters();
            Description.Name = DtoEnums.Search.SearchParameterName.Description;
            Description.Resource = ResourceType;
            Description.SearchParameterType = SearchParamType.String;
            Description.ModifierList = new List<SearchModifierType>() { SearchModifierType.Contains, SearchModifierType.Exact};
            Description.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Description.PrefixList = new List<SearchPrefixType>();
            List.Add(Description);

            var Code = new SupportedSearchParameters();
            Code.Name = DtoEnums.Search.SearchParameterName.Code;
            Code.Resource = ResourceType;
            Code.SearchParameterType = SearchParamType.Token;
            Code.ModifierList = new List<SearchModifierType>();
            Code.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Code.PrefixList = new List<SearchPrefixType>();
            List.Add(Code);

            var Date = new SupportedSearchParameters();
            Date.Name = DtoEnums.Search.SearchParameterName.Date;
            Date.Resource = ResourceType;
            Date.SearchParameterType = SearchParamType.Date;
            Date.ModifierList = new List<SearchModifierType>();
            Date.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Date.PrefixList = new List<SearchPrefixType>() 
            { 
              SearchPrefixType.Equal,
              SearchPrefixType.Greater,
              SearchPrefixType.GreaterOrEqual,
              SearchPrefixType.Less,
              SearchPrefixType.LessOrEqual,
              SearchPrefixType.NotEqual
            };
            List.Add(Date);

            var Context = new SupportedSearchParameters();
            Context.Name = DtoEnums.Search.SearchParameterName.Context;
            Context.Resource = ResourceType;
            Context.SearchParameterType = SearchParamType.Token;
            Context.ModifierList = new List<SearchModifierType>();
            Context.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Context.PrefixList = new List<SearchPrefixType>();
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
