using System;
using Hl7.Fhir.Model;

namespace Blaze.Common.Tools
{
  public static class FhirTimeSupport
  {
    private static int YearInteger = 10000;
    private static int MonthInteger = 100;    

    public enum DatePrecision { Year, Month, Day};

    public static int? ConvertDateToInteger(Date Date)
    {
      //2001-05-06
      int DateInt = 0;
      if (Int32.TryParse(Date.Value.Replace("-", "").Replace(" ","").PadRight(8, '0'), out DateInt))
      {
        return DateInt;
      }
      else
      {
        return null;
      }
    }

    public static int? ConvertDateToInteger(DateTime Date, DatePrecision Precision)
    {
      int DateInt = 0;
      switch (Precision)
      {
        case DatePrecision.Year:
          if (Int32.TryParse(Date.Year.ToString().PadRight(8, '0'), out DateInt))
          {
            return DateInt;
          }
          else
          {
            return null;
          }
        case DatePrecision.Month:
          if (Int32.TryParse((Date.Year.ToString() + Date.Month.ToString().PadLeft(2,'0')).PadRight(8,'0'), out DateInt))
          {
            return DateInt;
          }
          else
          {
            return null;
          }
        case DatePrecision.Day:
          if (Int32.TryParse((Date.Year.ToString() + Date.Month.ToString().PadLeft(2, '0') + Date.Day.ToString().PadLeft(2, '0')), out DateInt))
          {
            return DateInt;
          }
          else
          {
            return null;
          }
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(Precision.ToString(), (int)Precision, typeof(DatePrecision));
      }
      
    }

    public static DatePrecision GetIntegerDatePrecision(int IntegerDate)
    {
      //19870425
      if ((IntegerDate % YearInteger) == 0)
      {
        return DatePrecision.Year;
      }
      else if ((IntegerDate % MonthInteger) == 0)
      {
        return DatePrecision.Month;
      }
      else if ((IntegerDate / 10000000) == 1)
      {
        return DatePrecision.Day;
      }
      else
      {
        throw new FormatException($"Error in date integer calculation of precision for FHIR Date. Date Integer was: {IntegerDate.ToString()}");
      }
    }

    public static int AddToIntegerDate(int DateInteger, int AmountToAdd, DatePrecision TypeToAdd)
    {
      string DateString = DateInteger.ToString();
      DateTime DateTimetemp = DateTime.MinValue;
      //Get the current precision of the date
      var Precision = FhirTimeSupport.GetIntegerDatePrecision(DateInteger);
      //Convert the DateInteger to a DateTime Type
      switch (Precision)
      {
        case DatePrecision.Year:
          DateTimetemp = new DateTime(Convert.ToInt32(DateString.Substring(0, 4)), 1, 1);          
          break;
        case DatePrecision.Month:
          DateTimetemp = new DateTime(Convert.ToInt32(DateString.Substring(0, 4)), Convert.ToInt32(DateString.Substring(4, 2)), 1);
          break;
        case DatePrecision.Day:
          DateTimetemp = new DateTime(Convert.ToInt32(DateString.Substring(0, 4)), Convert.ToInt32(DateString.Substring(4, 2)), Convert.ToInt32(DateString.Substring(6, 2)));
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(Precision.ToString(), (int)Precision, typeof(DatePrecision));
      }
      //Add the correct type to the dateTime
      switch (TypeToAdd)
      {
        case DatePrecision.Year:
          DateTimetemp = DateTimetemp.AddYears(AmountToAdd);
          break;
        case DatePrecision.Month:
          if (Precision == DatePrecision.Year)
            AmountToAdd = AmountToAdd - 1;
          DateTimetemp = DateTimetemp.AddMonths(AmountToAdd);
          break;
        case DatePrecision.Day:
          if (Precision != DatePrecision.Day)
            AmountToAdd = AmountToAdd - 1;
          DateTimetemp = DateTimetemp.AddDays(AmountToAdd);
          break;
        default:
          throw new System.ComponentModel.InvalidEnumArgumentException(TypeToAdd.ToString(), (int)TypeToAdd, typeof(DatePrecision));
      }

      //Convert back to a DateInteger
      int? TempInt = FhirTimeSupport.ConvertDateToInteger(DateTimetemp, Precision);
      if (TempInt.HasValue)
        return TempInt.Value;
      else
        throw new NullReferenceException("Error in Converting a DateTime to a integer date, it returned null.");
    }

  }
}
