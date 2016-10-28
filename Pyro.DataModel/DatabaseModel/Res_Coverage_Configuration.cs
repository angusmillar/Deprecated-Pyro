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
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.beneficiary_identifier_Code).IsOptional();
      Property(x => x.beneficiary_identifier_System).IsOptional();
      Property(x => x.beneficiary_reference_VersionId).IsOptional();
      Property(x => x.beneficiary_reference_FhirId).IsOptional();
      Property(x => x.beneficiary_reference_Type).IsOptional();
      HasOptional(x => x.beneficiary_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.beneficiary_reference_Url).WithMany().HasForeignKey(x => x.beneficiary_reference_ServiceRootURL_StoreID);
      Property(x => x.dependent_Comparator).IsOptional();
      Property(x => x.dependent_Quantity).IsOptional().HasPrecision(28,14);
      Property(x => x.group_Code).IsOptional();
      Property(x => x.group_System).IsOptional();
      Property(x => x.issuer_identifier_Code).IsOptional();
      Property(x => x.issuer_identifier_System).IsOptional();
      Property(x => x.issuer_reference_VersionId).IsOptional();
      Property(x => x.issuer_reference_FhirId).IsOptional();
      Property(x => x.issuer_reference_Type).IsOptional();
      HasOptional(x => x.issuer_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.issuer_reference_Url).WithMany().HasForeignKey(x => x.issuer_reference_ServiceRootURL_StoreID);
      Property(x => x.plan_Code).IsOptional();
      Property(x => x.plan_System).IsOptional();
      Property(x => x.planholder_identifier_Code).IsOptional();
      Property(x => x.planholder_identifier_System).IsOptional();
      Property(x => x.planholder_reference_VersionId).IsOptional();
      Property(x => x.planholder_reference_FhirId).IsOptional();
      Property(x => x.planholder_reference_Type).IsOptional();
      HasOptional(x => x.planholder_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.planholder_reference_Url).WithMany().HasForeignKey(x => x.planholder_reference_ServiceRootURL_StoreID);
      Property(x => x.sequence_Comparator).IsOptional();
      Property(x => x.sequence_Quantity).IsOptional().HasPrecision(28,14);
      Property(x => x.subgroup_Code).IsOptional();
      Property(x => x.subgroup_System).IsOptional();
      Property(x => x.subplan_Code).IsOptional();
      Property(x => x.subplan_System).IsOptional();
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
    }
  }
}
