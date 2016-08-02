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
    public DatabaseModelInfo.BlazeIndexType IndexType { get; set; }
    public string IndexTypeString { get; set; }
    public string FhirType { get; set; }
    public string CustomeIndexMethod { get; set; }

    public string GetMethodSyntax()
    {
      if (!string.IsNullOrWhiteSpace(CustomeIndexMethod))
      {
        return this.CustomeIndexMethod;
      }
      else
      {
        string IDtoFhirRequestUri = "IDtoFhirRequestUri";
        string FhirRequestUri = "FhirRequestUri";
        string ICommonRepository = "ICommonRepository";
        string CommonRepository = "CommonRepository";
        if (IndexType == DatabaseModelInfo.BlazeIndexType.ReferenceIndex)
        {
          //ReferenceIndex SetResourceReference(ResourceReference ResourceReference, ReferenceIndex ReferenceIndex, IDtoFhirRequestUri FhirRequestUri, CommonRepository CommonRepository);
          return string.Format("{0} Set{1}({1} {1}, {0} {0}, {2} {3}, {4} {5});", DatabaseModelInfo.BlazeIndexTypeToStringDictonary[IndexType], FhirType, IDtoFhirRequestUri, FhirRequestUri, ICommonRepository, CommonRepository);
        }
        else
        {
          return string.Format("{0} Set{1}({1} {1}, {0} {0});", DatabaseModelInfo.BlazeIndexTypeToStringDictonary[IndexType], FhirType);
        }
      }
    }


  }
}
