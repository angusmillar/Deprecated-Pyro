using System;
using System.Collections.Generic;
using Blaze.CodeGenerationSupport.RepositoryCodeGeneration;

namespace Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class SearchParamEnumCodeGeneration
  {
    public Dictionary<string, SearchParamEnumInfoItem> DistinctSearchParamEnumInfoItemDictornary = null;

    public void Generate()
    {
      var RepositoryCodeGeneration = new Blaze.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      var RepositoryCodeGenModel = RepositoryCodeGeneration.Generate();

      DistinctSearchParamEnumInfoItemDictornary = new Dictionary<string, SearchParamEnumInfoItem>();

      foreach (RepositoryItem RepositoryItem in RepositoryCodeGenModel.RepositoryItemList)
      {
        foreach (CollectionIndexEntity CollectionIndexEntity in RepositoryItem.ResourceEntityCollectionPropertiesInfoList)
        {
          if (CollectionIndexEntity.SearchParameterInfo != null)
          {
            AddSearchNameToDictornary(CollectionIndexEntity.SearchParameterInfo.SearchParameterName);
          }
        }
        foreach (NonCollectionIndexEntity NonCollectionIndexEntity in RepositoryItem.ResourceEntityNonCollectionPropertiesInfoList)
        {
          if (NonCollectionIndexEntity.SearchParameterInfo != null)
          {
            AddSearchNameToDictornary(NonCollectionIndexEntity.SearchParameterInfo.SearchParameterName);
          }
        }
        AddSearchNameToDictornary("_id");
        AddSearchNameToDictornary("page");
      }
    }

    private void AddSearchNameToDictornary(string SearchParameterName)
    {
      string EnumName = DatabaseModelInfo.UnderScoreCSharpReservedWords(SearchParameterName.Replace("-", "_"));
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


  }
}
