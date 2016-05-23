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
  public class Res_Immunization_Index_reaction_date_Configuration : EntityTypeConfiguration<Res_Immunization_Index_reaction_date>
  {

    public Res_Immunization_Index_reaction_date_Configuration()
    {
      HasKey(x => x.Res_Immunization_Index_reaction_dateID).Property(x => x.Res_Immunization_Index_reaction_dateID).IsRequired();
      Property(x => x.DateTimeOffset).IsRequired();
      HasRequired(x => x.Res_Immunization).WithMany(x => x.reaction_date_List).WillCascadeOnDelete(true);
    }
  }
}
