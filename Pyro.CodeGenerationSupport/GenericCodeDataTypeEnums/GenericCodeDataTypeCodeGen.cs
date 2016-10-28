using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.CodeGenerationSupport.FhirApiIntrospection;
using Hl7.Fhir.Model;

namespace Pyro.CodeGenerationSupport.GenericCodeDataTypeEnums
{
  public class GenericCodeDataTypeCodeGen
  {
    private List<string> _ResourceList;
    private List<FhirApiSearchParameterInfo> _SearchParametersList;
    private List<string> _CodeDataTypeList;
    public List<string> Generate()
    {
      _CodeDataTypeList = new List<string>();
      _ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      _SearchParametersList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();

      foreach (var ResourceName in _ResourceList)
      {
        List<FhirApiSearchParameterInfo> SearchParametersForResource = SearchParameterFilter.GetParametersForResource(ResourceName, _SearchParametersList);
        List<FhirApiSearchParameterInfo> CollectionParameters = SearchParameterFilter.GetIsColectionParameters(true, SearchParametersForResource);
        List<FhirApiSearchParameterInfo> NonCollectionParameters = SearchParameterFilter.GetIsColectionParameters(false, SearchParametersForResource);

        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(NonCollectionParameters);
        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(CollectionParameters);

        foreach (FhirApiSearchParameterInfo CollectionParameter in CollectionParameters)
        {
          FhirSearchParameterSearchPathElement TargetSearchParameter = CollectionParameter.SearchParameterNavigationPathList[CollectionParameter.SearchParameterNavigationPathList.Count - 1];
          if (IsSubclassOfRawGeneric(typeof(Code<>), TargetSearchParameter.DataType))
          {
            var GenericTypeTOfCodeDataType = (((((System.Reflection.PropertyInfo[])(((System.Reflection.TypeInfo)(TargetSearchParameter.DataType.UnderlyingSystemType)).DeclaredProperties))[0]).PropertyType).GenericTypeArguments[0]).FullName;
            _CodeDataTypeList.Add(GenericTypeTOfCodeDataType);
          }

        }

        foreach (FhirApiSearchParameterInfo NonCollectionParameter in NonCollectionParameters)
        {
          FhirSearchParameterSearchPathElement TargetSearchParameter = NonCollectionParameter.SearchParameterNavigationPathList[NonCollectionParameter.SearchParameterNavigationPathList.Count - 1];
          if (IsSubclassOfRawGeneric(typeof(Code<>), TargetSearchParameter.DataType))
          {
            var GenericTypeTOfCodeDataType = (((((System.Reflection.PropertyInfo[])(((System.Reflection.TypeInfo)(TargetSearchParameter.DataType.UnderlyingSystemType)).DeclaredProperties))[0]).PropertyType).GenericTypeArguments[0]).FullName;
            _CodeDataTypeList.Add(GenericTypeTOfCodeDataType);
          }
        }

      }
      //Remove any duplicates we might have.
      _CodeDataTypeList = _CodeDataTypeList.Distinct().ToList();

      //Swap all "+" to "."
      for (int i = 0; i < _CodeDataTypeList.Count; i++)
      {
        _CodeDataTypeList[i] = _CodeDataTypeList[i].Replace("+", ".");
      }
      return _CodeDataTypeList;
    }

    public static bool IsSubclassOfRawGeneric(Type rawGeneric, Type subclass)
    {
      while (subclass != typeof(object))
      {
        var cur = subclass.IsGenericType ? subclass.GetGenericTypeDefinition() : subclass;
        if (rawGeneric == cur)
        {
          return true;
        }
        subclass = subclass.BaseType;
      }
      return false;
    }

  }

}
