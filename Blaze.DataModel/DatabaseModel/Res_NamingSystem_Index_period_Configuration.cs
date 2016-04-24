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
  public class Res_NamingSystem_Index_period_Configuration : EntityTypeConfiguration<Res_NamingSystem_Index_period>
  {

    public Res_NamingSystem_Index_period_Configuration()
    {
      HasKey(x => x.Res_NamingSystem_Index_periodID).Property(x => x.Res_NamingSystem_Index_periodID).IsRequired();
      Property(x => x.DateTimeOffset).IsRequired();
      HasRequired(x => x.Res_NamingSystem);
    }
  }
}
