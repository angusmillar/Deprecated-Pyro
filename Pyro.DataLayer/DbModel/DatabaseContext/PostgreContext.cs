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
      //Below is only commented out for LinqPad Debug testing
      DbContextUtils<PostgreContext>.SetInitializer(new MigrateDatabaseToLatestVersion<PostgreContext, MigrationsPostgre.ConfigurationPostgre>());
    }

    protected override void OnModelCreating(DbModelBuilder Mb)
    {
      Mb.HasDefaultSchema("public");
      base.OnModelCreating(Mb);      
    }

  }
}
