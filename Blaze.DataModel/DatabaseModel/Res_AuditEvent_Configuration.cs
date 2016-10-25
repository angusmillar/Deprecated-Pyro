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
  public class Res_AuditEvent_Configuration : EntityTypeConfiguration<Res_AuditEvent>
  {

    public Res_AuditEvent_Configuration()
    {
      HasKey(x => x.Res_AuditEventID).Property(x => x.Res_AuditEventID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.action_Code).IsOptional();
      Property(x => x.action_System).IsOptional();
      Property(x => x.date_DateTimeOffset).IsOptional();
      Property(x => x.outcome_Code).IsOptional();
      Property(x => x.outcome_System).IsOptional();
      Property(x => x.site_Code).IsOptional();
      Property(x => x.site_System).IsOptional();
      Property(x => x.source_Code).IsOptional();
      Property(x => x.source_System).IsOptional();
      Property(x => x.type_Code).IsOptional();
      Property(x => x.type_System).IsOptional();
    }
  }
}
