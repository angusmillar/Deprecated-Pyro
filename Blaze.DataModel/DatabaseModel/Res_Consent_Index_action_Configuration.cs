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
  public class Res_Consent_Index_action_Configuration : EntityTypeConfiguration<Res_Consent_Index_action>
  {

    public Res_Consent_Index_action_Configuration()
    {
      HasKey(x => x.Res_Consent_Index_actionID).Property(x => x.Res_Consent_Index_actionID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Consent).WithMany(x => x.action_List).WillCascadeOnDelete(true);
    }
  }
}
