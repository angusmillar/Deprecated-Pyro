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
  public class Res_CarePlan_Index_activitydate_Configuration : EntityTypeConfiguration<Res_CarePlan_Index_activitydate>
  {

    public Res_CarePlan_Index_activitydate_Configuration()
    {
      HasKey(x => x.Res_CarePlan_Index_activitydateID).Property(x => x.Res_CarePlan_Index_activitydateID).IsRequired();
      Property(x => x.DateTimeOffsetLow).IsOptional();
      Property(x => x.DateTimeOffsetHigh).IsOptional();
      HasRequired(x => x.Res_CarePlan).WithMany(x => x.activitydate_List).WillCascadeOnDelete(true);
    }
  }
}
