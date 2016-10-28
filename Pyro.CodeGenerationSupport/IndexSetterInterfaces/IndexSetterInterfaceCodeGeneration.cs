using System;
using System.Collections.Generic;
using System.Linq;
using Pyro.Common.Database;
using Pyro.Common.Enum;
using Pyro.CodeGenerationSupport.FhirApiIntrospection;
using Hl7.Fhir.Model;

namespace Pyro.CodeGenerationSupport.IndexSetterInterfaces
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
      DateListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DateIndex]);
      DateListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(DateListFinal);

      var DateTimeListFinal = new IndexSetterInterfaceCodeGenModel();
      DateTimeListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DateTimeIndex]);
      DateTimeListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(DateTimeListFinal);

      var DateTimePeriodListFinal = new IndexSetterInterfaceCodeGenModel();
      DateTimePeriodListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DateTimePeriodIndex]);
      DateTimePeriodListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(DateTimePeriodListFinal);

      var NumberFinal = new IndexSetterInterfaceCodeGenModel();
      NumberFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.NumberIndex]);
      NumberFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(NumberFinal);

      var QuantityListFinal = new IndexSetterInterfaceCodeGenModel();
      QuantityListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.QuantityIndex]);
      QuantityListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(QuantityListFinal);

      var QuantityRangeListFinal = new IndexSetterInterfaceCodeGenModel();
      QuantityRangeListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.QuantityRangeIndex]);
      QuantityRangeListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(QuantityRangeListFinal);

      var ReferenceListFinal = new IndexSetterInterfaceCodeGenModel();
      ReferenceListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.ReferenceIndex]);
      ReferenceListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(ReferenceListFinal);

      var StringListFinal = new IndexSetterInterfaceCodeGenModel();
      StringListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.StringIndex]);
      StringListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(StringListFinal);

      var TokenListFinal = new IndexSetterInterfaceCodeGenModel();
      TokenListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.TokenIndex]);
      TokenListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(TokenListFinal);

      var UriListFinal = new IndexSetterInterfaceCodeGenModel();
      UriListFinal.ClassName = ConstructInterfaceClassName(DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.UriIndex]);
      UriListFinal.ImplementsInterface = StaticDatabaseInfo.IndexSetterBaseInterfaceName;
      FinalResultList.Add(UriListFinal);

      CustomTokenInterfaceMethodForCodeTType(TokenListFinal);
      TypeAnalysisFullList.Add("Resource, Search Parameter Name, Search Parameter Type, DB Index Type, IsCollection, Logical Target Type, Path");
      foreach (var ResourceName in ResourceList)
      {
        List<FhirApiSearchParameterInfo> SearchParametersForResource = (from x in _SearchParametersList
                                                                        where x.Resource == ResourceName
                                                                        select x).ToList();

        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(SearchParametersForResource);
        foreach (FhirApiSearchParameterInfo Parameter in SearchParametersForResource)
        {
          if (Parameter.Resource == "DiagnosticReport" && Parameter.SearchName == "date")
          {
            //debug only
          }
          TypeAnalysisFullList.Add(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", Parameter.Resource, Parameter.SearchName, Parameter.SearchParamType, DatabaseModelInfo.GetServerSearchIndexTypeString(Parameter), Parameter.IsCollection.ToString(), Parameter.TargetFhirLogicalType, Parameter.SearchPath));
          //string Key = string.Format("{0}, {1}", Parameter.DbIndexType, ConstructInterfaceFhirType(Parameter.TargetFhirLogicalType.Name));
          string Key = string.Format("{0}, {1}", DatabaseModelInfo.GetServerSearchIndexTypeString(Parameter), ConstructInterfaceFhirType(Parameter.TargetFhirLogicalType.Name));
          if (TypeUnquieDic.Add(Key))
          {
            IndexSetterInterfaceMethod MethodInfo = new IndexSetterInterfaceMethod();
            MethodInfo.IndexTypeString = DatabaseModelInfo.GetServerSearchIndexTypeString(Parameter);
            MethodInfo.IndexType = DatabaseEnum.StringToDbIndexTypeDictonary[MethodInfo.IndexTypeString];
            MethodInfo.FhirType = ConstructInterfaceFhirType(Parameter.TargetFhirLogicalType.Name);


            switch (MethodInfo.IndexType)
            {
              case DatabaseEnum.DbIndexType.DateIndex:
                DateListFinal.IndexSetterMethodList.Add(MethodInfo);
                DatabaseModelInfo.GetServerSearchIndexTypeString(Parameter);
                break;
              case DatabaseEnum.DbIndexType.DateTimeIndex:
                DateTimeListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
                DateTimePeriodListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.NumberIndex:
                NumberFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.QuantityIndex:
                QuantityListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.QuantityRangeIndex:
                QuantityRangeListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.ReferenceIndex:
                ReferenceListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.StringIndex:
                StringListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.TokenIndex:
                TokenListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              case DatabaseEnum.DbIndexType.UriIndex:
                UriListFinal.IndexSetterMethodList.Add(MethodInfo);
                break;
              default:
                throw new System.ComponentModel.InvalidEnumArgumentException(MethodInfo.IndexType.ToString(), (int)MethodInfo.IndexType, typeof(DatabaseEnum.DbIndexType));
            }
          }
        }
      }

      //Debug file output
      //----------------------------------------------------------------------------------------------      
      string FilePath = @"C:\temp\BlaseDebugTypeFullInfo.csv";
      if (System.IO.File.Exists(FilePath))
        System.IO.File.Delete(FilePath);
      System.IO.File.AppendAllLines(FilePath, TypeAnalysisFullList);
      //----------------------------------------------------------------------------------------------




      return FinalResultList;

    }

    private static void CustomTokenInterfaceMethodForCodeTType(IndexSetterInterfaceCodeGenModel TokenListFinal)
    {
      IndexSetterInterfaceMethod CustomTokenCodeMethodInfo = new IndexSetterInterfaceMethod();
      CustomTokenCodeMethodInfo.CustomeIndexMethod = string.Format("TokenIndex SetCodeT(Element Element, TokenIndex TokenIndex);");
      CustomTokenCodeMethodInfo.IndexTypeString = DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.TokenIndex];
      CustomTokenCodeMethodInfo.IndexType = DatabaseEnum.StringToDbIndexTypeDictonary[CustomTokenCodeMethodInfo.IndexTypeString];
      TokenListFinal.IndexSetterMethodList.Add(CustomTokenCodeMethodInfo);
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

  }
}
