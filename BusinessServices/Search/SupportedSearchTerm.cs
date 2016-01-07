using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Engine.Search.SearchTermTypes;

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
    public ResourceType Resource { get; set; }
    public Conformance.SearchParamType SearchParameterType { get; set; }
    public List<SearchModifierType> ModifierList { get; set; }
    public List<ResourceType> TypeModifierResourceList { get; set; }
    public List<SearchPrefixType> PrefixList { get; set; }    

    private static void AddSupportedTermsForAllResources(List<SupportedSearchTerm> List)
    {
      var Page = new SupportedSearchTerm();
      Page.Name = Support.EnumSupport.SearchTermName.Page;
      Page.Resource = ResourceType.Resource;
      Page.SearchParameterType = Conformance.SearchParamType.Number;
      Page.ModifierList = new List<SearchModifierType>();
      Page.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
      Page.PrefixList = new List<SearchPrefixType>();
      List.Add(Page);

    }

    public static List<SupportedSearchTerm> GetSupportedTermList(ResourceType ResourceType)
    {
      var List = new List<SupportedSearchTerm>();
      AddSupportedTermsForAllResources(List);
      switch (ResourceType)
      {
        case ResourceType.Patient:
          {
            var Family = new SupportedSearchTerm();
            Family.Name = Support.EnumSupport.SearchTermName.Family;
            Family.Resource = ResourceType;
            Family.SearchParameterType = Conformance.SearchParamType.String;
            Family.ModifierList = new List<SearchModifierType>();
            Family.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Family.PrefixList = new List<SearchPrefixType>();
            List.Add(Family);

            var Given = new SupportedSearchTerm();
            Given.Name = Support.EnumSupport.SearchTermName.Given;
            Given.Resource = ResourceType;
            Given.SearchParameterType = Conformance.SearchParamType.String;
            Given.ModifierList = new List<SearchModifierType>();
            Given.TypeModifierResourceList = new List<Hl7.Fhir.Model.ResourceType>();
            Given.PrefixList = new List<SearchPrefixType>();
            
            List.Add(Given);

          }
          break;
        default:
          break;
      }
      return List;
    }  
  }
}
