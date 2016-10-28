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
  public class Res_CarePlan_Index_relatedcode_Configuration : EntityTypeConfiguration<Res_CarePlan_Index_relatedcode>
  {

    public Res_CarePlan_Index_relatedcode_Configuration()
    {
      HasKey(x => x.Res_CarePlan_Index_relatedcodeID).Property(x => x.Res_CarePlan_Index_relatedcodeID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_CarePlan).WithMany(x => x.relatedcode_List).WillCascadeOnDelete(true);
    }
  }
}
