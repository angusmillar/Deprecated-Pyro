using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Pyro.Common.Global
{
  public static class DatabaseConnection
  {
    public static string PyroConnectionStringName = "PyroConnectionString";
    public static string PostgreSQLProvider = "Npgsql";
    public static string MicrosoftSQLServerProvider = "System.Data.SqlClient";

    public static ConnectionStringSettings GetConectionStringSettings()
    {      
      try
      {        
        return ConfigurationManager.ConnectionStrings[PyroConnectionStringName];                
      }
      catch (Exception Exec)
      {
        string Message = $@"Unable to get the database connection string with the name '{PyroConnectionStringName}' from the App_Data\Connections.config file.";
        Logging.Logger.Log.Fatal(Exec, Message);
        throw new System.ApplicationException(Message, Exec);
      }
    }
  }
}
