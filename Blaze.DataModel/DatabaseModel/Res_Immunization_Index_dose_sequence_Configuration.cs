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
  public class Res_Immunization_Index_dose_sequence_Configuration : EntityTypeConfiguration<Res_Immunization_Index_dose_sequence>
  {

    public Res_Immunization_Index_dose_sequence_Configuration()
    {
      HasKey(x => x.Res_Immunization_Index_dose_sequenceID).Property(x => x.Res_Immunization_Index_dose_sequenceID).IsRequired();
      Property(x => x.Comparator).IsOptional();
      Property(x => x.Quantity).IsRequired().HasPrecision(28,14);
      HasRequired(x => x.Res_Immunization).WithMany(x => x.dose_sequence_List).WillCascadeOnDelete(true);
    }
  }
}
