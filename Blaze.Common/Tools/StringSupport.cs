using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Common.Tools
{
  public class StringSupport
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


  }
}
