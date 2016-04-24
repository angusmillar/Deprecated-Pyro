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
  public class Res_MessageHeader_Configuration : EntityTypeConfiguration<Res_MessageHeader>
  {

    public Res_MessageHeader_Configuration()
    {
      HasKey(x => x.Res_MessageHeaderID).Property(x => x.Res_MessageHeaderID).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.Received).IsRequired();
      Property(x => x.Version).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.author_FhirId).IsOptional();
      Property(x => x.author_Type).IsOptional();
      HasOptional(x => x.author_Aux_RootUrlStoreID);
      Property(x => x.code_Code).IsOptional();
      Property(x => x.code_System).IsOptional();
      Property(x => x.enterer_FhirId).IsOptional();
      Property(x => x.enterer_Type).IsOptional();
      HasOptional(x => x.enterer_Aux_RootUrlStoreID);
      Property(x => x.event_Code).IsOptional();
      Property(x => x.event_System).IsOptional();
      Property(x => x.receiver_FhirId).IsOptional();
      Property(x => x.receiver_Type).IsOptional();
      HasOptional(x => x.receiver_Aux_RootUrlStoreID);
      Property(x => x.response_id_Code).IsOptional();
      Property(x => x.response_id_System).IsOptional();
      Property(x => x.responsible_FhirId).IsOptional();
      Property(x => x.responsible_Type).IsOptional();
      HasOptional(x => x.responsible_Aux_RootUrlStoreID);
      Property(x => x.source_String).IsOptional();
      Property(x => x.source_uri_Uri).IsOptional();
      Property(x => x.timestamp_DateTimeOffset).IsOptional();
    }
  }
}
