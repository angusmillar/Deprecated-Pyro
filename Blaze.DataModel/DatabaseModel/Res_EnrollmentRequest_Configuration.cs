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
  public class Res_EnrollmentRequest_Configuration : EntityTypeConfiguration<Res_EnrollmentRequest>
  {

    public Res_EnrollmentRequest_Configuration()
    {
      HasKey(x => x.Res_EnrollmentRequestID).Property(x => x.Res_EnrollmentRequestID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.patient_identifier_Code).IsOptional();
      Property(x => x.patient_identifier_System).IsOptional();
      Property(x => x.patient_reference_VersionId).IsOptional();
      Property(x => x.patient_reference_FhirId).IsOptional();
      Property(x => x.patient_reference_Type).IsOptional();
      HasOptional(x => x.patient_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_reference_Url).WithMany().HasForeignKey(x => x.patient_reference_ServiceRootURL_StoreID);
      Property(x => x.subject_identifier_Code).IsOptional();
      Property(x => x.subject_identifier_System).IsOptional();
      Property(x => x.subject_reference_VersionId).IsOptional();
      Property(x => x.subject_reference_FhirId).IsOptional();
      Property(x => x.subject_reference_Type).IsOptional();
      HasOptional(x => x.subject_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.subject_reference_Url).WithMany().HasForeignKey(x => x.subject_reference_ServiceRootURL_StoreID);
    }
  }
}
