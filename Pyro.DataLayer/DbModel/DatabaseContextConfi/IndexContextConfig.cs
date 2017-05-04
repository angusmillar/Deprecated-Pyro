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

      
      Property(x => x.String).IsOptional();

      Property(x => x.DateTimeOffsetLow).IsOptional();
      Property(x => x.DateTimeOffsetHigh).IsOptional();
      
      //Example of index, note that max string for an index is 900 bytes
      //Property(x => x.DateTimeOffsetLow).IsOptional().IsOptional()
      //  .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("ix_DateTimeOffsetLow")));
      //Property(x => x.DateTimeOffsetHigh).IsOptional()
      //  .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("ix_DateTimeOffsetHigh")));


      Property(x => x.Uri).IsOptional();

      Property(x => x.Comparator).IsOptional();
      Property(x => x.Quantity).IsOptional().HasPrecision(28, 14); ;
      Property(x => x.Code).IsOptional();
      Property(x => x.System).IsOptional();
      Property(x => x.Unit).IsOptional();

      Property(x => x.ComparatorHigh).IsOptional();
      Property(x => x.QuantityHigh).IsOptional().HasPrecision(28, 14);
      Property(x => x.SystemHigh).IsOptional();
      Property(x => x.CodeHigh).IsOptional();
      Property(x => x.UnitHigh).IsOptional();

      Property(x => x.ReferenceFhirId).IsOptional();
      Property(x => x.ReferenceResourceType).IsOptional();
      Property(x => x.ReferenceVersionId).IsOptional();
      
      HasOptional(x => x.ReferenceUrl);
      HasOptional<ServiceBaseUrl>(x => x.ReferenceUrl).WithMany().HasForeignKey(x => x.ReferenceServiceBaseUrlId);      

      HasOptional<ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId).IsRequired();

      Property(x => x.ResourceId).IsRequired();
      //HasRequired(x => x.Resource).WithMany(x => x.IndexList).Map(m => m.MapKey("ResourceId"));
      //HasRequired(x => x.Resource).WithMany().HasForeignKey(x => x.ResourceId).WillCascadeOnDelete(true);


    }
  }
}
