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
  public class Res_List_Index_empty_reason_Configuration : EntityTypeConfiguration<Res_List_Index_empty_reason>
  {

    public Res_List_Index_empty_reason_Configuration()
    {
      HasKey(x => x.Res_List_Index_empty_reasonID).Property(x => x.Res_List_Index_empty_reasonID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_List).WithMany(x => x.empty_reason_List).WillCascadeOnDelete(true);
    }
  }
}
