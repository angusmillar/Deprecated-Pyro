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
      Property(x => x.IsCurrent).IsRequired();
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.IsDeleted).IsRequired();

      Property(t => t.FhirId)
          .HasColumnName("FhirId")
          .HasMaxLength(400)
          .IsRequired()
          .HasUniqueIndexAnnotation("UQ_FhirIdAndVersionId", 0);

      Property(t => t.VersionId)
         .HasColumnName("VersionId")
         .HasMaxLength(50)
         .IsRequired()
         .HasUniqueIndexAnnotation("UQ_FhirIdAndVersionId", 1);
      
      //Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      //Property(x => x.LastUpdated).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("dsf")));
      Property(x => x.LastUpdated).HasPrecision(3).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("dsf")));
      //Property(x => x.VersionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.Method).IsRequired();
      HasMany(c => c.IndexList).WithOptional(c => c.Resource).HasForeignKey(c => c.ResourceId).WillCascadeOnDelete(true);

    }
  }
}
