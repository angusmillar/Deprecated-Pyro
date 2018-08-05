using Pyro.DataLayer.Support;
using System.Data.Entity;

namespace Pyro.DataLayer.DbModel.DatabaseContext
{
  [DbConfigurationType("Pyro.DataLayer.DbModel.DbMicrosoftSQLServer.CustomApplicationDbConfiguration, Pyro.DataLayer")]
  public class MsSqlContext : PyroDbContext, IPyroDbContext
  {
    public MsSqlContext()
      : base()
    {
      //Below is only commented out for LinqPad Debug testing
      DbContextUtils<MsSqlContext>.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlContext, MigrationsMicrosoftSQLServer.ConfigurationMsSql>());
    }

  }
}
