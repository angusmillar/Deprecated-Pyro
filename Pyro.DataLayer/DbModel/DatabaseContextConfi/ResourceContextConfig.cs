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

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ResourceContextConfig<ResourceCurrentType, ResourceIndexType> : EntityTypeConfiguration<ResourceCurrentType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceIndexType>
    where ResourceIndexType : ResourceIndexBase<ResourceCurrentType, ResourceIndexType>
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
          .HasMaxLength(128)
          .IsRequired()
          .HasUniqueIndexAnnotation("UQ_FhirIdAndVersionId", 0);

      Property(t => t.VersionId)
         .HasColumnAnnotation("CaseSensitive", true)
         .HasColumnName("VersionId")
         .HasMaxLength(128)
         .IsRequired()
         .HasUniqueIndexAnnotation("UQ_FhirIdAndVersionId", 1);

      Property(x => x.LastUpdated)
        .HasPrecision(3)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_LastUpdated")));

      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.Method).IsRequired();
      HasMany(c => c.IndexList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);

    }
  }
}
