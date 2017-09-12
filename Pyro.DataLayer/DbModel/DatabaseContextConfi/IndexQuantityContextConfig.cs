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
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class IndexQuantityContextConfig<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> : EntityTypeConfiguration<ResIndexQuantityType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    
  {
    public IndexQuantityContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.ResourceId).IsRequired();
      HasOptional<ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ServiceSearchParameterId") { IsUnique = false }));

      //Low or Single
      Property(x => x.Comparator).IsOptional();

      Property(x => x.Quantity)
        .IsOptional()
        .HasPrecision(StaticDatabaseInfo.BaseResourceIndexConstatnts.QuantityPrecision,
        StaticDatabaseInfo.BaseResourceIndexConstatnts.QuantityScale);

      Property(x => x.Code)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.CodeMaxLength)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_Code") { IsUnique = false }));

      Property(x => x.System)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.SystemMaxLength)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_System") { IsUnique = false }));

      Property(x => x.Unit)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.SystemMaxLength)
        .IsOptional();

      //High
      Property(x => x.ComparatorHigh).IsOptional();

      Property(x => x.QuantityHigh)
        .IsOptional()
        .HasPrecision(StaticDatabaseInfo.BaseResourceIndexConstatnts.QuantityPrecision,
        StaticDatabaseInfo.BaseResourceIndexConstatnts.QuantityScale);

      Property(x => x.CodeHigh)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.CodeMaxLength)
        .IsOptional();

      Property(x => x.SystemHigh)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.SystemMaxLength)
        .IsOptional();

      Property(x => x.UnitHigh)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.UnitMaxLength)
        .IsOptional();

    }
  }
}
