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
  public class Res_Composition_Index_attester_Configuration : EntityTypeConfiguration<Res_Composition_Index_attester>
  {

    public Res_Composition_Index_attester_Configuration()
    {
      HasKey(x => x.Res_Composition_Index_attesterID).Property(x => x.Res_Composition_Index_attesterID).IsRequired();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<Blaze_RootUrlStore>(x => x.Url).WithMany().HasForeignKey(x => x.Url_Blaze_RootUrlStoreID);
      HasRequired(x => x.Res_Composition).WithMany(x => x.attester_List).WillCascadeOnDelete(true);
    }
  }
}
