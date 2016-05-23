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
  public class Res_Encounter_Index_special_arrangement_Configuration : EntityTypeConfiguration<Res_Encounter_Index_special_arrangement>
  {

    public Res_Encounter_Index_special_arrangement_Configuration()
    {
      HasKey(x => x.Res_Encounter_Index_special_arrangementID).Property(x => x.Res_Encounter_Index_special_arrangementID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Encounter).WithMany(x => x.special_arrangement_List).WillCascadeOnDelete(true);
    }
  }
}
