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
using Pyro.DataLayer.DbModel.EntityGenerated;
using Pyro.DataLayer.DbModel.EntityBase;
using Pyro.DataLayer.DbModel.Entity;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class IndexContextConfig<ResourceCurrentType, ResourceHistoryType, ResourceIndexType> : EntityTypeConfiguration<ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
    where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
    where ResourceIndexType : ResourceIndexBase
  {
    public IndexContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();

      Property(x => x.String).IsOptional();

      Property(x => x.Date).IsOptional();

      Property(x => x.DateTimeOffsetLow).IsOptional();
      Property(x => x.DateTimeOffsetHigh).IsOptional();

      Property(x => x.Uri).IsOptional();

      Property(x => x.Comparator).IsOptional();
      Property(x => x.Quantity).IsOptional();
      Property(x => x.Code).IsOptional();
      Property(x => x.System).IsOptional();
      Property(x => x.Unit).IsOptional();

      Property(x => x.ComparatorHigh).IsOptional();
      Property(x => x.QuantityHigh).IsOptional();
      Property(x => x.SystemHigh).IsOptional();
      Property(x => x.CodeHigh).IsOptional();
      Property(x => x.UnitHigh).IsOptional();

      Property(x => x.ReferenceFhirId).IsOptional();
      Property(x => x.ReferenceResourceType).IsOptional();
      Property(x => x.ReferenceVersionId).IsOptional();
      
      HasOptional<ServiceBaseUrl>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceBaseUrlId);
      Property(x => x.ServiceBaseUrlId).IsOptional();

      HasOptional<ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId).IsRequired();


    }
  }
}
