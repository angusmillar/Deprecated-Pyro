using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Blaze.Common.BusinessEntities.Dto;
using Blaze.Common.Enum;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;
using Hl7.Fhir.Model;

namespace Blaze.CodeGenerationSupport
{
  public static class DatabaseModelInfo
  {
    public static string ApplicationName { get { return "Blaze"; } }
    public static string ResourcePrefixText { get { return "Res"; } }
    public static string IndexPrefixText { get { return "Index"; } }
    public static string HistoryPrefixText { get { return "History"; } }
    public static string ListPostfixText { get { return "_List"; } }
    public static string XmlBlobPropertyText { get { return "XmlBlob"; } }
    public static string IndexSetterBaseInterfaceName = "IIndexSetter";
    public static string DatabaseModelBaseClassName { get { return "ModelBase"; } }
    public static string DatabaseModelResourceIndexBaseClassName { get { return "ResourceIndexBase"; } }


    public static Dictionary<DatabaseEnum.DbIndexType, List<string>> BlazeIndexTypeToDbPropertyNameStringList_Dictonary
    {
      get
      {
        var Dic = new Dictionary<DatabaseEnum.DbIndexType, List<string>>();

        var DateList = new List<string>();
        DateList.Add(DatabaseIndexPropertyConstatnts.DateIndexConstatnts.Date);
        Dic.Add(DatabaseEnum.DbIndexType.DateIndex, DateList);

        var DateTimeList = new List<string>();
        DateTimeList.Add(DatabaseIndexPropertyConstatnts.DateTimeIndexConstatnts.DateTimeOffset);        
        Dic.Add(DatabaseEnum.DbIndexType.DateTimeIndex, DateTimeList);

        var DateTimePeriodList = new List<string>();
        DateTimePeriodList.Add(DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetLow);
        DateTimePeriodList.Add(DatabaseIndexPropertyConstatnts.DateTimePeriodIndexConstatnts.DateTimeOffsetHigh);
        Dic.Add(DatabaseEnum.DbIndexType.DateTimePeriodIndex, DateTimePeriodList);

        var NumberIndexList = new List<string>();
        NumberIndexList.Add(DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Comparator);
        NumberIndexList.Add(DatabaseIndexPropertyConstatnts.NumberIndexConstatnts.Number);
        Dic.Add(DatabaseEnum.DbIndexType.NumberIndex, NumberIndexList);


        var QuantityIndexList = new List<string>();
        QuantityIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Comparator);
        QuantityIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Quantity);
        QuantityIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.System);
        QuantityIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityIndexConstatnts.Code);
        Dic.Add(DatabaseEnum.DbIndexType.QuantityIndex, QuantityIndexList);


        var QuantityRangeIndexList = new List<string>();
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.ComparatorLow);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.QuantityLow);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.SystemLow);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.CodeLow);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.ComparatorHigh);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.QuantityHigh);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.SystemHigh);
        QuantityRangeIndexList.Add(DatabaseIndexPropertyConstatnts.QuantityRangeIndexConstatnts.CodeHigh);
        Dic.Add(DatabaseEnum.DbIndexType.QuantityRangeIndex, QuantityRangeIndexList);

        var ReferenceIndexList = new List<string>();
        ReferenceIndexList.Add(DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.VersionId);
        ReferenceIndexList.Add(DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.FhirId);
        ReferenceIndexList.Add(DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Type);
        ReferenceIndexList.Add(DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.Url);
        ReferenceIndexList.Add(DatabaseIndexPropertyConstatnts.ReferenceIndexConstatnts.ServiceRootURL_StoreID);
        Dic.Add(DatabaseEnum.DbIndexType.ReferenceIndex, ReferenceIndexList);

        var StringIndexList = new List<string>();
        StringIndexList.Add(DatabaseIndexPropertyConstatnts.StringIndexConstatnts.String);
        Dic.Add(DatabaseEnum.DbIndexType.StringIndex, StringIndexList);

        var TokenIndexList = new List<string>();
        TokenIndexList.Add(DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.Code);
        TokenIndexList.Add(DatabaseIndexPropertyConstatnts.TokenIndexConstatnts.System);
        Dic.Add(DatabaseEnum.DbIndexType.TokenIndex, TokenIndexList);

        var UriIndexList = new List<string>();
        UriIndexList.Add(DatabaseIndexPropertyConstatnts.UriIndexConstatnts.Uri);
        Dic.Add(DatabaseEnum.DbIndexType.UriIndex, UriIndexList);

        return Dic;
      }
    }


    public static class DatabaseIndexPropertyConstatnts
    {

      public static class BaseResourceIndexConstatnts
      {
        public static string FhirId { get { return "FhirId"; } }
        public static string IsDeleted { get { return "IsDeleted"; } }
        public static string lastUpdated { get { return "lastUpdated"; } }
        public static string versionId { get { return "versionId"; } }
        public static string XmlBlob { get { return "XmlBlob"; } }
      }

      public static class DateTimePeriodIndexConstatnts
      {
        public static string DateTimeOffsetLow { get { return "DateTimeOffsetLow"; } }
        public static string DateTimeOffsetHigh { get { return "DateTimeOffsetHigh"; } }
      }

      public static class DateTimeIndexConstatnts
      {
        public static string DateTimeOffset { get { return "DateTimeOffset"; } }        
      }

      public static class DateIndexConstatnts
      {
        public static string Date { get { return "Date"; } }
      }

      public static class NumberIndexConstatnts
      {
        public static string Comparator { get { return "Comparator"; } }
        public static string Number { get { return "Number"; } }
      }

      public static class QuantityIndexConstatnts
      {
        public static string Comparator { get { return "Comparator"; } }
        public static string Quantity { get { return "Quantity"; } }
        public static string System { get { return "System"; } }
        public static string Code { get { return "Code"; } }
      }

      public static class QuantityRangeIndexConstatnts
      {
        public static string ComparatorLow { get { return "ComparatorLow"; } }
        public static string QuantityLow { get { return "QuantityLow"; } }
        public static string SystemLow { get { return "SystemLow"; } }
        public static string CodeLow { get { return "CodeLow"; } }

        public static string ComparatorHigh { get { return "ComparatorHigh"; } }
        public static string QuantityHigh { get { return "QuantityHigh"; } }
        public static string SystemHigh { get { return "SystemHigh"; } }
        public static string CodeHigh { get { return "CodeHigh"; } }
      }

      public static class ReferenceIndexConstatnts
      {
        public static string ClassNameServiceRootURL_Store { get { return "ServiceRootURL_Store"; } }

        public static string VersionId { get { return "VersionId"; } }
        public static string FhirId { get { return "FhirId"; } }
        public static string Type { get { return "Type"; } }
        public static string Url { get { return "Url"; } }
        public static string ServiceRootURL_StoreID { get { return "ServiceRootURL_StoreID"; } }
      }

      public static class StringIndexConstatnts
      {
        public static string String { get { return "String"; } }
      }

      public static class TokenIndexConstatnts
      {
        public static string Code { get { return "Code"; } }
        public static string System { get { return "System"; } }
      }

      public static class UriIndexConstatnts
      {
        public static string Uri { get { return "Uri"; } }
      }

    }


    /// <summary>
    /// Construct the class name string for the Resource Entity classes (e.g Res_Patient)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceClass(string ResourceName)
    {
      return String.Format("{0}_{1}", DatabaseModelInfo.ResourcePrefixText, ResourceName);
    }

    /// <summary>
    /// Construct the class name string for the Resource History Entity classes (e.g Res_Patient_History)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceHistory(string ResourceName)
    {
      return String.Format("{0}_{1}_{2}", DatabaseModelInfo.ResourcePrefixText, ResourceName, DatabaseModelInfo.HistoryPrefixText);
    }

    /// <summary>
    /// Construct the class name string for the Resource History Entity classes (e.g Res_Patient_History_List)
    /// </summary>
    /// <param name="ResourceName"></param>
    /// <returns></returns>
    public static string ConstructClassNameForResourceHistoryList(string ResourceName)
    {
      return String.Format("{0}_{1}_{2}{3}", DatabaseModelInfo.ResourcePrefixText, ResourceName, DatabaseModelInfo.HistoryPrefixText, DatabaseModelInfo.ListPostfixText);
    }

    /// <summary>
    /// Construct the property name string for the Collection lists of the Resource Entity classes (e.g address_postalcode_List)
    /// </summary>
    /// <param name="SearchParameterName"></param>
    /// <returns></returns>
    public static string ConstructCollectionListName(FhirApiSearchParameterInfo oFhirApiSearchParameterInfo)
    {
      return DatabaseModelInfo.ContructSearchParameterName(oFhirApiSearchParameterInfo.SearchName) + DatabaseModelInfo.ListPostfixText;
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
        return String.Format("{0}_{1}_{2}_{3}", DatabaseModelInfo.ResourcePrefixText, ResourceName, DatabaseModelInfo.IndexPrefixText, DatabaseModelInfo.ContructSearchParameterName(SearchParameterInfo.SearchName).Replace("_[x]", ""));
      else
        return String.Format("{0}_{1}_{2}_{3}", DatabaseModelInfo.ResourcePrefixText, ResourceName, DatabaseModelInfo.IndexPrefixText, DatabaseModelInfo.ContructSearchParameterName(SearchParameterInfo.SearchName));
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

      var DatabaseIndexType = DatabaseModelInfo.GetServerSearchIndexType(NonCollectionItem);

      foreach (string PropertyConstant in BlazeIndexTypeToDbPropertyNameStringList_Dictonary[DatabaseIndexType])
      {
        Propertylist.Add(String.Format("{0}{1}", FormatedPrefix, PropertyConstant));
      }
    }


    public static string GetServerSearchIndexTypeString(FhirApiSearchParameterInfo SearchParameter)
    {
      return DatabaseEnum.DbIndexTypeToStringDictonary[GetServerSearchIndexType(SearchParameter)];      
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




    public static string GetServerSearchIndexTypeStringOLD(FhirApiSearchParameterInfo SearchParameter)
    {
      if (SearchParameter.TargetFhirLogicalType == typeof(Period) ||
        SearchParameter.TargetFhirLogicalType == typeof(Timing))
      {
        return DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DateTimePeriodIndex];
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(Date))
      {
        return DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DateIndex];
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(FhirDateTime) ||
               SearchParameter.TargetFhirLogicalType == typeof(Instant))
      {
        if (SearchParameter.SearchParamType == SearchParamType.Token)
        {
          return DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.TokenIndex];
        }
        else
        {
          return DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DateTimeIndex];
        }        
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(Range))
      {
        return DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.QuantityRangeIndex];
      }
      else
      {
        return SearchParameter.SearchParamType.ToString() + DatabaseModelInfo.IndexPrefixText;
      }
    }

    public static DatabaseEnum.DbIndexType GetServerSearchIndexTypeOLD(FhirApiSearchParameterInfo SearchParameter)
    {
      if (SearchParameter.TargetFhirLogicalType == typeof(Period) ||
        SearchParameter.TargetFhirLogicalType == typeof(Timing))
      {
        return DatabaseEnum.DbIndexType.DateTimePeriodIndex;
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(Date))
      {
        return DatabaseEnum.DbIndexType.DateIndex;
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(FhirDateTime))
      {
        if (SearchParameter.SearchParamType == SearchParamType.Token)
        {
          return DatabaseEnum.DbIndexType.TokenIndex;
        }
        else
        {
          return DatabaseEnum.DbIndexType.DateTimeIndex;
        }        
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(Range))
      {
        return DatabaseEnum.DbIndexType.QuantityRangeIndex;
      }
      else
      {
        return DatabaseEnum.StringToDbIndexTypeDictonary[SearchParameter.SearchParamType.ToString() + DatabaseModelInfo.IndexPrefixText];
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

  }
}
