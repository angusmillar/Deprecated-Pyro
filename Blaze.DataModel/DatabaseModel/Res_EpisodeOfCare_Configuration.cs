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
  public class Res_EpisodeOfCare_Configuration : EntityTypeConfiguration<Res_EpisodeOfCare>
  {

    public Res_EpisodeOfCare_Configuration()
    {
      HasKey(x => x.Res_EpisodeOfCareID).Property(x => x.Res_EpisodeOfCareID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.care_manager_FhirId).IsOptional();
      Property(x => x.care_manager_Type).IsOptional();
      HasOptional(x => x.care_manager_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.care_manager_Url).WithMany().HasForeignKey(x => x.care_manager_Url_Blaze_RootUrlStoreID);
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.organization_Url).WithMany().HasForeignKey(x => x.organization_Url_Blaze_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
