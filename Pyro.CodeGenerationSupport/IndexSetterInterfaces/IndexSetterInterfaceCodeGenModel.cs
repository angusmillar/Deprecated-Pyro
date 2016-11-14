using System.Collections.Generic;
using Pyro.Common.Enum;

namespace Pyro.CodeGenerationSupport.IndexSetterInterfaces
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
    public DatabaseEnum.DbIndexType IndexType { get; set; }    
    public string IndexTypeString { get; set; }
    public string FhirTypeQualified { get; set; }
    public string FhirTypeName { get; set; }
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
        if (IndexType == DatabaseEnum.DbIndexType.ReferenceIndex)
        {          
          return string.Format("{0} Set{1}({2} {1}, {0} {0}, {3} {4}, {5} {6});",DatabaseEnum.DbIndexTypeToStringDictonary[IndexType], FhirTypeName, FhirTypeQualified, IDtoFhirRequestUri, FhirRequestUri, ICommonRepository, CommonRepository);
        }
        else
        {
          // DateTimeIndex SetFhirDateTime(FhirDateTime FhirDateTime, DateTimeIndex DateTimeIndex);
          return string.Format("{0} Set{1}({2} {1}, {0} {0});", DatabaseEnum.DbIndexTypeToStringDictonary[IndexType], FhirTypeName, FhirTypeQualified);
        }
      }
    }


  }
}
