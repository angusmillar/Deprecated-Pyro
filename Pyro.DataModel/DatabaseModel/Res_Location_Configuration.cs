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
  public class Res_Location_Configuration : EntityTypeConfiguration<Res_Location>
  {

    public Res_Location_Configuration()
    {
      HasKey(x => x.Res_LocationID).Property(x => x.Res_LocationID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.address_city_String).IsOptional();
      Property(x => x.address_country_String).IsOptional();
      Property(x => x.address_postalcode_String).IsOptional();
      Property(x => x.address_state_String).IsOptional();
      Property(x => x.address_use_Code).IsOptional();
      Property(x => x.address_use_System).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.near_Code).IsOptional();
      Property(x => x.near_System).IsOptional();
      Property(x => x.near_distance_Comparator).IsOptional();
      Property(x => x.near_distance_Quantity).IsOptional().HasPrecision(28,14);
      Property(x => x.near_distance_System).IsOptional();
      Property(x => x.near_distance_Code).IsOptional();
      Property(x => x.near_distance_Unit).IsOptional();
      Property(x => x.organization_VersionId).IsOptional();
      Property(x => x.organization_FhirId).IsOptional();
      Property(x => x.organization_Type).IsOptional();
      HasOptional(x => x.organization_Url);
      HasOptional<ServiceRootURL_Store>(x => x.organization_Url).WithMany().HasForeignKey(x => x.organization_ServiceRootURL_StoreID);
      Property(x => x.partof_VersionId).IsOptional();
      Property(x => x.partof_FhirId).IsOptional();
      Property(x => x.partof_Type).IsOptional();
      HasOptional(x => x.partof_Url);
      HasOptional<ServiceRootURL_Store>(x => x.partof_Url).WithMany().HasForeignKey(x => x.partof_ServiceRootURL_StoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
