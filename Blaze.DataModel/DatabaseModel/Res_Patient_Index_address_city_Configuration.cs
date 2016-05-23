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
  public class Res_Patient_Index_address_city_Configuration : EntityTypeConfiguration<Res_Patient_Index_address_city>
  {

    public Res_Patient_Index_address_city_Configuration()
    {
      HasKey(x => x.Res_Patient_Index_address_cityID).Property(x => x.Res_Patient_Index_address_cityID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_Patient).WithMany(x => x.address_city_List).WillCascadeOnDelete(true);
    }
  }
}
