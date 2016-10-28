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
  public class Res_Condition_Index_evidence_Configuration : EntityTypeConfiguration<Res_Condition_Index_evidence>
  {

    public Res_Condition_Index_evidence_Configuration()
    {
      HasKey(x => x.Res_Condition_Index_evidenceID).Property(x => x.Res_Condition_Index_evidenceID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Condition).WithMany(x => x.evidence_List).WillCascadeOnDelete(true);
    }
  }
}
