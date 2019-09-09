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
    private string ProductName = "Unknown Product";
    private string ServiceVersion = "Unknown Version";
    private System.Diagnostics.Stopwatch Stopwatch;
    private Random RandomGenerator;

    public void Start(string ProductName, string ServiceVersion)
    {
      this.ProductName = ProductName;
      this.ServiceVersion = ServiceVersion;
      TimeSpan _updateInterval = TimeSpan.FromMilliseconds(500 * 1); // secs
      RefreashCounter = 0;
      FirstWarmMessageDisplayed = false;
      MessageList = GetMessageList();
      Stopwatch = new System.Diagnostics.Stopwatch();
      Stopwatch.Start();
      _Timer = new Timer(InitilizeServerMessages, null, _updateInterval, _updateInterval);
      RandomGenerator = new Random();
    }

    public void Stop()
    {
      _Timer.Change(Timeout.Infinite, Timeout.Infinite);
      _Timer = null;
      Stopwatch.Stop();
      Console.ResetColor();
      Console.Clear();
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
      MsgList.Add("Checking patient's privacy settings with Telstra's Health Engine");

      return MsgList;
    }

    private void InitilizeServerMessages(object state)
    {

      int RandomNewMessageChnageInt = RandomGenerator.Next(6, 15);
      if (!FirstWarmMessageDisplayed)
      {
        CurrentMessage = FirstMessage;
        FirstWarmMessageDisplayed = true;
      }
      else
      {
        if (RefreashCounter % RandomNewMessageChnageInt == 0)
        {          
          int RandomMessageInt = RandomGenerator.Next(0, MessageList.Count);
          CurrentMessage = MessageList[RandomMessageInt];
        }
        else
        {
          CurrentMessage = CurrentMessage + ".";
        }
      }
      
      
      Console.Clear();
      Console.CursorVisible = false;
      Console.CursorTop = 0;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write(PyroText.PyroTextLogo(this.ProductName, this.ServiceVersion));
      Console.ResetColor();
      Console.WriteLine("");
      WriteFullLine(CurrentMessage);
      Console.CursorVisible = false;
      Console.CursorTop = 0;
      RefreashCounter++;
      
    }

    private void WriteFullLine(string value)
    {
      string time = $"Time elapsed: { Stopwatch.Elapsed.Minutes.ToString()} min, { Stopwatch.Elapsed.Seconds.ToString()} secs";
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.Write($"Please wait while the database schema loads.".PadRight(Console.WindowWidth));
      Console.Write("".PadRight(Console.WindowWidth));
      Console.Write(value.PadRight(Console.WindowWidth));
      Console.Write("".PadRight(Console.WindowWidth));
      Console.Write(time.PadLeft(Console.WindowWidth));
      Console.ResetColor();
    }


  }
}
