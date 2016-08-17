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
  public class Res_DiagnosticReport_Configuration : EntityTypeConfiguration<Res_DiagnosticReport>
  {

    public Res_DiagnosticReport_Configuration()
    {
      HasKey(x => x.Res_DiagnosticReportID).Property(x => x.Res_DiagnosticReportID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.date_DateTimeOffsetLow).IsOptional();
      Property(x => x.date_DateTimeOffsetHigh).IsOptional();
      Property(x => x.encounter_VersionId).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Url);
      HasOptional<ServiceRootURL_Store>(x => x.encounter_Url).WithMany().HasForeignKey(x => x.encounter_ServiceRootURL_StoreID);
      Property(x => x.issued_DateTimeOffset).IsOptional();
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.performer_VersionId).IsOptional();
      Property(x => x.performer_FhirId).IsOptional();
      Property(x => x.performer_Type).IsOptional();
      HasOptional(x => x.performer_Url);
      HasOptional<ServiceRootURL_Store>(x => x.performer_Url).WithMany().HasForeignKey(x => x.performer_ServiceRootURL_StoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_VersionId).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Url);
      HasOptional<ServiceRootURL_Store>(x => x.subject_Url).WithMany().HasForeignKey(x => x.subject_ServiceRootURL_StoreID);
    }
  }
}
