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
  public class Res_NamingSystem_Index_contact_Configuration : EntityTypeConfiguration<Res_NamingSystem_Index_contact>
  {

    public Res_NamingSystem_Index_contact_Configuration()
    {
      HasKey(x => x.Res_NamingSystem_Index_contactID).Property(x => x.Res_NamingSystem_Index_contactID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_NamingSystem).WithMany(x => x.contact_List).WillCascadeOnDelete(true);
    }
  }
}
