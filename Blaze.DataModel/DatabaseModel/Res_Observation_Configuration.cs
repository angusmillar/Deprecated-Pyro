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
  public class Res_Observation_Configuration : EntityTypeConfiguration<Res_Observation>
  {

    public Res_Observation_Configuration()
    {
      HasKey(x => x.Res_ObservationID).Property(x => x.Res_ObservationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.date_DateTimeOffsetLow).IsOptional();
      Property(x => x.date_DateTimeOffsetHigh).IsOptional();
      Property(x => x.device_VersionId).IsOptional();
      Property(x => x.device_FhirId).IsOptional();
      Property(x => x.device_Type).IsOptional();
      HasOptional(x => x.device_Url);
      HasOptional<ServiceRootURL_Store>(x => x.device_Url).WithMany().HasForeignKey(x => x.device_ServiceRootURL_StoreID);
      Property(x => x.encounter_VersionId).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Url);
      HasOptional<ServiceRootURL_Store>(x => x.encounter_Url).WithMany().HasForeignKey(x => x.encounter_ServiceRootURL_StoreID);
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.specimen_VersionId).IsOptional();
      Property(x => x.specimen_FhirId).IsOptional();
      Property(x => x.specimen_Type).IsOptional();
      HasOptional(x => x.specimen_Url);
      HasOptional<ServiceRootURL_Store>(x => x.specimen_Url).WithMany().HasForeignKey(x => x.specimen_ServiceRootURL_StoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_VersionId).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Url);
      HasOptional<ServiceRootURL_Store>(x => x.subject_Url).WithMany().HasForeignKey(x => x.subject_ServiceRootURL_StoreID);
      Property(x => x.value_date_DateTimeOffset).IsOptional();
      Property(x => x.value_date_DateTimeOffsetLow).IsOptional();
      Property(x => x.value_date_DateTimeOffsetHigh).IsOptional();
      Property(x => x.value_quantity_Comparator).IsOptional();
      Property(x => x.value_quantity_Quantity).IsOptional();
      Property(x => x.value_quantity_System).IsOptional();
      Property(x => x.value_quantity_Code).IsOptional();
      Property(x => x.value_string_String).IsOptional();
    }
  }
}
