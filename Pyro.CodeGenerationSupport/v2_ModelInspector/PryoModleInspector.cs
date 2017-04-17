using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;
using Hl7.Fhir.FhirPath;
using Hl7.FhirPath;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Introspection;

namespace Pyro.CodeGenerationSupport.v2_ModelInspector
{
  public static class PryoModleInspector
  {
    public static void Inspector()
    {
      var ResourceList = ModelInfo.SupportedResources;
      foreach(string ResourceName in ResourceList)
      {
        ModelInspector Model = new ModelInspector();
        ClassMapping Map = Model.FindClassMappingForResource(ResourceName);
        




        //var nav = new PocoNavigator(resource);
        var SearchParameters = ModelInfo.SearchParameters.Where(r => r.Resource == ResourceName && !String.IsNullOrEmpty(r.Expression));
        foreach(var Search in SearchParameters)
        {
          
        }

      }
    }
  }
}
