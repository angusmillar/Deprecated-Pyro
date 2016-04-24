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
  public class Res_ValueSet_Index_context_Configuration : EntityTypeConfiguration<Res_ValueSet_Index_context>
  {

    public Res_ValueSet_Index_context_Configuration()
    {
      HasKey(x => x.Res_ValueSet_Index_contextID).Property(x => x.Res_ValueSet_Index_contextID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_ValueSet);
    }
  }
}
