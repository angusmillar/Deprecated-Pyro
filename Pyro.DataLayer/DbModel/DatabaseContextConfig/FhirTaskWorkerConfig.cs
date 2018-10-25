using Pyro.Common.Database;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.Extentions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  class FhirTaskWorkerConfig : EntityTypeConfiguration<_FhirTaskWorker>
  {
    public FhirTaskWorkerConfig()
    {
      ToTable("_FhirTaskWorker");
      
      Property(x => x.TaskType)
        .IsRequired()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.CodeMaxLength)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_TaskType") { IsUnique = true }));

      Property(x => x.ClaimedBy)
        .IsOptional()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.CodeMaxLength)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ClaimedBy") { IsUnique = false }));      

    }
  }
}
