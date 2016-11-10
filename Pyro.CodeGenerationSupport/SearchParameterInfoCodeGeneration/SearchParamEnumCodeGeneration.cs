using System;
using System.Collections.Generic;
using Pyro.CodeGenerationSupport.RepositoryCodeGeneration;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;

namespace Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration
{
  public class SearchParamEnumCodeGeneration
  {
    public Dictionary<string, SearchParamEnumInfoItem> DistinctSearchParamEnumInfoItemDictornary = null;
    public List<Tuple<string, string>> ResourceTypeStingAndResourceTypeTupleList = null;

    public void Generate()
    {
      var RepositoryCodeGeneration = new Pyro.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
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
        //These are search parameters used by all resources, should re-factor this 
        //Base Resource Parameters
        AddSearchNameToDictornary("_id");
        AddSearchNameToDictornary("page");
        AddSearchNameToDictornary("_sort");
        //History Search parameters        
        AddSearchNameToDictornary("_since");
        AddSearchNameToDictornary("_at");
      }

      ResourceTypeStingAndResourceTypeTupleList = new List<Tuple<string, string>>();
      var ResourceTypeList = Enum.GetValues(typeof(ResourceType));
      foreach (ResourceType item in ResourceTypeList)
      {
        Tuple<string, string> NewTurple = new Tuple<string, string>(item.GetLiteral(), item.ToString());
        ResourceTypeStingAndResourceTypeTupleList.Add(NewTurple);
      }
      //{ "Account", ResourceType.Account},

      //foreach(var item in ResourceTypeStingAndResourceTypeTupleList)
      //{
      //  item.Item1
      //}
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
