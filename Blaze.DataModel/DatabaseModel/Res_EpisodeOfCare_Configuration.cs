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
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.care_manager_FhirId).IsOptional();
      Property(x => x.care_manager_Type).IsOptional();
      HasOptional(x => x.care_manager_Aux_RootUrlStoreID);
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Aux_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Aux_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
