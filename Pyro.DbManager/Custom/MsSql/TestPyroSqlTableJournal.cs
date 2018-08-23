using DbUp.Builder;
using DbUp.Engine.Output;
using DbUp.Engine.Transactions;
using DbUp.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DbManager.Custom.MsSql
{

  public class TestPyroSqlTableJournal : DbUp.SqlServer.SqlTableJournal
  {

    private string Schema = string.Empty;
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlTableJournal"/> class.
    /// </summary>
    /// <param name="connectionManager">The connection manager.</param>
    /// <param name="logger">The log.</param>
    /// <param name="schema">The schema that contains the table.</param>
    /// <param name="table">The table name.</param>
    /// <example>
    /// var journal = new TableJournal("Server=server;Database=database;Trusted_Connection=True", "dbo", "MyVersionTable");
    /// </example>
    public TestPyroSqlTableJournal(Func<IConnectionManager> connectionManager, Func<IUpgradeLog> logger, string schema, string table)
        : base(connectionManager, logger, schema, table)
    {
      Schema = schema;
    }


    protected override void OnTableCreated(Func<IDbCommand> dbCommandFactory)
    {


      Console.WriteLine("Check __MigrationHistory to __SchemaVersions synch.");
      IDbCommand cmd = dbCommandFactory();
      cmd.CommandText = $@"SELECT * 
                          FROM INFORMATION_SCHEMA.TABLES
                          WHERE TABLE_SCHEMA = '{Schema}'
                          AND TABLE_NAME = '__MigrationHistory'";

      
      bool __MigrationHistoryExists = false;
      using (var reader = cmd.ExecuteReader())
      {
        __MigrationHistoryExists = reader.Read();
      }

      if (__MigrationHistoryExists)
      {
        Console.WriteLine("__MigrationHistory to __SchemaVersions is required.");
        Console.WriteLine("Migrations to synch:");
        cmd.CommandText = $"SELECT [MigrationId] FROM [{Schema}].[__MigrationHistory]";
        List<string> InsertValueList = new List<string>();
        //2018-08-21 15:19:02.927
        string DateNowString = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            //Pyro.DbManager.SqlScripts.MsSQL.201706130247261_First.sql
            string ScriptName = reader.GetString(0);
            Console.WriteLine(ScriptName);
            string InsertValue = $"('Pyro.DbManager.SqlScripts.MsSQL.{ScriptName}', '{DateNowString}')";            
            InsertValueList.Add(InsertValue);            
          }
        }
        
        var scriptBuilder = new StringBuilder();
        scriptBuilder.Append($"INSERT INTO [{Schema}].[__SchemaVersions] ([ScriptName], [Applied]) VALUES ");
        for (int i = 0; i < InsertValueList.Count; i++)        
        {
          if (i == InsertValueList.Count - 1)
            scriptBuilder.AppendLine($"{InsertValueList[i]}");
          else
            scriptBuilder.AppendLine($"{InsertValueList[i]},");
        }

        cmd.CommandText = scriptBuilder.ToString();
        try
        {
          using (var reader2 = cmd.ExecuteReader())
          {
            int RowCount = reader2.RecordsAffected;
            Console.WriteLine("Commit synch.");
            Console.WriteLine($"Migrations commited count: {RowCount}");
          }
        }
        catch(System.Exception Exec)
        {
          Console.WriteLine(Exec.Message);
        }

      }
      Console.WriteLine($"__MigrationHistory to __SchemaVersions not required.");
    }
    
  }

  

}
