using System;
using System.Collections.Generic;
using Blaze.CodeGenerationSupport.RepositoryCodeGeneration;
using Blaze.Common.BusinessEntities.Search;
using Blaze.Common.Enum;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class SearchParamInfoCodeGeneration
  {
    public Dictionary<string, SearchParamEnumInfoItem> DistinctSearchParamEnumInfoItemDictornary = null;
    public List<ResourceSearchParamInfo> ResourceSearchParamInfoList = null;

    public void Generate()
    {
      var RepositoryCodeGeneration = new Blaze.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      var RepositoryCodeGenModel = RepositoryCodeGeneration.Generate();



      DistinctSearchParamEnumInfoItemDictornary = new Dictionary<string, SearchParamEnumInfoItem>();
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
            AddSearchNameToDictornary(CollectionIndexEntity.SearchParameterInfo.SearchParameterName);

            var ResourceSearchParamInfoItem = new ResourceSearchParamInfoItem();
            ResourceSearchParamInfoItem.SearchParameterNameType = UnderScoreReservedWords(CollectionIndexEntity.SearchParameterInfo.SearchParameterName.Replace("-", "_"));
            ResourceSearchParamInfoItem.ResourceName = RepositoryItem.ResourceName;
            ResourceSearchParamInfoItem.DbSearchParameterType = DatabaseEnum.BlazeIndexTypeToStringDictonary[CollectionIndexEntity.SearchParameterInfo.BlazeIndexType];
            ResourceSearchParamInfoItem.ModifierList = PopulateSearchparameterModifierList(CollectionIndexEntity.SearchParameterInfo.BlazeIndexType);
            ResourceSearchParamInfoItem.TypeModifierResourceList = PopulateTypeModifierResourceList(CollectionIndexEntity.SearchParameterInfo.BlazeIndexType);
            ResourceSearchParamInfoItem.PrefixList = PopulatePrefixListList(CollectionIndexEntity.SearchParameterInfo.BlazeIndexType);
            ResourceSearchParamInfoItem.IsDbCollection = true;
            ResourceSearchParamInfoItem.DbPropertyName = CollectionIndexEntity.PropertyName;
            ResourceSearchParamInfo.ResourceSearchParamInfoItemList.Add(ResourceSearchParamInfoItem);
          }
        }
        foreach (NonCollectionIndexEntity NonCollectionIndexEntity in RepositoryItem.ResourceEntityNonCollectionPropertiesInfoList)
        {
          if (NonCollectionIndexEntity.SearchParameterInfo != null)
          {
            AddSearchNameToDictornary(NonCollectionIndexEntity.SearchParameterInfo.SearchParameterName);

            foreach (string PropertyName in NonCollectionIndexEntity.PropertyNameList)
            {
              var ResourceSearchParamInfoItem = new ResourceSearchParamInfoItem();
              ResourceSearchParamInfoItem.SearchParameterNameType = UnderScoreReservedWords(NonCollectionIndexEntity.SearchParameterInfo.SearchParameterName.Replace("-", "_"));
              ResourceSearchParamInfoItem.ResourceName = RepositoryItem.ResourceName;
              ResourceSearchParamInfoItem.DbSearchParameterType = DatabaseEnum.BlazeIndexTypeToStringDictonary[NonCollectionIndexEntity.SearchParameterInfo.BlazeIndexType];
              ResourceSearchParamInfoItem.ModifierList = PopulateSearchparameterModifierList(NonCollectionIndexEntity.SearchParameterInfo.BlazeIndexType);
              ResourceSearchParamInfoItem.TypeModifierResourceList = PopulateTypeModifierResourceList(NonCollectionIndexEntity.SearchParameterInfo.BlazeIndexType);
              ResourceSearchParamInfoItem.PrefixList = PopulatePrefixListList(NonCollectionIndexEntity.SearchParameterInfo.BlazeIndexType);
              ResourceSearchParamInfoItem.IsDbCollection = false;
              ResourceSearchParamInfoItem.DbPropertyName = PropertyName;
              ResourceSearchParamInfo.ResourceSearchParamInfoItemList.Add(ResourceSearchParamInfoItem);
            }
          }
        }
        AddSearchNameToDictornary("_id");
        AddSearchNameToDictornary("page");
      }



    }

    private List<string> PopulateSearchparameterModifierList(DatabaseEnum.BlazeIndexType blazeIndexType)
    {
      var ReturnList = new List<string>();
      switch (blazeIndexType)
      {
        case DatabaseEnum.BlazeIndexType.DateIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.DatePeriodIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.NumberIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.QuantityIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.QuantityRangeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.ReferenceIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.StringIndex:
          {
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Contains.ToString());
            ReturnList.Add(FhirSearchEnum.SearchModifierType.Exact.ToString());
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.TokenIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.UriIndex:
          {
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(blazeIndexType.ToString(), (int)blazeIndexType, typeof(DatabaseEnum.BlazeIndexType));
      }
    }
    private List<string> PopulateTypeModifierResourceList(DatabaseEnum.BlazeIndexType blazeIndexType)
    {
      var ReturnList = new List<string>();
      switch (blazeIndexType)
      {
        case DatabaseEnum.BlazeIndexType.DateIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.DatePeriodIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.NumberIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.QuantityIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.QuantityRangeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.ReferenceIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.StringIndex:
          {
            //Example:
            //ReturnList.Add(Hl7.Fhir.Model.ResourceType.Account.ToString());
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.TokenIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.UriIndex:
          {
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(blazeIndexType.ToString(), (int)blazeIndexType, typeof(DatabaseEnum.BlazeIndexType));
      }
    }
    private List<string> PopulatePrefixListList(DatabaseEnum.BlazeIndexType blazeIndexType)
    {
      var ReturnList = new List<string>();
      switch (blazeIndexType)
      {
        case DatabaseEnum.BlazeIndexType.DateIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.DatePeriodIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.NumberIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.QuantityIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.QuantityRangeIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.ReferenceIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.StringIndex:
          {
            //Example:
            //ReturnList.Add(FhirSearchEnum.SearchPrefixType.GreaterOrEqual.ToString());
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.TokenIndex:
          {
            return ReturnList;
          }
        case DatabaseEnum.BlazeIndexType.UriIndex:
          {
            return ReturnList;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(blazeIndexType.ToString(), (int)blazeIndexType, typeof(DatabaseEnum.BlazeIndexType));
      }
    }

    private void AddSearchNameToDictornary(string SearchParameterName)
    {
      string EnumName = UnderScoreReservedWords(SearchParameterName.Replace("-", "_"));
      if (!DistinctSearchParamEnumInfoItemDictornary.ContainsKey(EnumName))
      {
        DistinctSearchParamEnumInfoItemDictornary.Add(EnumName, new SearchParamEnumInfoItem() { EnumName = EnumName, Name = SearchParameterName });
      }
      else
      {
        if (DistinctSearchParamEnumInfoItemDictornary[EnumName].Name != SearchParameterName)
        {
          throw new Exception(String.Format("Duplicate Search Parameters EnumNames with different Search parameter names. EnumName:'{0}', SearchNames: '{1}' and '{2}'", EnumName, DistinctSearchParamEnumInfoItemDictornary[EnumName].Name, SearchParameterName));
        }
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
