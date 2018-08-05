using Npgsql;
using System.Data.Entity;

namespace Pyro.DataLayer.DbModel.DbPostgreSql
{
  class NpgSqlConfiguration : DbConfiguration
  {
    public NpgSqlConfiguration()
    {
      var name = Common.Global.DatabaseConnection.PostgreSQLProvider;      
      SetProviderFactory(providerInvariantName: name,
      providerFactory: NpgsqlFactory.Instance);

      SetProviderServices(providerInvariantName: name,
      provider: NpgsqlServices.Instance);

      SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
      
    }

  }

}
