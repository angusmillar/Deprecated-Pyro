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
  public class IndexContextConfig<ResourceCurrentType, ResourceIndexType> : EntityTypeConfiguration<ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>    
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
  {
    public IndexContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();

      
      Property(x => x.String).HasMaxLength(450).IsOptional();

      Property(x => x.DateTimeOffsetLow).IsOptional();
      Property(x => x.DateTimeOffsetHigh).IsOptional();

      //Property(x => x.DateTimeOffsetLow).HasPrecision(3).IsOptional();
      //Property(x => x.DateTimeOffsetHigh).HasPrecision(3).IsOptional();


      //Example of index, note that max string for an index is 900 bytes
      //Property(x => x.DateTimeOffsetLow).IsOptional().IsOptional()
      //  .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("ix_DateTimeOffsetLow")));
      //Property(x => x.DateTimeOffsetHigh).IsOptional()
      //  .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("ix_DateTimeOffsetHigh")));


      Property(x => x.Uri).HasMaxLength(450).IsOptional();

      Property(x => x.Comparator).IsOptional();
      Property(x => x.Quantity).IsOptional().HasPrecision(28, 14); ;
      Property(x => x.Code).HasMaxLength(50).IsOptional();
      Property(x => x.System).HasMaxLength(300).IsOptional();
      Property(x => x.Unit).HasMaxLength(50).IsOptional();

      Property(x => x.ComparatorHigh).IsOptional();
      Property(x => x.QuantityHigh).IsOptional().HasPrecision(28, 14);
      Property(x => x.CodeHigh).HasMaxLength(50).IsOptional();
      Property(x => x.SystemHigh).HasMaxLength(300).IsOptional();      
      Property(x => x.UnitHigh).HasMaxLength(50).IsOptional();

      Property(x => x.ReferenceFhirId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(128).IsOptional();
      Property(x => x.ReferenceResourceType).HasMaxLength(50).IsOptional();
      Property(x => x.ReferenceVersionId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(128).IsOptional();
      
      HasOptional(x => x.ReferenceUrl);
      HasOptional<ServiceBaseUrl>(x => x.ReferenceUrl).WithMany().HasForeignKey(x => x.ReferenceServiceBaseUrlId);      

      HasOptional<ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId).IsRequired();

      Property(x => x.ResourceId).IsRequired();      

    }
  }
}
