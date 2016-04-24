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
  public class Res_TestScript_Index_testscript_setup_capability_Configuration : EntityTypeConfiguration<Res_TestScript_Index_testscript_setup_capability>
  {

    public Res_TestScript_Index_testscript_setup_capability_Configuration()
    {
      HasKey(x => x.Res_TestScript_Index_testscript_setup_capabilityID).Property(x => x.Res_TestScript_Index_testscript_setup_capabilityID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_TestScript);
    }
  }
}
