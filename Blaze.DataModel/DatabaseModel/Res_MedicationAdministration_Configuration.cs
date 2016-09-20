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
  public class Res_MedicationAdministration_Configuration : EntityTypeConfiguration<Res_MedicationAdministration>
  {

    public Res_MedicationAdministration_Configuration()
    {
      HasKey(x => x.Res_MedicationAdministrationID).Property(x => x.Res_MedicationAdministrationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.effectivetime_DateTimeOffsetLow).IsOptional();
      Property(x => x.effectivetime_DateTimeOffsetHigh).IsOptional();
      Property(x => x.encounter_VersionId).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Url);
      HasOptional<ServiceRootURL_Store>(x => x.encounter_Url).WithMany().HasForeignKey(x => x.encounter_ServiceRootURL_StoreID);
      Property(x => x.medication_VersionId).IsOptional();
      Property(x => x.medication_FhirId).IsOptional();
      Property(x => x.medication_Type).IsOptional();
      HasOptional(x => x.medication_Url);
      HasOptional<ServiceRootURL_Store>(x => x.medication_Url).WithMany().HasForeignKey(x => x.medication_ServiceRootURL_StoreID);
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.practitioner_VersionId).IsOptional();
      Property(x => x.practitioner_FhirId).IsOptional();
      Property(x => x.practitioner_Type).IsOptional();
      HasOptional(x => x.practitioner_Url);
      HasOptional<ServiceRootURL_Store>(x => x.practitioner_Url).WithMany().HasForeignKey(x => x.practitioner_ServiceRootURL_StoreID);
      Property(x => x.prescription_VersionId).IsOptional();
      Property(x => x.prescription_FhirId).IsOptional();
      Property(x => x.prescription_Type).IsOptional();
      HasOptional(x => x.prescription_Url);
      HasOptional<ServiceRootURL_Store>(x => x.prescription_Url).WithMany().HasForeignKey(x => x.prescription_ServiceRootURL_StoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.wasnotgiven_Code).IsOptional();
      Property(x => x.wasnotgiven_System).IsOptional();
    }
  }
}
