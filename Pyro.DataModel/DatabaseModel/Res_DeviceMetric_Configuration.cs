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
  public class Res_DeviceMetric_Configuration : EntityTypeConfiguration<Res_DeviceMetric>
  {

    public Res_DeviceMetric_Configuration()
    {
      HasKey(x => x.Res_DeviceMetricID).Property(x => x.Res_DeviceMetricID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.category_Code).IsOptional();
      Property(x => x.category_System).IsOptional();
      Property(x => x.identifier_Code).IsOptional();
      Property(x => x.identifier_System).IsOptional();
      Property(x => x.parent_VersionId).IsOptional();
      Property(x => x.parent_FhirId).IsOptional();
      Property(x => x.parent_Type).IsOptional();
      HasOptional(x => x.parent_Url);
      HasOptional<ServiceRootURL_Store>(x => x.parent_Url).WithMany().HasForeignKey(x => x.parent_ServiceRootURL_StoreID);
      Property(x => x.source_VersionId).IsOptional();
      Property(x => x.source_FhirId).IsOptional();
      Property(x => x.source_Type).IsOptional();
      HasOptional(x => x.source_Url);
      HasOptional<ServiceRootURL_Store>(x => x.source_Url).WithMany().HasForeignKey(x => x.source_ServiceRootURL_StoreID);
    }
  }
}
