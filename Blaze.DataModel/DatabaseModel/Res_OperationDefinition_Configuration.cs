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
  public class Res_OperationDefinition_Configuration : EntityTypeConfiguration<Res_OperationDefinition>
  {

    public Res_OperationDefinition_Configuration()
    {
      HasKey(x => x.Res_OperationDefinitionID).Property(x => x.Res_OperationDefinitionID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.base_FhirId).IsOptional();
      Property(x => x.base_Type).IsOptional();
      HasOptional(x => x.base_Aux_RootUrlStoreID);
      Property(x => x.code_Code).IsOptional();
      Property(x => x.code_System).IsOptional();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.instance_Code).IsOptional();
      Property(x => x.instance_System).IsOptional();
      Property(x => x.kind_Code).IsOptional();
      Property(x => x.kind_System).IsOptional();
      Property(x => x.name_String).IsOptional();
      Property(x => x.publisher_String).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
      Property(x => x.system_Code).IsOptional();
      Property(x => x.system_System).IsOptional();
      Property(x => x.url_Uri).IsOptional();
      Property(x => x.version_Code).IsOptional();
      Property(x => x.version_System).IsOptional();
    }
  }
}
