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
  public class Res_Linkage_Index_source_Configuration : EntityTypeConfiguration<Res_Linkage_Index_source>
  {

    public Res_Linkage_Index_source_Configuration()
    {
      HasKey(x => x.Res_Linkage_Index_sourceID).Property(x => x.Res_Linkage_Index_sourceID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<ServiceRootURL_Store>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceRootURL_StoreID);
      HasRequired(x => x.Res_Linkage).WithMany(x => x.source_List).WillCascadeOnDelete(true);
    }
  }
}
