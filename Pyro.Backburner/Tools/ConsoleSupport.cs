using System;

namespace Pyro.Backburner.Tools
{
  public static class ConsoleSupport
  {
    public static void ConsoleWriteLine(string message)
    {
      Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}: {message}");
    }
    public static void DividingLine()
    {
      Console.WriteLine("================================================================================");
    }
    public static void RegisterTask(string TaskName)
    {
      Console.WriteLine($" - {TaskName}");
    }

    
  }
}
