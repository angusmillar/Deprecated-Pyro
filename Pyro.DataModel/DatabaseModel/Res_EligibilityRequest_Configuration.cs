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

namespace Pyro.DataModel.DatabaseModel
{
  public class Res_EligibilityRequest_Configuration : EntityTypeConfiguration<Res_EligibilityRequest>
  {

    public Res_EligibilityRequest_Configuration()
    {
      HasKey(x => x.Res_EligibilityRequestID).Property(x => x.Res_EligibilityRequestID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.created_DateTimeOffset).IsOptional();
      Property(x => x.facility_identifier_Code).IsOptional();
      Property(x => x.facility_identifier_System).IsOptional();
      Property(x => x.facility_reference_VersionId).IsOptional();
      Property(x => x.facility_reference_FhirId).IsOptional();
      Property(x => x.facility_reference_Type).IsOptional();
      HasOptional(x => x.facility_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.facility_reference_Url).WithMany().HasForeignKey(x => x.facility_reference_ServiceRootURL_StoreID);
      Property(x => x.organization_identifier_Code).IsOptional();
      Property(x => x.organization_identifier_System).IsOptional();
      Property(x => x.organization_reference_VersionId).IsOptional();
      Property(x => x.organization_reference_FhirId).IsOptional();
      Property(x => x.organization_reference_Type).IsOptional();
      HasOptional(x => x.organization_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.organization_reference_Url).WithMany().HasForeignKey(x => x.organization_reference_ServiceRootURL_StoreID);
      Property(x => x.patient_identifier_Code).IsOptional();
      Property(x => x.patient_identifier_System).IsOptional();
      Property(x => x.patient_reference_VersionId).IsOptional();
      Property(x => x.patient_reference_FhirId).IsOptional();
      Property(x => x.patient_reference_Type).IsOptional();
      HasOptional(x => x.patient_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_reference_Url).WithMany().HasForeignKey(x => x.patient_reference_ServiceRootURL_StoreID);
      Property(x => x.provider_identifier_Code).IsOptional();
      Property(x => x.provider_identifier_System).IsOptional();
      Property(x => x.provider_reference_VersionId).IsOptional();
      Property(x => x.provider_reference_FhirId).IsOptional();
      Property(x => x.provider_reference_Type).IsOptional();
      HasOptional(x => x.provider_reference_Url);
      HasOptional<ServiceRootURL_Store>(x => x.provider_reference_Url).WithMany().HasForeignKey(x => x.provider_reference_ServiceRootURL_StoreID);
    }
  }
}
