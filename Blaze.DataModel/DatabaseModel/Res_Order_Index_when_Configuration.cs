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
  public class Res_Order_Index_when_Configuration : EntityTypeConfiguration<Res_Order_Index_when>
  {

    public Res_Order_Index_when_Configuration()
    {
      HasKey(x => x.Res_Order_Index_whenID).Property(x => x.Res_Order_Index_whenID).IsRequired();
      Property(x => x.DateTimeOffset).IsRequired();
      HasRequired(x => x.Res_Order).WithMany(x => x.when_List).WillCascadeOnDelete(true);
    }
  }
}
