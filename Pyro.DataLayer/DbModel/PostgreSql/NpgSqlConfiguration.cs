using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Pyro.DataLayer.Migrations.Custom;

namespace Pyro.DataLayer.DbModel.PostgreSql
{
  class NpgSqlConfiguration : DbConfiguration
  {
    public NpgSqlConfiguration()
    {
      var name = "Npgsql";
      
      SetProviderFactory(providerInvariantName: name,
      providerFactory: NpgsqlFactory.Instance);

      SetProviderServices(providerInvariantName: name,
      provider: NpgsqlServices.Instance);

      SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
      

      //SetMigrationSqlGenerator(
      //    SqlProviderServices.ProviderInvariantName,
      //    () => new CustomSqlServerMigrationSqlGenerator());

      //SetMigrationSqlGenerator(
      //    name,
      //    () => new CustomSqlServerMigrationSqlGenerator());


    }

  }

}
