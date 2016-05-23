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
  public class Res_Condition_Configuration : EntityTypeConfiguration<Res_Condition>
  {

    public Res_Condition_Configuration()
    {
      HasKey(x => x.Res_ConditionID).Property(x => x.Res_ConditionID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.asserter_FhirId).IsOptional();
      Property(x => x.asserter_Type).IsOptional();
      HasOptional(x => x.asserter_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.asserter_Url).WithMany().HasForeignKey(x => x.asserter_Url_Blaze_RootUrlStoreID);
      Property(x => x.clinicalstatus_Code).IsOptional();
      Property(x => x.clinicalstatus_System).IsOptional();
      Property(x => x.date_recorded_DateTimeOffset).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.encounter_Url).WithMany().HasForeignKey(x => x.encounter_Url_Blaze_RootUrlStoreID);
      Property(x => x.onset_DateTimeOffset).IsOptional();
      Property(x => x.onset_info_String).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
    }
  }
}
