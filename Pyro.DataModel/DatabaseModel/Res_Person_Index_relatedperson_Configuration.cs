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
  public class Res_Person_Index_relatedperson_Configuration : EntityTypeConfiguration<Res_Person_Index_relatedperson>
  {

    public Res_Person_Index_relatedperson_Configuration()
    {
      HasKey(x => x.Res_Person_Index_relatedpersonID).Property(x => x.Res_Person_Index_relatedpersonID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<ServiceRootURL_Store>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceRootURL_StoreID);
      HasRequired(x => x.Res_Person).WithMany(x => x.relatedperson_List).WillCascadeOnDelete(true);
    }
  }
}
