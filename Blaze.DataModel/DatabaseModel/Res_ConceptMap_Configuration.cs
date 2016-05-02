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
  public class Res_ConceptMap_Configuration : EntityTypeConfiguration<Res_ConceptMap>
  {

    public Res_ConceptMap_Configuration()
    {
      HasKey(x => x.Res_ConceptMapID).Property(x => x.Res_ConceptMapID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.description_String).IsOptional();
      Property(x => x.identifier_Code).IsOptional();
      Property(x => x.identifier_System).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.publisher_String).IsOptional();
      Property(x => x.source_FhirId).IsOptional();
      Property(x => x.source_Type).IsOptional();
      HasOptional(x => x.source_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.source_Url).WithMany().HasForeignKey(x => x.source_Url_Blaze_RootUrlStoreID);
      Property(x => x.source_uri_FhirId).IsOptional();
      Property(x => x.source_uri_Type).IsOptional();
      HasOptional(x => x.source_uri_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.source_uri_Url).WithMany().HasForeignKey(x => x.source_uri_Url_Blaze_RootUrlStoreID);
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.target_FhirId).IsOptional();
      Property(x => x.target_Type).IsOptional();
      HasOptional(x => x.target_Url);
      HasOptional<Blaze_RootUrlStore>(x => x.target_Url).WithMany().HasForeignKey(x => x.target_Url_Blaze_RootUrlStoreID);
      Property(x => x.url_Uri).IsOptional();
      Property(x => x.version_Code).IsOptional();
      Property(x => x.version_System).IsOptional();
    }
  }
}
