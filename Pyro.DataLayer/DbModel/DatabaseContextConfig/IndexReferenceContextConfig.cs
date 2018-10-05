using Pyro.Common.Database;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class IndexReferenceContextConfig<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType> : EntityTypeConfiguration<ResIndexReferenceType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType>

  {
    public IndexReferenceContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.ResourceId).IsRequired();
      HasOptional<_ServiceSearchParameter>(x => x.ServiceSearchParameter).WithMany().HasForeignKey(x => x.ServiceSearchParameterId);
      Property(x => x.ServiceSearchParameterId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_SearchParamId") { IsUnique = false }));

      if (StaticDatabaseInfo.DatabaseCreateSwitches.CaseSensitiveColumnAnnotationOn)
      {
        Property(x => x.ReferenceFhirId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_RefFhirId") { IsUnique = false }));

        Property(x => x.ReferenceVersionId)
        .HasColumnAnnotation("CaseSensitive", true)
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .IsOptional();
      }
      else
      {
        Property(x => x.ReferenceFhirId)
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_RefFhirId") { IsUnique = false }));

        Property(x => x.ReferenceVersionId)        
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .IsOptional();
      }

      Property(x => x.ReferenceResourceType).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.ResourceTypeStringMaxLength)
        .IsRequired();

      HasOptional(x => x.ReferenceUrl);
      HasOptional<_ServiceBaseUrl>(x => x.ReferenceUrl).WithMany().HasForeignKey(x => x.ReferenceServiceBaseUrlId);
      Property(x => x.ReferenceServiceBaseUrlId)
        .IsOptional()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_RefBaseUrlId") { IsUnique = false }));

    }
  }
}
