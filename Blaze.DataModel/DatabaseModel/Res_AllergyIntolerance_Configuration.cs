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
  public class Res_AllergyIntolerance_Configuration : EntityTypeConfiguration<Res_AllergyIntolerance>
  {

    public Res_AllergyIntolerance_Configuration()
    {
      HasKey(x => x.Res_AllergyIntoleranceID).Property(x => x.Res_AllergyIntoleranceID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.category_Code).IsOptional();
      Property(x => x.category_System).IsOptional();
      Property(x => x.criticality_Code).IsOptional();
      Property(x => x.criticality_System).IsOptional();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.last_date_DateTimeOffset).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.recorder_FhirId).IsOptional();
      Property(x => x.recorder_Type).IsOptional();
      HasOptional(x => x.recorder_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.recorder_Url).WithMany().HasForeignKey(x => x.recorder_Url_Blaze_RootUrlStoreID);
      Property(x => x.reporter_FhirId).IsOptional();
      Property(x => x.reporter_Type).IsOptional();
      HasOptional(x => x.reporter_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.reporter_Url).WithMany().HasForeignKey(x => x.reporter_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
    }
  }
}
