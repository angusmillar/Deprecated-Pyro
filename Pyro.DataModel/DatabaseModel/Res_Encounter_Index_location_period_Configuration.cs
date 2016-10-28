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
  public class Res_Encounter_Index_location_period_Configuration : EntityTypeConfiguration<Res_Encounter_Index_location_period>
  {

    public Res_Encounter_Index_location_period_Configuration()
    {
      HasKey(x => x.Res_Encounter_Index_location_periodID).Property(x => x.Res_Encounter_Index_location_periodID).IsRequired();
      Property(x => x.DateTimeOffsetLow).IsOptional();
      Property(x => x.DateTimeOffsetHigh).IsOptional();
      HasRequired(x => x.Res_Encounter).WithMany(x => x.location_period_List).WillCascadeOnDelete(true);
    }
  }
}
