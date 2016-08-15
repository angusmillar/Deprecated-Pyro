using System;
using System.Collections.Generic;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;
using Blaze.CodeGenerationSupport.RepositoryCodeGeneration;

namespace Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class SearchParamInfoCodeGeneration
  {    
    public Dictionary<string, SearchParamInfoItem> DistinctSearchParamInfoItemDictornary = null;

    public void Generate()
    {
      var RepositoryCodeGeneration = new Blaze.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      var RepositoryCodeGenModel = RepositoryCodeGeneration.Generate();

     
      DistinctSearchParamInfoItemDictornary = new Dictionary<string, SearchParamInfoItem>();

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

      //foreach(var item in DistinctSearchParamInfoItemDictornary)
      //{
      //  item.Value.Name
      //}

    }

    private void AddSearchNameToDictornary(string SearchParameterName)
    {
      string EnumName = UnderScoreReservedWords(SearchParameterName.Replace("-", "_"));
      if (!DistinctSearchParamInfoItemDictornary.ContainsKey(EnumName))
      {
        DistinctSearchParamInfoItemDictornary.Add(EnumName, new SearchParamInfoItem() { EnumName = EnumName, Name = SearchParameterName });
      }
      else
      {
        if (DistinctSearchParamInfoItemDictornary[EnumName].Name != SearchParameterName)
        {
          throw new Exception(String.Format("Duplicate Search Parameters EnumNames with different Search parameter names. EnumName:'{0}', SearchNames: '{1}' and '{2}'", EnumName, DistinctSearchParamInfoItemDictornary[EnumName].Name, SearchParameterName));
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
