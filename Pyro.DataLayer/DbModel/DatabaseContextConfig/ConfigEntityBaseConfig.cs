using Pyro.DataLayer.DbModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public abstract class ConfigEntityBaseConfig<T> : ModelBaseConfig<T> where T : ConfigEntityBase
  {
    public ConfigEntityBaseConfig()
    {
      Property(x => x.CreatedUser).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.NameMaxLength)
       .IsRequired();

      Property(x => x.CreatedDate)
        .HasPrecision(StaticDatabaseInfo.BaseDatabaseFieldLength.DateTimeOffsetPrecision)
        .IsRequired();

      Property(x => x.LastUpdated)
        .HasPrecision(StaticDatabaseInfo.BaseDatabaseFieldLength.DateTimeOffsetPrecision)
        .IsRequired();

      Property(x => x.LastUpdatedUser).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.NameMaxLength)
        .IsRequired();
    }
  }
}
