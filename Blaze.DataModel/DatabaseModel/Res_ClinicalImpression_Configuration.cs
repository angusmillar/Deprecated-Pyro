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
  public class Res_ClinicalImpression_Configuration : EntityTypeConfiguration<Res_ClinicalImpression>
  {

    public Res_ClinicalImpression_Configuration()
    {
      HasKey(x => x.Res_ClinicalImpressionID).Property(x => x.Res_ClinicalImpressionID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.assessor_VersionId).IsOptional();
      Property(x => x.assessor_FhirId).IsOptional();
      Property(x => x.assessor_Type).IsOptional();
      HasOptional(x => x.assessor_Url);
      HasOptional<ServiceRootURL_Store>(x => x.assessor_Url).WithMany().HasForeignKey(x => x.assessor_ServiceRootURL_StoreID);
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.previous_VersionId).IsOptional();
      Property(x => x.previous_FhirId).IsOptional();
      Property(x => x.previous_Type).IsOptional();
      HasOptional(x => x.previous_Url);
      HasOptional<ServiceRootURL_Store>(x => x.previous_Url).WithMany().HasForeignKey(x => x.previous_ServiceRootURL_StoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.trigger_VersionId).IsOptional();
      Property(x => x.trigger_FhirId).IsOptional();
      Property(x => x.trigger_Type).IsOptional();
      HasOptional(x => x.trigger_Url);
      HasOptional<ServiceRootURL_Store>(x => x.trigger_Url).WithMany().HasForeignKey(x => x.trigger_ServiceRootURL_StoreID);
    }
  }
}
