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
  public class Res_Sequence_Index_end_Configuration : EntityTypeConfiguration<Res_Sequence_Index_end>
  {

    public Res_Sequence_Index_end_Configuration()
    {
      HasKey(x => x.Res_Sequence_Index_endID).Property(x => x.Res_Sequence_Index_endID).IsRequired();
      Property(x => x.Comparator).IsOptional();
      Property(x => x.Quantity).IsRequired().HasPrecision(28,14);
      HasRequired(x => x.Res_Sequence).WithMany(x => x.end_List).WillCascadeOnDelete(true);
    }
  }
}
