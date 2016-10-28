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
  public class Res_Slot_Configuration : EntityTypeConfiguration<Res_Slot>
  {

    public Res_Slot_Configuration()
    {
      HasKey(x => x.Res_SlotID).Property(x => x.Res_SlotID).IsRequired();
      Property(x => x.IsDeleted).IsRequired();
      Property(x => x.FhirId).IsRequired().HasMaxLength(500).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_FhirId") { IsUnique = true }));
      Property(x => x.lastUpdated).IsRequired();
      Property(x => x.versionId).IsRequired();
      Property(x => x.XmlBlob).IsRequired();
      Property(x => x.schedule_VersionId).IsOptional();
      Property(x => x.schedule_FhirId).IsOptional();
      Property(x => x.schedule_Type).IsOptional();
      HasOptional(x => x.schedule_Url);
      HasOptional<ServiceRootURL_Store>(x => x.schedule_Url).WithMany().HasForeignKey(x => x.schedule_ServiceRootURL_StoreID);
      Property(x => x.start_DateTimeOffset).IsOptional();
      Property(x => x.status_Code).IsOptional();
      Property(x => x.status_System).IsOptional();
    }
  }
}
