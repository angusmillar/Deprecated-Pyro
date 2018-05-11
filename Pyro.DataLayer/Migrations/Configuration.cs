using Pyro.Common.DtoEntity;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Pyro.DataLayer.DbModel.DatabaseContext;
using Hl7.Fhir.Model;

namespace Pyro.DataLayer.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<PyroDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(PyroDbContext context)
    {
      DbSeeding.SeedPyroDatabase PyroSeed = new DbSeeding.SeedPyroDatabase(context);
      PyroSeed.Seed();
      base.Seed(context);
    }

  }
}

