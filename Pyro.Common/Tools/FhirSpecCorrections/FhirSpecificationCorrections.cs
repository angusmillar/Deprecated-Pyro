using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hl7.Fhir.Model.ModelInfo;

namespace Pyro.Common.Tools.FhirSpecCorrections
{
  public class FhirSpecificationCorrections : IFhirSpecificationCorrections
  {

    public void SearchParameterCorrections(SearchParamDefinition SearchParamDefinition)
    {

      //################################################################################################
      //This expression was "StructureDefinition.context" which hit a backbone element and not the correct child
      //Added .type to get the correct code value
      if (SearchParamDefinition.Name == "ext-context" &&
        SearchParamDefinition.Expression == "StructureDefinition.context" &&
        SearchParamDefinition.Resource == ResourceType.StructureDefinition.GetLiteral())
      {
        SearchParamDefinition.Expression = "StructureDefinition.context.type";
      }

      //################################################################################################
      //This corrects the SearchParameter _profile which does not have any resource target which it should have as it is a 
      //reference type parameter. It needs all resource types as its target. This changed in R4 from STU3, it was type Uri in STU3 
      //and therefore needed no targets.
      if (SearchParamDefinition.Name == "_profile" &&
        SearchParamDefinition.Expression == "Resource.meta.profile" &&
        (SearchParamDefinition.Target == null || SearchParamDefinition.Target.Count() == 0))
      {
        SearchParamDefinition.Target = new ResourceType[] { ResourceType.StructureDefinition };               
      }

    }


    public void SearchParameterCorrections(SearchParameter SearchParameter)
    {
      //################################################################################################
      //This expression was "StructureDefinition.context" which hit a backbone element and not the correct child
      //Added .type to get the correct code value
      if (SearchParameter.Name == "ext-context" &&
        SearchParameter.Expression == "StructureDefinition.context" &&
        SearchParameter.Base.Contains(ResourceType.StructureDefinition))
      {
        SearchParameter.Expression = "StructureDefinition.context.type";
      }


      //################################################################################################
      //This is an correction to the FHIR specification SearchParameter definitions found in the  
      //definitions.xml.zip file required for STU3, I believe it is fixed in R4 and it should be removed once tested that it is not hit.
      string IncorrectCanonicalUrl = "http://hl7.org/fhir/SearchParameter/Observation-code";
      string CorrectCanonicalUrl = "http://hl7.org/fhir/SearchParameter/clinical-code";
      var BrokenComponetList = SearchParameter.Component.Where(z => z.Definition == IncorrectCanonicalUrl);
      foreach (var BrokenComponet in BrokenComponetList)
      {
        BrokenComponet.Definition = CorrectCanonicalUrl;
      }

      //################################################################################################
      //This corrects the SearchParameter _profile which does not have any resource target which it should have as it is a 
      //reference type parameter. It needs all resource types as its target. This changed in R4 from STU3, it was type Uri in STU3 
      //and therefore needed no targets.
      if (SearchParameter.Name == "_profile" &&
        SearchParameter.Expression == "Resource.meta.profile" &&
        (SearchParameter.Target == null || SearchParameter.Target.Count() == 0))
      {        
        SearchParameter.Target = new List<ResourceType?>() { ResourceType.StructureDefinition }; 
      }
    }
  }
}
