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
  public class Res_MedicationDispense_Configuration : EntityTypeConfiguration<Res_MedicationDispense>
  {

    public Res_MedicationDispense_Configuration()
    {
      HasKey(x => x.Res_MedicationDispenseID).Property(x => x.Res_MedicationDispenseID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.code_Code).IsOptional();
      Property(x => x.code_System).IsOptional();
      Property(x => x.destination_FhirId).IsOptional();
      Property(x => x.destination_Type).IsOptional();
      HasOptional(x => x.destination_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.destination_Url).WithMany().HasForeignKey(x => x.destination_Url_Blaze_RootUrlStoreID);
      Property(x => x.dispenser_FhirId).IsOptional();
      Property(x => x.dispenser_Type).IsOptional();
      HasOptional(x => x.dispenser_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.dispenser_Url).WithMany().HasForeignKey(x => x.dispenser_Url_Blaze_RootUrlStoreID);
      Property(x => x.identifier_Code).IsOptional();
      Property(x => x.identifier_System).IsOptional();
      Property(x => x.medication_FhirId).IsOptional();
      Property(x => x.medication_Type).IsOptional();
      HasOptional(x => x.medication_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.medication_Url).WithMany().HasForeignKey(x => x.medication_Url_Blaze_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.whenhandedover_DateTimeOffset).IsOptional();
      Property(x => x.whenprepared_DateTimeOffset).IsOptional();
    }
  }
}
