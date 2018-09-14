using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.Support;
using System.Data.Entity;


namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  [DbConfigurationType("Pyro.DataLayer.DbModel.DbPostgreSql.NpgSqlConfiguration, Pyro.DataLayer")]
  public class PostgreContext : PyroDbContext, IPyroDbContext
  {
    public PostgreContext()
      : base("PyroConnectionString")
    {
      //To obtain a new SQL migration script for a database upgrade follow these steps:
      //-----------------------------------------------------------------------------------
      //1. Set Pyro.ConsoleServer as the StartUp project
      //2. Set the 'GenerateMigration' boolean below to True
      //3. Open the Package Manager Console under the tools menu in Visual Studio
      //4. Set the 'Default Project' drop-down in the Package Manager Console to 'Pyro.DataLayer'
      //5. Run the following command to create a new Migration class: 
      //     Add -Migration -Name [Migration Name] -ConfigurationTypeName ConfigurationPostgre   
      //6. Run the following command generate the SQL script based on the Migration class:      
      //     Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationPostgre 
      //7. Copy the generated SQL script into a new file in the project Pyro.DbManager under the folder 'SqlScripts\PostgreSql, 
      //   use the same file name as that generated Migration class, only changing the extension from .cs to .sql'
      //8. Set the Build Action of the new .sql file in the Pyro.DbManager project to 'Embedded Resource'
      //9. Set the 'GenerateMigration' boolean below back to False.
      //10. Run the Pyro.DbManager project to upgrade the database.
      //-----------------------------------------------------------------------------------

      bool GenerateMigration = true;
      if (GenerateMigration)
      {
        //if (!System.Diagnostics.Debugger.IsAttached)
        //{
        //  throw new System.ApplicationException("Oh no, the developer has left a development only setting of 'GenerateMigration' for Microsoft SQL Server as True and this code appears to be running outside of the development environment. " +
        //    "Unfortunately this is not allowed. Please contact your system administrator.");
        //}
        DbContextUtils<PostgreContext>.SetInitializer(new MigrateDatabaseToLatestVersion<PostgreContext, MigrationsPostgre.ConfigurationPostgre>());
      }
      else
      {
        Database.SetInitializer<PostgreContext>(null);
      }      
    }

    protected override void OnModelCreating(DbModelBuilder Mb)
    {
      Mb.HasDefaultSchema("public");
      base.OnModelCreating(Mb);      
    }

  }
}
