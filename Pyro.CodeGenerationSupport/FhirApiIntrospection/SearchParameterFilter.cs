using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.CodeGenerationSupport.FhirApiIntrospection
{
  public static class SearchParameterFilter
  {
    public static List<FhirApiSearchParameterInfo> GetParametersForResource(string ResourceName, List<FhirApiSearchParameterInfo> SearchParameterList)
    {
      return (from x in SearchParameterList where x.Resource == ResourceName select x).ToList();
    }

    public static List<FhirApiSearchParameterInfo> GetIsColectionParameters(bool IsCollection, List<FhirApiSearchParameterInfo> SearchParameterList)
    {
      return (from x in SearchParameterList where x.IsCollection == IsCollection select x).ToList();
    }



  }
}
