using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Builder;
using DbUp.SqlServer.Helpers;
using Pyro.DbManager.DbConnection;
using DbUp.Postgresql;
using Pyro.DbManager.Seeding;
using Pyro.DbManager.Custom.MsSql;

namespace Pyro.DbManager
{

  internal static class Program
  {
    public static void Main(string[] args)
    {

      //FhirSearchParamters test = new FhirSearchParamters();
      //string SQL = test.GetMSSQLQuerySearchParameterTargetResources();

      Dictionary<string, string> Arguments = ProcessArguments(args);
      bool UnattendedMode = false;
      if (Arguments.ContainsKey("-unattendedmode"))
      {
        if (Arguments["-unattendedmode"] == "true")
        {
          UnattendedMode = true;
        }        
      }


      WebConfigReader WebConfigReader = new WebConfigReader();
      DbConnectionInfo ConnectionInfo = WebConfigReader.Read("PyroConnectionString");
      //string connectionString = string.Empty;
      if (ConnectionInfo != null)
      {                             
        string TargetScriptFolder = string.Empty;
        Tools.SynchToDbUp SynchToDbUp = new Tools.SynchToDbUp();

        UpgradeEngineBuilder UpgradeEngineBuilder = null;
        if (ConnectionInfo.ProviderName == ResourceStore.MsSQLProviderName)
        {

          SynchToDbUp.RunMsSQL(ConnectionInfo.ConnectionString);

          EnsureDatabase.For.SqlDatabase(ConnectionInfo.ConnectionString);
          
          TargetScriptFolder = $"{ResourceStore.BaseSqlScriptFolder}.{ResourceStore.MsSQLScriptFolder}";
          UpgradeEngineBuilder = DeployChanges.To
             .SqlDatabase(ConnectionInfo.ConnectionString, null) //null or "" for default schema for user
             .JournalToSqlTable("dbo", ResourceStore.DbUpSchemaVersionsTableName)
             .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith(TargetScriptFolder));          
        }
        else if (ConnectionInfo.ProviderName == ResourceStore.PostgreSQLProviderName)
        {
          SynchToDbUp.RunPostgreSQL(ConnectionInfo.ConnectionString);
          EnsureDatabase.For.PostgresqlDatabase(ConnectionInfo.ConnectionString);
          
          TargetScriptFolder = $"{ResourceStore.BaseSqlScriptFolder}.{ResourceStore.PostgreSqlScriptFolder}";
          UpgradeEngineBuilder = DeployChanges.To
             .PostgresqlDatabase(ConnectionInfo.ConnectionString, null) //null or "" for default schema for user
             .JournalToPostgresqlTable("public", ResourceStore.DbUpSchemaVersionsTableName)
             .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string s) => s.StartsWith(TargetScriptFolder));
        }
        else
        {
          throw new ApplicationException($"The ProviderName from the Connection information in the Web.Config file is not supported. Name was {ConnectionInfo.ProviderName}, supported are '{ResourceStore.MsSQLProviderName}' and '{ResourceStore.PostgreSQLProviderName}'.");
        }

        //Common to both SQL Server and PostgreSQL 
        UpgradeEngineBuilder.WithTransactionPerScript()
                           .WithVariablesDisabled()
                           .LogToConsole()
                           .WithExecutionTimeout(TimeSpan.FromSeconds(180));              

        var upgrader = UpgradeEngineBuilder.Build();

        Console.WriteLine("Building upgrade knowledge, please wait...");
        System.Threading.Thread.Sleep(1000 * 10);        
        bool UpgradeRequired = upgrader.IsUpgradeRequired();
        Console.WriteLine("Database upgrade required: " + UpgradeRequired.ToString());
        if (UpgradeRequired)
        {
          var ScriptsToExecute = upgrader.GetScriptsToExecute();
          Console.WriteLine("Scripts to execute:");
          foreach (var Script in ScriptsToExecute)
          {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"  {Script.Name.Substring(TargetScriptFolder.Count() + 1, Script.Name.Count() - (TargetScriptFolder.Count() + 1))}");
          }

          

          Console.ForegroundColor = ConsoleColor.Magenta; 
          Console.WriteLine("");
          bool OutputComplted = false;
          while (!OutputComplted)
          {
            Console.WriteLine();
            Console.WriteLine("Would you like the SQL scripts output to a folder");
            Console.WriteLine("before they are applied to the database?");
            Console.Write("Answer (Y/N)?: ");
            bool OutputSqlScripts = false;
            if (UnattendedMode)
            {
              OutputSqlScripts = false;
              OutputComplted = true;
            }
            else
            {
              ConsoleKeyInfo Input = Console.ReadKey();
              if (Input.Key == ConsoleKey.Y)
                OutputSqlScripts = true;
              else
                OutputComplted = true;
            }
            
            if (OutputSqlScripts)
            {
              Console.Clear();
              Console.WriteLine();
              Console.WriteLine("Please type the directory name where you would like the SQL scripts writen to?");
              Console.WriteLine("e.g 'C:\\Temp\\PyroSqlScripts' and hit [Enter]");
              Console.Write("Directory: ");
              string UserPath = Console.ReadLine();
              UserPath = UserPath.TrimEnd('\\');
              Tools.ScriptFileDrop ScriptFileDrop = new Tools.ScriptFileDrop(UserPath, ScriptsToExecute);
              string ScriptFileDropResult = ScriptFileDrop.Output(TargetScriptFolder);
              if (string.IsNullOrWhiteSpace(ScriptFileDropResult))
              {
                OutputComplted = true;
                foreach (var Script in ScriptsToExecute)
                {
                  Console.ForegroundColor = ConsoleColor.Cyan;
                  Console.WriteLine($"  {Script.Name.Substring(TargetScriptFolder.Count() + 1, Script.Name.Count() - (TargetScriptFolder.Count() + 1))}");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"All Sql Scripts where output to : '{UserPath}'");
              }
              else
              {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ScriptFileDropResult);
                Console.ForegroundColor = ConsoleColor.Magenta;
                OutputComplted = false;
              }
            }
          }

          
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("###############################################################################");
          Console.WriteLine("################### Have you backed up your database? #########################");
          Console.WriteLine("###############################################################################");
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.WriteLine("Do you wish to perform the upgrade against the database ?");
          Console.Write("Answer (Y/N)?: ");           
          bool Run = false;
          if (UnattendedMode)
          {
            Run = true;
            
          }
          else
          {
            ConsoleKeyInfo Input = Console.ReadKey();
            if (Input.Key == ConsoleKey.Y)
              Run = true;
          }
            
          if (Run)
          {
            DateTime StartTime = DateTime.Now;
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Start Time: {StartTime.ToShortDateString()} {StartTime.ToShortTimeString()}"); 
            var result = upgrader.PerformUpgrade();

            // Display the result
            if (result.Successful)
            {
              Console.ForegroundColor = ConsoleColor.Green;
              Console.WriteLine("Success!");
              DateTime EndTime = DateTime.Now;
              var Timer = EndTime.Subtract(StartTime);
              Console.ResetColor();
              Console.WriteLine($"TimeTaken: {Timer.Hours}:Hrs, {Timer.Minutes}:Mins, {Timer.Seconds}: Secs");
            }
            else
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine(result.Error);
              Console.WriteLine("Failed!");
              DateTime EndTime = DateTime.Now;
              var Timer = EndTime.Subtract(StartTime);
              Console.ResetColor();
              Console.WriteLine($"TimeTaken: {Timer.Hours}:Hrs, {Timer.Minutes}:Mins, {Timer.Seconds}: Secs");
            }
          }
          else
          {
            Console.Clear();
            Console.WriteLine("Upgrade aborted, press any key to end.");
          }
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("");
          Console.WriteLine("No upgrades are required!");
        }

        Console.ResetColor();
        Console.WriteLine("");
        Console.Write("Hit any key to end.");
        Console.ReadKey();
      }


    }

    private static Dictionary<string, string> ProcessArguments(string[] args)
    {
      Dictionary<string, string> Dic = new Dictionary<string, string>();
      string Key = string.Empty;
      foreach(string item in args)
      {
        string itemLow = item.ToLower();
        if (item.StartsWith("-"))
        {
          Dic.Add(itemLow, "");
          Key = itemLow;
        }
        else
        {
          if (!string.IsNullOrWhiteSpace(Key))
          {
            Dic[Key] = itemLow;
          }
          else
          {
            Key = string.Empty;
            itemLow = string.Empty;
          }
        }
      }
      return Dic;
    }
  }
}
