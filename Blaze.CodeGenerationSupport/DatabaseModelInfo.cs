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

        var DataList = new List<string>();
        DataList.Add(DatabaseIndexPropertyConstatnts.DateIndexConstatnts.DateTimeOffset);
        Dic.Add(DatabaseEnum.DbIndexType.DateIndex, DataList);

        var DataPeriodList = new List<string>();
        DataPeriodList.Add(DatabaseIndexPropertyConstatnts.DatePeriodIndexConstatnts.DateTimeOffsetLow);
        DataPeriodList.Add(DatabaseIndexPropertyConstatnts.DatePeriodIndexConstatnts.DateTimeOffsetHigh);
        Dic.Add(DatabaseEnum.DbIndexType.DatePeriodIndex, DataPeriodList);

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

      public static class DatePeriodIndexConstatnts
      {
        public static string DateTimeOffsetLow { get { return "DateTimeOffsetLow"; } }
        public static string DateTimeOffsetHigh { get { return "DateTimeOffsetHigh"; } }
      }

      public static class DateIndexConstatnts
      {
        public static string DateTimeOffset { get { return "DateTimeOffset"; } }
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
      if (oFhirApiSearchParameterInfo.SearchParamType == SearchParamType.Composite)
        return DatabaseModelInfo.ContructSearchParameterName(oFhirApiSearchParameterInfo.SearchName).Replace("_[x]", "") + DatabaseModelInfo.ListPostfixText;
      else
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
      return SearchParameterName.Replace('-', '_');
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


      //switch (DatabaseIndexType)
      //{
      //  case DatabaseEnum.BlazeIndexType.DateIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}DateTimeOffset", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.DatePeriodIndex:
      //    {
      //      foreach(string PropertyConstant in BlazeIndexTypeToDbPropertyNameStringList_Dictonary[DatabaseIndexType])
      //      {
      //        Propertylist.Add(String.Format("{0}{1}", FormatedPrefix, PropertyConstant));
      //      }
      //      //Propertylist.Add(String.Format("{0}DateTimeOffsetLow", FormatedPrefix));
      //      //Propertylist.Add(String.Format("{0}DateTimeOffsetHigh", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.NumberIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Number", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.QuantityIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Quantity", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}System", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.QuantityRangeIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}ComparatorLow", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}QuantityLow", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}SystemLow", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}CodeLow", FormatedPrefix));

      //      Propertylist.Add(String.Format("{0}ComparatorHigh", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}QuantityHigh", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}SystemHigh", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}CodeHigh", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.ReferenceIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}FhirId", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Type", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Url", FormatedPrefix, DatabaseModelInfo.ApplicationName));
      //      Propertylist.Add(String.Format("{0}Url_{1}_RootUrlStoreID", FormatedPrefix, DatabaseModelInfo.ApplicationName));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.StringIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}String", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.TokenIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}System", FormatedPrefix));
      //      break;
      //    }
      //  case DatabaseEnum.BlazeIndexType.UriIndex:
      //    {
      //      Propertylist.Add(String.Format("{0}Uri", FormatedPrefix));
      //      break;
      //    }
      //  default:
      //    throw new InvalidEnumArgumentException(DatabaseIndexType.ToString(), (int)DatabaseIndexType, typeof(DatabaseEnum.BlazeIndexType));
      //}

      //switch (NonCollectionItem.SearchParamType)
      //{
      //  case Hl7.Fhir.Model.SearchParamType.Composite:
      //    {
      //      //Nothing to do for this type as composite type is a composite of the other types
      //      //We should never get here
      //      throw new ApplicationException("Attempt to create database fields for composite type search parameter. This should not happen.");
      //    }
      //  case Hl7.Fhir.Model.SearchParamType.Date:
      //    {

      //      if (NonCollectionItem.Resource == "Specimen" && NonCollectionItem.SearchName == "collected")
      //      {
      //        //debug only
      //      }

      //      if (NonCollectionItem.TargetFhirLogicalType == typeof(FhirDateTime) ||
      //        NonCollectionItem.TargetFhirLogicalType == typeof(Instant))
      //      {
      //        Propertylist.Add(String.Format("{0}DateTimeOffset", FormatedPrefix));
      //      }
      //      else if (NonCollectionItem.TargetFhirLogicalType == typeof(Date))
      //      {
      //        Propertylist.Add(String.Format("{0}DateTimeOffset", FormatedPrefix));
      //      }
      //      else if (NonCollectionItem.TargetFhirLogicalType == typeof(Timing))
      //      {
      //        Propertylist.Add(String.Format("{0}DateTimeOffsetLow", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}DateTimeOffsetHigh", FormatedPrefix));
      //      }
      //      else if (NonCollectionItem.TargetFhirLogicalType == typeof(Period))
      //      {
      //        Propertylist.Add(String.Format("{0}DateTimeOffsetLow", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}DateTimeOffsetHigh", FormatedPrefix));
      //      }
      //      else
      //        throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", NonCollectionItem.SearchParamType.ToString(), NonCollectionItem.TargetFhirType.ToString()));
      //      break;
      //    }
      //  case Hl7.Fhir.Model.SearchParamType.Number:
      //    {
      //      Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Number", FormatedPrefix));
      //    }
      //    break;
      //  case Hl7.Fhir.Model.SearchParamType.Quantity:
      //    {
      //      if (NonCollectionItem.TargetFhirLogicalType == typeof(Quantity) ||
      //        NonCollectionItem.TargetFhirLogicalType == typeof(Money))
      //      {
      //        Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}Quantity", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}System", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
      //      }
      //      else if (NonCollectionItem.TargetFhirLogicalType == typeof(SimpleQuantity))
      //      {
      //        Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}Quantity", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}System", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
      //      }
      //      else if (NonCollectionItem.TargetFhirLogicalType == typeof(Range))
      //      {
      //        Propertylist.Add(String.Format("{0}ComparatorLow", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}QuantityLow", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}SystemLow", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}CodeLow", FormatedPrefix));

      //        Propertylist.Add(String.Format("{0}ComparatorHigh", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}QuantityHigh", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}SystemHigh", FormatedPrefix));
      //        Propertylist.Add(String.Format("{0}CodeHigh", FormatedPrefix));
      //      }
      //      else
      //        throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", NonCollectionItem.SearchParamType.ToString(), NonCollectionItem.TargetFhirType.ToString()));
      //      break;
      //    }
      //  case Hl7.Fhir.Model.SearchParamType.Reference:
      //    {
      //      Propertylist.Add(String.Format("{0}FhirId", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Type", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}Url", FormatedPrefix, DatabaseModelInfo.ApplicationName));
      //      Propertylist.Add(String.Format("{0}Url_{1}_RootUrlStoreID", FormatedPrefix, DatabaseModelInfo.ApplicationName));
      //    }
      //    break;
      //  case Hl7.Fhir.Model.SearchParamType.String:
      //    {
      //      Propertylist.Add(String.Format("{0}String", FormatedPrefix));
      //    }
      //    break;
      //  case Hl7.Fhir.Model.SearchParamType.Token:
      //    {
      //      Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
      //      Propertylist.Add(String.Format("{0}System", FormatedPrefix));
      //    }
      //    break;
      //  case Hl7.Fhir.Model.SearchParamType.Uri:
      //    {
      //      Propertylist.Add(String.Format("{0}Uri", FormatedPrefix));
      //    }
      //    break;
      //  default:
      //    throw new InvalidEnumArgumentException(NonCollectionItem.SearchParamType.ToString(), (int)NonCollectionItem.SearchParamType, typeof(Hl7.Fhir.Model.SearchParamType));
      //}
    }

    public static string GetServerSearchIndexTypeString(FhirApiSearchParameterInfo SearchParameter)
    {
      if (SearchParameter.TargetFhirLogicalType == typeof(Period) ||
        SearchParameter.TargetFhirLogicalType == typeof(Timing))
      {
        return DatabaseEnum.DbIndexTypeToStringDictonary[DatabaseEnum.DbIndexType.DatePeriodIndex];
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

    public static DatabaseEnum.DbIndexType GetServerSearchIndexType(FhirApiSearchParameterInfo SearchParameter)
    {
      if (SearchParameter.TargetFhirLogicalType == typeof(Period) ||
        SearchParameter.TargetFhirLogicalType == typeof(Timing))
      {
        return DatabaseEnum.DbIndexType.DatePeriodIndex;
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

  }
}
