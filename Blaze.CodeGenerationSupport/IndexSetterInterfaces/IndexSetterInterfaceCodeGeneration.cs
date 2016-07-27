using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport.IndexSetterInterfaces
{
  public class IndexSetterInterfaceCodeGeneration
  {   
    public List<IndexSetterInterfaceCodeGenModel> Generate()
    {
      List<string> ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      List<FhirApiSearchParameterInfo> _SearchParametersList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();
      HashSet<string> TypeUnquieDic = new HashSet<string>();
      List<string> TypeAnalysisFullList = new List<string>();
      List<IndexSetterInterfaceCodeGenModel> FinalResultList = new List<IndexSetterInterfaceCodeGenModel>();
      
      var DateListFinal = new IndexSetterInterfaceCodeGenModel();
      DateListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.DateIndex]);
      DateListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(DateListFinal);

      var DatePeriodListFinal = new IndexSetterInterfaceCodeGenModel();
      DatePeriodListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.DatePeriodIndex]);
      DatePeriodListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(DatePeriodListFinal);

      var NumberFinal = new IndexSetterInterfaceCodeGenModel();
      NumberFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.NumberIndex]);
      NumberFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(NumberFinal);

      var QuantityListFinal = new IndexSetterInterfaceCodeGenModel();
      QuantityListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.QuantityIndex]);
      QuantityListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(QuantityListFinal);

      var QuantityRangeListFinal = new IndexSetterInterfaceCodeGenModel();
      QuantityRangeListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.QuantityRangeIndex]);
      QuantityRangeListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(QuantityRangeListFinal);

      var ReferenceListFinal = new IndexSetterInterfaceCodeGenModel();
      ReferenceListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.ReferenceIndex]);
      ReferenceListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(ReferenceListFinal);

      var StringListFinal = new IndexSetterInterfaceCodeGenModel();
      StringListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.StringIndex]);
      StringListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(StringListFinal);

      var TokenListFinal = new IndexSetterInterfaceCodeGenModel();
      TokenListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.TokenIndex]);
      TokenListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(TokenListFinal);

      var UriListFinal = new IndexSetterInterfaceCodeGenModel();
      UriListFinal.ClassName = ConstructInterfaceClassName(DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.UriIndex]);
      UriListFinal.ImplementsInterface = DatabaseModelInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(UriListFinal);

      foreach (var ResourceName in ResourceList)
      {
        List<FhirApiSearchParameterInfo> SearchParametersForResource = (from x in _SearchParametersList
                                                                        where x.Resource == ResourceName
                                                                        select x).ToList();

        //SearchParametersForResource = FhirApiSearchParameterInfoFactory.CheckAndRemoveDuplicates(SearchParametersForResource);
        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(SearchParametersForResource);


        

        foreach (FhirApiSearchParameterInfo Parameter in SearchParametersForResource)
        {
        
          TypeAnalysisFullList.Add(string.Format("{0}, {1}, {2}, {3}", Parameter.Resource, Parameter.SearchParamType, Parameter.TargetFhirLogicalType, Parameter.SearchPath));
          string Key = string.Format("{0}, {1}", Parameter.SearchParamType, ConstructInterfaceFhirType(Parameter.TargetFhirLogicalType.Name));
          if (TypeUnquieDic.Add(Key))
          {
            IndexSetterInterfaceMethod MethodInfo = new IndexSetterInterfaceMethod();
            //string ResolvedIndexType = ResolveIndexType(Parameter.SearchParamType.ToString(), ConstructInterfaceFhirType(Parameter.TargetFhirLogicalType.Name));
            MethodInfo.IndexTypeString = DatabaseModelInfo.GetServerSearchIndexTypeString(Parameter);
            MethodInfo.IndexType = DatabaseModelInfo.StringToBlazeIndexTypeDictonary[MethodInfo.IndexTypeString];            
            MethodInfo.FhirType = ConstructInterfaceFhirType(Parameter.TargetFhirLogicalType.Name);
           

            switch (MethodInfo.IndexType)
            {
              case DatabaseModelInfo.BlazeIndexType.DateIndex:                                
                DateListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.DatePeriodIndex:
                DatePeriodListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.NumberIndex:
                NumberFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.QuantityIndex:
                QuantityListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.QuantityRangeIndex:
                QuantityRangeListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.ReferenceIndex:
                ReferenceListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.StringIndex:
                StringListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.TokenIndex:
                TokenListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseModelInfo.BlazeIndexType.UriIndex:
                UriListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(MethodInfo.IndexType.ToString(), (int)MethodInfo.IndexType, typeof(DatabaseModelInfo.BlazeIndexType));                
            }
          }
        }
      }

      //Debug file output
      //----------------------------------------------------------------------------------------------
      //System.IO.File.AppendAllLines(@"C:\temp\BlaseDebugTypeUnquieInfo.csv", TypeUnquieDic);
      //System.IO.File.AppendAllLines(@"C:\temp\BlaseDebugTypeFullInfo.csv", TypeAnalysisFullList);
      //----------------------------------------------------------------------------------------------

      return FinalResultList;

    }
    

    private string ConstructInterfaceClassName(string IndexTypeName)
    {
      return string.Format("I{0}Setter", IndexTypeName);
    }

    private string ConstructInterfaceFhirType(string FhirTypeName)
    {      
      if (FhirTypeName.Contains("Code`1"))
      {
        //Here we need to capture Fhir types of Code<???> and return as just Code, also needs to be uppercase Code not code.
        //example: Hl7.Fhir.Model.Code`1[Hl7.Fhir.Model.AllergyIntolerance+AllergyIntoleranceCategory]        
        return typeof(Code).Name;
      }      
      else
      {
        var SplitOnDot = FhirTypeName.Split('.');
        return SplitOnDot[SplitOnDot.Length - 1];
      }
    }

    //private string ResolveIndexType(string SearchParameterType, string LogicalFhirType)
    //{
    //  if (SearchParameterType == DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.DateIndex])
    //  {
    //    if (LogicalFhirType == ModelInfo.FhirTypeToFhirTypeName(FHIRDefinedType.Timing) || LogicalFhirType == ModelInfo.FhirTypeToFhirTypeName(FHIRDefinedType.Period))
    //    {
    //      return DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.DatePeriodIndex];
    //    }
    //    else
    //    {
    //      return DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.DateIndex];
    //    }
    //  }
    //  else if (SearchParameterType == DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.QuantityIndex])
    //  {
    //    if (LogicalFhirType == ModelInfo.FhirTypeToFhirTypeName(FHIRDefinedType.Range))
    //    {
    //      return DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.QuantityRangeIndex];
    //    }
    //    else
    //    {
    //      return DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.QuantityIndex];
    //    }
    //  }
    //  else
    //  {
    //    return SearchParameterType + DatabaseModelInfo.IndexPrefixText;
    //  }
    //}

  }
}
