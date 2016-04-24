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
  public class Res_CommunicationRequest_Configuration : EntityTypeConfiguration<Res_CommunicationRequest>
  {

    public Res_CommunicationRequest_Configuration()
    {
      HasKey(x => x.Res_CommunicationRequestID).Property(x => x.Res_CommunicationRequestID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Aux_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Aux_RootUrlStoreID);
      Property(x => x.requested_DateTimeOffset).IsOptional();
      Property(x => x.requester_FhirId).IsOptional();
      Property(x => x.requester_Type).IsOptional();
      HasOptional(x => x.requester_Aux_RootUrlStoreID);
      Property(x => x.sender_FhirId).IsOptional();
      Property(x => x.sender_Type).IsOptional();
      HasOptional(x => x.sender_Aux_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Aux_RootUrlStoreID);
      Property(x => x.time_DateTimeOffset).IsOptional();
    }
  }
}
