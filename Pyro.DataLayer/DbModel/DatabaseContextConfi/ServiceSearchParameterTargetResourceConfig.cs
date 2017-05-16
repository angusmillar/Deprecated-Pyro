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
  public class ServiceSearchParameterTargetResourceConfig : EntityTypeConfiguration<ServiceSearchParameterTargetResource>
  {
    public ServiceSearchParameterTargetResourceConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.ResourceType).IsRequired();
      Property(x => x.ServiceSearchParameterId).IsRequired();      
    }
  }
}
