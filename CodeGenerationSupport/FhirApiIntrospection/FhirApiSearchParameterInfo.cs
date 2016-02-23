
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace CodeGenerationSupport.FhirApiIntrospection
{
  public class FhirApiSearchParameterInfo
  {
    public string Resource { get; set; }
    public SearchParamType SearchParamType { get; set; }
    public string SearchName { get; set; }
    public string SearchPath { get; set; }
    public bool SearchPathHasIndexes
    {
      get
      {
        return (SearchPath.Contains('[') && SearchPath.Contains(']'));
      }
    }
    public bool IsCollection { get; set; }
    public bool IsChoice { get; set; }
    public List<FhirApiSearchParameterInfo> CompositeSearchParameterList { get; set; }
  }
}
