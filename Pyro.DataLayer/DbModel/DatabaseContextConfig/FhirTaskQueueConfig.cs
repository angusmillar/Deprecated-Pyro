using Pyro.Common.Database;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.Extentions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  class FhirTaskQueueConfig : EntityTypeConfiguration<_FhirTaskQueue>
  {
    public FhirTaskQueueConfig()
    {
      ToTable("_FhirTaskQueue");
      

      Property(x => x.TaskFhirId)
        .IsRequired()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .HasUniqueIndexAnnotation("uq_TaskFhirIdAndType", 0);

      Property(x => x.TaskType)
        .IsRequired()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.CodeMaxLength)
        .HasUniqueIndexAnnotation("uq_TaskFhirIdAndType", 1);

      Property(x => x.PerfomrerConnectionId)        
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_PConnectId") { IsUnique = false }));

      Property(x => x.Status)
        .IsRequired()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.CodeMaxLength)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_Status") { IsUnique = false }));      

    }
  }
}
