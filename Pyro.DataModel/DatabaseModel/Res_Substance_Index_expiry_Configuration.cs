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
  public class Res_Substance_Index_expiry_Configuration : EntityTypeConfiguration<Res_Substance_Index_expiry>
  {

    public Res_Substance_Index_expiry_Configuration()
    {
      HasKey(x => x.Res_Substance_Index_expiryID).Property(x => x.Res_Substance_Index_expiryID).IsRequired();
      Property(x => x.DateTimeOffset).IsOptional();
      HasRequired(x => x.Res_Substance).WithMany(x => x.expiry_List).WillCascadeOnDelete(true);
    }
  }
}
