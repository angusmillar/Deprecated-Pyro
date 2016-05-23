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
      Property(x => x.facilityidentifier_Code).IsOptional();
      Property(x => x.facilityidentifier_System).IsOptional();
      Property(x => x.facilityreference_FhirId).IsOptional();
      Property(x => x.facilityreference_Type).IsOptional();
      HasOptional(x => x.facilityreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.facilityreference_Url).WithMany().HasForeignKey(x => x.facilityreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.organizationidentifier_Code).IsOptional();
      Property(x => x.organizationidentifier_System).IsOptional();
      Property(x => x.organizationreference_FhirId).IsOptional();
      Property(x => x.organizationreference_Type).IsOptional();
      HasOptional(x => x.organizationreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.organizationreference_Url).WithMany().HasForeignKey(x => x.organizationreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.patientidentifier_Code).IsOptional();
      Property(x => x.patientidentifier_System).IsOptional();
      Property(x => x.patientreference_FhirId).IsOptional();
      Property(x => x.patientreference_Type).IsOptional();
      HasOptional(x => x.patientreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.patientreference_Url).WithMany().HasForeignKey(x => x.patientreference_Url_Blaze_RootUrlStoreID);
      Property(x => x.provideridentifier_Code).IsOptional();
      Property(x => x.provideridentifier_System).IsOptional();
      Property(x => x.providerreference_FhirId).IsOptional();
      Property(x => x.providerreference_Type).IsOptional();
      HasOptional(x => x.providerreference_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.providerreference_Url).WithMany().HasForeignKey(x => x.providerreference_Url_Blaze_RootUrlStoreID);
    }
  }
}
