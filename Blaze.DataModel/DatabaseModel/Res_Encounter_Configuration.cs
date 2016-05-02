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
  public class Res_Encounter_Configuration : EntityTypeConfiguration<Res_Encounter>
  {

    public Res_Encounter_Configuration()
    {
      HasKey(x => x.Res_EncounterID).Property(x => x.Res_EncounterID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.appointment_FhirId).IsOptional();
      Property(x => x.appointment_Type).IsOptional();
      HasOptional(x => x.appointment_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.appointment_Url).WithMany().HasForeignKey(x => x.appointment_Url_Blaze_RootUrlStoreID);
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.length_Number).IsOptional();
      Property(x => x.part_of_FhirId).IsOptional();
      Property(x => x.part_of_Type).IsOptional();
      HasOptional(x => x.part_of_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.part_of_Url).WithMany().HasForeignKey(x => x.part_of_Url_Blaze_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
