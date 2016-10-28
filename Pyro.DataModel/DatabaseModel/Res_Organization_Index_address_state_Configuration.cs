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
  public class Res_Organization_Index_address_state_Configuration : EntityTypeConfiguration<Res_Organization_Index_address_state>
  {

    public Res_Organization_Index_address_state_Configuration()
    {
      HasKey(x => x.Res_Organization_Index_address_stateID).Property(x => x.Res_Organization_Index_address_stateID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_Organization).WithMany(x => x.address_state_List).WillCascadeOnDelete(true);
    }
  }
}
