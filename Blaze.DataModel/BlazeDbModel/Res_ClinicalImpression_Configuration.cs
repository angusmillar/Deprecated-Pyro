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
  public class Res_ClinicalImpression_Configuration : EntityTypeConfiguration<Res_ClinicalImpression>
  {

    public Res_ClinicalImpression_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));;
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();      
      Property(x => x.assessor_FhirId).IsOptional();
      Property(x => x.assessor_Type).IsOptional();
      Property(x => x.assessor_Url).IsOptional();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      Property(x => x.patient_Url).IsOptional();
      Property(x => x.previous_FhirId).IsOptional();
      Property(x => x.previous_Type).IsOptional();
      Property(x => x.previous_Url).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.trigger_FhirId).IsOptional();
      Property(x => x.trigger_Type).IsOptional();
      Property(x => x.trigger_Url).IsOptional();
      Property(x => x.trigger_code_Code).IsOptional();
      Property(x => x.trigger_code_System).IsOptional();
     
     }
  }
}
