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
      Property(x => x.creator_VersionId).IsOptional();
      Property(x => x.creator_FhirId).IsOptional();
      Property(x => x.creator_Type).IsOptional();
      HasOptional(x => x.creator_Url);
      HasOptional<ServiceRootURL_Store>(x => x.creator_Url).WithMany().HasForeignKey(x => x.creator_ServiceRootURL_StoreID);
      Property(x => x.definition_Uri).IsOptional();
      Property(x => x.identifier_Code).IsOptional();
      Property(x => x.identifier_System).IsOptional();
      Property(x => x.modified_DateTimeOffset).IsOptional();
      Property(x => x.owner_VersionId).IsOptional();
      Property(x => x.owner_FhirId).IsOptional();
      Property(x => x.owner_Type).IsOptional();
      HasOptional(x => x.owner_Url);
      HasOptional<ServiceRootURL_Store>(x => x.owner_Url).WithMany().HasForeignKey(x => x.owner_ServiceRootURL_StoreID);
      Property(x => x.parent_VersionId).IsOptional();
      Property(x => x.parent_FhirId).IsOptional();
      Property(x => x.parent_Type).IsOptional();
      HasOptional(x => x.parent_Url);
      HasOptional<ServiceRootURL_Store>(x => x.parent_Url).WithMany().HasForeignKey(x => x.parent_ServiceRootURL_StoreID);
      Property(x => x.priority_Code).IsOptional();
      Property(x => x.priority_System).IsOptional();
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
