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
    public string PropertyName { get; set; }
    public bool IsCollection { get; set; }
    public FhirSearchParameterSearchPathElement ChildElement { get; set; }
    public FhirSearchParameterSearchPathElement ParentElement { get; set; }

    /// <summary>
    /// Returns a new node element at the end of the path with it's parent set
    /// </summary>
    /// <returns></returns>
    public FhirSearchParameterSearchPathElement CreateChildElement()
    {      
     this.ChildElement = new FhirSearchParameterSearchPathElement(RecursiveFindChildElement(this));
     return this.ChildElement;
    }

    private FhirSearchParameterSearchPathElement RecursiveFindChildElement(FhirSearchParameterSearchPathElement Element)
    {      
      if (Element.ChildElement == null)
      {
        return Element;        
      }
      else
      {
        return RecursiveFindChildElement(Element.ChildElement);
      }      
    }

    public FhirSearchParameterSearchPathElement(FhirSearchParameterSearchPathElement Parent)
    {
      this.ParentElement = Parent;
    }

    public FhirSearchParameterSearchPathElement()
    {      
    }

  }
}
 