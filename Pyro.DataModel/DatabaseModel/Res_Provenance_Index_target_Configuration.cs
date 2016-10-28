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
  public class Res_Provenance_Index_target_Configuration : EntityTypeConfiguration<Res_Provenance_Index_target>
  {

    public Res_Provenance_Index_target_Configuration()
    {
      HasKey(x => x.Res_Provenance_Index_targetID).Property(x => x.Res_Provenance_Index_targetID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<ServiceRootURL_Store>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceRootURL_StoreID);
      HasRequired(x => x.Res_Provenance).WithMany(x => x.target_List).WillCascadeOnDelete(true);
    }
  }
}
