using System;
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
            ResourceSearchParamInfoItem.TypeModifierResourceList = PopulateTypeModifierResourceList(CollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.PrefixList = PopulatePrefixList(CollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.IsDbCollection = "true";
            ResourceSearchParamInfoItem.DbBasePropertyName = DatabaseModelInfo.ContructSearchParameterName(CollectionIndexEntity.SearchParameterInfo.SearchParameterName);
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
            ResourceSearchParamInfoItem.TypeModifierResourceList = PopulateTypeModifierResourceList(NonCollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.PrefixList = PopulatePrefixList(NonCollectionIndexEntity.SearchParameterInfo.DbIndexType);
            ResourceSearchParamInfoItem.IsDbCollection = "false";
            ResourceSearchParamInfoItem.DbBasePropertyName = DatabaseModelInfo.ContructSearchParameterName(NonCollectionIndexEntity.SearchParameterInfo.SearchParameterName);
            ResourceSearchParamInfo.ResourceSearchParamInfoItemList.Add(ResourceSearchParamInfoItem);

          }
        }
      }
    }

    private List<string> PopulateSearchParameterModifierList(DatabaseEnum.DbIndexType DbIndexType)
    {
      var ReturnList = new List<string>();
      switch (DbIndexType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.NumberIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.StringIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Contains.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Exact.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.TokenIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.UriIndex:
          {
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbIndexType.ToString(), (int)DbIndexType, typeof(DatabaseEnum.DbIndexType));
      }
    }
    private List<string> PopulateTypeModifierResourceList(DatabaseEnum.DbIndexType DbIndexType)
    {
      var ReturnList = new List<string>();
      switch (DbIndexType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.NumberIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.StringIndex:
          {
            //Example:
            //ReturnList.Add(Hl7.Fhir.Model.ResourceType.Account.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.TokenIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.UriIndex:
          {
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(DbIndexType.ToString(), (int)DbIndexType, typeof(DatabaseEnum.DbIndexType));
      }
    }
    private List<string> PopulatePrefixList(DatabaseEnum.DbIndexType DbIndexType)
    {
      var ReturnList = new List<string>();
      switch (DbIndexType)
      {
        case DatabaseEnum.DbIndexType.DateIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.DateTimePeriodIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.NumberIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.QuantityRangeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.ReferenceIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.StringIndex:
          {
            //Example:
            //ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.TokenIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.DbIndexType.UriIndex:
          {
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
