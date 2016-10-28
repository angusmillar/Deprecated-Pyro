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
  public class Res_Composition_Index_section_Configuration : EntityTypeConfiguration<Res_Composition_Index_section>
  {

    public Res_Composition_Index_section_Configuration()
    {
      HasKey(x => x.Res_Composition_Index_sectionID).Property(x => x.Res_Composition_Index_sectionID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Composition).WithMany(x => x.section_List).WillCascadeOnDelete(true);
    }
  }
}
