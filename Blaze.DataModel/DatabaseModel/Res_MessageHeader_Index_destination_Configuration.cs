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
  public class Res_MessageHeader_Index_destination_Configuration : EntityTypeConfiguration<Res_MessageHeader_Index_destination>
  {

    public Res_MessageHeader_Index_destination_Configuration()
    {
      HasKey(x => x.Res_MessageHeader_Index_destinationID).Property(x => x.Res_MessageHeader_Index_destinationID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_MessageHeader).WithMany(x => x.destination_List).WillCascadeOnDelete(true);
    }
  }
}
