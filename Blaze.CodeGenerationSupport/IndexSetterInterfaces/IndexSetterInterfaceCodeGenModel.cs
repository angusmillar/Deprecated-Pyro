using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport.IndexSetterInterfaces
{
  public class IndexSetterInterfaceCodeGenModel
  {
    public string ClassName { get; set; }
    public string ImplementsInterface { get; set; }
    public string IndexType { get; set; }
    public string GetClassSyntax()
    {
      return string.Format("interface {0} : {1}", ClassName, ImplementsInterface);
    }
    public List<IndexSetterInterfaceMethod> IndexSetterMethodList { get; set; }

    public IndexSetterInterfaceCodeGenModel()
    {
      IndexSetterMethodList = new List<IndexSetterInterfaceMethod>();
    }

  }

  public class IndexSetterInterfaceMethod
  {
    public string IndexType { get; set; }
    public string FhirType { get; set; }
    public string GetMethodSyntax()
    {
      return string.Format("{0} Set{1}({1} {1}, {0} {0});", IndexType, FhirType);
    }
  }
}
