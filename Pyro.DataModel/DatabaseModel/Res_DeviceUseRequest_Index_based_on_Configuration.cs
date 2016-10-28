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
  public class Res_DeviceUseRequest_Index_based_on_Configuration : EntityTypeConfiguration<Res_DeviceUseRequest_Index_based_on>
  {

    public Res_DeviceUseRequest_Index_based_on_Configuration()
    {
      HasKey(x => x.Res_DeviceUseRequest_Index_based_onID).Property(x => x.Res_DeviceUseRequest_Index_based_onID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<ServiceRootURL_Store>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceRootURL_StoreID);
      HasRequired(x => x.Res_DeviceUseRequest).WithMany(x => x.based_on_List).WillCascadeOnDelete(true);
    }
  }
}
