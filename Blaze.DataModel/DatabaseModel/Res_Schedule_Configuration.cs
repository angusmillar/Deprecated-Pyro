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
  public class Res_Schedule_Configuration : EntityTypeConfiguration<Res_Schedule>
  {

    public Res_Schedule_Configuration()
    {
      HasKey(x => x.Res_ScheduleID).Property(x => x.Res_ScheduleID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.actor_VersionId).IsOptional();
      Property(x => x.actor_FhirId).IsOptional();
      Property(x => x.actor_Type).IsOptional();
      HasOptional(x => x.actor_Url);
      HasOptional<ServiceRootURL_Store>(x => x.actor_Url).WithMany().HasForeignKey(x => x.actor_ServiceRootURL_StoreID);
      Property(x => x.date_DateTimeOffsetLow).IsOptional();
      Property(x => x.date_DateTimeOffsetHigh).IsOptional();
    }
  }
}
