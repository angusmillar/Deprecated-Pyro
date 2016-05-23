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
  public class Res_Task_Index_failure_Configuration : EntityTypeConfiguration<Res_Task_Index_failure>
  {

    public Res_Task_Index_failure_Configuration()
    {
      HasKey(x => x.Res_Task_Index_failureID).Property(x => x.Res_Task_Index_failureID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Task).WithMany(x => x.failure_List).WillCascadeOnDelete(true);
    }
  }
}
