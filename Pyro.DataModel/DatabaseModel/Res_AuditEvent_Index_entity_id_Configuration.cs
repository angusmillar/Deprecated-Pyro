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
  public class Res_AuditEvent_Index_entity_id_Configuration : EntityTypeConfiguration<Res_AuditEvent_Index_entity_id>
  {

    public Res_AuditEvent_Index_entity_id_Configuration()
    {
      HasKey(x => x.Res_AuditEvent_Index_entity_idID).Property(x => x.Res_AuditEvent_Index_entity_idID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_AuditEvent).WithMany(x => x.entity_id_List).WillCascadeOnDelete(true);
    }
  }
}
