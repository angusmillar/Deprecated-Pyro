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
  public class Res_Substance_Index_quantity_Configuration : EntityTypeConfiguration<Res_Substance_Index_quantity>
  {

    public Res_Substance_Index_quantity_Configuration()
    {
      HasKey(x => x.Res_Substance_Index_quantityID).Property(x => x.Res_Substance_Index_quantityID).IsRequired();
      Property(x => x.Comparator).IsOptional();
      Property(x => x.Quantity).IsRequired().HasPrecision(28,14);
      Property(x => x.System).IsOptional();
      Property(x => x.Code).IsOptional();
      Property(x => x.Unit).IsOptional();
      HasRequired(x => x.Res_Substance).WithMany(x => x.quantity_List).WillCascadeOnDelete(true);
    }
  }
}
