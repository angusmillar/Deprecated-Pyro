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

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceSearchParameterConfig : EntityTypeConfiguration<ServiceSearchParameter>
  {
    public ServiceSearchParameterConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.Name).IsRequired();
      Property(x => x.Description).IsOptional();
      Property(x => x.Resource).IsRequired();
      Property(x => x.Expression).IsRequired();
      Property(x => x.Type).IsRequired();
      Property(x => x.Url).IsOptional();
      Property(x => x.XPath).IsOptional();      
    }
  }
}
