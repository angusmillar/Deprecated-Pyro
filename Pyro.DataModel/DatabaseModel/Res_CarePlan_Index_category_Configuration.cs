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
  public class Res_CarePlan_Index_category_Configuration : EntityTypeConfiguration<Res_CarePlan_Index_category>
  {

    public Res_CarePlan_Index_category_Configuration()
    {
      HasKey(x => x.Res_CarePlan_Index_categoryID).Property(x => x.Res_CarePlan_Index_categoryID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_CarePlan).WithMany(x => x.category_List).WillCascadeOnDelete(true);
    }
  }
}
