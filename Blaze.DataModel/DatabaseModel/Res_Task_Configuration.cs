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
  public class Res_Task_Configuration : EntityTypeConfiguration<Res_Task>
  {

    public Res_Task_Configuration()
    {
      HasKey(x => x.Res_TaskID).Property(x => x.Res_TaskID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.created_DateTimeOffset).IsOptional();
      Property(x => x.definition_Uri).IsOptional();
      Property(x => x.focus_VersionId).IsOptional();
      Property(x => x.focus_FhirId).IsOptional();
      Property(x => x.focus_Type).IsOptional();
      HasOptional(x => x.focus_Url);
      HasOptional<ServiceRootURL_Store>(x => x.focus_Url).WithMany().HasForeignKey(x => x.focus_ServiceRootURL_StoreID);
      Property(x => x.identifier_Code).IsOptional();
      Property(x => x.identifier_System).IsOptional();
      Property(x => x.modified_DateTimeOffset).IsOptional();
      Property(x => x.owner_VersionId).IsOptional();
      Property(x => x.owner_FhirId).IsOptional();
      Property(x => x.owner_Type).IsOptional();
      HasOptional(x => x.owner_Url);
      HasOptional<ServiceRootURL_Store>(x => x.owner_Url).WithMany().HasForeignKey(x => x.owner_ServiceRootURL_StoreID);
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.priority_Code).IsOptional();
      Property(x => x.priority_System).IsOptional();
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
