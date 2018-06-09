using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pyro.Common.ProductText
{
  public class PyroWarmUpMessages
  {
    private Timer _Timer;
    private int RefreashCounter = 0;
    private bool FirstWarmMessageDisplayed = false;
    private List<string> MessageList;
    private string FirstMessage = "Fhiring up the database server";
    private string CurrentMessage = string.Empty;
    private System.Diagnostics.Stopwatch Stopwatch;

    public void Start()
    {
      TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000 * 1); // secs
      RefreashCounter = 0;
      FirstWarmMessageDisplayed = false;
      MessageList = GetMessageList();
      Stopwatch = new System.Diagnostics.Stopwatch();
      Stopwatch.Start();
      _Timer = new Timer(InitilizeServerMessages, null, _updateInterval, _updateInterval);
    }

    public void Stop()
    {
      _Timer.Change(Timeout.Infinite, Timeout.Infinite);
      _Timer = null;
      Stopwatch.Stop();
    }

    private List<string> GetMessageList()
    {
      var MsgList = new List<string>();
      MsgList.Add("Powering up defibrillators");
      MsgList.Add("Interrupting doctors golf game");
      MsgList.Add("Fixing HL7's International Reputation (FHIR)");
      MsgList.Add("Deleting your facilities PMI database");
      MsgList.Add("Uploading all patient records to Cambridge Analytica");
      MsgList.Add("Validating cassette tape capacity");
      MsgList.Add("Defragging disk drives");
      MsgList.Add("Instantiating Blockchain and Health AI");
      MsgList.Add("Re-aligning moon orbit for satellite connection");
      MsgList.Add("Transposing Mumps code libraries to .NET");
      MsgList.Add("Downloading My Health Records to database ");
      MsgList.Add("Signal check Department of Human Services 56k modem");
      MsgList.Add("Parsing HL7 V2.1 Message structures");
      MsgList.Add("Kermit protocol packet checking in progress");
      MsgList.Add("Cerner feature request, progress unknown");
      MsgList.Add("Loading green screen rendering engine");
      MsgList.Add("Importing green screen rendering engine enhancment 'Orange'");

      return MsgList;
    }

    private void InitilizeServerMessages(object state)
    {
      if (!FirstWarmMessageDisplayed)
      {
        CurrentMessage = FirstMessage;
        FirstWarmMessageDisplayed = true;
      }
      else
      {
        if (RefreashCounter % 6 == 0)
        {
          Random RandomGenerator = new Random();
          int RandomInt = RandomGenerator.Next(0, MessageList.Count);
          CurrentMessage = MessageList[RandomInt];
        }
        else
        {
          CurrentMessage = CurrentMessage + ".";
        }
      }
      
      Console.Clear();
      Console.CursorVisible = false;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write(Common.ProductText.PyroText.PyroTextLogo(" Pyro Server  "));
      Console.ResetColor();
      Console.WriteLine("");
      WriteFullLine(CurrentMessage);      
      RefreashCounter++;
    }

    private void WriteFullLine(string value)
    {
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine($"Please wait while the database schema loads. Time elapsed: {Stopwatch.Elapsed.Minutes.ToString()} min, {Stopwatch.Elapsed.Seconds.ToString()} secs".PadRight(Console.WindowWidth - 1));
      Console.WriteLine("".PadRight(Console.WindowWidth - 1));
      Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
      Console.WriteLine("".PadRight(Console.WindowWidth - 1));
      Console.WriteLine("".PadRight(Console.WindowWidth - 1));      
      Console.ResetColor();
    }

  }
}
