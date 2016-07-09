using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport.FhirApiIntrospection
{
  public class FhirSearchParameterSearchPathElement
  {
    public Type DataType { get; set; }
    public Type ChoiceDataType { get; set; }
    public string PropertyName { get; set; }
    public bool IsCollection { get; set; }   
  }
}
 