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

namespace Pyro.DataModel.DatabaseModel
{
  public class Res_Bundle_Configuration : EntityTypeConfiguration<Res_Bundle>
  {

    public Res_Bundle_Configuration()
    {
      HasKey(x => x.Res_BundleID).Property(x => x.Res_BundleID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.composition_VersionId).IsOptional();
      Property(x => x.composition_FhirId).IsOptional();
      Property(x => x.composition_Type).IsOptional();
      HasOptional(x => x.composition_Url);
      HasOptional<ServiceRootURL_Store>(x => x.composition_Url).WithMany().HasForeignKey(x => x.composition_ServiceRootURL_StoreID);
      Property(x => x.message_VersionId).IsOptional();
      Property(x => x.message_FhirId).IsOptional();
      Property(x => x.message_Type).IsOptional();
      HasOptional(x => x.message_Url);
      HasOptional<ServiceRootURL_Store>(x => x.message_Url).WithMany().HasForeignKey(x => x.message_ServiceRootURL_StoreID);
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
    }
  }
}
