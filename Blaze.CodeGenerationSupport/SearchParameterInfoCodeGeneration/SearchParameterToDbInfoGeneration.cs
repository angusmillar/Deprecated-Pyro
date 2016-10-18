using System;
using System.Linq;
using System.Collections.Generic;
using Blaze.CodeGenerationSupport.RepositoryCodeGeneration;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Enum;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class SearchParameterToDbInfoGeneration
  {
    public List<ResourceSearchParamInfo> ResourceSearchParamInfoList = null;

    public void Generate()
    {
      var RepositoryCodeGeneration = new Blaze.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      var RepositoryCodeGenModel = RepositoryCodeGeneration.Generate();

      ResourceSearchParamInfoList = new List<ResourceSearchParamInfo>();

      foreach (RepositoryItem RepositoryItem in RepositoryCodeGenModel.RepositoryItemList)
      {

        var ResourceSearchParamInfo = new ResourceSearchParamInfo();
        ResourceSearchParamInfo.ResourceName = RepositoryItem.ResourceName;
        ResourceSearchParamInfo.ResourceSearchParamInfoItemList = new List<ResourceSearchParamInfoItem>();
        ResourceSearchParamInfoList.Add(ResourceSearchParamInfo);

        foreach (CollectionIndexEntity CollectionIndexEntity in RepositoryItem.ResourceEntityCollectionPropertiesInfoList)
        {
          if (CollectionIndexEntity.SearchParameterInfo != null)
          {
            var ResourceSearchParamInfoItem = new ResourceSearchParamInfoItem();
            ResourceSearchParamInfoItem.SearchParameterNameType = DatabaseModelInfo.UnderScoreCSharpReservedWords(DatabaseModelInfo.ContructSearchParameterName(CollectionIndexEntity.SearchParameterInfo.SearchParameterName));
            ResourceSearchParamInfoItem.ResourceType = RepositoryItem.ResourceName;
            ResourceSearchParamInfoItem.DbSearchParameterType = DatabaseEnum.DbIndexTypeToStringDictonary[CollectionIndexEntity.SearchParameterInfo.DbIndexType];
            ResourceSearchParamInfoItem.ModifierList = PopulateSearchParameterModifierList(CollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.TypeModifierResourceList = PopulateTypeModifierResourceList(CollectionIndexEntity.SearchParameterInfo.ReferanceResourceTypeList);
            ResourceSearchParamInfoItem.PrefixList = PopulatePrefixList(CollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.IsDbCollection = "true";
            ResourceSearchParamInfoItem.DbBasePropertyName = DatabaseModelInfo.ContructSearchParameterName(CollectionIndexEntity.SearchParameterInfo.SearchParameterName);
            if (!DoesResourceSearchParamInfoItemListAlreadyContainSearchParameter(ResourceSearchParamInfoItem, ResourceSearchParamInfo.ResourceSearchParamInfoItemList))
              ResourceSearchParamInfo.ResourceSearchParamInfoItemList.Add(ResourceSearchParamInfoItem);
          }
        }
        foreach (NonCollectionIndexEntity NonCollectionIndexEntity in RepositoryItem.ResourceEntityNonCollectionPropertiesInfoList)
        {
          if (NonCollectionIndexEntity.SearchParameterInfo != null)
          {

            var ResourceSearchParamInfoItem = new ResourceSearchParamInfoItem();
            ResourceSearchParamInfoItem.SearchParameterNameType = DatabaseModelInfo.UnderScoreCSharpReservedWords(DatabaseModelInfo.ContructSearchParameterName(NonCollectionIndexEntity.SearchParameterInfo.SearchParameterName));
            ResourceSearchParamInfoItem.ResourceType = RepositoryItem.ResourceName;
            ResourceSearchParamInfoItem.DbSearchParameterType = DatabaseEnum.DbIndexTypeToStringDictonary[NonCollectionIndexEntity.SearchParameterInfo.DbIndexType];
            ResourceSearchParamInfoItem.ModifierList = PopulateSearchParameterModifierList(NonCollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.TypeModifierResourceList = PopulateTypeModifierResourceList(NonCollectionIndexEntity.SearchParameterInfo.ReferanceResourceTypeList);
            ResourceSearchParamInfoItem.PrefixList = PopulatePrefixList(NonCollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.IsDbCollection = "false";
            ResourceSearchParamInfoItem.DbBasePropertyName = DatabaseModelInfo.ContructSearchParameterName(NonCollectionIndexEntity.SearchParameterInfo.SearchParameterName);
            if (!DoesResourceSearchParamInfoItemListAlreadyContainSearchParameter(ResourceSearchParamInfoItem, ResourceSearchParamInfo.ResourceSearchParamInfoItemList))
              ResourceSearchParamInfo.ResourceSearchParamInfoItemList.Add(ResourceSearchParamInfoItem);

          }
        }
      }
    }
    /// <summary>
    /// Some Resource search parameters have a choice of different resource target types and are there for listed many times, we need to remove the duplicates 
    /// when building this search parameter list as they all have the same search parameter type
    /// </summary>
    /// <param name="resourceSearchParamInfoItem"></param>
    /// <param name="CurrentResourceSearchParameterList"></param>
    /// <returns></returns>
    private bool DoesResourceSearchParamInfoItemListAlreadyContainSearchParameter(ResourceSearchParamInfoItem resourceSearchParamInfoItem, List<ResourceSearchParamInfoItem> CurrentResourceSearchParameterList)
    {
      return CurrentResourceSearchParameterList.Exists(x => x.ResourceType == resourceSearchParamInfoItem.ResourceType && x.SearchParameterNameType == resourceSearchParamInfoItem.SearchParameterNameType);
    }

    private List<string> PopulateSearchParameterModifierList(DatabaseEnum.DbIndexType DbIndexType)
    {
      var ReturnList = new List<string>();
      switch (DbIndexType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.NumberIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          {
            //None supported as yet as no QuantityRange search types in STU3 to date.
            //ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Type.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.StringIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Contains.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Exact.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.TokenIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            //The modifiers below are supported in the spec for token but not 
            //implemented by this server as yet

            //ReturnList.Add(FhirSearchEnum.SearchModifierType.Text.ToString());
            //ReturnList.Add(FhirSearchEnum.SearchModifierType.In.ToString());
            //ReturnList.Add(FhirSearchEnum.SearchModifierType.Below.ToString());
            //ReturnList.Add(FhirSearchEnum.SearchModifierType.Above.ToString());
            //ReturnList.Add(FhirSearchEnum.SearchModifierType.In.ToString());
            //ReturnList.Add(FhirSearchEnum.SearchModifierType.NotIn.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.UriIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Missing.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Below.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Above.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Contains.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Exact.ToString());
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbIndexType.ToString(), (int)DbIndexType, typeof(DatabaseEnum.DbIndexType));
      }
    }
    private List<string> PopulateTypeModifierResourceList(List<Hl7.Fhir.Model.ResourceType> ReferanceResourceTypeList)
    {
      var ReturnList = new List<string>();

      foreach (ResourceType ResourceType in ReferanceResourceTypeList)
      {
        //Just double checking the FHIR API that the Resource given is valid
        Type Type = ModelInfo.GetTypeForFhirType(ResourceType.ToString());
        if (Type != null && ModelInfo.IsKnownResource(Type))
        {
          ReturnList.Add(ModelInfo.GetFhirTypeNameForType(Type));
        }
        else
        {
          throw new Exception($"The Reference Resource Type for a search parameter is not a valid resource type, Resource name was: {ResourceType.ToString()}");
        }
      }
      return ReturnList;
    }
    private List<string> PopulatePrefixList(DatabaseEnum.DbIndexType DbIndexType)
    {
      var ReturnList = new List<string>();
      switch (DbIndexType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.NotEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Equal.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Greater.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Less.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.LessOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.NotEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Equal.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Greater.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Less.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.LessOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.NotEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Equal.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Greater.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Less.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.LessOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.NumberIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.NotEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Equal.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Greater.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Less.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.LessOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.NotEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Equal.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Greater.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.Less.ToString());
            ReturnList.Add(FhirSearchEnum.SearchPrefixType.LessOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          {
            //None supported as yet as no QuantityRange search types in STU3 to date.
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          {
            //Any search parameter that's value is a string will not have prefixes
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.StringIndex:
          {
            //Any search parameter that's value is a string will not have prefixes
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.TokenIndex:
          {
            //Any search parameter that's value is a string will not have prefixes
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.UriIndex:
          {
            //Any search parameter that's value is a string will not have prefixes
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbIndexType.ToString(), (int)DbIndexType, typeof(DatabaseEnum.DbIndexType));
      }
    }

    //Some Search Parameters are C# reserved words, we will underscore prefix them
    private string UnderScoreReservedWords(string text)
    {
      string Prefix = "_";
      if (text == "class" ||
          text == "event" ||
          text == "abstract" ||
          text == "base" ||
          text == "operator")
        return Prefix + text;
      else
        return text;

    }
  }
}
