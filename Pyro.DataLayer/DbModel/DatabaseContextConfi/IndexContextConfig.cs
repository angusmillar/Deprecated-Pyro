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
  public class IndexContextConfig<ResourceCurrentType, ResourceIndexType> : EntityTypeConfiguration<ResourceIndexType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
  {
    public IndexContextConfig()
    {

      HasKey(x => x.Id).Property(x => x.Id).IsRequired();

      Property(x => x.String).HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.StringMaxLength)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_String") { IsUnique = false }));

      Property(x => x.DateTimeOffsetLow)
        .HasPrecision(StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetPrecision)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_DateTimeOffsetLow") { IsUnique = false }));

      Property(x => x.DateTimeOffsetHigh)
        .HasPrecision(StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetPrecision)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_DateTimeOffsetHigh") { IsUnique = false }));

      Property(x => x.Uri).HasMaxLength(StaticDatabaseInfo.BaseResourceIndexConstatnts.UriMaxLength)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_Uri") { IsUnique = false }));

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

      Property(x => x.ReferenceFhirId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceConstatnts.FhirIdMaxLength)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ReferenceFhirId") { IsUnique = false }));

      Property(x => x.ReferenceResourceType).HasMaxLength(50).IsOptional();

      Property(x => x.ReferenceVersionId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(StaticDatabaseInfo.BaseResourceConstatnts.FhirIdMaxLength)
        .IsOptional();

      HasOptional(x => x.ReferenceUrl);
      HasOptional<ServiceBaseUrl>(x => x.ReferenceUrl).WithMany().HasForeignKey(x => x.ReferenceServiceBaseUrlId);
      Property(x => x.ReferenceServiceBaseUrlId)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ReferenceServiceBaseUrlId") { IsUnique = false }));


      HasOptional<ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ServiceSearchParameterId") { IsUnique = false }));

      Property(x => x.ResourceId).IsRequired();

    }
  }
}
