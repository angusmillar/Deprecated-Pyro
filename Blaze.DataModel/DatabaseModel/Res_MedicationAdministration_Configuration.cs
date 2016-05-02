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
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.code_Code).IsOptional();
      Property(x => x.code_System).IsOptional();
      Property(x => x.effectivetime_DateTimeOffset).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.encounter_Url).WithMany().HasForeignKey(x => x.encounter_Url_Blaze_RootUrlStoreID);
      Property(x => x.medication_FhirId).IsOptional();
      Property(x => x.medication_Type).IsOptional();
      HasOptional(x => x.medication_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.medication_Url).WithMany().HasForeignKey(x => x.medication_Url_Blaze_RootUrlStoreID);
      Property(x => x.notgiven_Code).IsOptional();
      Property(x => x.notgiven_System).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.practitioner_FhirId).IsOptional();
      Property(x => x.practitioner_Type).IsOptional();
      HasOptional(x => x.practitioner_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.practitioner_Url).WithMany().HasForeignKey(x => x.practitioner_Url_Blaze_RootUrlStoreID);
      Property(x => x.prescription_FhirId).IsOptional();
      Property(x => x.prescription_Type).IsOptional();
      HasOptional(x => x.prescription_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.prescription_Url).WithMany().HasForeignKey(x => x.prescription_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
