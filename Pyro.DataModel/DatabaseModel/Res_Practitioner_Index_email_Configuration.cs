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
  public class Res_Practitioner_Index_email_Configuration : EntityTypeConfiguration<Res_Practitioner_Index_email>
  {

    public Res_Practitioner_Index_email_Configuration()
    {
      HasKey(x => x.Res_Practitioner_Index_emailID).Property(x => x.Res_Practitioner_Index_emailID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Practitioner).WithMany(x => x.email_List).WillCascadeOnDelete(true);
    }
  }
}
