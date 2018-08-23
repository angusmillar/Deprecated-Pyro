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
      DbContextUtils<MsSqlContext>.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlContext, MigrationsMicrosoftSQLServer.ConfigurationMsSql>());
    }

    protected override void OnModelCreating(DbModelBuilder Mb)
    {
      Mb.Properties<System.DateTime>().Configure(c => c.HasColumnType("datetime2"));
      base.OnModelCreating(Mb);
    }
  }

}
