using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Engine.Search.SearchTermTypes;
using BusinessEntities;

namespace Blaze.Engine.Search
{
  //This class holds the information about what Search terms are supported
  //As new search functionality is added to the blaze server new instances 
  //of this object will be hard coded into the Supported search term List
  //That list is always cross referenced against new search terms that are sent into the server via URL
  //and parsed into SearchTerm object instances.
  public class SupportedSearchTerm
  {
    public Blaze.Engine.Support.EnumSupport.SearchTermName Name { get; set; }
    public DtoEnums.SupportedFhirResource Resource { get; set; }
    public SearchParamType SearchParameterType { get; set; }
    public List<SearchModifierType> ModifierList { get; set; }
    public List<ResourceType> TypeModifierResourceList { get; set; }
    public List<SearchPrefixType> PrefixList { get; set; }    

    private static void AddSupportedTermsForAllResources(List<SupportedSearchTerm> List)
    {
      var Page = new SupportedSearchTerm();
      Page.Name = Support.EnumSupport.SearchTermName.Page;
      Page.Resource = DtoEnums.SupportedFhirResource.Resource;
      Page.SearchParameterType = SearchParamType.Number;
      Page.ModifierList = new List<SearchModifierType>();
      Page.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      Page.PrefixList = new List<SearchPrefixType>();
      List.Add(Page);

      var _Id = new SupportedSearchTerm();
      _Id.Name = Support.EnumSupport.SearchTermName._Id;
      _Id.Resource = DtoEnums.SupportedFhirResource.Resource;
      _Id.SearchParameterType = SearchParamType.String;
      _Id.ModifierList = new List<SearchModifierType>();
      _Id.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      _Id.PrefixList = new List<SearchPrefixType>();
      List.Add(_Id);

    }

    public static List<SupportedSearchTerm> GetSupportedTermList(DtoEnums.SupportedFhirResource ResourceType)
    {
      var List = new List<SupportedSearchTerm>();
      AddSupportedTermsForAllResources(List);
      switch (ResourceType)
      {
        case DtoEnums.SupportedFhirResource.Patient:
          {
            var Family = new SupportedSearchTerm();
            Family.Name = Support.EnumSupport.SearchTermName.Family;
            Family.Resource = ResourceType;
            Family.SearchParameterType = SearchParamType.String;
            Family.ModifierList = new List<SearchModifierType>();
            Family.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Family.PrefixList = new List<SearchPrefixType>();
            List.Add(Family);

            var Given = new SupportedSearchTerm();
            Given.Name = Support.EnumSupport.SearchTermName.Given;
            Given.Resource = ResourceType;
            Given.SearchParameterType = SearchParamType.String;
            Given.ModifierList = new List<SearchModifierType>();
            Given.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Given.PrefixList = new List<SearchPrefixType>();            
            List.Add(Given);

            var Name = new SupportedSearchTerm();
            Name.Name = Support.EnumSupport.SearchTermName.Name;
            Name.Resource = ResourceType;
            Name.SearchParameterType = SearchParamType.String;
            Name.ModifierList = new List<SearchModifierType>();
            Name.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Name.PrefixList = new List<SearchPrefixType>();
            List.Add(Name);

            var Phonetic = new SupportedSearchTerm();
            Phonetic.Name = Support.EnumSupport.SearchTermName.Phonetic;
            Phonetic.Resource = ResourceType;
            Phonetic.SearchParameterType = SearchParamType.String;
            Phonetic.ModifierList = new List<SearchModifierType>();
            Phonetic.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Phonetic.PrefixList = new List<SearchPrefixType>();
            List.Add(Phonetic);

            var Identifier = new SupportedSearchTerm();
            Identifier.Name = Support.EnumSupport.SearchTermName.Identifier;
            Identifier.Resource = ResourceType;
            Identifier.SearchParameterType = SearchParamType.Token;
            Identifier.ModifierList = new List<SearchModifierType>();
            Identifier.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Identifier.PrefixList = new List<SearchPrefixType>();
            List.Add(Identifier);

            var Active = new SupportedSearchTerm();
            Active.Name = Support.EnumSupport.SearchTermName.Active;
            Active.Resource = ResourceType;
            Active.SearchParameterType = SearchParamType.Token;
            Active.ModifierList = new List<SearchModifierType>();
            Active.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Active.PrefixList = new List<SearchPrefixType>();
            List.Add(Active);

          }
          break;
        default:
          break;
      }
      return List;
    }  
  }
}
