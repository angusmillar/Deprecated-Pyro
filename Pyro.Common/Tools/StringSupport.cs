using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools
{
  public static class StringSupport
  {
    public static string RemoveDiacritics(string text)
    {
      return string.Concat(
          text.Normalize(NormalizationForm.FormD)
          .Where(ch => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch) !=
                       System.Globalization.UnicodeCategory.NonSpacingMark)
        ).Normalize(NormalizationForm.FormC);
    }

    public static string ToLowerFast(string text)
    {
      return text.ToLower(System.Globalization.CultureInfo.CurrentCulture);
    }

    public static string ToLowerAndRemoveDiacritics(string text)
    {
      return ToLowerFast(RemoveDiacritics(text));
    }

    public static string ToLowerTrimRemoveDiacriticsTruncate(string text, int TruncateMaxLength)
    {
      return ToLowerFast(RemoveDiacritics(text.Trim().Truncate(TruncateMaxLength)));
    }

    public static string UppercaseFirst(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      char[] a = s.ToCharArray();
      a[0] = char.ToUpper(a[0]);
      return new string(a);
    }

    public static string RemoveWhitespace(string text)
    {
      return new string(text.ToCharArray()
          .Where(c => !Char.IsWhiteSpace(c))
          .ToArray());
    }

    public static int GetScaleFromDecimal(string value)
    {
      const string DecimalPoint = ".";
      if (value.Contains(DecimalPoint))
      {
        return value.Length - (value.IndexOf(DecimalPoint) + 1);
      }
      else
      {
        return 0;
      }
    }

    public static int GetPrecisionFromDecimal(string value)
    {
      const string DecimalPoint = ".";
      if (value.Contains(DecimalPoint))
      {
        return value.Length - 1;
      }
      else
      {
        return value.Length;
      }
    }

    public static string Truncate(this string str, int maxLength)
    {
      if (str.Length > maxLength)
      {
        return str.Substring(0, maxLength);
      }
      return str;      
    }

    public static bool StringToBoolean(string value)
    {
      value = ToLowerFast(value);
      if ((value == "true") || (value == "yes") || (value == "on") || (value == "1"))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool StringIsBoolean(string value)
    {
      value = ToLowerFast(value);
      if ((value == "true") || (value == "yes") || (value == "on") || (value == "1") ||
        (value == "false") || (value == "no") || (value == "off") || (value == "0"))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Returns the string removing http:// or https://
    /// </summary>
    /// <param name="Uri"></param>
    /// <returns></returns>
    public static string StripHttp(this string Uri)
    {
      string http = "http://";
      string https = "https://";
      if (Uri.ToLower().StartsWith(http))
      {
        Uri = Uri.Substring(http.Count(), Uri.Count() - http.Count());
      }
      if (Uri.ToLower().StartsWith(https))
      {
        Uri = Uri.Substring(https.Count(), Uri.Count() - https.Count());
      }
      return Uri;
    }
    /// <summary>
    /// Strips of either https or http and performs a insensative compare between the two uris
    /// </summary>
    /// <param name="left"></param>
    /// <param name="Uri"></param>
    /// <returns></returns>
    public static bool IsEqualUri(this string left, string Uri)
    {
      return (left.StripHttp() == Uri.StripHttp());
    }

    public static string GetPropertyName<TValue>(Expression<Func<TValue>> propertyId)
    {
      return ((MemberExpression)propertyId.Body).Member.Name;
    }
    
    public static string ReconstructSortSearchParameter(IList<Tuple<string, Hl7.Fhir.Rest.SortOrder>> SortList)
    {
      string Result = string.Empty;
      for (int i = 0; i < SortList.Count; i++)
      {
        string Temp = string.Empty;
        if (SortList[i].Item2 == Hl7.Fhir.Rest.SortOrder.Descending)
        {
          Temp = "-";
        }
        Temp = Temp + SortList[i].Item1;        
        if (i < SortList.Count - 1)
          Temp = Temp + ",";
        Result = Result + Temp;
      }
      return "_sort=" + Result;
    }
  }
}
