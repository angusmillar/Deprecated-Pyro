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
using Pyro.DataLayer.DbModel.Extentions;
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ResourceContextConfig<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType> :
    EntityTypeConfiguration<ResCurrentType>
    where ResCurrentType : ResourceCurrentBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexStringType : ResourceIndexString<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexTokenType : ResourceIndexToken<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexUriType : ResourceIndexUri<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexReferenceType : ResourceIndexReference<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexQuantityType : ResourceIndexQuantity<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexDateTimeType : ResourceIndexDateTime<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
    where ResIndexBaseType : ResourceIndexBase<ResCurrentType, ResIndexStringType, ResIndexTokenType, ResIndexUriType, ResIndexReferenceType, ResIndexQuantityType, ResIndexDateTimeType, ResIndexBaseType>
  {
    public ResourceContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();

      Property(x => x.IsCurrent)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_IsCurrent")));

      Property(x => x.IsDeleted)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_IsDeleted")));

      // Should be only 64 char not 400?? Version is the same they are both id datatypes
      // They are also both CaseSensitive
      Property(t => t.FhirId)
          .HasColumnAnnotation("CaseSensitive", true)
          .HasColumnName("FhirId")
          .HasMaxLength(StaticDatabaseInfo.BaseResourceConstatnts.FhirIdMaxLength)
          .IsRequired()
          .HasUniqueIndexAnnotation("uq_FhirIdAndVersionId", 0);

      Property(t => t.VersionId)
         .HasColumnAnnotation("CaseSensitive", true)
         .HasColumnName("VersionId")
         .HasMaxLength(StaticDatabaseInfo.BaseResourceConstatnts.FhirIdMaxLength)
         .IsRequired()
         .HasUniqueIndexAnnotation("uq_FhirIdAndVersionId", 1);

      Property(x => x.LastUpdated)
        .HasPrecision(StaticDatabaseInfo.BaseResourceIndexConstatnts.DateTimeOffsetPrecision)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_LastUpdated")));

      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.Method).IsRequired();
      HasMany(c => c.IndexDataTimeList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);
      HasMany(c => c.IndexQuantityList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);
      HasMany(c => c.IndexReferenceList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);
      HasMany(c => c.IndexStringList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);
      HasMany(c => c.IndexTokenList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);
      HasMany(c => c.IndexUriList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);
      //HasMany(c => c.IndexList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);

    }
  }
}
