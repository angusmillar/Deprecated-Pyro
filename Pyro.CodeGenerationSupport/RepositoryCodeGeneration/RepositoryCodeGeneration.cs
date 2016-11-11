using System;
using System.Collections.Generic;
using System.Text;
using Pyro.CodeGenerationSupport.FhirApiIntrospection;
using Pyro.Common.Enum;
using Pyro.Common.Database;

namespace Pyro.CodeGenerationSupport.RepositoryCodeGeneration
{
  public class RepositoryCodeGeneration
  {
    private List<string> _ResourceList;
    private List<FhirApiSearchParameterInfo> _SearchParametersList;

    public RepositoryCodeGenModel Generate()
    {
      _ResourceList = Hl7.Fhir.Model.ModelInfo.SupportedResources;
      _SearchParametersList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();

      var RepositoryCodeGenModel = new RepositoryCodeGenModel();
      RepositoryCodeGenModel.RepositoryItemList = new List<RepositoryItem>();
      int DebugCounter = 0;
      foreach (var ResourceName in _ResourceList)
      {
        DebugCounter++;
        if (DebugCounter == 10)
        {
          DebugCounter = 0;
        }
        List<FhirApiSearchParameterInfo> SearchParametersForResource = SearchParameterFilter.GetParametersForResource(ResourceName, _SearchParametersList);
        List<FhirApiSearchParameterInfo> CollectionParameters = SearchParameterFilter.GetIsColectionParameters(true, SearchParametersForResource);
        List<FhirApiSearchParameterInfo> NonCollectionParameters = SearchParameterFilter.GetIsColectionParameters(false, SearchParametersForResource);

        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(NonCollectionParameters);
        FhirApiSearchParameterInfoFactory.FHIRApiCorrectionsForRepository(CollectionParameters);
        FhirApiSearchParameterInfoFactory.CheckForUnhandledChoiceElements(NonCollectionParameters);
        FhirApiSearchParameterInfoFactory.CheckForUnhandledChoiceElements(CollectionParameters);


        var RepositoryItem = new RepositoryItem();
        RepositoryCodeGenModel.RepositoryItemList.Add(RepositoryItem);

        RepositoryItem.RepositoryClassName = String.Format("{0}{1}", ResourceName, "Repository");
        RepositoryItem.ResourceEntityName = DatabaseModelInfo.ConstructClassNameForResourceClass(ResourceName);
        RepositoryItem.ResourceName = ResourceName;
        RepositoryItem.ResourceHistoryEntityName = DatabaseModelInfo.ConstructClassNameForResourceHistory(ResourceName);
        RepositoryItem.ResourceHistoryEntityListName = DatabaseModelInfo.ConstructClassNameForResourceHistoryList(ResourceName);

        foreach (FhirApiSearchParameterInfo CollectionParameter in CollectionParameters)
        {
          RepositoryItem.ResourceEntityIncludesList.Add(DatabaseModelInfo.ConstructCollectionListName(CollectionParameter));
          CollectionIndexEntity oIndexEntity = new CollectionIndexEntity();
          RepositoryItem.ResourceEntityCollectionPropertiesInfoList.Add(oIndexEntity);
          oIndexEntity.ClassName = DatabaseModelInfo.ConstructClassNameForResourceSearchClass(ResourceName, CollectionParameter);
          oIndexEntity.PropertyName = DatabaseModelInfo.ConstructCollectionListName(CollectionParameter);
          oIndexEntity.SearchParameterInfo = new SearchParameterInfo();
          oIndexEntity.SearchParameterInfo.DbIndexType = DatabaseEnum.StringToDbIndexTypeDictonary[DatabaseModelInfo.GetServerSearchIndexTypeString(CollectionParameter)];
          oIndexEntity.SearchParameterInfo.SearchParamType = CollectionParameter.SearchParamType;
          oIndexEntity.SearchParameterInfo.SearchParameterName = CollectionParameter.SearchName;
          oIndexEntity.SearchParameterInfo.ReferanceResourceTypeList = CollectionParameter.ReferanceTargetResourceType;

        }

        foreach (FhirApiSearchParameterInfo NonCollectionParameter in NonCollectionParameters)
        {
          List<string> Propertylist = new List<string>();
          DatabaseModelInfo.GenerateNonCollectionPropertiesNames(Propertylist, NonCollectionParameter);

          var NonColectionIndexEntity = new NonCollectionIndexEntity();
          NonColectionIndexEntity.PropertyNameList.AddRange(Propertylist);
          NonColectionIndexEntity.SearchParameterInfo = new SearchParameterInfo();
          NonColectionIndexEntity.SearchParameterInfo.DbIndexType = DatabaseEnum.StringToDbIndexTypeDictonary[DatabaseModelInfo.GetServerSearchIndexTypeString(NonCollectionParameter)];
          NonColectionIndexEntity.SearchParameterInfo.SearchParamType = NonCollectionParameter.SearchParamType;
          NonColectionIndexEntity.SearchParameterInfo.SearchParameterName = NonCollectionParameter.SearchName;
          NonColectionIndexEntity.SearchParameterInfo.ReferanceResourceTypeList = NonCollectionParameter.ReferanceTargetResourceType;
          RepositoryItem.ResourceEntityNonCollectionPropertiesInfoList.Add(NonColectionIndexEntity);

        }
        //var XmlBlobNonColectionIndexEntity = new NonCollectionIndexEntity();
        //XmlBlobNonColectionIndexEntity.PropertyNameList.Add(StaticDatabaseInfo.XmlBlobPropertyText);
        //RepositoryItem.ResourceEntityNonCollectionPropertiesInfoList.Add(XmlBlobNonColectionIndexEntity);

        //Below 'if' is for debug only
        if (ResourceName != "")
        //if (ResourceName != "Bundle")    
        //if (ResourceName == "Observation")
        {
          List<string> LogicList = new List<string>();
          //Non Collection search parameter logic
          //---------------------------------------------------------------------------------------
          foreach (FhirApiSearchParameterInfo NonCollectionParameter in NonCollectionParameters)
          {
            StringBuilder Sb = new StringBuilder();
            Sb = RepositoryNonCollectionSetterLogicBuilder.Build(NonCollectionParameter, ResourceName, "ResourceTyped", "ResourseEntity");
            LogicList.Add(Sb.ToString());
          }

          //Collection search parameter logic
          //---------------------------------------------------------------------------------------
          foreach (FhirApiSearchParameterInfo CollectionParameter in CollectionParameters)
          {
            StringBuilder Sb = new StringBuilder();
            Sb = RepositoryCollectionSetterLogicBuilder.Build(CollectionParameter, ResourceName, "ResourceTyped", "ResourseEntity");
            LogicList.Add(Sb.ToString());
          }


          string CompileAllLogic = string.Empty;
          LogicList.ForEach(x => CompileAllLogic = CompileAllLogic + x);
          RepositoryItem.EntitySetterLogic = CompileAllLogic;
        }
      }

      return RepositoryCodeGenModel;
    }

    static string UppercaseFirst(string s)
    {
      // Check for empty string.
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      // Return char and concat substring.
      return char.ToUpper(s[0]) + s.Substring(1);
    }

    static string DepthSpace(int DepthCounter)
    {
      string Result = string.Empty;
      for (int i = 0; i < DepthCounter; i++)
      {
        Result = Result + " ";
      }
      return Result;
    }

  }
}
