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
      AutomaticMigrationsEnabled = true;
      MigrationsDirectory = "MigrationsMicrosoftSQLServer";
      //We must set the ContextKey to the older name of this class as 
      //the older databases out there will have this older ContextKey set in their 
      //__MigrationHistory table
      ContextKey = "Pyro.DataLayer.Migrations.Configuration";      
    }
    
  }
}

