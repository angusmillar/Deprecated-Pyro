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
  public class Res_Provenance_Index_userid_Configuration : EntityTypeConfiguration<Res_Provenance_Index_userid>
  {

    public Res_Provenance_Index_userid_Configuration()
    {
      HasKey(x => x.Res_Provenance_Index_useridID).Property(x => x.Res_Provenance_Index_useridID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Provenance).WithMany(x => x.userid_List).WillCascadeOnDelete(true);
    }
  }
}
