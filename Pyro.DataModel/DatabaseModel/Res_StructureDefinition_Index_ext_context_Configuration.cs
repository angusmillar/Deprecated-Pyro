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
  public class Res_StructureDefinition_Index_ext_context_Configuration : EntityTypeConfiguration<Res_StructureDefinition_Index_ext_context>
  {

    public Res_StructureDefinition_Index_ext_context_Configuration()
    {
      HasKey(x => x.Res_StructureDefinition_Index_ext_contextID).Property(x => x.Res_StructureDefinition_Index_ext_contextID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_StructureDefinition).WithMany(x => x.ext_context_List).WillCascadeOnDelete(true);
    }
  }
}
