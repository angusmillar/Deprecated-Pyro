using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.CodeGenerationSupport.FhirApiIntrospection
{
  public static class FhirApiSearchSupport
  {
    /// <summary>
    /// This method splits the search parameters name away from the Data Type of the parameter in the case of search parameters which are  a choice.
    /// For instance in the Observation resource we have Observation.ValueCodeableConcept meaning the 'Value' property is of type CodeableConcept.
    /// This method splits these so that we can match on the property name 'Value' and deduce it's datatype 'CodeableConcept' 
    /// </summary>
    /// <param name="SearchTargetName"></param>
    /// <returns></returns>
    public static SearchChoiceProperty ResolvePropertyNameMiniusDataType(string SearchTargetName)
    {
      SearchChoiceProperty SearchChoiceProperty = new SearchChoiceProperty();
      var FhirTypeList = Enum.GetValues(typeof(FHIRAllTypes));
      foreach (FHIRAllTypes FhirType in FhirTypeList)
      {
        if (SearchTargetName.ToLower().EndsWith(ModelInfo.FhirTypeToFhirTypeName(FhirType).ToLower()))
        {
          SearchChoiceProperty.Name = SearchTargetName.Substring(0, (SearchTargetName.Length - ModelInfo.FhirTypeToFhirTypeName(FhirType).Length));
          SearchChoiceProperty.Type = ModelInfo.FhirTypeToCsType[ModelInfo.FhirTypeToFhirTypeName(FhirType)];
          return SearchChoiceProperty;
        }
      }
      throw new Exception("Choice Data Type was not resolved to a real FHIR data type. Search Property name was: " + SearchTargetName);
    }

  }
}
