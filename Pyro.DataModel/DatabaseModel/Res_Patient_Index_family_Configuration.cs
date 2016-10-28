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
  public class Res_Patient_Index_family_Configuration : EntityTypeConfiguration<Res_Patient_Index_family>
  {

    public Res_Patient_Index_family_Configuration()
    {
      HasKey(x => x.Res_Patient_Index_familyID).Property(x => x.Res_Patient_Index_familyID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_Patient).WithMany(x => x.family_List).WillCascadeOnDelete(true);
    }
  }
}
