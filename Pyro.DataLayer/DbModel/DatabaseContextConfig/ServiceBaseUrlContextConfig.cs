using Pyro.Common.Database;
using Pyro.DataLayer.DbModel.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Pyro.DataLayer.DbModel.DatabaseContextConfig
{
  public class ServiceBaseUrlContextConfig : ConfigEntityBaseConfig<_ServiceBaseUrl>
  {
    public ServiceBaseUrlContextConfig()
    {
      ToTable("_BaseUrl");
      
      Property(x => x.Url).IsRequired()
        .HasMaxLength(StaticDatabaseInfo.BaseDatabaseFieldLength.StringMaxLength)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        new IndexAnnotation(new IndexAttribute("ix_Url") { IsUnique = true }));

      Property(x => x.IsServersPrimaryUrlRoot).IsRequired();      
    }
  }
}
