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
  public class Res_Device_Configuration : EntityTypeConfiguration<Res_Device>
  {

    public Res_Device_Configuration()
    {
      HasKey(x => x.Res_DeviceID).Property(x => x.Res_DeviceID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.location_VersionId).IsOptional();
      Property(x => x.location_FhirId).IsOptional();
      Property(x => x.location_Type).IsOptional();
      HasOptional(x => x.location_Url);
      HasOptional<ServiceRootURL_Store>(x => x.location_Url).WithMany().HasForeignKey(x => x.location_ServiceRootURL_StoreID);
      Property(x => x.manufacturer_String).IsOptional();
      Property(x => x.model_String).IsOptional();
      Property(x => x.organization_VersionId).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Url);
      HasOptional<ServiceRootURL_Store>(x => x.organization_Url).WithMany().HasForeignKey(x => x.organization_ServiceRootURL_StoreID);
      Property(x => x.patient_VersionId).IsOptional();
      Property(x => x.patient_FhirId).IsOptional();
      Property(x => x.patient_Type).IsOptional();
      HasOptional(x => x.patient_Url);
      HasOptional<ServiceRootURL_Store>(x => x.patient_Url).WithMany().HasForeignKey(x => x.patient_ServiceRootURL_StoreID);
      Property(x => x.udicarrier_Code).IsOptional();
      Property(x => x.udicarrier_System).IsOptional();
      Property(x => x.url_Uri).IsOptional();
    }
  }
}
