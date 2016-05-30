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
  public class Res_Immunization_Configuration : EntityTypeConfiguration<Res_Immunization>
  {

    public Res_Immunization_Configuration()
    {
      HasKey(x => x.Res_ImmunizationID).Property(x => x.Res_ImmunizationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.location_VersionId).IsOptional();
      Property(x => x.location_FhirId).IsOptional();
      Property(x => x.location_Type).IsOptional();
      HasOptional(x => x.location_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.location_Url).WithMany().HasForeignKey(x => x.location_Url_Blaze_RootUrlStoreID);
      Property(x => x.lot_number_String).IsOptional();
      Property(x => x.manufacturer_VersionId).IsOptional();
      Property(x => x.manufacturer_FhirId).IsOptional();
      Property(x => x.manufacturer_Type).IsOptional();
      HasOptional(x => x.manufacturer_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.manufacturer_Url).WithMany().HasForeignKey(x => x.manufacturer_Url_Blaze_RootUrlStoreID);
      Property(x => x.notgiven_Code).IsOptional();
      Property(x => x.notgiven_System).IsOptional();
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_Url_Blaze_RootUrlStoreID);
      Property(x => x.performer_VersionId).IsOptional();
      Property(x => x.performer_FhirId).IsOptional();
      Property(x => x.performer_Type).IsOptional();
      HasOptional(x => x.performer_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.performer_Url).WithMany().HasForeignKey(x => x.performer_Url_Blaze_RootUrlStoreID);
      Property(x => x.requester_VersionId).IsOptional();
      Property(x => x.requester_FhirId).IsOptional();
      Property(x => x.requester_Type).IsOptional();
      HasOptional(x => x.requester_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.requester_Url).WithMany().HasForeignKey(x => x.requester_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
