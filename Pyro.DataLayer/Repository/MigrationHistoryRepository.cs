using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Pyro.Common.Interfaces.Repositories;
using System.Collections.Generic;
using Pyro.Common.Logging;

namespace Pyro.DataLayer.Repository
{
  public class MigrationHistoryRepository : BaseRepository, IMigrationHistoryRepository
  {
    private readonly ILog ILog;

    private readonly string MicrosoftSQLServerMigrationsDirectory = "MigrationsMicrosoftSQLServer";
    private readonly string PostgreSQLServerMigrationsDirectory = "MigrationsPostgre";

    public MigrationHistoryRepository(IPyroDbContext IPyroDbContext, ILog ILog)
      : base(IPyroDbContext)
    {
      this.ILog = ILog;
    }
    
    public bool CheckMigrationsPerformed()
    {
      string CurrentProviderName = Pyro.Common.Global.DatabaseConnection.CurrentProviderName();
      string CurrentMigrationsDirectory = string.Empty;
      string SqlMigrationHistoryQuery = string.Empty;

      if (CurrentProviderName == Pyro.Common.Global.DatabaseConnection.PostgreSQLProvider)
      {
        //PostgreSQL
        CurrentMigrationsDirectory = PostgreSQLServerMigrationsDirectory;
        SqlMigrationHistoryQuery = "SELECT \"MigrationId\" FROM public.\"__MigrationHistory\" order by LEFT(\"MigrationId\", 15) desc LIMIT 1;";
      }
      else if (CurrentProviderName == Pyro.Common.Global.DatabaseConnection.MicrosoftSQLServerProvider)
      {
        //Microsoft SQL Server
        CurrentMigrationsDirectory = MicrosoftSQLServerMigrationsDirectory;
        SqlMigrationHistoryQuery = "SELECT top 1 [MigrationId] FROM [dbo].[__MigrationHistory] order by LEFT([MigrationId], 15) desc";
      }

      var DataLayerAssembly = System.Reflection.Assembly.GetExecutingAssembly();
      var MigrationMetadataList = DataLayerAssembly.GetTypes()
                       .Where(x => typeof(System.Data.Entity.Migrations.DbMigration).IsAssignableFrom(x))
                       .Select(migration => (System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata)System.Activator.CreateInstance(migration))                                              
                       .OrderBy(x => x.Id)
                       .ToList();

      
      var MigrationsForCurrentProviderList = new List<string>();
      foreach(var Migration in MigrationMetadataList)
      {
        string TypeName = Migration.GetType().ToString();
        if (TypeName.Contains($".{CurrentMigrationsDirectory}."))
        {
          MigrationsForCurrentProviderList.Add(Migration.Id);
        }
      }              
     if (MigrationsForCurrentProviderList.Count == 0)
      {
        string Message = "The MigrationsForCurrentProviderList was empty, this should not happen as their must always be a 'First' Migration. " +
          $"Check that the migration directories are still correct in the code base. These should be '{MicrosoftSQLServerMigrationsDirectory}' for MSSQL and '{PostgreSQLServerMigrationsDirectory}' for PostgreSQL. ";
        ILog.Fatal(Message);
        throw new System.ApplicationException(Message);
      }

      try
      {
        string MostRecentDbMigrationID = IPyroDbContext.Database.SqlQuery<string>(SqlMigrationHistoryQuery).FirstOrDefault();
        if (!MostRecentDbMigrationID.Equals(MigrationsForCurrentProviderList.Last(), System.StringComparison.CurrentCultureIgnoreCase))
        {
          //Error Migration not applied.
          string Message = "The Pyro FHIR server's database appears to not be upgraded to a version which matches the application version " +
            $"currently running. The database reports the last migration performed as '{MostRecentDbMigrationID}' and the application reports the last migration " +
            $"required as '{MigrationsForCurrentProviderList.Last()}'. Please run the Pyro.DbManager tool to ensure your database is up-to-date.";
          ILog.Fatal(Message);
          return false;
        }
        return true;
      }
      catch(System.Exception Exec)
      {
        string Message = "Exception thrown trying to query the database on start-up to Check Migrations Are Applied. See inner exception for more detail.";
        ILog.Fatal(Exec, Message);
        throw new System.ApplicationException(Message, Exec);
      }      
    }
  }
}
