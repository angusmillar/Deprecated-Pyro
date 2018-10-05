using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public abstract class ModelBaseConfig<T> : EntityTypeConfiguration<T> where T : EntityBase.ModelBase
  {
    public ModelBaseConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
    }
  }
}
