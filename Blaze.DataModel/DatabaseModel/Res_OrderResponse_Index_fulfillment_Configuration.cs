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
  public class Res_OrderResponse_Index_fulfillment_Configuration : EntityTypeConfiguration<Res_OrderResponse_Index_fulfillment>
  {

    public Res_OrderResponse_Index_fulfillment_Configuration()
    {
      HasKey(x => x.Res_OrderResponse_Index_fulfillmentID).Property(x => x.Res_OrderResponse_Index_fulfillmentID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<Blaze_RootUrlStore>(x => x.Url).WithMany().HasForeignKey(x => x.Url_Blaze_RootUrlStoreID);
      HasRequired(x => x.Res_OrderResponse).WithMany(x => x.fulfillment_List).WillCascadeOnDelete(true);
    }
  }
}
