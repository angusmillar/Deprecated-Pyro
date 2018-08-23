using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUp.Engine;

namespace Pyro.DbManager.DbConnection
{
  public class WebConfigReader
  {
    private readonly string WebConfigFileName = "Web.config";
    private readonly string AppConfigFileName = "App.config";
    public DbConnectionInfo Read(string ConnectionStringName, string WebConfigFilePath = "")
    {
      string TargetWebConfigFilePath = string.Empty;
      if (!string.IsNullOrWhiteSpace(WebConfigFilePath))
      {
        //Path provided are an argument to the console application
        TargetWebConfigFilePath = WebConfigFilePath;
      }
      else if (System.Diagnostics.Debugger.IsAttached)
      {
        //When running in Visual Studio we use the Pyro.ConsoleServer db connection info
        string ExecutingDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string ProjectDirectory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(ExecutingDirectoryPath).FullName).FullName).FullName;        
        TargetWebConfigFilePath = $@"{ProjectDirectory}\Pyro.ConsoleServer\{AppConfigFileName}";
      }
      else
      {
        //When run out side of Visual Studio and no argument parameter is given, we asume the web.config file 
        //is in the parent directory. This is true when deployed in IIS
        string ExecutingDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string RootFolder = System.IO.Directory.GetParent(ExecutingDirectoryPath).FullName;
        TargetWebConfigFilePath = $@"{RootFolder}\{WebConfigFileName}";
      }

      if (!System.IO.File.Exists(TargetWebConfigFilePath))
      {
        //Last resort, check if the WebConfig file is in the same directory.
        string ExecutingDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        TargetWebConfigFilePath = $@"{ExecutingDirectoryPath}\{WebConfigFileName}";
        if (!System.IO.File.Exists(TargetWebConfigFilePath))
        {
          throw new FieldAccessException($"Unable to locate the {WebConfigFileName} file at the path: {TargetWebConfigFilePath}");
        }
      }

      var webFile = new System.Configuration.ExeConfigurationFileMap();
      webFile.ExeConfigFilename = TargetWebConfigFilePath; 
      System.Configuration.Configuration myConn = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(webFile, System.Configuration.ConfigurationUserLevel.None);
      System.Configuration.ConnectionStringSettings connSet = myConn.ConnectionStrings.ConnectionStrings[ConnectionStringName];
      if (connSet == null)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Failed!");
        Console.WriteLine("Unable to read the database connection string from the Web.Config file.");
        return null;
      }
      else
      {
        var ConnectionString = connSet.ConnectionString;
        var ProviderName = connSet.ProviderName;
        var DbConnectionInfo = new DbConnectionInfo();
        DbConnectionInfo.ProviderName = connSet.ProviderName;
        DbConnectionInfo.ConnectionString = connSet.ConnectionString;
        return DbConnectionInfo;
      }

    }
  }
}
