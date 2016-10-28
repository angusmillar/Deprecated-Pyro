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
  public class Res_ReferralRequest_Configuration : EntityTypeConfiguration<Res_ReferralRequest>
  {

    public Res_ReferralRequest_Configuration()
    {
      HasKey(x => x.Res_ReferralRequestID).Property(x => x.Res_ReferralRequestID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.category_Code).IsOptional();
      Property(x => x.category_System).IsOptional();
      Property(x => x.context_VersionId).IsOptional();
      Property(x => x.context_FhirId).IsOptional();
      Property(x => x.context_Type).IsOptional();
      HasOptional(x => x.context_Url);
      HasOptional<ServiceRootURL_Store>(x => x.context_Url).WithMany().HasForeignKey(x => x.context_ServiceRootURL_StoreID);
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.parent_Code).IsOptional();
      Property(x => x.parent_System).IsOptional();
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.requester_VersionId).IsOptional();
      Property(x => x.requester_FhirId).IsOptional();
      Property(x => x.requester_Type).IsOptional();
      HasOptional(x => x.requester_Url);
      HasOptional<ServiceRootURL_Store>(x => x.requester_Url).WithMany().HasForeignKey(x => x.requester_ServiceRootURL_StoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
