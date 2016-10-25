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
      Property(x => x.asserter_VersionId).IsOptional();
      Property(x => x.asserter_FhirId).IsOptional();
      Property(x => x.asserter_Type).IsOptional();
      HasOptional(x => x.asserter_Url);
      HasOptional<ServiceRootURL_Store>(x => x.asserter_Url).WithMany().HasForeignKey(x => x.asserter_ServiceRootURL_StoreID);
      Property(x => x.clinicalstatus_Code).IsOptional();
      Property(x => x.clinicalstatus_System).IsOptional();
      Property(x => x.context_VersionId).IsOptional();
      Property(x => x.context_FhirId).IsOptional();
      Property(x => x.context_Type).IsOptional();
      HasOptional(x => x.context_Url);
      HasOptional<ServiceRootURL_Store>(x => x.context_Url).WithMany().HasForeignKey(x => x.context_ServiceRootURL_StoreID);
      Property(x => x.date_recorded_Date).IsOptional();
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.subject_VersionId).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Url);
      HasOptional<ServiceRootURL_Store>(x => x.subject_Url).WithMany().HasForeignKey(x => x.subject_ServiceRootURL_StoreID);
    }
  }
}
