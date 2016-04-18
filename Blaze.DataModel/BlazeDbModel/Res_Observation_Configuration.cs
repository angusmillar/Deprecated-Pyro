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

namespace Blaze.DataModel.BlazeDbModel
{
  public class Res_Observation_Configuration : EntityTypeConfiguration<Res_Observation>
  {

    public Res_Observation_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Property(x => x.Received).IsRequired();
      Property(x => x.XmlBlob).IsRequired();      
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.device_FhirId).IsOptional();
      Property(x => x.device_Type).IsOptional();
      Property(x => x.device_Url).IsOptional();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      Property(x => x.encounter_Url).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      Property(x => x.patient_Url).IsOptional();
      Property(x => x.specimen_FhirId).IsOptional();
      Property(x => x.specimen_Type).IsOptional();
      Property(x => x.specimen_Url).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      Property(x => x.subject_Url).IsOptional();
      Property(x => x.value_concept_Code).IsOptional();
      Property(x => x.value_concept_System).IsOptional();
      Property(x => x.value_date_DateTimeOffset).IsOptional();
      Property(x => x.value_quantity_Quantity).IsOptional();
      Property(x => x.value_quantity_System).IsOptional();
      Property(x => x.value_quantity_Code).IsOptional();
      Property(x => x.value_string_String).IsOptional();
     
     }
  }
}
