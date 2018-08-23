using Pyro.Common.DtoEntity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.MigrationsMicrosoftSQLServer
{
  internal sealed class ConfigurationMsSql : DbMigrationsConfiguration<MsSqlContext>
  {
    public ConfigurationMsSql()
    {
      //To obtain a new SQL script for an upgrade change the 'AutomaticMigrationsEnabled' to equal True and run
      //Update-Database -Script -ConfigurationTypeName ConfigurationMsSql
      //Remember to then set back to False after the SQL script is obtained.
      //Also remember that you must haved the Pyro.ConsoleServer project selected as the start-up project for 
      //it to pick up that projects Web.config settings
      AutomaticMigrationsEnabled = false;
      //AutomaticMigrationDataLossAllowed = true;
      MigrationsDirectory = "MigrationsMicrosoftSQLServer";
      //We must set the ContextKey to the older name of this class as 
      //older databases out there will have this ContextKey set in their __MigrationHistory table
      ContextKey = "Pyro.DataLayer.Migrations.Configuration";
      
    }

    //protected override void Seed(MsSqlContext context)
    //{
    //  DbSeeding.SeedPyroDatabase PyroSeed = new DbSeeding.SeedPyroDatabase(context);
    //  PyroSeed.Seed();
    //  base.Seed(context);
    //}

  }
}

