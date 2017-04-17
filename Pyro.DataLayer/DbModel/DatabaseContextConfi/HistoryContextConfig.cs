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

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class HistoryContextConfig<ResourceCurrentType, ResourceHistoryType, ResourceIndexType> : EntityTypeConfiguration<ResourceHistoryType>
    where ResourceCurrentType : ResourceCurrentBase<ResourceCurrentType, ResourceHistoryType, ResourceIndexType>
    where ResourceHistoryType : ResourceHistoryBase<ResourceCurrentType>
    where ResourceIndexType : ResourceIndexBase    
  {
    public HistoryContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = false })); ;
      Property(x => x.LastUpdated).IsRequired();
      Property(x => x.VersionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      HasRequired(x => x.Resource).WithMany(x => x.HistoryList).WillCascadeOnDelete(false);
    }
  }
}
