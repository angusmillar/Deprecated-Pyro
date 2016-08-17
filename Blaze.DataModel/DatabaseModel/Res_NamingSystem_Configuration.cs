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

//This is an Auto generated file do not change it's contents!!.

namespace Blaze.DataModel.DatabaseModel
{
  public class Res_NamingSystem_Configuration : EntityTypeConfiguration<Res_NamingSystem>
  {

    public Res_NamingSystem_Configuration()
    {
      HasKey(x => x.Res_NamingSystemID).Property(x => x.Res_NamingSystemID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.kind_Code).IsOptional();
      Property(x => x.kind_System).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.publisher_String).IsOptional();
      Property(x => x.replaced_by_VersionId).IsOptional();
      Property(x => x.replaced_by_FhirId).IsOptional();
      Property(x => x.replaced_by_Type).IsOptional();
      HasOptional(x => x.replaced_by_Url);
      HasOptional<ServiceRootURL_Store>(x => x.replaced_by_Url).WithMany().HasForeignKey(x => x.replaced_by_ServiceRootURL_StoreID);
      Property(x => x.responsible_String).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
