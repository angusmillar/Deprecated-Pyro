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
  public class Res_Provenance_Configuration : EntityTypeConfiguration<Res_Provenance>
  {

    public Res_Provenance_Configuration()
    {
      HasKey(x => x.Res_ProvenanceID).Property(x => x.Res_ProvenanceID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.end_DateTimeOffset).IsOptional();
      Property(x => x.location_VersionId).IsOptional();
      Property(x => x.location_FhirId).IsOptional();
      Property(x => x.location_Type).IsOptional();
      HasOptional(x => x.location_Url);
      HasOptional<ServiceRootURL_Store>(x => x.location_Url).WithMany().HasForeignKey(x => x.location_ServiceRootURL_StoreID);
      Property(x => x.start_DateTimeOffset).IsOptional();
    }
  }
}
