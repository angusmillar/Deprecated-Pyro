using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Pyro.DataLayer.DbModel.DbMicrosoftSQLServer
{
  public class CustomApplicationDbConfiguration : DbConfiguration
  {
    public CustomApplicationDbConfiguration()
    {      
      SetMigrationSqlGenerator(
          SqlProviderServices.ProviderInvariantName,
          () => new CustomSqlServerMigrationSqlGenerator());
    }
  }
}
