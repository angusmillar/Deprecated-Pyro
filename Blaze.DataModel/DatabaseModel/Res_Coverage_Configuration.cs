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
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.beneficiaryidentifier_Code).IsOptional();
      Property(x => x.beneficiaryidentifier_System).IsOptional();
      Property(x => x.beneficiaryreference_FhirId).IsOptional();
      Property(x => x.beneficiaryreference_Type).IsOptional();
      HasOptional(x => x.beneficiaryreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.beneficiaryreference_Url).WithMany().HasForeignKey(x => x.beneficiaryreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.dependent_Code).IsOptional();
      Property(x => x.dependent_System).IsOptional();
      Property(x => x.group_Code).IsOptional();
      Property(x => x.group_System).IsOptional();
      Property(x => x.issueridentifier_Code).IsOptional();
      Property(x => x.issueridentifier_System).IsOptional();
      Property(x => x.issuerreference_FhirId).IsOptional();
      Property(x => x.issuerreference_Type).IsOptional();
      HasOptional(x => x.issuerreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.issuerreference_Url).WithMany().HasForeignKey(x => x.issuerreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.plan_Code).IsOptional();
      Property(x => x.plan_System).IsOptional();
      Property(x => x.planholderidentifier_Code).IsOptional();
      Property(x => x.planholderidentifier_System).IsOptional();
      Property(x => x.planholderreference_FhirId).IsOptional();
      Property(x => x.planholderreference_Type).IsOptional();
      HasOptional(x => x.planholderreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.planholderreference_Url).WithMany().HasForeignKey(x => x.planholderreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.sequence_Code).IsOptional();
      Property(x => x.sequence_System).IsOptional();
      Property(x => x.subplan_Code).IsOptional();
      Property(x => x.subplan_System).IsOptional();
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
    }
  }
}
