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
  public class Res_Organization_Configuration : EntityTypeConfiguration<Res_Organization>
  {

    public Res_Organization_Configuration()
    {
      HasKey(x => x.Res_OrganizationID).Property(x => x.Res_OrganizationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.active_Code).IsOptional();
      Property(x => x.active_System).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.partof_FhirId).IsOptional();
      Property(x => x.partof_Type).IsOptional();
      HasOptional(x => x.partof_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.partof_Url).WithMany().HasForeignKey(x => x.partof_Url_Blaze_RootUrlStoreID);
      Property(x => x.phonetic_String).IsOptional();
    }
  }
}
