using Pyro.DataLayer.Support;
using System.Data.Entity;

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  [DbConfigurationType("Pyro.DataLayer.DbModel.DbMicrosoftSQLServer.CustomApplicationDbConfiguration, Pyro.DataLayer")]
  public class MsSqlContext : PyroDbContext, IPyroDbContext
  {
    public MsSqlContext()
      : base("PyroConnectionString")
    {
      //To obtain a new SQL migration script for a database upgrade follow these steps:
      //-----------------------------------------------------------------------------------
      //1. Set Pyro.ConsoleServer as the StartUp project
      //2. Set the 'DevelopmentOnlyGenerateMigrations' boolean to True
      //3. Open the Package Manager Console under the tools menu in Visual Studio
      //4. Set the 'Default Project' drop-down in the Package Manager Console to 'Pyro.DataLayer'
      //5. Run the following command to create a new Migration class: 
      //     Add-Migration -Name [Migration Name] -ConfigurationTypeName ConfigurationMsSql 
      //6. Run the following command generate the SQL script based on the Migration class:      
      //     Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationMsSql 
      //7. Copy the generated SQL script into a new file in the project Pyro.DbManager under the folder 'SqlScripts\MsSQL, 
      //   use the same file name as that generated Migration class, only changing the extension from .cs to .sql'
      //   add prefix the file name with an underscore e.g: '_[filename].sql'
      //8. Set the Build Action of the new .sql file in the Pyro.DbManager project to 'Embedded Resource'
      //9. Set the 'GenerateMigration' boolean below back to False.
      //10. Run the Pyro.DbManager project to upgrade the database.
      //-----------------------------------------------------------------------------------


      if (Common.Database.StaticDatabaseInfo.DatabaseCreateSwitches.DevelopmentOnlyGenerateMigrations)
      {       
        DbContextUtils<MsSqlContext>.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlContext, MigrationsMicrosoftSQLServer.ConfigurationMsSql>());
      }
      else
      {
        Database.SetInitializer<PostgreContext>(null);
      }
      
    }

    protected override void OnModelCreating(DbModelBuilder Mb)
    {
      Mb.Properties<System.DateTime>().Configure(c => c.HasColumnType("datetime2"));
      base.OnModelCreating(Mb);
    }
  }

}
