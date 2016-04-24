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
  public class Res_Coverage_Configuration : EntityTypeConfiguration<Res_Coverage>
  {

    public Res_Coverage_Configuration()
    {
      HasKey(x => x.Res_CoverageID).Property(x => x.Res_CoverageID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.dependent_Code).IsOptional();
      Property(x => x.dependent_System).IsOptional();
      Property(x => x.group_Code).IsOptional();
      Property(x => x.group_System).IsOptional();
      Property(x => x.issuer_FhirId).IsOptional();
      Property(x => x.issuer_Type).IsOptional();
      HasOptional(x => x.issuer_Aux_RootUrlStoreID);
      Property(x => x.plan_Code).IsOptional();
      Property(x => x.plan_System).IsOptional();
      Property(x => x.sequence_Code).IsOptional();
      Property(x => x.sequence_System).IsOptional();
      Property(x => x.subplan_Code).IsOptional();
      Property(x => x.subplan_System).IsOptional();
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
    }
  }
}
