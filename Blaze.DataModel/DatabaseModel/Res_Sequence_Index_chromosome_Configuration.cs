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
  public class Res_Sequence_Index_chromosome_Configuration : EntityTypeConfiguration<Res_Sequence_Index_chromosome>
  {

    public Res_Sequence_Index_chromosome_Configuration()
    {
      HasKey(x => x.Res_Sequence_Index_chromosomeID).Property(x => x.Res_Sequence_Index_chromosomeID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Sequence);
    }
  }
}
