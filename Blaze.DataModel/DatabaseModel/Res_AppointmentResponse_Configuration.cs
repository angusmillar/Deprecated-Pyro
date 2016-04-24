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
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.actor_FhirId).IsOptional();
      Property(x => x.actor_Type).IsOptional();
      HasOptional(x => x.actor_Aux_RootUrlStoreID);
      Property(x => x.appointment_FhirId).IsOptional();
      Property(x => x.appointment_Type).IsOptional();
      HasOptional(x => x.appointment_Aux_RootUrlStoreID);
      Property(x => x.location_FhirId).IsOptional();
      Property(x => x.location_Type).IsOptional();
      HasOptional(x => x.location_Aux_RootUrlStoreID);
      Property(x => x.part_status_Code).IsOptional();
      Property(x => x.part_status_System).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Aux_RootUrlStoreID);
      Property(x => x.practitioner_FhirId).IsOptional();
      Property(x => x.practitioner_Type).IsOptional();
      HasOptional(x => x.practitioner_Aux_RootUrlStoreID);
    }
  }
}
