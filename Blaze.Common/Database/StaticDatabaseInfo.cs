using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.Enum;

namespace Blaze.Common.Database
{
  public static class StaticDatabaseInfo
  {
    public static string ResourcePrefixText { get { return "Res"; } }
    public static string IndexPrefixText { get { return "Index"; } }
    public static string HistoryPrefixText { get { return "History"; } }
    public static string ListPostfixText { get { return "_List"; } }
    public static string XmlBlobPropertyText { get { return "XmlBlob"; } }
    public static string IndexSetterBaseInterfaceName = "IIndexSetter";
    public static string DatabaseModelBaseClassName { get { return "ModelBase"; } }
    public static string DatabaseModelResourceIndexBaseClassName { get { return "ResourceIndexBase"; } }



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

  }
}
