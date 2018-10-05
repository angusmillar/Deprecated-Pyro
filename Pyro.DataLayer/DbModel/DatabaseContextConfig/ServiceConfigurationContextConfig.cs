using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceConfigurationContextConfig : ConfigEntityBaseConfig<_ServiceConfiguration>
  {
    public ServiceConfigurationContextConfig()
    {
      ToTable("_ServConfig");
      
      Property(x => x.Parameter).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength);
      Property(x => x.Value).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength);      
      
    }
  }
}
