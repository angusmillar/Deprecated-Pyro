using System;

namespace Pyro.Common.Tools
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

    public static void NewLine()
    {      
      Console.WriteLine();
    }

    public static void Line()
    {
      if (!Console.IsOutputRedirected)
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(Line('-'));
      }
    }

    public static void TimeStampWriteLine(string message)
    {
      if (!Console.IsOutputRedirected)
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{TimeStamp}: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{message}");
        Line();
      }
    }

    public static void DateTimeStampWriteLine(string message)
    {
      if (!Console.IsOutputRedirected)
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{DateTimeStamp}: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{message}");
      }
    }

  }
}
