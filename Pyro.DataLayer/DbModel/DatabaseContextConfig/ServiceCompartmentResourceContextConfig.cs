using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using Pyro.DataLayer.DbModel.Entity;
using Pyro.DataLayer.DbModel.Extentions;
using Pyro.Common.Database;


namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceCompartmentResourceContextConfig : EntityTypeConfiguration<_ServiceCompartmentResource>
  {
    public ServiceCompartmentResourceContextConfig()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.Code).IsRequired().HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.ResourceTypeStringMaxLength); ;
      Property(x => x.Param).IsOptional();
      Property(x => x._ServiceCompartmentId)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_ServiceCompartmentId") { IsUnique = false }));
    }  
  }
}
