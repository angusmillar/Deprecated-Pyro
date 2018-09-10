using Pyro.Common.DtoEntity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.MigrationsPostgre
{
  internal sealed class ConfigurationPostgre : DbMigrationsConfiguration<PostgreContext>
  {
    public ConfigurationPostgre()
    {
      //To obtain a new SQL script for an upgrade change the 'AutomaticMigrationsEnabled' to equal True and run

      //Add-Migration -Name [Migration Name] -ConfigurationTypeName ConfigurationPostgre   

      //and
      
      //Update-Database -TargetMigration [Migration Name] -Script -ConfigurationTypeName ConfigurationPostgre 

      //Remember to then set back to False after the SQL script is obtained.
      //Also remember that you must have the Pyro.ConsoleServer project selected as the start-up project for 
      //it to pick up that projects Web.config settings
      AutomaticMigrationsEnabled = false;
      MigrationsDirectory = "MigrationsPostgre";
      ContextKey = "PostgreSQL";
    }

    //protected override void Seed(PostgreContext context)
    //{
    //  DbSeeding.SeedPyroDatabase PyroSeed = new DbSeeding.SeedPyroDatabase(context);
    //  PyroSeed.Seed();
    //  base.Seed(context);
    //}

  }
}

