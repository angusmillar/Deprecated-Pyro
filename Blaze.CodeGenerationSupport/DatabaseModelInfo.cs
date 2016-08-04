using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
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

    public enum BlazeIndexType { DateIndex, DatePeriodIndex, NumberIndex, QuantityIndex, QuantityRangeIndex, ReferenceIndex, StringIndex, TokenIndex, UriIndex };
    public static Dictionary<BlazeIndexType, string> BlazeIndexTypeToStringDictonary
    {
      get
      {
        var Dic = new Dictionary<BlazeIndexType, string>();
        Dic.Add(BlazeIndexType.DateIndex, "DateIndex");
        Dic.Add(BlazeIndexType.DatePeriodIndex, "DatePeriodIndex");
        Dic.Add(BlazeIndexType.NumberIndex, "NumberIndex");
        Dic.Add(BlazeIndexType.QuantityIndex, "QuantityIndex");
        Dic.Add(BlazeIndexType.QuantityRangeIndex, "QuantityRangeIndex");
        Dic.Add(BlazeIndexType.ReferenceIndex, "ReferenceIndex");
        Dic.Add(BlazeIndexType.StringIndex, "StringIndex");
        Dic.Add(BlazeIndexType.TokenIndex, "TokenIndex");
        Dic.Add(BlazeIndexType.UriIndex, "UriIndex");
        return Dic;
      }
    }
    public static Dictionary<string, BlazeIndexType> StringToBlazeIndexTypeDictonary
    {
      get
      {
        var Dic = new Dictionary<string, BlazeIndexType>();
        Dic.Add("DateIndex", BlazeIndexType.DateIndex);
        Dic.Add("DatePeriodIndex", BlazeIndexType.DatePeriodIndex);
        Dic.Add("NumberIndex", BlazeIndexType.NumberIndex);
        Dic.Add("QuantityIndex", BlazeIndexType.QuantityIndex);
        Dic.Add("QuantityRangeIndex", BlazeIndexType.QuantityRangeIndex);
        Dic.Add("ReferenceIndex", BlazeIndexType.ReferenceIndex);
        Dic.Add("StringIndex", BlazeIndexType.StringIndex);
        Dic.Add("TokenIndex", BlazeIndexType.TokenIndex);
        Dic.Add("UriIndex", BlazeIndexType.UriIndex);
        return Dic;
      }
    }
    public static string IndexSetterBaseInterfaceName = "IIndexSetter";

    public static string DatabaseModelBaseClassName { get { return "ModelBase"; } }
    public static string DatabaseModelResourceIndexBaseClassName { get { return "ResourceIndexBase"; } }

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

    public static void GenerateNonCollectionPropertiesNames(List<string> Propertylist, FhirApiSearchParameterInfo NonCollectionItem)
    {
      string FormatedPrefix = DatabaseModelInfo.ContructSearchParameterName(NonCollectionItem.SearchName) + '_';

      switch (NonCollectionItem.SearchParamType)
      {
        case Hl7.Fhir.Model.SearchParamType.Composite:
          {
            //Nothing to do for this type as composite type is a composite of the other types
            //We should never get here
            throw new ApplicationException("Attempt to create database fields for composite type search parameter. This should not happen.");
          }
        case Hl7.Fhir.Model.SearchParamType.Date:
          {

            if (NonCollectionItem.Resource == "Specimen" && NonCollectionItem.SearchName == "collected")
            {
              //debug only
            }

            if (NonCollectionItem.TargetFhirLogicalType == typeof(FhirDateTime) ||
              NonCollectionItem.TargetFhirLogicalType == typeof(Instant))
            {
              Propertylist.Add(String.Format("{0}DateTimeOffset", FormatedPrefix));
            }
            else if (NonCollectionItem.TargetFhirLogicalType == typeof(Date))
            {
              Propertylist.Add(String.Format("{0}DateTimeOffset", FormatedPrefix));
            }
            else if (NonCollectionItem.TargetFhirLogicalType == typeof(Timing))
            {
              Propertylist.Add(String.Format("{0}DateTimeOffsetLow", FormatedPrefix));
              Propertylist.Add(String.Format("{0}DateTimeOffsetHigh", FormatedPrefix));
            }
            else if (NonCollectionItem.TargetFhirLogicalType == typeof(Period))
            {
              Propertylist.Add(String.Format("{0}DateTimeOffsetLow", FormatedPrefix));
              Propertylist.Add(String.Format("{0}DateTimeOffsetHigh", FormatedPrefix));
            }
            else
              throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", NonCollectionItem.SearchParamType.ToString(), NonCollectionItem.TargetFhirType.ToString()));
            break;
          }
        case Hl7.Fhir.Model.SearchParamType.Number:
          {
            Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
            Propertylist.Add(String.Format("{0}Number", FormatedPrefix));
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Quantity:
          {
            if (NonCollectionItem.TargetFhirLogicalType == typeof(Quantity) ||
              NonCollectionItem.TargetFhirLogicalType == typeof(Money))
            {
              Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
              Propertylist.Add(String.Format("{0}Quantity", FormatedPrefix));
              Propertylist.Add(String.Format("{0}System", FormatedPrefix));
              Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
            }
            else if (NonCollectionItem.TargetFhirLogicalType == typeof(SimpleQuantity))
            {
              Propertylist.Add(String.Format("{0}Comparator", FormatedPrefix));
              Propertylist.Add(String.Format("{0}Quantity", FormatedPrefix));
              Propertylist.Add(String.Format("{0}System", FormatedPrefix));
              Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
            }
            else if (NonCollectionItem.TargetFhirLogicalType == typeof(Range))
            {
              Propertylist.Add(String.Format("{0}ComparatorLow", FormatedPrefix));
              Propertylist.Add(String.Format("{0}QuantityLow", FormatedPrefix));
              Propertylist.Add(String.Format("{0}SystemLow", FormatedPrefix));
              Propertylist.Add(String.Format("{0}CodeLow", FormatedPrefix));

              Propertylist.Add(String.Format("{0}ComparatorHigh", FormatedPrefix));
              Propertylist.Add(String.Format("{0}QuantityHigh", FormatedPrefix));
              Propertylist.Add(String.Format("{0}SystemHigh", FormatedPrefix));
              Propertylist.Add(String.Format("{0}CodeHigh", FormatedPrefix));
            }
            else
              throw new Exception(String.Format("Search parameter of '{0}' could not be resolved to a BaseIndex database type. TargetType was '{1}'", NonCollectionItem.SearchParamType.ToString(), NonCollectionItem.TargetFhirType.ToString()));
            break;
          }
        case Hl7.Fhir.Model.SearchParamType.Reference:
          {
            Propertylist.Add(String.Format("{0}FhirId", FormatedPrefix));
            Propertylist.Add(String.Format("{0}Type", FormatedPrefix));
            Propertylist.Add(String.Format("{0}Url", FormatedPrefix, DatabaseModelInfo.ApplicationName));
            Propertylist.Add(String.Format("{0}Url_{1}_RootUrlStoreID", FormatedPrefix, DatabaseModelInfo.ApplicationName));
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.String:
          {
            Propertylist.Add(String.Format("{0}String", FormatedPrefix));
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Token:
          {
            Propertylist.Add(String.Format("{0}Code", FormatedPrefix));
            Propertylist.Add(String.Format("{0}System", FormatedPrefix));
          }
          break;
        case Hl7.Fhir.Model.SearchParamType.Uri:
          {
            Propertylist.Add(String.Format("{0}Uri", FormatedPrefix));
          }
          break;
        default:
          throw new InvalidEnumArgumentException(NonCollectionItem.SearchParamType.ToString(), (int)NonCollectionItem.SearchParamType, typeof(Hl7.Fhir.Model.SearchParamType));
      }
    }

    public static string GetServerSearchIndexTypeString(FhirApiSearchParameterInfo SearchParameter)
    {
      if (SearchParameter.TargetFhirLogicalType == typeof(Period) ||
        SearchParameter.TargetFhirLogicalType == typeof(Timing))
      {
        return DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.DatePeriodIndex];
      }
      else if (SearchParameter.TargetFhirLogicalType == typeof(Range))
      {
        return DatabaseModelInfo.BlazeIndexTypeToStringDictonary[DatabaseModelInfo.BlazeIndexType.QuantityRangeIndex];
      }
      else
      {
        return SearchParameter.SearchParamType.ToString() + DatabaseModelInfo.IndexPrefixText;
      }
    }

    public static string GenerateIndexSetter(string Item, string BlazeIndexType, string ReturnType, bool IsReferanceType = false)
    {
      if (IsReferanceType)
      {
        return string.Format("Index = IndexSetterFactory.Create(typeof({0})).Set({1}, Index, FhirRequestUri, this) as {2};", BlazeIndexType, Item, ReturnType);
      }
      else
      {
        return string.Format("Index = IndexSetterFactory.Create(typeof({0})).Set({1}, Index) as {2};", BlazeIndexType, Item, ReturnType);
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
