using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;

//This is an Auto generated file do not change it's contents!!.

namespace Blaze.DataModel.BlazeDbModel
{
  public class Res_Order_Index_detail_Configuration : EntityTypeConfiguration<Res_Order_Index_detail>
  {
    public Res_Order_Index_detail_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      HasRequired(x => x.Res_Order);
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      Property(x => x.Url).IsOptional();
     }
  }
}