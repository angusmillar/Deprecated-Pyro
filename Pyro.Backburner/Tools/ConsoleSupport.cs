using Hl7.Fhir.Utility;
using Pyro.Common.BackgroundTask;
using Pyro.Common.Enum;
using System;

namespace Pyro.Backburner.Tools
{
  public static class ConsoleSupport
  {

    private static string Line(char charToUse)
    {
      return new String(charToUse, 79);
    }

    private static string DateTimeStamp
    {
      get { return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"); }
    }

    private static string TimeStamp
    {
      get { return DateTime.Now.ToString("HH:mm:ss.fff"); }
    }

    public static void Line()
    {
      Console.WriteLine(Line('-'));
    }

    public static void TimeStampWriteLine(string message)
    {
      Console.WriteLine($"{TimeStamp}: {message}");
      ConsoleSupport.Line();
    }

    public static void DateTimeStampWriteLine(string message)
    {
      Console.WriteLine($"{DateTimeStamp}: {message}");
    }

  }
}
