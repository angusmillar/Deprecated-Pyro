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
  public class Res_PractitionerRole_Configuration : EntityTypeConfiguration<Res_PractitionerRole>
  {

    public Res_PractitionerRole_Configuration()
    {
      HasKey(x => x.Res_PractitionerRoleID).Property(x => x.Res_PractitionerRoleID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.organization_VersionId).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Url);
      HasOptional<ServiceRootURL_Store>(x => x.organization_Url).WithMany().HasForeignKey(x => x.organization_ServiceRootURL_StoreID);
      Property(x => x.practitioner_VersionId).IsOptional();
      Property(x => x.practitioner_FhirId).IsOptional();
      Property(x => x.practitioner_Type).IsOptional();
      HasOptional(x => x.practitioner_Url);
      HasOptional<ServiceRootURL_Store>(x => x.practitioner_Url).WithMany().HasForeignKey(x => x.practitioner_ServiceRootURL_StoreID);
    }
  }
}
