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
  public class Res_Observation_Index_value_string_Configuration : EntityTypeConfiguration<Res_Observation_Index_value_string>
  {

    public Res_Observation_Index_value_string_Configuration()
    {
      HasKey(x => x.Res_Observation_Index_value_stringID).Property(x => x.Res_Observation_Index_value_stringID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_Observation).WithMany(x => x.value_string_List).WillCascadeOnDelete(true);
    }
  }
}
