
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Pyro.Common.Enum;

namespace Pyro.CodeGenerationSupport.FhirApiIntrospection
{
  public class FhirApiSearchParameterInfo
  {
    public FhirApiSearchParameterInfo()
    {
      this.SearchParameterNavigationPathList = new List<FhirSearchParameterSearchPathElement>();
      this.ReferanceTargetResourceType = new List<ResourceType>();
    }

    public string Resource { get; set; }
    public SearchParamType SearchParamType { get; set; }
    public DatabaseEnum.DbIndexType DbIndexType { get; set; }
    public Type TargetFhirType
    {
      get
      {
        if (SearchParameterNavigationPathList != null)
          return SearchParameterNavigationPathList[SearchParameterNavigationPathList.Count - 1].DataType;
        else
          return null;
      }
    }
    public Type TargetFhirChoiceType
    {
      get
      {
        if (SearchParameterNavigationPathList != null)
          return SearchParameterNavigationPathList[SearchParameterNavigationPathList.Count - 1].ChoiceDataType;
        else
          return null;
      }
    }
    public Type TargetFhirLogicalType
    {
      get
      {
        if (TargetFhirChoiceType != null)
          return TargetFhirChoiceType;
        else
          return TargetFhirType;
      }
    }
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
    public List<ResourceType> ReferanceTargetResourceType { get; set; }
    public List<FhirSearchParameterSearchPathElement> SearchParameterNavigationPathList { get; set; }
    public List<FhirApiSearchParameterInfo> CompositeSearchParameterList { get; set; }
  }
}
