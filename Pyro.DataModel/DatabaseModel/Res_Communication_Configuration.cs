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
  public class Res_Communication_Configuration : EntityTypeConfiguration<Res_Communication>
  {

    public Res_Communication_Configuration()
    {
      HasKey(x => x.Res_CommunicationID).Property(x => x.Res_CommunicationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.context_VersionId).IsOptional();
      Property(x => x.context_FhirId).IsOptional();
      Property(x => x.context_Type).IsOptional();
      HasOptional(x => x.context_Url);
      HasOptional<ServiceRootURL_Store>(x => x.context_Url).WithMany().HasForeignKey(x => x.context_ServiceRootURL_StoreID);
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.received_DateTimeOffset).IsOptional();
      Property(x => x.sender_VersionId).IsOptional();
      Property(x => x.sender_FhirId).IsOptional();
      Property(x => x.sender_Type).IsOptional();
      HasOptional(x => x.sender_Url);
      HasOptional<ServiceRootURL_Store>(x => x.sender_Url).WithMany().HasForeignKey(x => x.sender_ServiceRootURL_StoreID);
      Property(x => x.sent_DateTimeOffset).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.subject_VersionId).IsOptional();
      Property(x => x.subject_FhirId).IsOptional();
      Property(x => x.subject_Type).IsOptional();
      HasOptional(x => x.subject_Url);
      HasOptional<ServiceRootURL_Store>(x => x.subject_Url).WithMany().HasForeignKey(x => x.subject_ServiceRootURL_StoreID);
    }
  }
}
