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
  public class Res_ProcedureRequest_Configuration : EntityTypeConfiguration<Res_ProcedureRequest>
  {

    public Res_ProcedureRequest_Configuration()
    {
      HasKey(x => x.Res_ProcedureRequestID).Property(x => x.Res_ProcedureRequestID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.encounter_FhirId).IsOptional();
      Property(x => x.encounter_Type).IsOptional();
      HasOptional(x => x.encounter_Aux_RootUrlStoreID);
      Property(x => x.orderer_FhirId).IsOptional();
      Property(x => x.orderer_Type).IsOptional();
      HasOptional(x => x.orderer_Aux_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Aux_RootUrlStoreID);
      Property(x => x.performer_FhirId).IsOptional();
      Property(x => x.performer_Type).IsOptional();
      HasOptional(x => x.performer_Aux_RootUrlStoreID);
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Aux_RootUrlStoreID);
    }
  }
}
