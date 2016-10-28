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
  public class Res_AppointmentResponse_Configuration : EntityTypeConfiguration<Res_AppointmentResponse>
  {

    public Res_AppointmentResponse_Configuration()
    {
      HasKey(x => x.Res_AppointmentResponseID).Property(x => x.Res_AppointmentResponseID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.actor_VersionId).IsOptional();
      Property(x => x.actor_FhirId).IsOptional();
      Property(x => x.actor_Type).IsOptional();
      HasOptional(x => x.actor_Url);
      HasOptional<ServiceRootURL_Store>(x => x.actor_Url).WithMany().HasForeignKey(x => x.actor_ServiceRootURL_StoreID);
      Property(x => x.appointment_VersionId).IsOptional();
      Property(x => x.appointment_FhirId).IsOptional();
      Property(x => x.appointment_Type).IsOptional();
      HasOptional(x => x.appointment_Url);
      HasOptional<ServiceRootURL_Store>(x => x.appointment_Url).WithMany().HasForeignKey(x => x.appointment_ServiceRootURL_StoreID);
      Property(x => x.location_VersionId).IsOptional();
      Property(x => x.location_FhirId).IsOptional();
      Property(x => x.location_Type).IsOptional();
      HasOptional(x => x.location_Url);
      HasOptional<ServiceRootURL_Store>(x => x.location_Url).WithMany().HasForeignKey(x => x.location_ServiceRootURL_StoreID);
      Property(x => x.part_status_Code).IsOptional();
      Property(x => x.part_status_System).IsOptional();
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.practitioner_VersionId).IsOptional();
      Property(x => x.practitioner_FhirId).IsOptional();
      Property(x => x.practitioner_Type).IsOptional();
      HasOptional(x => x.practitioner_Url);
      HasOptional<ServiceRootURL_Store>(x => x.practitioner_Url).WithMany().HasForeignKey(x => x.practitioner_ServiceRootURL_StoreID);
    }
  }
}
