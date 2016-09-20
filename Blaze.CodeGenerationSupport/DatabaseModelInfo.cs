using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Enum;
using Blaze.Common.Database;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport
{
  public static class DatabaseModelInfo
  {
    /// <summary>
    /// Construct the class name string for the Resource Entity classes (e.g Res_Patient)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceClass(string ResourceName)
    {
      return String.Format("{0}_{1}", StaticDatabaseInfo.ResourcePrefixText, ResourceName);
    }

    /// <summary>
    /// Construct the class name string for the Resource History Entity classes (e.g Res_Patient_History)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceHistory(string ResourceName)
    {
      return String.Format("{0}_{1}_{2}", StaticDatabaseInfo.ResourcePrefixText, ResourceName, StaticDatabaseInfo.HistoryPrefixText);
    }

    /// <summary>
    /// Construct the class name string for the Resource History Entity classes (e.g Res_Patient_History_List)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceHistoryList(string ResourceName)
    {
      return String.Format("{0}_{1}_{2}{3}", StaticDatabaseInfo.ResourcePrefixText, ResourceName, StaticDatabaseInfo.HistoryPrefixText, StaticDatabaseInfo.ListPostfixText);
    }

    /// <summary>
    /// Construct the property name string for the Collection lists of the Resource Entity classes (e.g address_postalcode_List)
    /// </summary>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructCollectionListName(FhirApiSearchParameterInfo oFhirApiSearchParameterInfo)
    {
      return DatabaseModelInfo.ContructSearchParameterName(oFhirApiSearchParameterInfo.SearchName) + StaticDatabaseInfo.ListPostfixText;
    }

    /// <summary>
    /// Construct the class name string for the Resource Search Entity Classes (e.g Res_Patient_Index_address_country)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceSearchClass(string ResourceName, FhirApiSearchParameterInfo SearchParameterInfo)
    {
      if (SearchParameterInfo.SearchParamType == SearchParamType.Composite)
        return String.Format("{0}_{1}_{2}_{3}", StaticDatabaseInfo.ResourcePrefixText, ResourceName, StaticDatabaseInfo.IndexPrefixText, DatabaseModelInfo.ContructSearchParameterName(SearchParameterInfo.SearchName).Replace("_[x]", ""));
      else
        return String.Format("{0}_{1}_{2}_{3}", StaticDatabaseInfo.ResourcePrefixText, ResourceName, StaticDatabaseInfo.IndexPrefixText, DatabaseModelInfo.ContructSearchParameterName(SearchParameterInfo.SearchName));
    }

    /// <summary>
    /// Construct the Search Parameter Name as it will be used in the model. 
    /// </summary>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ContructSearchParameterName(string SearchParameterName)
    {
      return SearchParameterName.Replace('-', '_').Replace("_[x]", "");
    }

    public static void GenerateNonCollectionPropertiesNames(List<string> Propertylist, FhirApiSearchParameterInfo NonCollectionItem, bool OnlyReturnStaticPortion = false)
    {
      string FormatedPrefix = string.Empty;
      if (!OnlyReturnStaticPortion)
      {
        FormatedPrefix = DatabaseModelInfo.ContructSearchParameterName(NonCollectionItem.SearchName) + '_';
      }
      foreach (string PropertyConstant in StaticDatabaseInfo.BlazeIndexTypeToDbPropertyNameStringList_Dictonary[NonCollectionItem.DbIndexType])
      {
        Propertylist.Add(String.Format("{0}{1}", FormatedPrefix, PropertyConstant));
      }
    }

    public static string GetServerSearchIndexTypeString(FhirApiSearchParameterInfo SearchParameter)
    {
      return DatabaseEnum.DbIndexTypeToStringDictonary[SearchParameter.DbIndexType];
    }

    public static DatabaseEnum.DbIndexType GetServerSearchIndexType(FhirApiSearchParameterInfo SearchParameter)
    {
      switch (SearchParameter.SearchParamType)
      {
        case SearchParamType.Number:
          return DatabaseEnum.DbIndexType.NumberIndex;
        case SearchParamType.Date:
          if (SearchParameter.TargetFhirLogicalType == typeof(Date))
          {
            return DatabaseEnum.DbIndexType.DateIndex;
          }
          else if (SearchParameter.TargetFhirLogicalType == typeof(Period) ||
                   SearchParameter.TargetFhirLogicalType == typeof(Timing))
          {
            return DatabaseEnum.DbIndexType.DateTimePeriodIndex;
          }
          else
          {
            return DatabaseEnum.DbIndexType.DateTimeIndex;
          }
        case SearchParamType.String:
          return DatabaseEnum.DbIndexType.StringIndex;
        case SearchParamType.Token:
          return DatabaseEnum.DbIndexType.TokenIndex;
        case SearchParamType.Reference:
          return DatabaseEnum.DbIndexType.ReferenceIndex;
        case SearchParamType.Composite:
          throw new Exception("Should never get a Composite here.");
        case SearchParamType.Quantity:
          if (SearchParameter.TargetFhirLogicalType == typeof(Range))
          {
            return DatabaseEnum.DbIndexType.QuantityRangeIndex;
          }
          else
          {
            return DatabaseEnum.DbIndexType.QuantityIndex;
          }
        case SearchParamType.Uri:
          return DatabaseEnum.DbIndexType.UriIndex;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(SearchParameter.SearchParamType.ToString(), (int)SearchParameter.SearchParamType, typeof(DatabaseEnum.DbIndexType));
      }
    }

    public static string GenerateIndexSetter(string Item, string DbIndexType, string ReturnType, bool IsReferanceType = false)
    {
      if (IsReferanceType)
      {
        return string.Format("Index = IndexSetterFactory.Create(typeof({0})).Set({1}, Index, FhirRequestUri, this) as {2};", DbIndexType, Item, ReturnType);
      }
      else
      {
        return string.Format("Index = IndexSetterFactory.Create(typeof({0})).Set({1}, Index) as {2};", DbIndexType, Item, ReturnType);
      }

    }

    public static string NameGenericType(this Type type, bool WithType_T = true)
    {
      string friendlyName = type.FullName.Replace('+', '.');
      if (type.IsGenericType)
      {
        int iBacktick = friendlyName.IndexOf('`');
        if (iBacktick > 0)
        {
          friendlyName = friendlyName.Remove(iBacktick);
        }
        if (WithType_T)
        {
          friendlyName += "<";
          Type[] typeParameters = type.GetGenericArguments();
          for (int i = 0; i < typeParameters.Length; ++i)
          {
            string typeParamName = typeParameters[i].FullName.Replace('+', '.');
            friendlyName += (i == 0 ? typeParamName : "," + typeParamName);
          }
          friendlyName += ">";
        }
      }

      return friendlyName;
    }

    public static string NameGenericType_T(this Type type)
    {
      string friendlyName = type.Name;
      if (type.IsGenericType)
      {
        Type[] typeParameters = type.GetGenericArguments();
        for (int i = 0; i < typeParameters.Length; ++i)
        {
          string typeParamName = typeParameters[i].FullName.Replace('+', '.');
          friendlyName = (i == 0 ? typeParamName : "," + typeParamName);
        }
      }
      return friendlyName;
    }

    //Some Search Parameters are C# reserved words, we will underscore prefix them
    public static string UnderScoreCSharpReservedWords(string text)
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

    /// <summary>
    /// This is to fix the issue where you have the same search parameter name being equal to many logical types of date variant
    /// For instance the Specimen Resource has a search parameter 'collected' which can be a DateTime or a Period. In this
    /// case we want the search index to be of type DateTimePeriod where the high and low will both be equal to the single DateTime value.
    /// This way the search logic does not need to look in two places, two different search indexes for the one search parameter.    
    /// </summary>
    /// <param name="SearchParameterList"></param>
    internal static void SetServerSearchIndexType(List<FhirApiSearchParameterInfo> SearchParameterList)
    {
      var ResourceList = ModelInfo.SupportedResources;

      foreach (string ResourceName in ResourceList)
      {
        List<FhirApiSearchParameterInfo> ResourceSearchParameterList = (from x in SearchParameterList
                                                                        where x.Resource == ResourceName
                                                                        select x).ToList();
        foreach (var SearchItem in ResourceSearchParameterList)
        {
          DatabaseEnum.DbIndexType TempDbIndexType = DatabaseModelInfo.GetServerSearchIndexType(SearchItem);

          if (SearchItem.SearchParamType == SearchParamType.Date)
          {
            List<FhirApiSearchParameterInfo> SameSearchNamesList = (from x in ResourceSearchParameterList
                                                                    where x.SearchName == SearchItem.SearchName
                                                                    select x).ToList();
            if (SameSearchNamesList.Count > 1 &&
              SameSearchNamesList.Exists(x => x.TargetFhirLogicalType == typeof(Period) &&
              TempDbIndexType == DatabaseEnum.DbIndexType.DateTimeIndex))
            {
              TempDbIndexType = DatabaseEnum.DbIndexType.DateTimePeriodIndex;
            }
          }
          SearchItem.DbIndexType = TempDbIndexType;
        }
      }
    }

  }
}
