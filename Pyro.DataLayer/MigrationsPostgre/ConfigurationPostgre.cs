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
      AutomaticMigrationsEnabled = true;
      MigrationsDirectory = "MigrationsPostgre";
      ContextKey = "PostgreSQL";
    }    
  }
}

