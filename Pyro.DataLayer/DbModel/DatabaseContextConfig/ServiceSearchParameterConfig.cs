using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.Extentions;
using Pyro.Common.Database;


namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceSearchParameterConfig : EntityTypeConfiguration<_ServiceSearchParameter>
  {
    public ServiceSearchParameterConfig()
    {
      ToTable("_SearchParam");
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.Name).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.NameMaxLength)
        .IsRequired()
        .HasUniqueIndexAnnotation("uq_ResourceAndName", 1);

      Property(x => x.Description).IsOptional();
      Property(x => x.Resource).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.DescriptionMaxLength)
        .IsRequired()
        .HasUniqueIndexAnnotation("uq_ResourceAndName", 0);

      Property(x => x.Expression).IsRequired();
      Property(x => x.Type).IsRequired();
      Property(x => x.Url).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength).IsOptional();
      Property(x => x.XPath).IsOptional();
      Property(x => x.LastUpdated).IsRequired();
      Property(x => x.IsIndexed)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_IsIndexed") { IsUnique = false }));

      Property(x => x.Status)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_Status") { IsUnique = false }));

      Property(x => x.SearchParameterResourceId).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength).IsOptional();
      Property(x => x.SearchParameterResourceVersion).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.FhirIdMaxLength).IsOptional();
      HasMany(c => c.TargetResourceTypeList).WithRequired(c => c.ServiceSearchParameter).HasForeignKey(c => c.ServiceSearchParameterId).WillCascadeOnDelete(true);

    }
  }
}
