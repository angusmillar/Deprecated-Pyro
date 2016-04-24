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
  public class Res_Specimen_Configuration : EntityTypeConfiguration<Res_Specimen>
  {

    public Res_Specimen_Configuration()
    {
      HasKey(x => x.Res_SpecimenID).Property(x => x.Res_SpecimenID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.accession_Code).IsOptional();
      Property(x => x.accession_System).IsOptional();
      Property(x => x.collected_DateTimeOffset).IsOptional();
      Property(x => x.collector_FhirId).IsOptional();
      Property(x => x.collector_Type).IsOptional();
      HasOptional(x => x.collector_Aux_RootUrlStoreID);
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Aux_RootUrlStoreID);
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Aux_RootUrlStoreID);
    }
  }
}
