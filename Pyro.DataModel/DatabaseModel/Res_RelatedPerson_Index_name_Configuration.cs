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
  public class Res_RelatedPerson_Index_name_Configuration : EntityTypeConfiguration<Res_RelatedPerson_Index_name>
  {

    public Res_RelatedPerson_Index_name_Configuration()
    {
      HasKey(x => x.Res_RelatedPerson_Index_nameID).Property(x => x.Res_RelatedPerson_Index_nameID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_RelatedPerson).WithMany(x => x.name_List).WillCascadeOnDelete(true);
    }
  }
}
