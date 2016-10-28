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
  public class Res_DiagnosticRequest_Index_stage_Configuration : EntityTypeConfiguration<Res_DiagnosticRequest_Index_stage>
  {

    public Res_DiagnosticRequest_Index_stage_Configuration()
    {
      HasKey(x => x.Res_DiagnosticRequest_Index_stageID).Property(x => x.Res_DiagnosticRequest_Index_stageID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_DiagnosticRequest).WithMany(x => x.stage_List).WillCascadeOnDelete(true);
    }
  }
}
