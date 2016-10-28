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
  public class Res_StructureDefinition_Index_base_path_Configuration : EntityTypeConfiguration<Res_StructureDefinition_Index_base_path>
  {

    public Res_StructureDefinition_Index_base_path_Configuration()
    {
      HasKey(x => x.Res_StructureDefinition_Index_base_pathID).Property(x => x.Res_StructureDefinition_Index_base_pathID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_StructureDefinition).WithMany(x => x.base_path_List).WillCascadeOnDelete(true);
    }
  }
}
