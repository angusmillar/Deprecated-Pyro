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
  public class Res_Group_Index_exclude_Configuration : EntityTypeConfiguration<Res_Group_Index_exclude>
  {

    public Res_Group_Index_exclude_Configuration()
    {
      HasKey(x => x.Res_Group_Index_excludeID).Property(x => x.Res_Group_Index_excludeID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Group).WithMany(x => x.exclude_List).WillCascadeOnDelete(true);
    }
  }
}
