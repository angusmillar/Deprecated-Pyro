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
  public class Res_StructureDefinition_Configuration : EntityTypeConfiguration<Res_StructureDefinition>
  {

    public Res_StructureDefinition_Configuration()
    {
      HasKey(x => x.Res_StructureDefinitionID).Property(x => x.Res_StructureDefinitionID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.abstract_Code).IsOptional();
      Property(x => x.abstract_System).IsOptional();
      Property(x => x.base_Uri).IsOptional();
      Property(x => x.context_type_Code).IsOptional();
      Property(x => x.context_type_System).IsOptional();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.derivation_Code).IsOptional();
      Property(x => x.derivation_System).IsOptional();
      Property(x => x.description_String).IsOptional();
      Property(x => x.display_String).IsOptional();
      Property(x => x.experimental_Code).IsOptional();
      Property(x => x.experimental_System).IsOptional();
      Property(x => x.kind_Code).IsOptional();
      Property(x => x.kind_System).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.publisher_String).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
      Property(x => x.url_Uri).IsOptional();
      Property(x => x.version_Code).IsOptional();
      Property(x => x.version_System).IsOptional();
    }
  }
}
