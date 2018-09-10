using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.Extentions;
using Pyro.Common.Database;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceSearchParameterCompositePivotConfig : EntityTypeConfiguration<_ServiceSearchParameterCompositePivot>
  {
    public ServiceSearchParameterCompositePivotConfig()
    {
      
      ToTable("_SCompositePivot");
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.Url).HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength).IsOptional();
      Property(x => x.Expression).IsRequired();
      Property(x => x.SequentialOrder).IsRequired();

      //HasRequired(x => x.ParentServiceSearchParameter)
      //  .WithMany(c => c.ServiceSearchParameterCompositePivotList)
      //  .HasForeignKey(z => z.ParentServiceSearchParameterId);
        
      Property(x => x.ParentServiceSearchParameterId)
        .IsRequired()        
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ParentParamId") { IsUnique = false }));

      HasRequired(x => x.ChildServiceSearchParameter)
        .WithMany()
        .HasForeignKey(a => a.ChildServiceSearchParameterId)
        .WillCascadeOnDelete(false);
        
      Property(x => x.ChildServiceSearchParameterId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ChildParamId") { IsUnique = false }));
    }
  }
}
